Imports System.Windows.Forms

Public Class Dialog1

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.ApplicationLanguage = "English" Then
            EnglishLanguageRadioButton.Select()
            LanguageGroupBox.Text = "Language"
            Me.Text = "Settings"
        ElseIf My.Settings.ApplicationLanguage = "Chinese" Then
            ChineseLanguageRadioButton.Select()
            LanguageGroupBox.Text = "语言"
            Me.Text = "设置"
        End If
        If My.Settings.ShowCopyPrompt = True Then
            CopyPromptCheckBox.Checked = False
        ElseIf My.Settings.ShowCopyPrompt = False Then
            CopyPromptCheckBox.Checked = True
        End If
        If My.Settings.SaveScores = True Then
            SaveScoreDataCheckBox.Checked = False
        ElseIf My.Settings.SaveScores = False Then
            SaveScoreDataCheckBox.Checked = True
        End If
        If My.Settings.ClearScoreBox = True Then
            ClearScoreBoxCheckBox.Checked = False
        ElseIf My.Settings.ClearScoreBox = False Then
            ClearScoreBoxCheckBox.Checked = True
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim EnglishNativeSelectedIndex = Form1.EnglishNativeComboBox.SelectedIndex
        Dim ChineseNativeSelectedIndex = Form1.ChineseNativeComboBox.SelectedIndex
        Dim EnglishLevelSelectedIndex = Form1.EnglishLevelComboBox.SelectedIndex
        Dim ChineseLevelSelectedIndex = Form1.ChineseLevelComboBox.SelectedIndex
        If EnglishLanguageRadioButton.Checked = True Then
            My.Settings.ApplicationLanguage = "English"
            Form1.English.Text = "English"
            Form1.Chinese.Text = "Chinese"
            Form1.Math.Text = "Math"
            Form1.History.Text = "History"
            Form1.ITEnglishWriting.Text = "IT/English Writing"
            Form1.Physics.Text = "Physics"
            Form1.Chemistry.Text = "Chemistry"
            Form1.EnglishNativeComboBox.Items.Clear()
            Form1.EnglishNativeComboBox.Items.Add("Native")
            Form1.EnglishNativeComboBox.Items.Add("Non-Native")
            Form1.ChineseNativeComboBox.Items.Clear()
            Form1.ChineseNativeComboBox.Items.Add("Native")
            Form1.ChineseNativeComboBox.Items.Add("Non-Native")
            Form1.CalculateGPA.Text = "Calculate GPA"
            Form1.Settings.Text = "Settings"
            Form1.About.Text = "About"
        ElseIf ChineseLanguageRadioButton.Checked = True Then
            My.Settings.ApplicationLanguage = "Chinese"
            Form1.English.Text = "英文"
            Form1.Chinese.Text = "中文"
            Form1.Math.Text = "数学"
            Form1.History.Text = "历史"
            Form1.ITEnglishWriting.Text = "计算机/英文写作"
            Form1.Physics.Text = "物理"
            Form1.Chemistry.Text = "化学"
            Form1.EnglishNativeComboBox.Items.Clear()
            Form1.EnglishNativeComboBox.Items.Add("母语")
            Form1.EnglishNativeComboBox.Items.Add("非母语")
            Form1.ChineseNativeComboBox.Items.Clear()
            Form1.ChineseNativeComboBox.Items.Add("母语")
            Form1.ChineseNativeComboBox.Items.Add("非母语")
            Form1.CalculateGPA.Text = "计算GPA"
            Form1.Settings.Text = "设置"
            Form1.About.Text = "关于"
        End If
        Form1.EnglishNativeComboBox.SelectedIndex = EnglishNativeSelectedIndex
        Form1.ChineseNativeComboBox.SelectedIndex = ChineseNativeSelectedIndex
        Form1.EnglishLevelComboBox.SelectedIndex = EnglishLevelSelectedIndex
        Form1.ChineseLevelComboBox.SelectedIndex = ChineseLevelSelectedIndex
        If CopyPromptCheckBox.Checked = False Then
            My.Settings.ShowCopyPrompt = True
        ElseIf CopyPromptCheckBox.Checked = True Then
            My.Settings.ShowCopyPrompt = False
        End If
        If SaveScoreDataCheckBox.Checked = False Then
            My.Settings.SaveScores = True
        ElseIf SaveScoreDataCheckBox.Checked = True Then
            My.Settings.SaveScores = False
        End If
        If ClearScoreBoxCheckBox.Checked = False Then
            My.Settings.ClearScoreBox = True
        ElseIf ClearScoreBoxCheckBox.Checked = True Then
            My.Settings.ClearScoreBox = False
        End If
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class