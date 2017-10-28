VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "EzGPA v1.4 (VB6 Edition)"
   ClientHeight    =   4215
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   5055
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   ScaleHeight     =   4215
   ScaleWidth      =   5055
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   1680
      Top             =   1680
   End
   Begin VB.CommandButton CopyGPAButton 
      Caption         =   "Copy"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   3720
      TabIndex        =   23
      Top             =   3600
      Width           =   1095
   End
   Begin VB.TextBox ITEnglishWritingScoreTextBox 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   4320
      TabIndex        =   21
      Text            =   "100"
      Top             =   3120
      Width           =   495
   End
   Begin VB.TextBox ChemistryScoreTextBox 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   4320
      TabIndex        =   20
      Text            =   "100"
      Top             =   2640
      Width           =   495
   End
   Begin VB.TextBox HistoryScoreTextBox 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   4320
      TabIndex        =   19
      Text            =   "100"
      Top             =   2160
      Width           =   495
   End
   Begin VB.TextBox PhysicsScoreTextBox 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   4320
      TabIndex        =   18
      Text            =   "100"
      Top             =   1680
      Width           =   495
   End
   Begin VB.TextBox MathScoreTextBox 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   4320
      MaxLength       =   3
      TabIndex        =   17
      Text            =   "100"
      Top             =   1200
      Width           =   495
   End
   Begin VB.TextBox EnglishScoreTextBox 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   4320
      MaxLength       =   3
      TabIndex        =   16
      Text            =   "100"
      Top             =   720
      Width           =   495
   End
   Begin VB.ComboBox ChemistryLevelComboBox 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "Form1.frx":0000
      Left            =   2760
      List            =   "Form1.frx":000D
      Style           =   2  'Dropdown List
      TabIndex        =   15
      Top             =   2640
      Width           =   1455
   End
   Begin VB.ComboBox HistoryLevelComboBox 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "Form1.frx":001B
      Left            =   2760
      List            =   "Form1.frx":0028
      Style           =   2  'Dropdown List
      TabIndex        =   14
      Top             =   2160
      Width           =   1455
   End
   Begin VB.ComboBox EnglishLevelComboBox 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   2760
      Style           =   2  'Dropdown List
      TabIndex        =   13
      Top             =   720
      Width           =   1455
   End
   Begin VB.ComboBox ChineseLevelComboBox 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   2760
      Style           =   2  'Dropdown List
      TabIndex        =   12
      Top             =   240
      Width           =   1455
   End
   Begin VB.TextBox ChineseScoreTextBox 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   4320
      MaxLength       =   3
      TabIndex        =   11
      Text            =   "100"
      Top             =   240
      Width           =   495
   End
   Begin VB.ComboBox PhysicsLevelComboBox 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "Form1.frx":0036
      Left            =   2760
      List            =   "Form1.frx":0043
      Style           =   2  'Dropdown List
      TabIndex        =   10
      Top             =   1680
      Width           =   1455
   End
   Begin VB.ComboBox MathLevelComboBox 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "Form1.frx":0051
      Left            =   2760
      List            =   "Form1.frx":005E
      Style           =   2  'Dropdown List
      TabIndex        =   9
      Top             =   1200
      Width           =   1455
   End
   Begin VB.ComboBox EnglishNativeComboBox 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "Form1.frx":006C
      Left            =   1200
      List            =   "Form1.frx":0076
      Style           =   2  'Dropdown List
      TabIndex        =   8
      Top             =   720
      Width           =   1455
   End
   Begin VB.ComboBox ChineseNativeComboBox 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "Form1.frx":008E
      Left            =   1200
      List            =   "Form1.frx":0098
      Style           =   2  'Dropdown List
      TabIndex        =   7
      Top             =   240
      Width           =   1455
   End
   Begin VB.Label Label9 
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   11.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   1680
      TabIndex        =   24
      Top             =   3720
      Width           =   1935
   End
   Begin VB.Label Label8 
      Caption         =   "Your GPA is:"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   22
      Top             =   3720
      Width           =   1335
   End
   Begin VB.Label Label7 
      Caption         =   "IT/English Writing"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   6
      Top             =   3120
      Width           =   1575
   End
   Begin VB.Label Label6 
      Caption         =   "Chemistry"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   5
      Top             =   2640
      Width           =   975
   End
   Begin VB.Label Label5 
      Caption         =   "History"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   4
      Top             =   2160
      Width           =   735
   End
   Begin VB.Label Label4 
      Caption         =   "Physics"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   3
      Top             =   1680
      Width           =   735
   End
   Begin VB.Label Label3 
      Caption         =   "Math"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   2
      Top             =   1200
      Width           =   495
   End
   Begin VB.Label Label2 
      Caption         =   "English"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   1
      Top             =   720
      Width           =   735
   End
   Begin VB.Label Label1 
      Caption         =   "Chinese"
      BeginProperty Font 
         Name            =   "Candara"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   255
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
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

Private Sub Form_Load()
        ChineseNativeComboBox.ListIndex = 0
        ChineseLevelComboBox.ListIndex = 0
        EnglishNativeComboBox.ListIndex = 0
        EnglishLevelComboBox.ListIndex = 0
        MathLevelComboBox.ListIndex = 0
        PhysicsLevelComboBox.ListIndex = 0
        HistoryLevelComboBox.ListIndex = 0
        ChemistryLevelComboBox.ListIndex = 0
End Sub

Private Sub ChineseNativeComboBox_Click()
        If ChineseNativeComboBox.Text = "Native" Then
            ChineseNative = True
            ChineseLevelComboBox.Clear
            ChineseLevelComboBox.AddItem "S"
            ChineseLevelComboBox.AddItem "H"
       ElseIf ChineseNativeComboBox.Text = "Non-Native" Then
            ChineseNative = False
            ChineseLevelComboBox.Clear
            ChineseLevelComboBox.AddItem "入门、初级"
            ChineseLevelComboBox.AddItem "准中级、中级"
            ChineseLevelComboBox.AddItem "读写、高级"
       End If
       ChineseLevelComboBox.ListIndex = 0
End Sub

Private Sub EnglishNativeComboBox_Click()
        If EnglishNativeComboBox.Text = "Native" Then
            EnglishNative = True
            EnglishLevelComboBox.Clear
            EnglishLevelComboBox.AddItem "H"
            EnglishLevelComboBox.AddItem "H+"
        ElseIf EnglishNativeComboBox.Text = "Non-Native" Then
            EnglishNative = False
            EnglishLevelComboBox.Clear
            EnglishLevelComboBox.AddItem "S"
            EnglishLevelComboBox.AddItem "S+"
        End If
        EnglishLevelComboBox.ListIndex = 0
End Sub

Private Sub ChineseScoreTextBox_KeyPress(KeyAscii As Integer)
Select Case KeyAscii
Case 8, 48 To 57
Case Else
KeyAscii = 0
End Select
End Sub

Private Sub EnglishScoreTextBox_KeyPress(KeyAscii As Integer)
Select Case KeyAscii
Case 8, 48 To 57
Case Else
KeyAscii = 0
End Select
End Sub

Private Sub MathScoreTextBox_KeyPress(KeyAscii As Integer)
Select Case KeyAscii
Case 8, 48 To 57
Case Else
KeyAscii = 0
End Select
End Sub
Private Sub PhysicsScoreTextBox_KeyPress(KeyAscii As Integer)
Select Case KeyAscii
Case 8, 48 To 57
Case Else
KeyAscii = 0
End Select
End Sub

Private Sub HistoryScoreTextBox_KeyPress(KeyAscii As Integer)
Select Case KeyAscii
Case 8, 48 To 57
Case Else
KeyAscii = 0
End Select
End Sub

Private Sub ChemistryScoreTextBox_KeyPress(KeyAscii As Integer)
Select Case KeyAscii
Case 8, 48 To 57
Case Else
KeyAscii = 0
End Select
End Sub

Private Sub ITEnglishWritingScoreTextBox_KeyPress(KeyAscii As Integer)
Select Case KeyAscii
Case 8, 48 To 57
Case Else
KeyAscii = 0
End Select
End Sub

Private Sub ChineseScoreTextBox_LostFocus()
        ChineseScoreTextBox.Text = Val(ChineseScoreTextBox.Text)
        If Val(ChineseScoreTextBox.Text) > 100 Then
            ChineseScoreTextBox.Text = 100
        End If
End Sub

Private Sub EnglishScoreTextBox_LostFocus()
EnglishScoreTextBox.Text = Val(EnglishScoreTextBox.Text)
        If Val(EnglishScoreTextBox.Text) > 100 Then
            EnglishScoreTextBox.Text = 100
        End If
End Sub

Private Sub MathScoreTextBox_LostFocus()
MathScoreTextBox.Text = Val(MathScoreTextBox.Text)
        If Val(MathScoreTextBox.Text) > 100 Then
            MathScoreTextBox.Text = 100
        End If
End Sub

Private Sub PhysicsScoreTextBox_LostFocus()
PhysicsScoreTextBox.Text = Val(PhysicsScoreTextBox.Text)
        If Val(PhysicsScoreTextBox.Text) > 100 Then
            PhysicsScoreTextBox.Text = 100
        End If
End Sub

Private Sub HistoryScoreTextBox_LostFocus()
HistoryScoreTextBox.Text = Val(HistoryScoreTextBox.Text)
        If Val(HistoryScoreTextBox.Text) > 100 Then
            HistoryScoreTextBox.Text = 100
        End If
End Sub

Private Sub ChemistryScoreTextBox_LostFocus()
ChemistryScoreTextBox.Text = Val(ChemistryScoreTextBox.Text)
        If Val(ChemistryScoreTextBox.Text) > 100 Then
            ChemistryScoreTextBox.Text = 100
        End If
End Sub

Private Sub ITEnglishWritingScoreTextBox_LostFocus()
ITEnglishWritingScoreTextBox.Text = Val(ITEnglishWritingScoreTextBox.Text)
        If Val(ITEnglishWritingScoreTextBox.Text) > 100 Then
            ITEnglishWritingScoreTextBox.Text = 100
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
        CalculateSubjectGPA (Val(ChineseScoreTextBox.Text))
        If Val(ChineseScoreTextBox.Text) >= 60 Then
            ChineseGPA = SubjectGPA + ChineseExtraGPA
        ElseIf Val(ChineseScoreTextBox.Text) < 60 Then
            ChineseGPA = SubjectGPA
        End If
        CalculateSubjectGPA (Val(EnglishScoreTextBox.Text))
        If Val(EnglishScoreTextBox.Text) >= 60 Then
            EnglishGPA = SubjectGPA + EnglishExtraGPA
        ElseIf Val(EnglishScoreTextBox.Text) < 60 Then
            EnglishGPA = SubjectGPA
        End If
        CalculateSubjectGPA (Val(MathScoreTextBox.Text))
        If Val(MathScoreTextBox.Text) >= 60 Then
            MathGPA = SubjectGPA + MathExtraGPA
        ElseIf Val(MathScoreTextBox.Text) < 60 Then
            MathGPA = SubjectGPA
        End If
        CalculateSubjectGPA (Val(PhysicsScoreTextBox.Text))
        If Val(PhysicsScoreTextBox.Text) >= 60 Then
            PhysicsGPA = SubjectGPA + PhysicsExtraGPA
        ElseIf Val(PhysicsScoreTextBox.Text) < 60 Then
            PhysicsGPA = SubjectGPA
        End If
        CalculateSubjectGPA (Val(HistoryScoreTextBox.Text))
        If Val(HistoryScoreTextBox.Text) >= 60 Then
            HistoryGPA = SubjectGPA + HistoryExtraGPA
        ElseIf Val(HistoryScoreTextBox.Text) < 60 Then
            HistoryGPA = SubjectGPA
        End If
        CalculateSubjectGPA (Val(ITEnglishWritingScoreTextBox.Text))
        ITEnglishWritingGPA = SubjectGPA
        CalculateSubjectGPA (Val(ChemistryScoreTextBox.Text))
        If Val(ChemistryScoreTextBox.Text) >= 60 Then
            ChemistryGPA = SubjectGPA + ChemistryExtraGPA
        ElseIf Val(ChemistryScoreTextBox.Text) < 60 Then
            ChemistryGPA = SubjectGPA
        End If
        FinalGPA = ((ChineseGPA * 4.5) + (EnglishGPA * 7.5) + (MathGPA * 7) + (PhysicsGPA * 4) + (HistoryGPA * 3.5) + (ITEnglishWritingGPA * 1.5) + (ChemistryGPA * 3)) / 31
    End Sub
    
    Private Sub CopyGPAButton_Click()
    CalculateFinalGPA
        Clipboard.Clear
        On Error Resume Next
        Clipboard.SetText (FinalGPA)
        On Error Resume Next
        MsgBox "Your GPA has successfully been copied to the clipboard.", vbInformation
    End Sub

Private Sub Timer1_Timer()
        ChineseExtraGPA = 0
        If ChineseNative = True Then
            If ChineseLevelComboBox.Text = "S" Then
                ChineseExtraGPA = 0.3
            ElseIf ChineseLevelComboBox.Text = "H" Then
                ChineseExtraGPA = 0.4
            End If
        ElseIf ChineseNative = False Then
            If ChineseLevelComboBox.Text = "准中级、中级" Then
                ChineseExtraGPA = 0.1
            ElseIf ChineseLevelComboBox.Text = "读写、高级" Then
                ChineseExtraGPA = 0.2
            End If
        End If
        
        EnglishExtraGPA = 0
        If EnglishNative = True Then
            If EnglishLevelComboBox.Text = "H" Then
                EnglishExtraGPA = 0.3
            ElseIf EnglishLevelComboBox.Text = "H+" Then
                EnglishExtraGPA = 0.4
            End If
        ElseIf EnglishNative = False Then
            If EnglishLevelComboBox.Text = "S+" Then
                EnglishExtraGPA = 0.2
            End If
        End If

        MathExtraGPA = 0
        If MathLevelComboBox.Text = "S+" Then
            MathExtraGPA = 0.15
        ElseIf MathLevelComboBox.Text = "H" Then
            MathExtraGPA = 0.3
        End If

        PhysicsExtraGPA = 0
        If PhysicsLevelComboBox.Text = "S+" Then
            PhysicsExtraGPA = 0.15
        ElseIf PhysicsLevelComboBox.Text = "H" Then
            PhysicsExtraGPA = 0.3
        End If

        HistoryExtraGPA = 0
        If HistoryLevelComboBox.Text = "S+" Then
            HistoryExtraGPA = 0.15
        ElseIf HistoryLevelComboBox.Text = "H" Then
            HistoryExtraGPA = 0.3
        End If

        ChemistryExtraGPA = 0
        If ChemistryLevelComboBox.Text = "S+" Then
            ChemistryExtraGPA = 0.15
        ElseIf ChemistryLevelComboBox.Text = "H" Then
            ChemistryExtraGPA = 0.3
        End If
        CalculateFinalGPA
        Label9.Caption = FinalGPA
End Sub
