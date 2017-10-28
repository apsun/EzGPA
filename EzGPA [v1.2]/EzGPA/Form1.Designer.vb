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
        Me.CalculateGPA = New System.Windows.Forms.Button()
        Me.History = New System.Windows.Forms.Label()
        Me.HistoryLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.ITLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.HistoryScoreTextBox = New System.Windows.Forms.TextBox()
        Me.PhysicsScoreTextBox = New System.Windows.Forms.TextBox()
        Me.ChemistryScoreTextBox = New System.Windows.Forms.TextBox()
        Me.ITScoreTextBox = New System.Windows.Forms.TextBox()
        Me.PhysicsLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.ChemistryLevelComboBox = New System.Windows.Forms.ComboBox()
        Me.IT = New System.Windows.Forms.Label()
        Me.Physics = New System.Windows.Forms.Label()
        Me.Chemistry = New System.Windows.Forms.Label()
        Me.About = New System.Windows.Forms.Button()
        Me.Settings = New System.Windows.Forms.Button()
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
        Me.MathLevelComboBox.Location = New System.Drawing.Point(77, 66)
        Me.MathLevelComboBox.Name = "MathLevelComboBox"
        Me.MathLevelComboBox.Size = New System.Drawing.Size(178, 21)
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
        Me.MathScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CalculateGPA
        '
        Me.CalculateGPA.Location = New System.Drawing.Point(15, 201)
        Me.CalculateGPA.Name = "CalculateGPA"
        Me.CalculateGPA.Size = New System.Drawing.Size(109, 23)
        Me.CalculateGPA.TabIndex = 13
        Me.CalculateGPA.Text = "Calculate GPA"
        Me.CalculateGPA.UseVisualStyleBackColor = True
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
        Me.HistoryLevelComboBox.Location = New System.Drawing.Point(77, 120)
        Me.HistoryLevelComboBox.Name = "HistoryLevelComboBox"
        Me.HistoryLevelComboBox.Size = New System.Drawing.Size(178, 21)
        Me.HistoryLevelComboBox.TabIndex = 15
        '
        'ITLevelComboBox
        '
        Me.ITLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ITLevelComboBox.FormattingEnabled = True
        Me.ITLevelComboBox.Items.AddRange(New Object() {"S", "S+", "H"})
        Me.ITLevelComboBox.Location = New System.Drawing.Point(77, 147)
        Me.ITLevelComboBox.Name = "ITLevelComboBox"
        Me.ITLevelComboBox.Size = New System.Drawing.Size(178, 21)
        Me.ITLevelComboBox.TabIndex = 16
        '
        'HistoryScoreTextBox
        '
        Me.HistoryScoreTextBox.Location = New System.Drawing.Point(261, 120)
        Me.HistoryScoreTextBox.MaxLength = 3
        Me.HistoryScoreTextBox.Name = "HistoryScoreTextBox"
        Me.HistoryScoreTextBox.ShortcutsEnabled = False
        Me.HistoryScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.HistoryScoreTextBox.TabIndex = 17
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
        Me.PhysicsScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ChemistryScoreTextBox
        '
        Me.ChemistryScoreTextBox.Location = New System.Drawing.Point(261, 174)
        Me.ChemistryScoreTextBox.MaxLength = 3
        Me.ChemistryScoreTextBox.Name = "ChemistryScoreTextBox"
        Me.ChemistryScoreTextBox.ShortcutsEnabled = False
        Me.ChemistryScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.ChemistryScoreTextBox.TabIndex = 19
        Me.ChemistryScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ITScoreTextBox
        '
        Me.ITScoreTextBox.Location = New System.Drawing.Point(261, 147)
        Me.ITScoreTextBox.MaxLength = 3
        Me.ITScoreTextBox.Name = "ITScoreTextBox"
        Me.ITScoreTextBox.ShortcutsEnabled = False
        Me.ITScoreTextBox.Size = New System.Drawing.Size(25, 20)
        Me.ITScoreTextBox.TabIndex = 20
        Me.ITScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PhysicsLevelComboBox
        '
        Me.PhysicsLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PhysicsLevelComboBox.FormattingEnabled = True
        Me.PhysicsLevelComboBox.Items.AddRange(New Object() {"S", "H"})
        Me.PhysicsLevelComboBox.Location = New System.Drawing.Point(77, 93)
        Me.PhysicsLevelComboBox.Name = "PhysicsLevelComboBox"
        Me.PhysicsLevelComboBox.Size = New System.Drawing.Size(178, 21)
        Me.PhysicsLevelComboBox.TabIndex = 21
        '
        'ChemistryLevelComboBox
        '
        Me.ChemistryLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ChemistryLevelComboBox.FormattingEnabled = True
        Me.ChemistryLevelComboBox.Items.AddRange(New Object() {"S", "H"})
        Me.ChemistryLevelComboBox.Location = New System.Drawing.Point(77, 174)
        Me.ChemistryLevelComboBox.Name = "ChemistryLevelComboBox"
        Me.ChemistryLevelComboBox.Size = New System.Drawing.Size(178, 21)
        Me.ChemistryLevelComboBox.TabIndex = 22
        '
        'IT
        '
        Me.IT.AutoSize = True
        Me.IT.Location = New System.Drawing.Point(12, 150)
        Me.IT.Name = "IT"
        Me.IT.Size = New System.Drawing.Size(17, 13)
        Me.IT.TabIndex = 23
        Me.IT.Text = "IT"
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
        Me.Chemistry.Location = New System.Drawing.Point(12, 177)
        Me.Chemistry.Name = "Chemistry"
        Me.Chemistry.Size = New System.Drawing.Size(52, 13)
        Me.Chemistry.TabIndex = 25
        Me.Chemistry.Text = "Chemistry"
        '
        'About
        '
        Me.About.Location = New System.Drawing.Point(211, 201)
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(75, 23)
        Me.About.TabIndex = 26
        Me.About.Text = "About"
        Me.About.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.Settings.Location = New System.Drawing.Point(130, 201)
        Me.Settings.Name = "Settings"
        Me.Settings.Size = New System.Drawing.Size(75, 23)
        Me.Settings.TabIndex = 27
        Me.Settings.Text = "Settings"
        Me.Settings.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 236)
        Me.Controls.Add(Me.Settings)
        Me.Controls.Add(Me.About)
        Me.Controls.Add(Me.Chemistry)
        Me.Controls.Add(Me.Physics)
        Me.Controls.Add(Me.IT)
        Me.Controls.Add(Me.ChemistryLevelComboBox)
        Me.Controls.Add(Me.PhysicsLevelComboBox)
        Me.Controls.Add(Me.ITScoreTextBox)
        Me.Controls.Add(Me.ChemistryScoreTextBox)
        Me.Controls.Add(Me.PhysicsScoreTextBox)
        Me.Controls.Add(Me.HistoryScoreTextBox)
        Me.Controls.Add(Me.ITLevelComboBox)
        Me.Controls.Add(Me.HistoryLevelComboBox)
        Me.Controls.Add(Me.History)
        Me.Controls.Add(Me.CalculateGPA)
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
    Friend WithEvents CalculateGPA As System.Windows.Forms.Button
    Friend WithEvents History As System.Windows.Forms.Label
    Friend WithEvents HistoryLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ITLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents HistoryScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhysicsScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ChemistryScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ITScoreTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PhysicsLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ChemistryLevelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents IT As System.Windows.Forms.Label
    Friend WithEvents Physics As System.Windows.Forms.Label
    Friend WithEvents Chemistry As System.Windows.Forms.Label
    Friend WithEvents About As System.Windows.Forms.Button
    Friend WithEvents Settings As System.Windows.Forms.Button

End Class
