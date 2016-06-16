<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnBrowseFile = New System.Windows.Forms.Button()
        Me.btnBrowseFolder = New System.Windows.Forms.Button()
        Me.FilePath = New System.Windows.Forms.TextBox()
        Me.SavePath = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.ErrorDisplay = New System.Windows.Forms.RichTextBox()
        Me.DownloadProgress = New System.Windows.Forms.ProgressBar()
        Me.TermsProgress = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.FileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TotalImagesToDownload = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.TotalImagesToDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBrowseFile
        '
        Me.btnBrowseFile.Location = New System.Drawing.Point(524, 10)
        Me.btnBrowseFile.Name = "btnBrowseFile"
        Me.btnBrowseFile.Size = New System.Drawing.Size(35, 23)
        Me.btnBrowseFile.TabIndex = 0
        Me.btnBrowseFile.Text = "..."
        Me.btnBrowseFile.UseVisualStyleBackColor = True
        '
        'btnBrowseFolder
        '
        Me.btnBrowseFolder.Location = New System.Drawing.Point(524, 39)
        Me.btnBrowseFolder.Name = "btnBrowseFolder"
        Me.btnBrowseFolder.Size = New System.Drawing.Size(35, 23)
        Me.btnBrowseFolder.TabIndex = 1
        Me.btnBrowseFolder.Text = "..."
        Me.btnBrowseFolder.UseVisualStyleBackColor = True
        '
        'FilePath
        '
        Me.FilePath.Location = New System.Drawing.Point(107, 12)
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        Me.FilePath.Size = New System.Drawing.Size(413, 20)
        Me.FilePath.TabIndex = 2
        Me.FilePath.Text = "C:\Tertius-Practice\GoogleImageSearch\GoogleImageSearch\Keywords.xlsx"
        '
        'SavePath
        '
        Me.SavePath.Location = New System.Drawing.Point(107, 41)
        Me.SavePath.Name = "SavePath"
        Me.SavePath.ReadOnly = True
        Me.SavePath.Size = New System.Drawing.Size(413, 20)
        Me.SavePath.TabIndex = 3
        Me.SavePath.Text = "C:\Tertius-Practice\GoogleImageSearch\GoogleImageSearch\"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(486, 420)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 4
        Me.btnStart.Text = "Begin"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'ErrorDisplay
        '
        Me.ErrorDisplay.Location = New System.Drawing.Point(12, 347)
        Me.ErrorDisplay.Name = "ErrorDisplay"
        Me.ErrorDisplay.Size = New System.Drawing.Size(466, 96)
        Me.ErrorDisplay.TabIndex = 5
        Me.ErrorDisplay.Text = ""
        '
        'DownloadProgress
        '
        Me.DownloadProgress.Location = New System.Drawing.Point(12, 318)
        Me.DownloadProgress.Name = "DownloadProgress"
        Me.DownloadProgress.Size = New System.Drawing.Size(549, 23)
        Me.DownloadProgress.Step = 1
        Me.DownloadProgress.TabIndex = 6
        '
        'TermsProgress
        '
        Me.TermsProgress.Location = New System.Drawing.Point(12, 289)
        Me.TermsProgress.Name = "TermsProgress"
        Me.TermsProgress.Size = New System.Drawing.Size(549, 23)
        Me.TermsProgress.Step = 1
        Me.TermsProgress.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Excel File"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Save Path"
        '
        'FileDialog
        '
        Me.FileDialog.FileName = "FileDialog"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(236, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 24)
        Me.Label3.TabIndex = 10
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TotalImagesToDownload
        '
        Me.TotalImagesToDownload.Location = New System.Drawing.Point(439, 67)
        Me.TotalImagesToDownload.Name = "TotalImagesToDownload"
        Me.TotalImagesToDownload.Size = New System.Drawing.Size(120, 20)
        Me.TotalImagesToDownload.TabIndex = 11
        Me.TotalImagesToDownload.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(277, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Number of Images to Download"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 455)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TotalImagesToDownload)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TermsProgress)
        Me.Controls.Add(Me.DownloadProgress)
        Me.Controls.Add(Me.ErrorDisplay)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.SavePath)
        Me.Controls.Add(Me.FilePath)
        Me.Controls.Add(Me.btnBrowseFolder)
        Me.Controls.Add(Me.btnBrowseFile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Main"
        Me.Text = "Image Search"
        CType(Me.TotalImagesToDownload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBrowseFile As Button
    Friend WithEvents btnBrowseFolder As Button
    Friend WithEvents FilePath As TextBox
    Friend WithEvents SavePath As TextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents ErrorDisplay As RichTextBox
    Friend WithEvents DownloadProgress As ProgressBar
    Friend WithEvents TermsProgress As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderDialog As FolderBrowserDialog
    Friend WithEvents FileDialog As OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents TotalImagesToDownload As NumericUpDown
    Friend WithEvents Label4 As Label
End Class
