<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.EnglishLanguageRadioButton = New System.Windows.Forms.RadioButton()
        Me.ChineseLanguageRadioButton = New System.Windows.Forms.RadioButton()
        Me.LanguageGroupBox = New System.Windows.Forms.GroupBox()
        Me.CopyPromptCheckBox = New System.Windows.Forms.CheckBox()
        Me.SaveScoreDataCheckBox = New System.Windows.Forms.CheckBox()
        Me.ClearScoreBoxCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.LanguageGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(304, 102)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'EnglishLanguageRadioButton
        '
        Me.EnglishLanguageRadioButton.AutoSize = True
        Me.EnglishLanguageRadioButton.Location = New System.Drawing.Point(27, 19)
        Me.EnglishLanguageRadioButton.Name = "EnglishLanguageRadioButton"
        Me.EnglishLanguageRadioButton.Size = New System.Drawing.Size(59, 17)
        Me.EnglishLanguageRadioButton.TabIndex = 2
        Me.EnglishLanguageRadioButton.TabStop = True
        Me.EnglishLanguageRadioButton.Text = "English"
        Me.EnglishLanguageRadioButton.UseVisualStyleBackColor = True
        '
        'ChineseLanguageRadioButton
        '
        Me.ChineseLanguageRadioButton.AutoSize = True
        Me.ChineseLanguageRadioButton.Location = New System.Drawing.Point(92, 19)
        Me.ChineseLanguageRadioButton.Name = "ChineseLanguageRadioButton"
        Me.ChineseLanguageRadioButton.Size = New System.Drawing.Size(49, 17)
        Me.ChineseLanguageRadioButton.TabIndex = 3
        Me.ChineseLanguageRadioButton.TabStop = True
        Me.ChineseLanguageRadioButton.Text = "中文"
        Me.ChineseLanguageRadioButton.UseVisualStyleBackColor = True
        '
        'LanguageGroupBox
        '
        Me.LanguageGroupBox.Controls.Add(Me.EnglishLanguageRadioButton)
        Me.LanguageGroupBox.Controls.Add(Me.ChineseLanguageRadioButton)
        Me.LanguageGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.LanguageGroupBox.Name = "LanguageGroupBox"
        Me.LanguageGroupBox.Size = New System.Drawing.Size(162, 50)
        Me.LanguageGroupBox.TabIndex = 4
        Me.LanguageGroupBox.TabStop = False
        Me.LanguageGroupBox.Text = "Language"
        '
        'CopyPromptCheckBox
        '
        Me.CopyPromptCheckBox.AutoSize = True
        Me.CopyPromptCheckBox.Location = New System.Drawing.Point(12, 68)
        Me.CopyPromptCheckBox.Name = "CopyPromptCheckBox"
        Me.CopyPromptCheckBox.Size = New System.Drawing.Size(156, 17)
        Me.CopyPromptCheckBox.TabIndex = 6
        Me.CopyPromptCheckBox.Text = "Do not prompt to copy GPA"
        Me.CopyPromptCheckBox.UseVisualStyleBackColor = True
        '
        'SaveScoreDataCheckBox
        '
        Me.SaveScoreDataCheckBox.AutoSize = True
        Me.SaveScoreDataCheckBox.Location = New System.Drawing.Point(12, 91)
        Me.SaveScoreDataCheckBox.Name = "SaveScoreDataCheckBox"
        Me.SaveScoreDataCheckBox.Size = New System.Drawing.Size(205, 17)
        Me.SaveScoreDataCheckBox.TabIndex = 7
        Me.SaveScoreDataCheckBox.Text = "Do not save scores between sessions"
        Me.SaveScoreDataCheckBox.UseVisualStyleBackColor = True
        '
        'ClearScoreBoxCheckBox
        '
        Me.ClearScoreBoxCheckBox.AutoSize = True
        Me.ClearScoreBoxCheckBox.Location = New System.Drawing.Point(12, 114)
        Me.ClearScoreBoxCheckBox.Name = "ClearScoreBoxCheckBox"
        Me.ClearScoreBoxCheckBox.Size = New System.Drawing.Size(210, 17)
        Me.ClearScoreBoxCheckBox.TabIndex = 8
        Me.ClearScoreBoxCheckBox.Text = "Do not clear score boxes when clicked"
        Me.ClearScoreBoxCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(180, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 52)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "THIS IS SPARTA! ...or is it...?" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Naw, it's just something to take up all this b" & _
    "lank space" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "until I add some more options. Until then, enjoy Sparta."
        '
        'Dialog1
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(462, 143)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ClearScoreBoxCheckBox)
        Me.Controls.Add(Me.SaveScoreDataCheckBox)
        Me.Controls.Add(Me.CopyPromptCheckBox)
        Me.Controls.Add(Me.LanguageGroupBox)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.LanguageGroupBox.ResumeLayout(False)
        Me.LanguageGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents EnglishLanguageRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ChineseLanguageRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LanguageGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents CopyPromptCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SaveScoreDataCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ClearScoreBoxCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
