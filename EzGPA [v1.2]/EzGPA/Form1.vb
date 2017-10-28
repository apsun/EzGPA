Public Class Form1

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
    Dim ITEnglishWritingExtraGPA As Double
    Dim ChemistryExtraGPA As Double
    Dim ChineseNative As Boolean
    Dim EnglishNative As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.ApplicationLanguage = 1 Then
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
            IT.Text = "地理"
            Chemistry.Text = "生物"
            CalculateGPA.Text = "计算GPA"
            Settings.Text = "设置"
            About.Text = "关于"
        End If
        ChineseNativeComboBox.SelectedIndex = My.Settings.ChineseNative
        ChineseLevelComboBox.SelectedIndex = My.Settings.ChineseLevel
        ChineseScoreTextBox.Text = My.Settings.ChineseScore

        EnglishNativeComboBox.SelectedIndex = My.Settings.EnglishNative
        EnglishLevelComboBox.SelectedIndex = My.Settings.EnglishLevel
        EnglishScoreTextBox.Text = My.Settings.EnglishScore

        MathLevelComboBox.SelectedIndex = My.Settings.MathLevel
        MathScoreTextBox.Text = My.Settings.MathScore

        PhysicsLevelComboBox.SelectedIndex = My.Settings.PhysicsLevel
        PhysicsScoreTextBox.Text = My.Settings.PhysicsScore

        HistoryLevelComboBox.SelectedIndex = My.Settings.HistoryLevel
        HistoryScoreTextBox.Text = My.Settings.HistoryScore

        ITLevelComboBox.SelectedIndex = My.Settings.ITEnglishWritingLevel
        ITScoreTextBox.Text = My.Settings.ITEnglishWritingScore

        ChemistryLevelComboBox.SelectedIndex = My.Settings.ChemistryLevel
        ChemistryScoreTextBox.Text = My.Settings.ChemistryScore
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
        If PhysicsLevelComboBox.SelectedItem = "H" Then
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

    Private Sub GeographyLevelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITLevelComboBox.SelectedIndexChanged
        GeographyExtraGPA = 0
        If ITLevelComboBox.SelectedItem = "S+" Then
            GeographyExtraGPA = 0.15
        ElseIf ITLevelComboBox.SelectedItem = "H" Then
            GeographyExtraGPA = 0.3
        End If
    End Sub

    Private Sub BiologyLevelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChemistryLevelComboBox.SelectedIndexChanged
        BiologyExtraGPA = 0
        If ChemistryLevelComboBox.SelectedItem = "H" Then
            BiologyExtraGPA = 0.3
        End If
    End Sub

    Private Sub ChineseScoreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ChineseScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub EnglishScoreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EnglishScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub MathScoreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MathScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub PhysicsScoreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PhysicsScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub HistoryScoreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles HistoryScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GeographyScoreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ITScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BiologyScoreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ChemistryScoreTextBox.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ChineseScoreTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChineseScoreTextBox.TextChanged
        If Val(ChineseScoreTextBox.Text) > 100 Then
            ChineseScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub EnglishScoreTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnglishScoreTextBox.TextChanged
        If Val(EnglishScoreTextBox.Text) > 100 Then
            EnglishScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub MathScoreTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MathScoreTextBox.TextChanged
        If Val(MathScoreTextBox.Text) > 100 Then
            MathScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub PhysicsScoreTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhysicsScoreTextBox.TextChanged
        If Val(PhysicsScoreTextBox.Text) > 100 Then
            PhysicsScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub HistoryScoreTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryScoreTextBox.TextChanged
        If Val(HistoryScoreTextBox.Text) > 100 Then
            HistoryScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub ITEnglishWritingScoreTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITScoreTextBox.TextChanged
        If Val(ITScoreTextBox.Text) > 100 Then
            ITScoreTextBox.Text = 100
        End If
    End Sub

    Private Sub ChemistryScoreTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChemistryScoreTextBox.TextChanged
        If Val(ChemistryScoreTextBox.Text) > 100 Then
            ChemistryScoreTextBox.Text = 100
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
        CalculateSubjectGPA(Val(ITScoreTextBox.Text))
        If Val(ITScoreTextBox.Text) >= 60 Then
            ITEnglishWritingGPA = SubjectGPA + ITEnglishWritingExtraGPA
        ElseIf Val(ITScoreTextBox.Text) < 60 Then
            ITEnglishWritingGPA = SubjectGPA
        End If
        CalculateSubjectGPA(Val(ChemistryScoreTextBox.Text))
        If Val(ChemistryScoreTextBox.Text) >= 60 Then
            ChemistryGPA = SubjectGPA + ChemistryExtraGPA
        ElseIf Val(ChemistryScoreTextBox.Text) < 60 Then
            ChemistryGPA = SubjectGPA
        End If
        FinalGPA = ((ChineseGPA * 5) + (EnglishGPA * 7) + (MathGPA * 7) + (PhysicsGPA * 3) + (HistoryGPA * 2) + (GeographyGPA * 2) + (BiologyGPA * 3)) / 29
    End Sub

    Private Sub CalculateGPA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculateGPA.Click
        If EnglishScoreTextBox.Text = "" Or ChineseScoreTextBox.Text = "" Or MathScoreTextBox.Text = "" Or HistoryScoreTextBox.Text = "" Or ITScoreTextBox.Text = "" Or PhysicsScoreTextBox.Text = "" Or ChemistryScoreTextBox.Text = "" Then
            If My.Settings.ApplicationLanguage = 0 Then
                MsgBox("Please enter all of your scores!", MsgBoxStyle.Exclamation)
            ElseIf My.Settings.ApplicationLanguage = 0 Then
                MsgBox("请输入你所有的成绩!", MsgBoxStyle.Exclamation)
            End If
        Else
            CalculateFinalGPA()
            MsgBox(FinalGPA, MsgBoxStyle.Information, "EzGPA")
            If My.Settings.ApplicationLanguage = 0 Then
                Dim CopyGPA = MsgBox("Do you want to copy your GPA to the clipboard?", MessageBoxButtons.YesNo + MessageBoxIcon.Question)
                If CopyGPA = MsgBoxResult.Yes Then
                    Clipboard.Clear()
                    On Error Resume Next
                    Clipboard.SetText(FinalGPA)
                    On Error Resume Next
                    MsgBox("Your GPA has successfully been copied to the clipboard.", MsgBoxStyle.Information)
                End If
            ElseIf My.Settings.ApplicationLanguage = 1 Then
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
        If My.Settings.ApplicationLanguage = 0 Then
            MsgBox("EzGPA v1.3" & Environment.NewLine & "Copyright © 2011 Andrew Sun <crossbowffs@live.com>" & Environment.NewLine & Environment.NewLine & "v1.3 changelog: Updated for 9th grade. For 8th grade, use v1.2.", MsgBoxStyle.Information)
        ElseIf My.Settings.ApplicationLanguage = 1 Then
            MsgBox("EzGPA v1.3" & Environment.NewLine & "版权所有 © 2011 Andrew Sun <crossbowffs@live.com>" & Environment.NewLine & Environment.NewLine & "v1.2 更新日志: THE GAME! (you found the hidden text lol)", MsgBoxStyle.Information)
        End If

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.ChineseNative = ChineseNativeComboBox.SelectedIndex
        My.Settings.ChineseLevel = ChineseLevelComboBox.SelectedIndex
        My.Settings.ChineseScore = Val(ChineseScoreTextBox.Text)

        My.Settings.EnglishNative = EnglishNativeComboBox.SelectedIndex
        My.Settings.EnglishLevel = EnglishLevelComboBox.SelectedIndex
        My.Settings.EnglishScore = Val(EnglishScoreTextBox.Text)

        My.Settings.MathLevel = MathLevelComboBox.SelectedIndex
        My.Settings.MathScore = Val(MathScoreTextBox.Text)

        My.Settings.HistoryLevel = HistoryLevelComboBox.SelectedIndex
        My.Settings.HistoryScore = Val(HistoryScoreTextBox.Text)

        My.Settings.ITEnglishWritingLevel = ITLevelComboBox.SelectedIndex
        My.Settings.ITEnglishWritingScore = Val(ITScoreTextBox.Text)

        My.Settings.PhysicsLevel = PhysicsLevelComboBox.SelectedIndex
        My.Settings.PhysicsScore = Val(PhysicsScoreTextBox.Text)

        My.Settings.ChemistryLevel = ChemistryLevelComboBox.SelectedIndex
        My.Settings.ChemistryScore = Val(ChemistryScoreTextBox.Text)
    End Sub
End Class