Imports System.Windows.Forms

Public Class Dialog1

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.ApplicationLanguage = 0 Then
            EnglishLanguageRadioButton.Select()
            LanguageGroupBox.Text = "Language"
            Me.Text = "Settings"
        End If
        If My.Settings.ApplicationLanguage = 1 Then
            ChineseLanguageRadioButton.Select()
            LanguageGroupBox.Text = "语言"
            Me.Text = "设置"
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If EnglishLanguageRadioButton.Checked = True Then
            My.Settings.ApplicationLanguage = 0
            Form1.English.Text = "English"
            Form1.Chinese.Text = "Chinese"
            Form1.Math.Text = "Math"
            Form1.History.Text = "History"
            Form1.IT.Text = "Geography"
            Form1.Physics.Text = "Physics"
            Form1.Chemistry.Text = "Biology"
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
            My.Settings.ApplicationLanguage = 1
            Form1.English.Text = "英文"
            Form1.Chinese.Text = "中文"
            Form1.Math.Text = "数学"
            Form1.History.Text = "历史"
            Form1.IT.Text = "地理"
            Form1.Physics.Text = "物理"
            Form1.Chemistry.Text = "生物"
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
        Form1.EnglishNativeComboBox.SelectedIndex = 0
        Form1.ChineseNativeComboBox.SelectedIndex = 0
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class