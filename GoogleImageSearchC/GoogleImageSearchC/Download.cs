using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace GoogleImageSearchC
{
    public partial class Download : Form
    {
        private WebBrowser Browser = new WebBrowser();
        private ArrayList AvailableImages = new ArrayList();
        private WebClient WebClientDownload = new WebClient();
        private string CurrentSearchTerm = "";
        private ArrayList SearchList = new ArrayList();
        private ArrayList CompletedList = new ArrayList();
        private Thread MyThread;
        private string MyThreadErrors;
        private string FocusOnWebsite;
        Dictionary<string, string> ImageSizes = new Dictionary<string, string>();
        public Download()
        {
            InitializeComponent();
            ImageSizes.Add("Large", "&tbs=isz:l");
            ImageSizes.Add("Medium", "&tbs=isz:m");
            ImageSizes.Add("Small", "&tbs=isz:s");
            ImageSizes.Add("Any", "");
            ImageSizes.Add("", "");
            //Browser
            this.Browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.Browser_DocumentCompleted);
            FilePath.Text = Properties.Settings.Default.LastFile;
            SavePath.Text = Properties.Settings.Default.LastFolder;
            txtSiteExtra.Text = Properties.Settings.Default.LastSite;
        }
        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!CompletedList.Contains(Browser.Name))
            {
                CompletedList.Add(Browser.Name);
                AvailableImages = new ArrayList();
                string[] SplitArray = ((WebBrowser)sender).Document.Body.InnerText.Split(new[] { "\"ou\":\"" }, StringSplitOptions.None);
                foreach (string varItem in SplitArray)
                {
                    if (OUContainsImage(varItem) && varItem.Substring(0, 4) == "http")
                    {
                        AvailableImages.Add(varItem.Substring(0, varItem.IndexOf("\"")));
                        if (AvailableImages.Count >= TotalImagesToDownload.Value)
                        {
                            break;
                        }
                    }
                }
                TermsProgress.PerformStep();
                DownloadProgress.Maximum = AvailableImages.Count;
                DownloadProgress.Value = 0;
                if (!System.IO.Directory.Exists(Properties.Settings.Default.LastFolder + "\\" + CurrentSearchTerm + "\\"))
                {
                    System.IO.Directory.CreateDirectory(Properties.Settings.Default.LastFolder + "\\" + CurrentSearchTerm + "\\");
                }
                MyThread = new System.Threading.Thread(DownloadFile);
                MyThread.Start();
            }
        }
        private void FileDialog_FileOk(object sender, CancelEventArgs e)
        {
            FilePath.Text = FileDialog.FileName;
            Properties.Settings.Default.LastFile = FileDialog.FileName;
            Properties.Settings.Default.Save();
        }
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            FileDialog.ShowDialog();
        }
        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            if (FolderDialog.ShowDialog() == DialogResult.OK)
            {
                SavePath.Text = FolderDialog.SelectedPath;
                Properties.Settings.Default.LastFolder = FolderDialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            string ExcelPath = FilePath.Text;
            if (ExcelPath.Contains(".txt"))
            {
                using (TextReader reader = File.OpenText(@ExcelPath))
                {
                    string text = reader.ReadToEnd();
                    if (text.Contains("\n"))
                    {
                        foreach (string textItem in text.Split(new[] { "\r\n" }, StringSplitOptions.None))
                        {
                            if (textItem.TrimEnd() != "")
                            {
                                SearchList.Add(textItem.Replace("\"", "").TrimEnd());
                            }
                        }
                    }
                    else {
                        SearchList.Add(text.Replace("\"", "").TrimEnd());
                    }
                }
                TermsProgress.Maximum = SearchList.Count;
                CurrentSearchTerm = (String)SearchList[0];
                CurrentTermLabel.Text = CurrentSearchTerm;
                Browser.Name = CurrentSearchTerm;
                Browser.Navigate("https://www.google.com/search?q=" + CurrentSearchTerm.Replace(" ", "+") + FocusOnWebsite + "&tbm=isch" + ImageSizes[(string)SizeDropdown.Text]);
            }
            else
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = default(Microsoft.Office.Interop.Excel.Workbook);
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = default(Microsoft.Office.Interop.Excel.Worksheet);

                xlWorkBook = xlApp.Workbooks.Open(ExcelPath);
                xlWorkSheet = xlWorkBook.Worksheets[Properties.Settings.Default.WorkSheetName];

                int MaxXValue = 0;
                int MaxYValue = 0;
                for (int x = 1; x <= 200; x++)
                {
                    if (string.IsNullOrEmpty(xlWorkSheet.Cells[x, 1].value))
                    {
                        MaxXValue = x;
                        break; 
                    }
                }
                for (int y = 1; y <= 200; y++)
                {
                    if (string.IsNullOrEmpty(xlWorkSheet.Cells[1, y].value))
                    {
                        MaxYValue = y;
                        break; 
                    }
                }

                for (int x = 1; x <= MaxXValue; x++)
                {
                    for (int y = 1; y <= MaxYValue; y++)
                    {
                        if (!string.IsNullOrEmpty(xlWorkSheet.Cells[x, y].value))
                        {
                            SearchList.Add(xlWorkSheet.Cells[x, y].value);
                        }
                        else
                        {
                            break; 
                        }
                    }
                }
                if (txtSiteExtra.Text != "")
                {
                    FocusOnWebsite = "+site:" + txtSiteExtra.Text;
                }
                TermsProgress.Maximum = SearchList.Count;
                CurrentSearchTerm = (String)SearchList[0];
                CurrentTermLabel.Text = CurrentSearchTerm;
                Browser.Name = CurrentSearchTerm;
                Browser.Navigate("https://www.google.com/search?q=" + CurrentSearchTerm.Replace(" ", "+") + FocusOnWebsite + "&tbm=isch" + ImageSizes[(string)SizeDropdown.Text]);

                xlWorkBook.Close();
                xlApp.Quit();

                releaseObject(xlApp);
                releaseObject(xlWorkBook);
                releaseObject(xlWorkSheet);
            }
        }
        private void DownloadFile()
        {
            foreach (string varFile in AvailableImages)
            {
                while (WebClientDownload.IsBusy)
                {
                    Thread.Sleep(1000);
                }
                try
                {
                    var Rename = "";
                    var FullFileName = GetFileNameFromURL(varFile);
                    var FileExtention = "";
                    var FileName = "";
                    if (FullFileName.Contains(".jpg"))
                    {
                        FileName = FullFileName.Replace(".jpg", "");
                        FileExtention = ".jpg";
                    }
                    else if (FullFileName.Contains(".png"))
                    {
                        FileName = FullFileName.Replace(".png", "");
                        FileExtention = ".png";
                    }
                    else if (FullFileName.Contains(".ico"))
                    {
                        FileName = FullFileName.Replace(".ico", "");
                        FileExtention = ".ico";
                    }
                    else if (FullFileName.Contains(".png"))
                    {
                        FileName = FullFileName.Replace(".png", "");
                        FileExtention = ".png";
                    }
                    else if (FullFileName.Contains(".gif"))
                    {
                        FileName = FullFileName.Replace(".gif", "");
                        FileExtention = ".gif";
                    }
                    else if (FullFileName.Contains(".bmp"))
                    {
                        FileName = FullFileName.Replace(".bmp", "");
                        FileExtention = ".bmp";
                    }
                    else if (FullFileName.Contains(".jpeg"))
                    {
                        FileName = FullFileName.Replace(".jpeg", "");
                        FileExtention = ".jpeg";
                    }

                    var FileStorePath = SavePath.Text + "\\" + CurrentSearchTerm + "\\";
                    while (System.IO.File.Exists(FileStorePath + FileName + Rename + FileExtention))
                    {
                        if (Rename == "")
                        {
                            Rename = "1";
                        }
                        else
                        {
                            Rename = (int.Parse(Rename) + 1).ToString();
                        }
                    }
                    if (Rename != "")
                    {
                        FileName = FileName + "_" + Rename.ToString();
                    }
                    WebClientDownload.DownloadFile(varFile, FileStorePath + FileName + FileExtention);
                }
                catch (System.Net.WebException ex)
                {
                    MyThreadErrors += ex.Message + System.Environment.NewLine;
                    DisplayError();
                }
                finally
                {
                    PreformStep1();
                }
            }
            NextSearchTerm();
        }
        private void PreformStep1()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(PreformStep1));
            }
            else
            {
                DownloadProgress.PerformStep();
            }
        }
        private void DisplayError()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(DisplayError));
            }
            else
            {
                ErrorDisplay.Text = MyThreadErrors;
            }
        }
        private void NextSearchTerm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(NextSearchTerm));
            }
            else
            {
                if (SearchList.Count > 1)
                {
                    AvailableImages.Clear();
                    SearchList.RemoveAt(0);
                    CurrentSearchTerm = (string)SearchList[0];
                    CurrentTermLabel.Text = CurrentSearchTerm;
                    Browser.Name = CurrentSearchTerm;
                    Browser.Navigate("https://www.google.com/search?q=" + CurrentSearchTerm.Replace(" ", "+") + FocusOnWebsite + "&tbm=isch" + ImageSizes[(string)SizeDropdown.Text]);
                }
                else
                {
                    AvailableImages.Clear();
                    SearchList.Clear();
                    SearchList.Clear();
                    CompletedList.Clear();
                    CurrentSearchTerm = "";
                    CurrentTermLabel.Text = "---COMPLETE---";
                    Browser.Name = "";
                    DownloadProgress.Value = 0;
                    TermsProgress.Value = 0;
                }
            }
        }
        private bool OUContainsImage(string Input)
        {
            Input = Input.ToLower();
            var _with1 = Input;
            if ((_with1.Contains(".jpeg") || _with1.Contains(".png") || _with1.Contains(".jpg") || _with1.Contains(".ico") || _with1.Contains(".gif") || _with1.Contains(".bmp")) && _with1.Contains("http"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private string GetFileNameFromURL(string InputFileName)
        {
            InputFileName = Path.GetFileName(InputFileName);

            return InputFileName.Replace("+", " ").Replace("/", "").Replace("%20", " ");
        }
        private void txtSiteExtra_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastSite = txtSiteExtra.Text;
            Properties.Settings.Default.Save();
        }
    }
}
