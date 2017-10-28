<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.EnglishNativeComboBox = New System.Windows.Forms.ComboBox()
        Me.English = New System.Windows.Forms.Label()
        Me.EnglishLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.EnglishScoreTextBox = New System.Windows.Forms.TextBox()
        Me.Chinese = New System.Windows.Forms.Label()
        Me.ChineseNativeComboBox = New System.Windows.Forms.ComboBox()
        Me.ChineseLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.ChineseScoreTextBox = New System.Windows.Forms.TextBox()
        Me.Math = New System.Windows.Forms.Label()
        Me.MathLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.MathScoreTextBox = New System.Windows.Forms.TextBox()
        Me.History = New System.Windows.Forms.Label()
        Me.HistoryLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.HistoryScoreTextBox = New System.Windows.Forms.TextBox()
        Me.PhysicsScoreTextBox = New System.Windows.Forms.TextBox()
        Me.ChemistryScoreTextBox = New System.Windows.Forms.TextBox()
        Me.PhysicsLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.ChemistryLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.Physics = New System.Windows.Forms.Label()
        Me.Chemistry = New System.Windows.Forms.Label()
        Me.About = New System.Windows.Forms.Button()
        Me.Settings = New System.Windows.Forms.Button()
        Me.ITEnglishWriting = New System.Windows.Forms.Label()
        Me.ITEnglishWritingScoreTextBox = New System.Windows.Forms.TextBox()
        Me.GPALabel = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CopyGPAButton = New System.Windows.Forms.Button()
        Me.AutoClearCheckBox = New System.Windows.Forms.CheckBox()
        Me.SaveScoresCheckBox = New System.Windows.Forms.CheckBox()
        Me.LanguageGroupBox = New System.Windows.Forms.GroupBox()
        Me.EnglishLanguageRadioButton = New System.Windows.Forms.RadioButton()
        Me.ChineseLanguageRadioButton = New System.Windows.Forms.RadioButton()
        Me.LanguageGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'EnglishNativeComboBox
        '
        Me.EnglishNativeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EnglishNativeComboBox.FormattingEnabled = True
        Me.EnglishNativeComboBox.Items.AddRange(New Object() {"Native", "Non-Native"})
        Me.EnglishNativeComboBox.Location = New System.Drawing.Point(77, 39)
        Me.EnglishNativeComboBox.Name = "EnglishNativeComboBox"
        Me.EnglishNativeComboBox.Size = New System.Drawing.Size(81, 21)
        Me.EnglishNativeComboBox.TabIndex = 0
        Me.EnglishNativeComboBox.Tag = ""
        '
        'English
        '
        Me.English.AutoSize = True
        Me.English.Location = New System.Drawing.Point(12, 42)
        Me.English.Name = "English"
        Me.English.Size = New System.Drawing.Size(41, 13)
        Me.English.TabIndex = 1
        Me.English.Text = "English"
        '
        'EnglishLevelComboBox
        '
        Me.EnglishLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EnglishLevelComboBox.FormattingEnabled = True
        Me.EnglishLevelComboBox.Location = New System.Drawing.Point(164, 39)
        Me.EnglishLevelComboBox.Name = "EnglishLevelComboBox"
        Me.EnglishLevelComboBox.Size = New System.Drawing.Size(91, 21)
        Me.EnglishLevelComboBox.TabIndex = 2
        '
        'EnglishScoreTextBox
        '
        Me.EnglishScoreTextBox.Location = New System.Drawing.Point(261, 39)
        Me.EnglishScoreTextBox.MaxLength = 3
        Me.EnglishScoreTextBox.Name = "EnglishScoreTextBox"
        Me.EnglishScoreTextBox.ShortcutsEnabled = False
        Me.EnglishScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.EnglishScoreTextBox.TabIndex = 4
        Me.EnglishScoreTextBox.Text = "100"
        Me.EnglishScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Chinese
        '
        Me.Chinese.AutoSize = True
        Me.Chinese.Location = New System.Drawing.Point(12, 15)
        Me.Chinese.Name = "Chinese"
        Me.Chinese.Size = New System.Drawing.Size(45, 13)
        Me.Chinese.TabIndex = 5
        Me.Chinese.Text = "Chinese"
        '
        'ChineseNativeComboBox
        '
        Me.ChineseNativeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ChineseNativeComboBox.FormattingEnabled = True
        Me.ChineseNativeComboBox.Items.AddRange(New Object() {"Native", "Non-Native"})
        Me.ChineseNativeComboBox.Location = New System.Drawing.Point(77, 12)
        Me.ChineseNativeComboBox.Name = "ChineseNativeComboBox"
        Me.ChineseNativeComboBox.Size = New System.Drawing.Size(81, 21)
        Me.ChineseNativeComboBox.TabIndex = 6
        '
        'ChineseLevelComboBox
        '
        Me.ChineseLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ChineseLevelComboBox.FormattingEnabled = True
        Me.ChineseLevelComboBox.Location = New System.Drawing.Point(164, 12)
        Me.ChineseLevelComboBox.Name = "ChineseLevelComboBox"
        Me.ChineseLevelComboBox.Size = New System.Drawing.Size(91, 21)
        Me.ChineseLevelComboBox.TabIndex = 7
        '
        'ChineseScoreTextBox
        '
        Me.ChineseScoreTextBox.Location = New System.Drawing.Point(261, 12)
        Me.ChineseScoreTextBox.MaxLength = 3
        Me.ChineseScoreTextBox.Name = "ChineseScoreTextBox"
        Me.ChineseScoreTextBox.ShortcutsEnabled = False
        Me.ChineseScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.ChineseScoreTextBox.TabIndex = 8
        Me.ChineseScoreTextBox.Text = "100"
        Me.ChineseScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Math
        '
        Me.Math.AutoSize = True
        Me.Math.Location = New System.Drawing.Point(12, 69)
        Me.Math.Name = "Math"
        Me.Math.Size = New System.Drawing.Size(31, 13)
        Me.Math.TabIndex = 9
        Me.Math.Text = "Math"
        '
        'MathLevelComboBox
        '
        Me.MathLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MathLevelComboBox.FormattingEnabled = True
        Me.MathLevelComboBox.Items.AddRange(New Object() {"S", "S+", "H"})
        Me.MathLevelComboBox.Location = New System.Drawing.Point(164, 66)
        Me.MathLevelComboBox.Name = "MathLevelComboBox"
        Me.MathLevelComboBox.Size = New System.Drawing.Size(91, 21)
        Me.MathLevelComboBox.TabIndex = 11
        '
        'MathScoreTextBox
        '
        Me.MathScoreTextBox.Location = New System.Drawing.Point(261, 66)
        Me.MathScoreTextBox.MaxLength = 3
        Me.MathScoreTextBox.Name = "MathScoreTextBox"
        Me.MathScoreTextBox.ShortcutsEnabled = False
        Me.MathScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.MathScoreTextBox.TabIndex = 12
        Me.MathScoreTextBox.Text = "100"
        Me.MathScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'History
        '
        Me.History.AutoSize = True
        Me.History.Location = New System.Drawing.Point(12, 123)
        Me.History.Name = "History"
        Me.History.Size = New System.Drawing.Size(39, 13)
        Me.History.TabIndex = 14
        Me.History.Text = "History"
        '
        'HistoryLevelComboBox
        '
        Me.HistoryLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.HistoryLevelComboBox.FormattingEnabled = True
        Me.HistoryLevelComboBox.Items.AddRange(New Object() {"S", "S+", "H"})
        Me.HistoryLevelComboBox.Location = New System.Drawing.Point(164, 120)
        Me.HistoryLevelComboBox.Name = "HistoryLevelComboBox"
        Me.HistoryLevelComboBox.Size = New System.Drawing.Size(91, 21)
        Me.HistoryLevelComboBox.TabIndex = 15
        '
        'HistoryScoreTextBox
        '
        Me.HistoryScoreTextBox.Location = New System.Drawing.Point(261, 120)
        Me.HistoryScoreTextBox.MaxLength = 3
        Me.HistoryScoreTextBox.Name = "HistoryScoreTextBox"
        Me.HistoryScoreTextBox.ShortcutsEnabled = False
        Me.HistoryScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.HistoryScoreTextBox.TabIndex = 17
        Me.HistoryScoreTextBox.Text = "100"
        Me.HistoryScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PhysicsScoreTextBox
        '
        Me.PhysicsScoreTextBox.Location = New System.Drawing.Point(261, 93)
        Me.PhysicsScoreTextBox.MaxLength = 3
        Me.PhysicsScoreTextBox.Name = "PhysicsScoreTextBox"
        Me.PhysicsScoreTextBox.ShortcutsEnabled = False
        Me.PhysicsScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.PhysicsScoreTextBox.TabIndex = 18
        Me.PhysicsScoreTextBox.Text = "100"
        Me.PhysicsScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChemistryScoreTextBox
        '
        Me.ChemistryScoreTextBox.Location = New System.Drawing.Point(261, 147)
        Me.ChemistryScoreTextBox.MaxLength = 3
        Me.ChemistryScoreTextBox.Name = "ChemistryScoreTextBox"
        Me.ChemistryScoreTextBox.ShortcutsEnabled = False
        Me.ChemistryScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.ChemistryScoreTextBox.TabIndex = 19
        Me.ChemistryScoreTextBox.Text = "100"
        Me.ChemistryScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PhysicsLevelComboBox
        '
        Me.PhysicsLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PhysicsLevelComboBox.FormattingEnabled = True
        Me.PhysicsLevelComboBox.Items.AddRange(New Object() {"S", "S+", "H"})
        Me.PhysicsLevelComboBox.Location = New System.Drawing.Point(164, 93)
        Me.PhysicsLevelComboBox.Name = "PhysicsLevelComboBox"
        Me.PhysicsLevelComboBox.Size = New System.Drawing.Size(91, 21)
        Me.PhysicsLevelComboBox.TabIndex = 21
        '
        'ChemistryLevelComboBox
        '
        Me.ChemistryLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ChemistryLevelComboBox.FormattingEnabled = True
        Me.ChemistryLevelComboBox.Items.AddRange(New Object() {"S", "S+", "H"})
        Me.ChemistryLevelComboBox.Location = New System.Drawing.Point(164, 147)
        Me.ChemistryLevelComboBox.Name = "ChemistryLevelComboBox"
        Me.ChemistryLevelComboBox.Size = New System.Drawing.Size(91, 21)
        Me.ChemistryLevelComboBox.TabIndex = 22
        '
        'Physics
        '
        Me.Physics.AutoSize = True
        Me.Physics.Location = New System.Drawing.Point(12, 96)
        Me.Physics.Name = "Physics"
        Me.Physics.Size = New System.Drawing.Size(43, 13)
        Me.Physics.TabIndex = 24
        Me.Physics.Text = "Physics"
        '
        'Chemistry
        '
        Me.Chemistry.AutoSize = True
        Me.Chemistry.Location = New System.Drawing.Point(12, 150)
        Me.Chemistry.Name = "Chemistry"
        Me.Chemistry.Size = New System.Drawing.Size(52, 13)
        Me.Chemistry.TabIndex = 25
        Me.Chemistry.Text = "Chemistry"
        '
        'About
        '
        Me.About.Location = New System.Drawing.Point(203, 229)
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(83, 23)
        Me.About.TabIndex = 26
        Me.About.Text = "About"
        Me.About.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.Settings.Location = New System.Drawing.Point(12, 229)
        Me.Settings.Name = "Settings"
        Me.Settings.Size = New System.Drawing.Size(185, 23)
        Me.Settings.TabIndex = 27
        Me.Settings.Text = "Settings"
        Me.Settings.UseVisualStyleBackColor = True
        '
        'ITEnglishWriting
        '
        Me.ITEnglishWriting.AutoSize = True
        Me.ITEnglishWriting.Location = New System.Drawing.Point(12, 177)
        Me.ITEnglishWriting.Name = "ITEnglishWriting"
        Me.ITEnglishWriting.Size = New System.Drawing.Size(92, 13)
        Me.ITEnglishWriting.TabIndex = 30
        Me.ITEnglishWriting.Text = "IT/English Writing"
        '
        'ITEnglishWritingScoreTextBox
        '
        Me.ITEnglishWritingScoreTextBox.Location = New System.Drawing.Point(261, 174)
        Me.ITEnglishWritingScoreTextBox.MaxLength = 3
        Me.ITEnglishWritingScoreTextBox.Name = "ITEnglishWritingScoreTextBox"
        Me.ITEnglishWritingScoreTextBox.ShortcutsEnabled = False
        Me.ITEnglishWritingScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.ITEnglishWritingScoreTextBox.TabIndex = 29
        Me.ITEnglishWritingScoreTextBox.Text = "100"
        Me.ITEnglishWritingScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GPALabel
        '
        Me.GPALabel.AutoSize = True
        Me.GPALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPALabel.Location = New System.Drawing.Point(12, 203)
        Me.GPALabel.Name = "GPALabel"
        Me.GPALabel.Size = New System.Drawing.Size(83, 16)
        Me.GPALabel.TabIndex = 31
        Me.GPALabel.Text = "Your GPA is:"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'CopyGPAButton
        '
        Me.CopyGPAButton.Location = New System.Drawing.Point(203, 200)
        Me.CopyGPAButton.Name = "CopyGPAButton"
        Me.CopyGPAButton.Size = New System.Drawing.Size(83, 23)
        Me.CopyGPAButton.TabIndex = 32
        Me.CopyGPAButton.Text = "Copy GPA"
        Me.CopyGPAButton.UseVisualStyleBackColor = True
        '
        'AutoClearCheckBox
        '
        Me.AutoClearCheckBox.AutoSize = True
        Me.AutoClearCheckBox.Checked = True
        Me.AutoClearCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoClearCheckBox.Location = New System.Drawing.Point(12, 349)
        Me.AutoClearCheckBox.Name = "AutoClearCheckBox"
        Me.AutoClearCheckBox.Size = New System.Drawing.Size(213, 17)
        Me.AutoClearCheckBox.TabIndex = 35
        Me.AutoClearCheckBox.Text = "Automatically clear scores when clicked"
        Me.AutoClearCheckBox.UseVisualStyleBackColor = True
        '
        'SaveScoresCheckBox
        '
        Me.SaveScoresCheckBox.AutoSize = True
        Me.SaveScoresCheckBox.Checked = True
        Me.SaveScoresCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SaveScoresCheckBox.Location = New System.Drawing.Point(12, 326)
        Me.SaveScoresCheckBox.Name = "SaveScoresCheckBox"
        Me.SaveScoresCheckBox.Size = New System.Drawing.Size(187, 17)
        Me.SaveScoresCheckBox.TabIndex = 34
        Me.SaveScoresCheckBox.Text = "Save my scores between sessions"
        Me.SaveScoresCheckBox.UseVisualStyleBackColor = True
        '
        'LanguageGroupBox
        '
        Me.LanguageGroupBox.Controls.Add(Me.EnglishLanguageRadioButton)
        Me.LanguageGroupBox.Controls.Add(Me.ChineseLanguageRadioButton)
        Me.LanguageGroupBox.Location = New System.Drawing.Point(12, 270)
        Me.LanguageGroupBox.Name = "LanguageGroupBox"
        Me.LanguageGroupBox.Size = New System.Drawing.Size(274, 50)
        Me.LanguageGroupBox.TabIndex = 33
        Me.LanguageGroupBox.TabStop = False
        Me.LanguageGroupBox.Text = "Language"
        '
        'EnglishLanguageRadioButton
        '
        Me.EnglishLanguageRadioButton.AutoSize = True
        Me.EnglishLanguageRadioButton.Location = New System.Drawing.Point(33, 19)
        Me.EnglishLanguageRadioButton.Name = "EnglishLanguageRadioButton"
        Me.EnglishLanguageRadioButton.Size = New System.Drawing.Size(58, 17)
        Me.EnglishLanguageRadioButton.TabIndex = 2
        Me.EnglishLanguageRadioButton.TabStop = True
        Me.EnglishLanguageRadioButton.Text = "English"
        Me.EnglishLanguageRadioButton.UseVisualStyleBackColor = True
        '
        'ChineseLanguageRadioButton
        '
        Me.ChineseLanguageRadioButton.AutoSize = True
        Me.ChineseLanguageRadioButton.Location = New System.Drawing.Point(191, 19)
        Me.ChineseLanguageRadioButton.Name = "ChineseLanguageRadioButton"
        Me.ChineseLanguageRadioButton.Size = New System.Drawing.Size(48, 17)
        Me.ChineseLanguageRadioButton.TabIndex = 3
        Me.ChineseLanguageRadioButton.TabStop = True
        Me.ChineseLanguageRadioButton.Text = "中文"
        Me.ChineseLanguageRadioButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 378)
        Me.Controls.Add(Me.AutoClearCheckBox)
        Me.Controls.Add(Me.SaveScoresCheckBox)
        Me.Controls.Add(Me.LanguageGroupBox)
        Me.Controls.Add(Me.CopyGPAButton)
        Me.Controls.Add(Me.GPALabel)
        Me.Controls.Add(Me.ITEnglishWriting)
        Me.Controls.Add(Me.ITEnglishWritingScoreTextBox)
        Me.Controls.Add(Me.Settings)
        Me.Controls.Add(Me.About)
        Me.Controls.Add(Me.Chemistry)
        Me.Controls.Add(Me.Physics)
        Me.Controls.Add(Me.ChemistryLevelComboBox)
        Me.Controls.Add(Me.PhysicsLevelComboBox)
        Me.Controls.Add(Me.ChemistryScoreTextBox)
        Me.Controls.Add(Me.PhysicsScoreTextBox)
        Me.Controls.Add(Me.HistoryScoreTextBox)
        Me.Controls.Add(Me.HistoryLevelComboBox)
        Me.Controls.Add(Me.History)
        Me.Controls.Add(Me.MathScoreTextBox)
        Me.Controls.Add(Me.MathLevelComboBox)
        Me.Controls.Add(Me.Math)
        Me.Controls.Add(Me.ChineseScoreTextBox)
        Me.Controls.Add(Me.ChineseLevelComboBox)
        Me.Controls.Add(Me.ChineseNativeComboBox)
        Me.Controls.Add(Me.Chinese)
        Me.Controls.Add(Me.EnglishScoreTextBox)
        Me.Controls.Add(Me.EnglishLevelComboBox)
        Me.Controls.Add(Me.English)
        Me.Controls.Add(Me.EnglishNativeComboBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "EzGPA"
        Me.LanguageGroupBox.ResumeLayout(False)
        Me.LanguageGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EnglishNativeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents English As System.Windows.Forms.Label
    Friend WithEvents EnglishLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents EnglishScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Chinese As System.Windows.Forms.Label
    Friend WithEvents ChineseNativeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ChineseLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ChineseScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Math As System.Windows.Forms.Label
    Friend WithEvents MathLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MathScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents History As System.Windows.Forms.Label
    Friend WithEvents HistoryLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents HistoryScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhysicsScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ChemistryScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhysicsLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ChemistryLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Physics As System.Windows.Forms.Label
    Friend WithEvents Chemistry As System.Windows.Forms.Label
    Friend WithEvents About As System.Windows.Forms.Button
    Friend WithEvents Settings As System.Windows.Forms.Button
    Friend WithEvents ITEnglishWriting As System.Windows.Forms.Label
    Friend WithEvents ITEnglishWritingScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GPALabel As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CopyGPAButton As System.Windows.Forms.Button
    Friend WithEvents AutoClearCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents SaveScoresCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LanguageGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents EnglishLanguageRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ChineseLanguageRadioButton As System.Windows.Forms.RadioButton

End Class
