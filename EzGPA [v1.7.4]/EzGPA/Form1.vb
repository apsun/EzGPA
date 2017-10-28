Public Class Form1

    Dim ForceExit As Boolean
    Dim ChineseGPA As Double
    Dim EnglishGPA As Double
    Dim MathGPA As Double
    Dim PhysicsGPA As Double
    Dim HistoryGPA As Double
    Dim ITEnglishWritingGPA As Double
    Dim ChemistryGPA As Double
    Dim ChineseExtraGPA As Double
    Dim EnglishExtraGPA As Double
    Dim MathExtraGPA As Double
    Dim PhysicsExtraGPA As Double
    Dim HistoryExtraGPA As Double
    Dim ChemistryExtraGPA As Double
    Dim ChineseNative As Boolean
    Dim EnglishNative As Boolean
    Dim SaveScores As Boolean = True
    Dim AutoClear As Boolean = True
    Dim ApplicationLanguage As String = "English"
    Dim VersionNumber As String = "1.7.4"
    Dim MajorEdit As String = "a"
    Dim ChangeLogEN As String = "The caret inside the score textboxes no longer jumps to the left when entering a value greater than 100."
    Dim FutureChangesEN As String = "I don't know either... >_>"
    Dim ChangeLogCN As String = "未知"
    Dim FutureChangesCN As String = "未知"

    Private Sub ReadWriteRegistryValues(Optional Action As String = Nothing)
        If Action = "Read" Then
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\EzGPA", "CrashOnStartup", 0) = 1 Then
                Dim mbr As MsgBoxResult = MsgBox("It seems EzGPA crashed the last time it started while loading settings; if you manually ended the process, click no and disregard this message; otherwise, click yes to attempt to fix the problem." & Environment.NewLine & Environment.NewLine & "Do you wish to reset all settings to their default values?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)
                If mbr = MsgBoxResult.Yes Then
                    Dim TempRegKey = Registry.CurrentUser.OpenSubKey("Software", True)
                    TempRegKey.DeleteSubKeyTree("EzGPA")
                    TempRegKey.Close()
                ElseIf mbr = MsgBoxResult.No Then
                    My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\EzGPA", "CrashOnStartup", 0)
                End If
            End If
        End If

        Dim RegistryKeyMain = Registry.CurrentUser.OpenSubKey("Software\\EzGPA", True)

        If RegistryKeyMain Is Nothing Then
            Registry.CurrentUser.CreateSubKey("Software\\EzGPA")
            RegistryKeyMain = Registry.CurrentUser.OpenSubKey("Software\\EzGPA", True)
            RegistryKeyMain.SetValue("MajorEdit", MajorEdit)
            ReadWriteRegistryValues("Read")
        ElseIf My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\EzGPA", "MajorEdit", Nothing) <> MajorEdit Then
            MsgBox("An older (or possibly newer) version of EzGPA has been detected which conflicts with the currently stored settings. Due to possible compatibility issues, all settings have been reset to their default values.", MsgBoxStyle.Information)
            Dim TempRegKey = Registry.CurrentUser.OpenSubKey("Software", True)
            TempRegKey.DeleteSubKey("EzGPA", False)
            TempRegKey.Close()
            ReadWriteRegistryValues()
        End If

        If Action = "Read" Then
            Try
                SaveScoresCheckBox.Checked = RegistryKeyMain.GetValue("SaveScores", True)
                AutoClearCheckBox.Checked = RegistryKeyMain.GetValue("AutoClear", True)
                ApplicationLanguage = RegistryKeyMain.GetValue("ApplicationLanguage", "English")

                ChineseNativeComboBox.SelectedIndex = RegistryKeyMain.GetValue("ChineseNative", 0)
                EnglishNativeComboBox.SelectedIndex = RegistryKeyMain.GetValue("EnglishNative", 0)
                ChineseLevelComboBox.SelectedIndex = RegistryKeyMain.GetValue("ChineseLevel", 0)
                EnglishLevelComboBox.SelectedIndex = RegistryKeyMain.GetValue("EnglishLevel", 0)
                MathLevelComboBox.SelectedIndex = RegistryKeyMain.GetValue("MathLevel", 0)
                PhysicsLevelComboBox.SelectedIndex = RegistryKeyMain.GetValue("PhysicsLevel", 0)
                HistoryLevelComboBox.SelectedIndex = RegistryKeyMain.GetValue("HistoryLevel", 0)
                ChemistryLevelComboBox.SelectedIndex = RegistryKeyMain.GetValue("ChemistryLevel", 0)

                If SaveScores = True Then
                    ChineseScoreTextBox.Text = RegistryKeyMain.GetValue("ChineseScore", 100)
                    EnglishScoreTextBox.Text = RegistryKeyMain.GetValue("EnglishScore", 100)
                    MathScoreTextBox.Text = RegistryKeyMain.GetValue("MathScore", 100)
                    PhysicsScoreTextBox.Text = RegistryKeyMain.GetValue("PhysicsScore", 100)
                    HistoryScoreTextBox.Text = RegistryKeyMain.GetValue("HistoryScore", 100)
                    ChemistryScoreTextBox.Text = RegistryKeyMain.GetValue("ChemistryScore", 100)
                    ITEnglishWritingScoreTextBox.Text = RegistryKeyMain.GetValue("ITEnglishWritingScore", 100)
                Else
                    For Each MyControl As Control In Me.Controls
                        If MyControl.Name.EndsWith("TextBox") Then
                            MyControl.Text = "100"
                        End If
                    Next
                End If
            Catch
                RegistryKeyMain.SetValue("CrashOnStartup", 1)
                MsgBox("Error loading user settings!", MsgBoxStyle.Critical)
                ForceExit = True
                Application.Exit()
            End Try
        ElseIf Action = "Write" Then
            RegistryKeyMain.SetValue("SaveScores", SaveScoresCheckBox.Checked)
            RegistryKeyMain.SetValue("AutoClear", AutoClearCheckBox.Checked)
            If EnglishLanguageRadioButton.Checked Then
                RegistryKeyMain.SetValue("ApplicationLanguage", "English")
            ElseIf ChineseLanguageRadioButton.Checked Then
                RegistryKeyMain.SetValue("ApplicationLanguage", "Chinese")
            End If

            RegistryKeyMain.SetValue("ChineseNative", ChineseNativeComboBox.SelectedIndex)
            RegistryKeyMain.SetValue("EnglishNative", EnglishNativeComboBox.SelectedIndex)
            RegistryKeyMain.SetValue("ChineseLevel", ChineseLevelComboBox.SelectedIndex)
            RegistryKeyMain.SetValue("EnglishLevel", EnglishLevelComboBox.SelectedIndex)
            RegistryKeyMain.SetValue("MathLevel", MathLevelComboBox.SelectedIndex)
            RegistryKeyMain.SetValue("PhysicsLevel", PhysicsLevelComboBox.SelectedIndex)
            RegistryKeyMain.SetValue("HistoryLevel", HistoryLevelComboBox.SelectedIndex)
            RegistryKeyMain.SetValue("ChemistryLevel", ChemistryLevelComboBox.SelectedIndex)

            If SaveScoresCheckBox.Checked = True Then
                RegistryKeyMain.SetValue("ChineseScore", ChineseScoreTextBox.Text)
                RegistryKeyMain.SetValue("EnglishScore", EnglishScoreTextBox.Text)
                RegistryKeyMain.SetValue("MathScore", MathScoreTextBox.Text)
                RegistryKeyMain.SetValue("PhysicsScore", PhysicsScoreTextBox.Text)
                RegistryKeyMain.SetValue("HistoryScore", HistoryScoreTextBox.Text)
                RegistryKeyMain.SetValue("ChemistryScore", ChemistryScoreTextBox.Text)
                RegistryKeyMain.SetValue("ITEnglishWritingScore", ITEnglishWritingScoreTextBox.Text)
            End If
        End If
    End Sub

    Private Sub RefreshLanguage()
        Dim EnglishNativeSelectedIndex = EnglishNativeComboBox.SelectedIndex
        Dim ChineseNativeSelectedIndex = ChineseNativeComboBox.SelectedIndex
        Dim EnglishLevelSelectedIndex = EnglishLevelComboBox.SelectedIndex
        Dim ChineseLevelSelectedIndex = ChineseLevelComboBox.SelectedIndex
        If ApplicationLanguage = "English" Then
            English.Text = "English"
            Chinese.Text = "Chinese"
            Math.Text = "Math"
            History.Text = "History"
            ITEnglishWriting.Text = "IT/English Writing"
            Physics.Text = "Physics"
            Chemistry.Text = "Chemistry"
            EnglishNativeComboBox.Items.Clear()
            EnglishNativeComboBox.Items.Add("Native")
            EnglishNativeComboBox.Items.Add("Non-Native")
            ChineseNativeComboBox.Items.Clear()
            ChineseNativeComboBox.Items.Add("Native")
            ChineseNativeComboBox.Items.Add("Non-Native")
            GPALabel.Text = "Your GPA is:"
            CopyGPAButton.Text = "Copy GPA"
            Settings.Text = "Settings"
            About.Text = "About"
            LanguageGroupBox.Text = "Language"
            SaveScoresCheckBox.Text = "Save my scores between sessions"
            AutoClearCheckBox.Text = "Automatically clear scores when clicked"
        ElseIf ApplicationLanguage = "Chinese" Then
            Chinese.Text = "汉语"
            ChineseNativeComboBox.Items.Clear()
            ChineseNativeComboBox.Items.Add("母语")
            ChineseNativeComboBox.Items.Add("非母语")
            English.Text = "英文"
            EnglishNativeComboBox.Items.Clear()
            EnglishNativeComboBox.Items.Add("母语")
            EnglishNativeComboBox.Items.Add("非母语")
            Math.Text = "数学"
            Physics.Text = "物理"
            History.Text = "历史"
            ITEnglishWriting.Text = "计算机/英文写作"
            Chemistry.Text = "化学"
            GPALabel.Text = "你的GPA是:"
            CopyGPAButton.Text = "复制 GPA"
            Settings.Text = "设置"
            About.Text = "关于"
            LanguageGroupBox.Text = "语言"
            SaveScoresCheckBox.Text = "保存成绩数值"
            AutoClearCheckBox.Text = "点击成绩数值时自动清空"
        End If
        EnglishNativeComboBox.SelectedIndex = EnglishNativeSelectedIndex
        ChineseNativeComboBox.SelectedIndex = ChineseNativeSelectedIndex
        EnglishLevelComboBox.SelectedIndex = EnglishLevelSelectedIndex
        ChineseLevelComboBox.SelectedIndex = ChineseLevelSelectedIndex
    End Sub

    Function BuildTime() As DateTime 'http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html
        Const PeHeaderOffset As Integer = 60
        Const LinkerTimestampOffset As Integer = 8

        Dim b(2047) As Byte
        Dim s As IO.Stream
        Try
            s = New IO.FileStream(System.Reflection.Assembly.GetCallingAssembly().Location, IO.FileMode.Open, IO.FileAccess.Read)
            s.Read(b, 0, 2048)
        Finally
            If Not s Is Nothing Then s.Close()
        End Try

        Dim i As Integer = BitConverter.ToInt32(b, PeHeaderOffset)

        Dim SecondsSince1970 As Integer = BitConverter.ToInt32(b, i + LinkerTimestampOffset)
        Dim dt As New DateTime(1970, 1, 1, 0, 0, 0)
        dt = dt.AddSeconds(SecondsSince1970)
        dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours)
        Return dt
    End Function

    Function SubjectGPA(Score As Integer)
        If Score >= 93 Then
            Return 4
        ElseIf Score >= 88 And Score < 93 Then
            Return 3.7
        ElseIf Score >= 83 And Score < 88 Then
            Return 3.4
        ElseIf Score >= 78 And Score < 83 Then
            Return 3.1
        ElseIf Score >= 73 And Score < 78 Then
            Return 2.8
        ElseIf Score >= 68 And Score < 73 Then
            Return 2.5
        ElseIf Score >= 60 And Score < 68 Then
            Return 2.1
        Else
            Return 0
        End If
    End Function

    Function FinalGPA()
        If Val(ChineseScoreTextBox.Text) >= 60 Then
            ChineseGPA = SubjectGPA(Val(ChineseScoreTextBox.Text)) + ChineseExtraGPA
        ElseIf Val(ChineseScoreTextBox.Text) < 60 Then
            ChineseGPA = SubjectGPA(Val(ChineseScoreTextBox.Text))
        End If

        If Val(EnglishScoreTextBox.Text) >= 60 Then
            EnglishGPA = SubjectGPA(Val(EnglishScoreTextBox.Text)) + EnglishExtraGPA
        ElseIf Val(EnglishScoreTextBox.Text) < 60 Then
            EnglishGPA = SubjectGPA(Val(EnglishScoreTextBox.Text))
        End If

        If Val(MathScoreTextBox.Text) >= 60 Then
            MathGPA = SubjectGPA(Val(MathScoreTextBox.Text)) + MathExtraGPA
        ElseIf Val(MathScoreTextBox.Text) < 60 Then
            MathGPA = SubjectGPA(Val(MathScoreTextBox.Text))
        End If

        If Val(PhysicsScoreTextBox.Text) >= 60 Then
            PhysicsGPA = SubjectGPA(Val(PhysicsScoreTextBox.Text)) + PhysicsExtraGPA
        ElseIf Val(PhysicsScoreTextBox.Text) < 60 Then
            PhysicsGPA = SubjectGPA(Val(PhysicsScoreTextBox.Text))
        End If

        If Val(HistoryScoreTextBox.Text) >= 60 Then
            HistoryGPA = SubjectGPA(Val(HistoryScoreTextBox.Text)) + HistoryExtraGPA
        ElseIf Val(HistoryScoreTextBox.Text) < 60 Then
            HistoryGPA = SubjectGPA(Val(HistoryScoreTextBox.Text))
        End If

        If Val(ChemistryScoreTextBox.Text) >= 60 Then
            ChemistryGPA = SubjectGPA(Val(ChemistryScoreTextBox.Text)) + ChemistryExtraGPA
        ElseIf Val(ChemistryScoreTextBox.Text) < 60 Then
            ChemistryGPA = SubjectGPA(Val(ChemistryScoreTextBox.Text))
        End If

        ITEnglishWritingGPA = SubjectGPA(Val(ITEnglishWritingScoreTextBox.Text))

        'Return ((ChineseGPA * 4.5) + (EnglishGPA * 7.5) + (MathGPA * 7) + (PhysicsGPA * 4) + (HistoryGPA * 3.5) + (ChemistryGPA * 3) + (ITEnglishWritingGPA * 1.5)) / 31 'ORIGINAL
        'Return System.Math.Round(((ChineseGPA * 4.5) + (EnglishGPA * 7.5) + (MathGPA * 7) + (PhysicsGPA * 4) + (HistoryGPA * 3.5) + (ChemistryGPA * 3) + (ITEnglishWritingGPA * 1.5)) / 31 - 0.5 / System.Math.Pow(10, 12), 12) 'TRUNCATE: http://social.msdn.microsoft.com/Forums/en/netfxbcl/thread/7e83a3f0-421c-4eae-b3e0-d0cde6e29741
        Return Val(String.Format("{0:0.000000000000}", ((ChineseGPA * 4.5) + (EnglishGPA * 7.5) + (MathGPA * 7) + (PhysicsGPA * 4) + (HistoryGPA * 3.5) + (ChemistryGPA * 3) + (ITEnglishWritingGPA * 1.5)) / 31)) 'ROUND
    End Function

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If ChineseScoreTextBox.Text = "" Or EnglishScoreTextBox.Text = "" Or MathScoreTextBox.Text = "" Or PhysicsScoreTextBox.Text = "" Or HistoryScoreTextBox.Text = "" Or ChemistryScoreTextBox.Text = "" Or ITEnglishWritingScoreTextBox.Text = "" Then
            If ApplicationLanguage = "English" Then
                GPALabel.Text = "Please enter all of your scores!"
            ElseIf ApplicationLanguage = "Chinese" Then
                GPALabel.Text = "请输入你所有的成绩!"
            End If
            CopyGPAButton.Enabled = False
        Else
            If ApplicationLanguage = "English" Then
                GPALabel.Text = "Your GPA is: " & FinalGPA()
            ElseIf ApplicationLanguage = "Chinese" Then
                GPALabel.Text = "你的GPA是: " & FinalGPA()
            End If
            CopyGPAButton.Enabled = True
        End If
    End Sub

    Private Sub Settings_Click(sender As System.Object, e As System.EventArgs) Handles Settings.Click
        If Me.Height = 292 Then
            Me.Height = 406
        ElseIf Height = 406 Then
            Me.Height = 292
        End If
    End Sub

    Private Sub About_Click(sender As System.Object, e As System.EventArgs) Handles About.Click
        If ApplicationLanguage = "English" Then
            MsgBox("EzGPA v" & VersionNumber & Environment.NewLine & "Copyright © 2011-2012 Andrew Sun <crossbowffs@live.com>" & Environment.NewLine & "Built on: " & BuildTime() & Environment.NewLine & Environment.NewLine & "v" & VersionNumber & " changelog: " & ChangeLogEN & Environment.NewLine & Environment.NewLine & "Future changes: " & FutureChangesEN, MsgBoxStyle.Information)
        ElseIf ApplicationLanguage = "Chinese" Then
            MsgBox("EzGPA v" & VersionNumber & Environment.NewLine & "版权所有 © 2011-2012 Andrew Sun <crossbowffs@live.com>" & Environment.NewLine & "编译日期: " & BuildTime() & Environment.NewLine & Environment.NewLine & "v" & VersionNumber & " 更改日志: " & ChangeLogCN & Environment.NewLine & Environment.NewLine & "未来改进: " & FutureChangesCN, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CopyGPAButton_Click(sender As System.Object, e As System.EventArgs) Handles CopyGPAButton.Click
        On Error Resume Next
        Clipboard.SetText(FinalGPA())
        If ApplicationLanguage = "English" Then
            MsgBox("Your GPA has successfully been copied to the clipboard.", MsgBoxStyle.Information)
        ElseIf ApplicationLanguage = "Chinese" Then
            MsgBox("复制成功!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ReadWriteRegistryValues("Read")
        Me.Height = 292
        Me.Text = "EzGPA v" & VersionNumber

        If ApplicationLanguage = "English" Then
            EnglishLanguageRadioButton.Select()
        ElseIf ApplicationLanguage = "Chinese" Then
            ChineseLanguageRadioButton.Select()
        End If
        SaveScoresCheckBox.Checked = SaveScores
        AutoClearCheckBox.Checked = AutoClear

        RefreshLanguage()
    End Sub

    Private Sub Form1_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If ForceExit = False Then
            ReadWriteRegistryValues("Write")
        End If
    End Sub

    Private Sub ChineseNativeComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ChineseNativeComboBox.SelectedIndexChanged
        If ChineseNativeComboBox.SelectedItem = "Native" Or ChineseNativeComboBox.SelectedItem = "母语" Then
            ChineseNative = True
            ChineseLevelComboBox.Items.Clear()
            ChineseLevelComboBox.Items.Add("S")
            ChineseLevelComboBox.Items.Add("H")
        ElseIf ChineseNativeComboBox.SelectedItem = "Non-Native" Or ChineseNativeComboBox.SelectedItem = "非母语" Then
            ChineseNative = False
            ChineseLevelComboBox.Items.Clear()
            ChineseLevelComboBox.Items.Add("初级/入门")
            ChineseLevelComboBox.Items.Add("中级/准中级")
            ChineseLevelComboBox.Items.Add("高级/读写")
        End If
        ChineseLevelComboBox.SelectedIndex = 0
    End Sub

    Private Sub EnglishNativeComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles EnglishNativeComboBox.SelectedIndexChanged
        If EnglishNativeComboBox.SelectedItem = "Native" Or EnglishNativeComboBox.SelectedItem = "母语" Then
            EnglishNative = True
            EnglishLevelComboBox.Items.Clear()
            EnglishLevelComboBox.Items.Add("H")
            EnglishLevelComboBox.Items.Add("H+")
        ElseIf EnglishNativeComboBox.SelectedItem = "Non-Native" Or EnglishNativeComboBox.SelectedItem = "非母语" Then
            EnglishNative = False
            EnglishLevelComboBox.Items.Clear()
            EnglishLevelComboBox.Items.Add("S")
            EnglishLevelComboBox.Items.Add("S+")
        End If
        EnglishLevelComboBox.SelectedIndex = 0
    End Sub

    Private Sub ChineseLevelComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ChineseLevelComboBox.SelectedIndexChanged
        If ChineseNative = True Then
            If ChineseLevelComboBox.SelectedItem = "S" Then
                ChineseExtraGPA = 0.3
            ElseIf ChineseLevelComboBox.SelectedItem = "H" Then
                ChineseExtraGPA = 0.4
            End If
        ElseIf ChineseNative = False Then
            If ChineseLevelComboBox.SelectedItem = "初级/入门" Then
                ChineseExtraGPA = 0
            ElseIf ChineseLevelComboBox.SelectedItem = "中级/准中级" Then
                ChineseExtraGPA = 0.1
            ElseIf ChineseLevelComboBox.SelectedItem = "高级/读写" Then
                ChineseExtraGPA = 0.2
            End If
        End If
    End Sub

    Private Sub EnglishLevelComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles EnglishLevelComboBox.SelectedIndexChanged
        If EnglishNative = True Then
            If EnglishLevelComboBox.SelectedItem = "H" Then
                EnglishExtraGPA = 0.3
            ElseIf EnglishLevelComboBox.SelectedItem = "H+" Then
                EnglishExtraGPA = 0.4
            End If
        ElseIf EnglishNative = False Then
            If EnglishLevelComboBox.SelectedItem = "S" Then
                EnglishExtraGPA = 0
            ElseIf EnglishLevelComboBox.SelectedItem = "S+" Then
                EnglishExtraGPA = 0.2
            End If
        End If
    End Sub

    Private Sub MathLevelComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles MathLevelComboBox.SelectedIndexChanged
        If MathLevelComboBox.SelectedItem = "S" Then
            MathExtraGPA = 0
        ElseIf MathLevelComboBox.SelectedItem = "S+" Then
            MathExtraGPA = 0.15
        ElseIf MathLevelComboBox.SelectedItem = "H" Then
            MathExtraGPA = 0.3
        End If
    End Sub

    Private Sub PhysicsLevelComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles PhysicsLevelComboBox.SelectedIndexChanged
        If PhysicsLevelComboBox.SelectedItem = "S" Then
            PhysicsExtraGPA = 0
        ElseIf PhysicsLevelComboBox.SelectedItem = "S+" Then
            PhysicsExtraGPA = 0.15
        ElseIf PhysicsLevelComboBox.SelectedItem = "H" Then
            PhysicsExtraGPA = 0.3
        End If
    End Sub

    Private Sub HistoryLevelComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles HistoryLevelComboBox.SelectedIndexChanged
        If HistoryLevelComboBox.SelectedItem = "S" Then
            HistoryExtraGPA = 0
        ElseIf HistoryLevelComboBox.SelectedItem = "S+" Then
            HistoryExtraGPA = 0.15
        ElseIf HistoryLevelComboBox.SelectedItem = "H" Then
            HistoryExtraGPA = 0.3
        End If
    End Sub

    Private Sub ChemistryLevelComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ChemistryLevelComboBox.SelectedIndexChanged
        If ChemistryLevelComboBox.SelectedItem = "S" Then
            ChemistryExtraGPA = 0
        ElseIf ChemistryLevelComboBox.SelectedItem = "S+" Then
            ChemistryExtraGPA = 0.15
        ElseIf ChemistryLevelComboBox.SelectedItem = "H" Then
            ChemistryExtraGPA = 0.3
        End If
    End Sub

    Private Sub ScoreTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles ChineseScoreTextBox.TextChanged, EnglishScoreTextBox.TextChanged, MathScoreTextBox.TextChanged, PhysicsScoreTextBox.TextChanged, HistoryScoreTextBox.TextChanged, ChemistryScoreTextBox.TextChanged, ITEnglishWritingScoreTextBox.TextChanged
        If Val(sender.Text) > 100 Then
            sender.Text = 100
            sender.SelectionStart = sender.TextLength
        End If
    End Sub

    Private Sub ScoreTextBox_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ChineseScoreTextBox.KeyPress, EnglishScoreTextBox.KeyPress, MathScoreTextBox.KeyPress, PhysicsScoreTextBox.KeyPress, HistoryScoreTextBox.KeyPress, ChemistryScoreTextBox.KeyPress, ITEnglishWritingScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ScoreTextBox_LostFocus(sender As System.Object, e As System.EventArgs) Handles ChineseScoreTextBox.LostFocus, EnglishScoreTextBox.LostFocus, MathScoreTextBox.LostFocus, PhysicsScoreTextBox.LostFocus, HistoryScoreTextBox.LostFocus, ChemistryScoreTextBox.LostFocus, ITEnglishWritingScoreTextBox.LostFocus
        If Not sender.Text = Nothing Then
            sender.Text = Val(sender.Text)
        End If
    End Sub

    Private Sub ScoreTextBox_GotFocus(sender As System.Object, e As System.EventArgs) Handles ChineseScoreTextBox.GotFocus, EnglishScoreTextBox.GotFocus, MathScoreTextBox.GotFocus, PhysicsScoreTextBox.GotFocus, HistoryScoreTextBox.GotFocus, ChemistryScoreTextBox.GotFocus, ITEnglishWritingScoreTextBox.GotFocus
        If AutoClear = True Then
            sender.Clear()
        End If
    End Sub

    Private Sub SaveScoreDataCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles SaveScoresCheckBox.CheckedChanged
        SaveScores = SaveScoresCheckBox.Checked
    End Sub

    Private Sub AutoClearCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles AutoClearCheckBox.CheckedChanged
        AutoClear = AutoClearCheckBox.Checked
    End Sub

    Private Sub LanguageRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles EnglishLanguageRadioButton.CheckedChanged, ChineseLanguageRadioButton.CheckedChanged
        If EnglishLanguageRadioButton.Checked Then
            ApplicationLanguage = "English"
        ElseIf ChineseLanguageRadioButton.Checked = True Then
            ApplicationLanguage = "Chinese"
        End If
        RefreshLanguage()
    End Sub
End Class