<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FetchForm
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
        Me.fetchBtn = New System.Windows.Forms.Button()
        Me.consoleBox = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.csvFileBox = New System.Windows.Forms.TextBox()
        Me.readBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'fetchBtn
        '
        Me.fetchBtn.Enabled = False
        Me.fetchBtn.Location = New System.Drawing.Point(439, 8)
        Me.fetchBtn.Name = "fetchBtn"
        Me.fetchBtn.Size = New System.Drawing.Size(75, 23)
        Me.fetchBtn.TabIndex = 0
        Me.fetchBtn.Text = "Fetch"
        Me.fetchBtn.UseVisualStyleBackColor = True
        '
        'consoleBox
        '
        Me.consoleBox.Location = New System.Drawing.Point(15, 38)
        Me.consoleBox.Multiline = True
        Me.consoleBox.Name = "consoleBox"
        Me.consoleBox.ReadOnly = True
        Me.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.consoleBox.Size = New System.Drawing.Size(831, 212)
        Me.consoleBox.TabIndex = 3
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'csvFileBox
        '
        Me.csvFileBox.Location = New System.Drawing.Point(15, 11)
        Me.csvFileBox.Name = "csvFileBox"
        Me.csvFileBox.ReadOnly = True
        Me.csvFileBox.Size = New System.Drawing.Size(304, 20)
        Me.csvFileBox.TabIndex = 4
        Me.csvFileBox.Text = "Click to load CSV/TXT file ..."
        '
        'readBtn
        '
        Me.readBtn.Location = New System.Drawing.Point(325, 8)
        Me.readBtn.Name = "readBtn"
        Me.readBtn.Size = New System.Drawing.Size(108, 23)
        Me.readBtn.TabIndex = 5
        Me.readBtn.Text = "Read"
        Me.readBtn.UseVisualStyleBackColor = True
        '
        'FetchForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 263)
        Me.Controls.Add(Me.readBtn)
        Me.Controls.Add(Me.csvFileBox)
        Me.Controls.Add(Me.consoleBox)
        Me.Controls.Add(Me.fetchBtn)
        Me.Name = "FetchForm"
        Me.Text = "Fetch RSS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fetchBtn As System.Windows.Forms.Button
    Friend WithEvents consoleBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents csvFileBox As System.Windows.Forms.TextBox
    Friend WithEvents readBtn As System.Windows.Forms.Button

End Class
