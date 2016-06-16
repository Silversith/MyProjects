Imports System.ComponentModel
Imports System.Net
Imports System.Threading
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Main
    Private WithEvents Browser As New WebBrowser
    Private AvailableImages As New ArrayList
    Private WithEvents WebClientDownload As New WebClient
    Private CurrentSearchTerm As String = ""
    Private SearchList As New ArrayList
    Private CompletedList As New ArrayList
    Private MyThread As Thread
    Private MyThreadErrors As String
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim ExcelPath As String = FilePath.Text

        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlWorkBook = xlApp.Workbooks.Open(ExcelPath)
        xlWorkSheet = xlWorkBook.Worksheets(My.Settings.WorkSheetName)
        'display the cells value B2
        Dim MaxXValue As Integer = 0
        Dim MaxYValue As Integer = 0
        For x As Integer = 1 To 200
            If xlWorkSheet.Cells(x, 1).value = "" Then
                MaxXValue = x
                Exit For
            End If
        Next
        For y As Integer = 1 To 200
            If xlWorkSheet.Cells(1, y).value = "" Then
                MaxYValue = y
                Exit For
            End If
        Next

        For x As Integer = 1 To MaxXValue
            For y As Integer = 1 To MaxYValue
                If xlWorkSheet.Cells(x, y).value <> "" Then
                    SearchList.Add(xlWorkSheet.Cells(x, y).value)
                Else
                    Exit For
                End If
            Next
        Next
        TermsProgress.Maximum = SearchList.Count
        CurrentSearchTerm = SearchList(0)
        Label3.Text = CurrentSearchTerm
        Browser.Name = CurrentSearchTerm
        Browser.Navigate("https://www.google.com/search?q=" & CurrentSearchTerm & "&tbm=isch")

        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Sub

    Private Sub Browser_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles Browser.DocumentCompleted
        If Not CompletedList.Contains(Browser.Name) Then
            CompletedList.Add(Browser.Name)
            AvailableImages = New ArrayList
            Dim SplitArray() As String = sender.Document.Body.InnerText.Split("""ou""")
            For Each item In SplitArray
                If OUContainsImage(item) Then
                    If item.Contains("?") Then
                        AvailableImages.Add(item.Substring(0, item.Length - (item.Length - item.IndexOf("?"))))
                    Else
                        AvailableImages.Add(item)
                    End If
                    If AvailableImages.Count >= TotalImagesToDownload.Value Then
                        Exit For
                    End If
                End If
            Next
            TermsProgress.PerformStep()
            DownloadProgress.Maximum = AvailableImages.Count
            DownloadProgress.Value = 0
            If Not System.IO.Directory.Exists(My.Settings.LastFolder + "\" + CurrentSearchTerm + "\") Then
                System.IO.Directory.CreateDirectory(My.Settings.LastFolder + "\" + CurrentSearchTerm + "\")
            End If
            MyThread = New System.Threading.Thread(AddressOf DownloadFile)
            MyThread.Start()
        End If
    End Sub
    Private Sub DownloadFile()
        For Each File In AvailableImages
            While WebClientDownload.IsBusy
                Thread.Sleep(1000)
            End While
            Try
                WebClientDownload.DownloadFile(File, SavePath.Text + "\" + CurrentSearchTerm + "\" + GetFileNameFromURL(File))
            Catch ex As System.Net.WebException
                MyThreadErrors += ex.Message + vbCrLf
                DisplayError()
            Finally
                PreformStep1()
            End Try
        Next
        NextSearchTerm()
    End Sub
    Private Sub PreformStep1()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf PreformStep1))
        Else
            DownloadProgress.PerformStep()
        End If
    End Sub
    Private Sub DisplayError()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf DisplayError))
        Else
            ErrorDisplay.Text = MyThreadErrors
        End If
    End Sub
    Private Sub NextSearchTerm()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf NextSearchTerm))
        Else
            If SearchList.Count > 1 Then
                AvailableImages.Clear()
                SearchList.RemoveAt(0)
                CurrentSearchTerm = SearchList(0)
                Label3.Text = CurrentSearchTerm
                Browser.Name = CurrentSearchTerm
                Browser.Navigate("https://www.google.com/search?q=" & CurrentSearchTerm & "&tbm=isch")
            Else
                AvailableImages.Clear()
                SearchList.Clear()
                SearchList.Clear()
                CompletedList.Clear()
                CurrentSearchTerm = ""
                Label3.Text = "---COMPLETE---"
                Browser.Name = ""
                DownloadProgress.Value = 0
                TermsProgress.Value = 0
            End If
        End If
    End Sub
    Private Function OUContainsImage(ByVal Input As String) As Boolean
        Input = Input.ToLower
        With Input
            If (.Contains(".jpeg") Or .Contains(".png") Or .Contains(".jpg") Or .Contains(".ico") Or .Contains(".gif")) And .Contains("http") Then
                Return True
            Else Return False
            End If
        End With
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Function GetFileNameFromURL(ByVal InputFileName As String) As String
        InputFileName = InputFileName.Substring(InputFileName.LastIndexOf("/"), InputFileName.Length - InputFileName.LastIndexOf("/"))
        If (InputFileName.Contains("?")) Then
            InputFileName = InputFileName.Substring(0, InputFileName.Length - (InputFileName.Length - InputFileName.IndexOf("?")))
        End If
        If (InputFileName.Contains(".jpg")) Then
            InputFileName = InputFileName.Substring(0, InputFileName.Length - (InputFileName.Length - InputFileName.IndexOf(".jpg") - 4))
        End If
        If (InputFileName.Contains(".jpeg")) Then
            InputFileName = InputFileName.Substring(0, InputFileName.Length - (InputFileName.Length - InputFileName.IndexOf(".jpeg") - 5))
        End If
        If (InputFileName.Contains(".png")) Then
            InputFileName = InputFileName.Substring(0, InputFileName.Length - (InputFileName.Length - InputFileName.IndexOf(".png") - 4))
        End If
        If (InputFileName.Contains(".ico")) Then
            InputFileName = InputFileName.Substring(0, InputFileName.Length - (InputFileName.Length - InputFileName.IndexOf(".ico") - 4))
        End If
        If (InputFileName.Contains(".gif")) Then
            InputFileName = InputFileName.Substring(0, InputFileName.Length - (InputFileName.Length - InputFileName.IndexOf(".gif") - 4))
        End If

        Return InputFileName.Replace("+", " ").Replace("/", "").Replace("%20", " ")
    End Function

    Private Sub btnBrowseFolder_Click(sender As Object, e As EventArgs) Handles btnBrowseFolder.Click
        If FolderDialog.ShowDialog() = DialogResult.OK Then
            SavePath.Text = FolderDialog.SelectedPath
            My.Settings.LastFolder = FolderDialog.SelectedPath
            My.Settings.Save()
        End If
    End Sub

    Private Sub btnBrowseFile_Click(sender As Object, e As EventArgs) Handles btnBrowseFile.Click
        FileDialog.ShowDialog()
    End Sub

    Private Sub FileDialog_FileOk(sender As Object, e As CancelEventArgs) Handles FileDialog.FileOk
        FilePath.Text = FileDialog.FileName
        My.Settings.LastFile = FileDialog.FileName
        My.Settings.Save()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        FilePath.Text = My.Settings.LastFile
        SavePath.Text = My.Settings.LastFolder
    End Sub
End Class
