﻿Public Class Form1

    Dim FinalGPA As Double
    Dim SubjectGPA As Double
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
    Dim VersionNumber As String = "1.5.1"
    Dim BuildDate As String = "11/17/2011"
    Dim ChangeLog As String = "Added an option to disable score box clearing. Settings are now stored in AppData\Roaming, as opposed to being stored in AppData\Local previously."
    Dim FutureChanges As String = "I might store settings as registry values in the future so moving the app doesn't wipe out your settings/saved data."

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "EzGPA v" & VersionNumber
        If My.Settings.ApplicationLanguage = "Chinese" Then
            Chinese.Text = "中文"
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
            CalculateGPA.Text = "计算GPA"
            Settings.Text = "设置"
            About.Text = "关于"
        End If
        ChineseNativeComboBox.SelectedIndex = My.Settings.ChineseNative
        ChineseLevelComboBox.SelectedIndex = My.Settings.ChineseLevel
        EnglishNativeComboBox.SelectedIndex = My.Settings.EnglishNative
        EnglishLevelComboBox.SelectedIndex = My.Settings.EnglishLevel
        MathLevelComboBox.SelectedIndex = My.Settings.MathLevel
        PhysicsLevelComboBox.SelectedIndex = My.Settings.PhysicsLevel
        HistoryLevelComboBox.SelectedIndex = My.Settings.HistoryLevel
        ChemistryLevelComboBox.SelectedIndex = My.Settings.ChemistryLevel
        If My.Settings.SaveScores = True Then
            ChineseScoreTextBox.Text = My.Settings.ChineseScore
            EnglishScoreTextBox.Text = My.Settings.EnglishScore
            MathScoreTextBox.Text = My.Settings.MathScore
            PhysicsScoreTextBox.Text = My.Settings.PhysicsScore
            HistoryScoreTextBox.Text = My.Settings.HistoryScore
            ITEnglishWritingScoreTextBox.Text = My.Settings.ITEnglishWritingScore
            ChemistryScoreTextBox.Text = My.Settings.ChemistryScore
        End If
    End Sub

    Private Sub ChineseNativeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChineseNativeComboBox.SelectedIndexChanged
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

    Private Sub EnglishNativeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishNativeComboBox.SelectedIndexChanged
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

    Private Sub ChineseLevelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChineseLevelComboBox.SelectedIndexChanged
        ChineseExtraGPA = 0
        If ChineseNative = True Then
            If ChineseLevelComboBox.SelectedItem = "S" Then
                ChineseExtraGPA = 0.3
            ElseIf ChineseLevelComboBox.SelectedItem = "H" Then
                ChineseExtraGPA = 0.4
            End If
        ElseIf ChineseNative = False Then
            If ChineseLevelComboBox.SelectedItem = "中级/准中级" Then
                ChineseExtraGPA = 0.1
            ElseIf ChineseLevelComboBox.SelectedItem = "高级/读写" Then
                ChineseExtraGPA = 0.2
            End If
        End If
    End Sub

    Private Sub EnglishLevelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishLevelComboBox.SelectedIndexChanged
        EnglishExtraGPA = 0
        If EnglishNative = True Then
            If EnglishLevelComboBox.SelectedItem = "H" Then
                EnglishExtraGPA = 0.3
            ElseIf EnglishLevelComboBox.SelectedItem = "H+" Then
                EnglishExtraGPA = 0.4
            End If
        ElseIf EnglishNative = False Then
            If EnglishLevelComboBox.SelectedItem = "S+" Then
                EnglishExtraGPA = 0.2
            End If
        End If
    End Sub

    Private Sub MathLevelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MathLevelComboBox.SelectedIndexChanged
        MathExtraGPA = 0
        If MathLevelComboBox.SelectedItem = "S+" Then
            MathExtraGPA = 0.15
        ElseIf MathLevelComboBox.SelectedItem = "H" Then
            MathExtraGPA = 0.3
        End If
    End Sub

    Private Sub PhysicsLevelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhysicsLevelComboBox.SelectedIndexChanged
        PhysicsExtraGPA = 0
        If PhysicsLevelComboBox.SelectedItem = "S+" Then
            PhysicsExtraGPA = 0.15
        ElseIf PhysicsLevelComboBox.SelectedItem = "H" Then
            PhysicsExtraGPA = 0.3
        End If
    End Sub

    Private Sub HistoryLevelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryLevelComboBox.SelectedIndexChanged
        HistoryExtraGPA = 0
        If HistoryLevelComboBox.SelectedItem = "S+" Then
            HistoryExtraGPA = 0.15
        ElseIf HistoryLevelComboBox.SelectedItem = "H" Then
            HistoryExtraGPA = 0.3
        End If
    End Sub

    Private Sub ChemistryLevelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChemistryLevelComboBox.SelectedIndexChanged
        ChemistryExtraGPA = 0
        If ChemistryLevelComboBox.SelectedItem = "S+" Then
            ChemistryExtraGPA = 0.15
        ElseIf ChemistryLevelComboBox.SelectedItem = "H" Then
            ChemistryExtraGPA = 0.3
        End If
    End Sub

    Private Sub ScoreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ChineseScoreTextBox.KeyPress, EnglishScoreTextBox.KeyPress, MathScoreTextBox.KeyPress, PhysicsScoreTextBox.KeyPress, HistoryScoreTextBox.KeyPress, ChemistryScoreTextBox.KeyPress, ITEnglishWritingScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ChineseScoreTextBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChineseScoreTextBox.LostFocus
        If Not ChineseScoreTextBox.Text = Nothing Then
            ChineseScoreTextBox.Text = Val(ChineseScoreTextBox.Text)
        End If
        If Val(ChineseScoreTextBox.Text) > 100 Then
            ChineseScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub EnglishScoreTextBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishScoreTextBox.LostFocus
        If Not EnglishScoreTextBox.Text = Nothing Then
            EnglishScoreTextBox.Text = Val(EnglishScoreTextBox.Text)
        End If
        If Val(EnglishScoreTextBox.Text) > 100 Then
            EnglishScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub MathScoreTextBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MathScoreTextBox.LostFocus
        If Not MathScoreTextBox.Text = Nothing Then
            MathScoreTextBox.Text = Val(MathScoreTextBox.Text)
        End If
        If Val(MathScoreTextBox.Text) > 100 Then
            MathScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub PhysicsScoreTextBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhysicsScoreTextBox.LostFocus
        If Not PhysicsScoreTextBox.Text = Nothing Then
            PhysicsScoreTextBox.Text = Val(PhysicsScoreTextBox.Text)
        End If
        If Val(PhysicsScoreTextBox.Text) > 100 Then
            PhysicsScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub HistoryScoreTextBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryScoreTextBox.LostFocus
        If Not HistoryScoreTextBox.Text = Nothing Then
            HistoryScoreTextBox.Text = Val(HistoryScoreTextBox.Text)
        End If
        If Val(HistoryScoreTextBox.Text) > 100 Then
            HistoryScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub ITEnglishWritingScoreTextBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEnglishWritingScoreTextBox.LostFocus
        If Not ITEnglishWritingScoreTextBox.Text = Nothing Then
            ITEnglishWritingScoreTextBox.Text = Val(ITEnglishWritingScoreTextBox.Text)
        End If
        If Val(ITEnglishWritingScoreTextBox.Text) > 100 Then
            ITEnglishWritingScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub ChemistryScoreTextBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChemistryScoreTextBox.LostFocus
        If Not ChemistryScoreTextBox.Text = Nothing Then
            ChemistryScoreTextBox.Text = Val(ChemistryScoreTextBox.Text)
        End If
        If Val(ChemistryScoreTextBox.Text) > 100 Then
            ChemistryScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub ChineseScoreTextBox_GotFocus(sender As System.Object, e As System.EventArgs) Handles ChineseScoreTextBox.GotFocus
        If My.Settings.ClearScoreBox = True Then
            ChineseScoreTextBox.Clear()
        End If
    End Sub

    Private Sub EnglishScoreTextBox_GotFocus(sender As System.Object, e As System.EventArgs) Handles EnglishScoreTextBox.GotFocus
        If My.Settings.ClearScoreBox = True Then
            EnglishScoreTextBox.Clear()
        End If
    End Sub

    Private Sub MathScoreTextBox_GotFocus(sender As System.Object, e As System.EventArgs) Handles MathScoreTextBox.GotFocus
        If My.Settings.ClearScoreBox = True Then
            MathScoreTextBox.Clear()
        End If
    End Sub

    Private Sub PhysicsScoreTextBox_GotFocus(sender As System.Object, e As System.EventArgs) Handles PhysicsScoreTextBox.GotFocus
        If My.Settings.ClearScoreBox = True Then
            PhysicsScoreTextBox.Clear()
        End If
    End Sub

    Private Sub HistoryScoreTextBox_GotFocus(sender As System.Object, e As System.EventArgs) Handles HistoryScoreTextBox.GotFocus
        If My.Settings.ClearScoreBox = True Then
            HistoryScoreTextBox.Clear()
        End If
    End Sub

    Private Sub ChemistryScoreTextBox_GotFocus(sender As System.Object, e As System.EventArgs) Handles ChemistryScoreTextBox.GotFocus
        If My.Settings.ClearScoreBox = True Then
            ChemistryScoreTextBox.Clear()
        End If
    End Sub

    Private Sub ITEnglishWritingScoreTextBox_GotFocus(sender As System.Object, e As System.EventArgs) Handles ITEnglishWritingScoreTextBox.GotFocus
        If My.Settings.ClearScoreBox = True Then
            ITEnglishWritingScoreTextBox.Clear()
        End If
    End Sub

    Private Sub CalculateSubjectGPA(ByVal Score As Integer)
        If Score >= 93 And Score <= 100 Then
            SubjectGPA = 4
        ElseIf Score >= 88 And Score < 93 Then
            SubjectGPA = 3.7
        ElseIf Score >= 83 And Score < 88 Then
            SubjectGPA = 3.4
        ElseIf Score >= 78 And Score < 83 Then
            SubjectGPA = 3.1
        ElseIf Score >= 73 And Score < 78 Then
            SubjectGPA = 2.8
        ElseIf Score >= 68 And Score < 73 Then
            SubjectGPA = 2.5
        ElseIf Score >= 60 And Score < 68 Then
            SubjectGPA = 2.1
        ElseIf Score < 60 Then
            SubjectGPA = 0
        End If
    End Sub

    Private Sub CalculateFinalGPA()
        CalculateSubjectGPA(Val(ChineseScoreTextBox.Text))
        If Val(ChineseScoreTextBox.Text) >= 60 Then
            ChineseGPA = SubjectGPA + ChineseExtraGPA
        ElseIf Val(ChineseScoreTextBox.Text) < 60 Then
            ChineseGPA = SubjectGPA
        End If
        CalculateSubjectGPA(Val(EnglishScoreTextBox.Text))
        If Val(EnglishScoreTextBox.Text) >= 60 Then
            EnglishGPA = SubjectGPA + EnglishExtraGPA
        ElseIf Val(EnglishScoreTextBox.Text) < 60 Then
            EnglishGPA = SubjectGPA
        End If
        CalculateSubjectGPA(Val(MathScoreTextBox.Text))
        If Val(MathScoreTextBox.Text) >= 60 Then
            MathGPA = SubjectGPA + MathExtraGPA
        ElseIf Val(MathScoreTextBox.Text) < 60 Then
            MathGPA = SubjectGPA
        End If
        CalculateSubjectGPA(Val(PhysicsScoreTextBox.Text))
        If Val(PhysicsScoreTextBox.Text) >= 60 Then
            PhysicsGPA = SubjectGPA + PhysicsExtraGPA
        ElseIf Val(PhysicsScoreTextBox.Text) < 60 Then
            PhysicsGPA = SubjectGPA
        End If
        CalculateSubjectGPA(Val(HistoryScoreTextBox.Text))
        If Val(HistoryScoreTextBox.Text) >= 60 Then
            HistoryGPA = SubjectGPA + HistoryExtraGPA
        ElseIf Val(HistoryScoreTextBox.Text) < 60 Then
            HistoryGPA = SubjectGPA
        End If
        CalculateSubjectGPA(Val(ITEnglishWritingScoreTextBox.Text))
        ITEnglishWritingGPA = SubjectGPA
        CalculateSubjectGPA(Val(ChemistryScoreTextBox.Text))
        If Val(ChemistryScoreTextBox.Text) >= 60 Then
            ChemistryGPA = SubjectGPA + ChemistryExtraGPA
        ElseIf Val(ChemistryScoreTextBox.Text) < 60 Then
            ChemistryGPA = SubjectGPA
        End If
        FinalGPA = ((ChineseGPA * 4.5) + (EnglishGPA * 7.5) + (MathGPA * 7) + (PhysicsGPA * 4) + (HistoryGPA * 3.5) + (ITEnglishWritingGPA * 1.5) + (ChemistryGPA * 3)) / 31
    End Sub

    Private Sub CalculateGPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateGPA.Click
        If EnglishScoreTextBox.Text = "" Or ChineseScoreTextBox.Text = "" Or MathScoreTextBox.Text = "" Or HistoryScoreTextBox.Text = "" Or ITEnglishWritingScoreTextBox.Text = "" Or PhysicsScoreTextBox.Text = "" Or ChemistryScoreTextBox.Text = "" Then
            If My.Settings.ApplicationLanguage = "English" Then
                MsgBox("Please enter all of your scores!", MsgBoxStyle.Exclamation)
            ElseIf My.Settings.ApplicationLanguage = "Chinese" Then
                MsgBox("请输入你所有的成绩!", MsgBoxStyle.Exclamation)
            End If
        Else
            CalculateFinalGPA()
            MsgBox(FinalGPA, MsgBoxStyle.Information, "EzGPA")
            If My.Settings.ApplicationLanguage = "English" And My.Settings.ShowCopyPrompt = True Then
                Dim CopyGPA = MsgBox("Do you want to copy your GPA to the clipboard?", MessageBoxButtons.YesNo + MessageBoxIcon.Question)
                If CopyGPA = MsgBoxResult.Yes Then
                    Clipboard.Clear()
                    On Error Resume Next
                    Clipboard.SetText(FinalGPA)
                    On Error Resume Next
                    MsgBox("Your GPA has successfully been copied to the clipboard.", MsgBoxStyle.Information)
                End If
            ElseIf My.Settings.ApplicationLanguage = "Chinese" And My.Settings.ShowCopyPrompt = True Then
                Dim CopyGPA = MsgBox("是否要把你的GPA复制到剪贴板?", MessageBoxButtons.YesNo + MessageBoxIcon.Question)
                If CopyGPA = MsgBoxResult.Yes Then
                    Clipboard.Clear()
                    On Error Resume Next
                    Clipboard.SetText(FinalGPA)
                    On Error Resume Next
                    MsgBox("复制成功!", MsgBoxStyle.Information)
                End If
            End If
        End If
    End Sub

    Private Sub Settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Settings.Click
        Dialog1.Show()
    End Sub

    Private Sub About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles About.Click
        'If My.Settings.ApplicationLanguage = "English" Then
        MsgBox("EzGPA v" & VersionNumber & Environment.NewLine & "Copyright © 2011 Andrew Sun <crossbowffs@live.com>" & Environment.NewLine & "Built on " & BuildDate & Environment.NewLine & Environment.NewLine & "v" & VersionNumber & " changelog: " & ChangeLog & Environment.NewLine & Environment.NewLine & "Planned changes: " & FutureChanges, MsgBoxStyle.Information)
        'ElseIf My.Settings.ApplicationLanguage = "Chinese" Then
        'MsgBox("EzGPA v1.3" & Environment.NewLine & "版权所有 © 2011 Andrew Sun <crossbowffs@live.com>" & Environment.NewLine & Environment.NewLine & "v1.3 更新日志: THE GAME! (I was too lazy to translate that into Chinese. Please bear with me.)", MsgBoxStyle.Information)
        'End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.ChineseNative = ChineseNativeComboBox.SelectedIndex
        My.Settings.ChineseLevel = ChineseLevelComboBox.SelectedIndex
        My.Settings.EnglishNative = EnglishNativeComboBox.SelectedIndex
        My.Settings.EnglishLevel = EnglishLevelComboBox.SelectedIndex
        My.Settings.MathLevel = MathLevelComboBox.SelectedIndex
        My.Settings.HistoryLevel = HistoryLevelComboBox.SelectedIndex
        My.Settings.PhysicsLevel = PhysicsLevelComboBox.SelectedIndex
        My.Settings.ChemistryLevel = ChemistryLevelComboBox.SelectedIndex
        If My.Settings.SaveScores = True Then
            My.Settings.ChineseScore = ChineseScoreTextBox.Text
            My.Settings.EnglishScore = EnglishScoreTextBox.Text
            My.Settings.MathScore = MathScoreTextBox.Text
            My.Settings.HistoryScore = HistoryScoreTextBox.Text
            My.Settings.ITEnglishWritingScore = ITEnglishWritingScoreTextBox.Text
            My.Settings.PhysicsScore = PhysicsScoreTextBox.Text
            My.Settings.ChemistryScore = ChemistryScoreTextBox.Text
        End If
    End Sub
End Class