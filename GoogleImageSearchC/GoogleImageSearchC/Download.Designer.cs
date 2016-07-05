using System.Windows.Forms;

namespace GoogleImageSearchC
{
    partial class Download
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.TermsProgress = new System.Windows.Forms.ProgressBar();
            this.DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.ErrorDisplay = new System.Windows.Forms.RichTextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SavePath = new System.Windows.Forms.TextBox();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Label4 = new System.Windows.Forms.Label();
            this.TotalImagesToDownload = new System.Windows.Forms.NumericUpDown();
            this.CurrentTermLabel = new System.Windows.Forms.Label();
            this.SizeDropdown = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSiteExtra = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TotalImagesToDownload)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(10, 36);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 13);
            this.Label2.TabIndex = 35;
            this.Label2.Text = "Save Path";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(10, 7);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 13);
            this.Label1.TabIndex = 34;
            this.Label1.Text = "Excel/Text File";
            // 
            // TermsProgress
            // 
            this.TermsProgress.Location = new System.Drawing.Point(10, 281);
            this.TermsProgress.Name = "TermsProgress";
            this.TermsProgress.Size = new System.Drawing.Size(549, 23);
            this.TermsProgress.Step = 1;
            this.TermsProgress.TabIndex = 33;
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Location = new System.Drawing.Point(10, 310);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(549, 23);
            this.DownloadProgress.Step = 1;
            this.DownloadProgress.TabIndex = 32;
            // 
            // ErrorDisplay
            // 
            this.ErrorDisplay.Location = new System.Drawing.Point(10, 339);
            this.ErrorDisplay.Name = "ErrorDisplay";
            this.ErrorDisplay.Size = new System.Drawing.Size(466, 96);
            this.ErrorDisplay.TabIndex = 31;
            this.ErrorDisplay.Text = "";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(484, 412);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 30;
            this.btnStart.Text = "Begin";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // SavePath
            // 
            this.SavePath.Location = new System.Drawing.Point(105, 33);
            this.SavePath.Name = "SavePath";
            this.SavePath.ReadOnly = true;
            this.SavePath.Size = new System.Drawing.Size(413, 20);
            this.SavePath.TabIndex = 29;
            this.SavePath.Text = "C:\\Tertius-Practice\\GoogleImageSearch\\GoogleImageSearch\\";
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(105, 4);
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Size = new System.Drawing.Size(413, 20);
            this.FilePath.TabIndex = 28;
            this.FilePath.Text = "C:\\Tertius-Practice\\GoogleImageSearch\\GoogleImageSearch\\Keywords.xlsx";
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(522, 31);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(35, 23);
            this.btnBrowseFolder.TabIndex = 27;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(522, 2);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(35, 23);
            this.btnBrowseFile.TabIndex = 26;
            this.btnBrowseFile.Text = "...";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "FileDialog";
            this.FileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.FileDialog_FileOk);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(275, 61);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(156, 13);
            this.Label4.TabIndex = 38;
            this.Label4.Text = "Number of Images to Download";
            // 
            // TotalImagesToDownload
            // 
            this.TotalImagesToDownload.Location = new System.Drawing.Point(437, 59);
            this.TotalImagesToDownload.Name = "TotalImagesToDownload";
            this.TotalImagesToDownload.Size = new System.Drawing.Size(120, 20);
            this.TotalImagesToDownload.TabIndex = 37;
            this.TotalImagesToDownload.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // CurrentTermLabel
            // 
            this.CurrentTermLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTermLabel.AutoSize = true;
            this.CurrentTermLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentTermLabel.Location = new System.Drawing.Point(254, 173);
            this.CurrentTermLabel.Name = "CurrentTermLabel";
            this.CurrentTermLabel.Size = new System.Drawing.Size(0, 24);
            this.CurrentTermLabel.TabIndex = 36;
            this.CurrentTermLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SizeDropdown
            // 
            this.SizeDropdown.FormattingEnabled = true;
            this.SizeDropdown.Items.AddRange(new object[] {
            "Any",
            "Large",
            "Medium",
            "Small"});
            this.SizeDropdown.Location = new System.Drawing.Point(436, 85);
            this.SizeDropdown.Name = "SizeDropdown";
            this.SizeDropdown.Size = new System.Drawing.Size(121, 21);
            this.SizeDropdown.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Size of the Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(528, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "All links are obtained from Google and can therefore be missing, corrupt or inacc" +
    "essable. - Developer: Silversith";
            // 
            // txtSiteExtra
            // 
            this.txtSiteExtra.Location = new System.Drawing.Point(436, 112);
            this.txtSiteExtra.Name = "txtSiteExtra";
            this.txtSiteExtra.Size = new System.Drawing.Size(121, 20);
            this.txtSiteExtra.TabIndex = 42;
            this.txtSiteExtra.TextChanged += new System.EventHandler(this.txtSiteExtra_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Website to Search";
            // 
            // Download
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 460);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSiteExtra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SizeDropdown);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TermsProgress);
            this.Controls.Add(this.DownloadProgress);
            this.Controls.Add(this.ErrorDisplay);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.SavePath);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.btnBrowseFile);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.TotalImagesToDownload);
            this.Controls.Add(this.CurrentTermLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Download";
            this.Text = "Download";
            ((System.ComponentModel.ISupportInitialize)(this.TotalImagesToDownload)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ProgressBar TermsProgress;
        internal System.Windows.Forms.ProgressBar DownloadProgress;
        internal System.Windows.Forms.RichTextBox ErrorDisplay;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.TextBox SavePath;
        internal System.Windows.Forms.TextBox FilePath;
        internal System.Windows.Forms.Button btnBrowseFolder;
        internal System.Windows.Forms.Button btnBrowseFile;
        internal System.Windows.Forms.FolderBrowserDialog FolderDialog;
        internal System.Windows.Forms.OpenFileDialog FileDialog;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown TotalImagesToDownload;
        internal System.Windows.Forms.Label CurrentTermLabel;
        private ComboBox SizeDropdown;
        internal Label label5;
        private Label label3;
        private TextBox txtSiteExtra;
        internal Label label6;
    }
}