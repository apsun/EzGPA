namespace EzGPA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.G9_OptionalLabel = new System.Windows.Forms.Label();
            this.G9_ChemistryLabel = new System.Windows.Forms.Label();
            this.G9_HistoryLabel = new System.Windows.Forms.Label();
            this.G9_PhysicsLabel = new System.Windows.Forms.Label();
            this.G9_MathLabel = new System.Windows.Forms.Label();
            this.G9_EnglishLabel = new System.Windows.Forms.Label();
            this.G9_ChineseLabel = new System.Windows.Forms.Label();
            this.G9_OptionalScoreTextBox = new System.Windows.Forms.TextBox();
            this.G9_ChemistryScoreTextBox = new System.Windows.Forms.TextBox();
            this.G9_HistoryScoreTextBox = new System.Windows.Forms.TextBox();
            this.G9_PhysicsScoreTextBox = new System.Windows.Forms.TextBox();
            this.G9_MathScoreTextBox = new System.Windows.Forms.TextBox();
            this.G9_EnglishScoreTextBox = new System.Windows.Forms.TextBox();
            this.G9_ChineseScoreTextBox = new System.Windows.Forms.TextBox();
            this.G9_ChemistryLevelComboBox = new System.Windows.Forms.ComboBox();
            this.G9_HistoryLevelComboBox = new System.Windows.Forms.ComboBox();
            this.G9_PhysicsLevelComboBox = new System.Windows.Forms.ComboBox();
            this.G9_MathLevelComboBox = new System.Windows.Forms.ComboBox();
            this.G9_EnglishLevelComboBox = new System.Windows.Forms.ComboBox();
            this.G9_ChineseLevelComboBox = new System.Windows.Forms.ComboBox();
            this.G9_EnglishNativeComboBox = new System.Windows.Forms.ComboBox();
            this.G9_ChineseNativeComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GPALabel = new System.Windows.Forms.Label();
            this.CopyGPAButton = new System.Windows.Forms.Button();
            this.AboutButton = new System.Windows.Forms.Button();
            this.SaveScoresCheckBox = new System.Windows.Forms.CheckBox();
            this.AutoClearCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 220);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.G9_OptionalLabel);
            this.tabPage1.Controls.Add(this.G9_ChemistryLabel);
            this.tabPage1.Controls.Add(this.G9_HistoryLabel);
            this.tabPage1.Controls.Add(this.G9_PhysicsLabel);
            this.tabPage1.Controls.Add(this.G9_MathLabel);
            this.tabPage1.Controls.Add(this.G9_EnglishLabel);
            this.tabPage1.Controls.Add(this.G9_ChineseLabel);
            this.tabPage1.Controls.Add(this.G9_OptionalScoreTextBox);
            this.tabPage1.Controls.Add(this.G9_ChemistryScoreTextBox);
            this.tabPage1.Controls.Add(this.G9_HistoryScoreTextBox);
            this.tabPage1.Controls.Add(this.G9_PhysicsScoreTextBox);
            this.tabPage1.Controls.Add(this.G9_MathScoreTextBox);
            this.tabPage1.Controls.Add(this.G9_EnglishScoreTextBox);
            this.tabPage1.Controls.Add(this.G9_ChineseScoreTextBox);
            this.tabPage1.Controls.Add(this.G9_ChemistryLevelComboBox);
            this.tabPage1.Controls.Add(this.G9_HistoryLevelComboBox);
            this.tabPage1.Controls.Add(this.G9_PhysicsLevelComboBox);
            this.tabPage1.Controls.Add(this.G9_MathLevelComboBox);
            this.tabPage1.Controls.Add(this.G9_EnglishLevelComboBox);
            this.tabPage1.Controls.Add(this.G9_ChineseLevelComboBox);
            this.tabPage1.Controls.Add(this.G9_EnglishNativeComboBox);
            this.tabPage1.Controls.Add(this.G9_ChineseNativeComboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(292, 194);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Grade 9";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // G9_OptionalLabel
            // 
            this.G9_OptionalLabel.AutoSize = true;
            this.G9_OptionalLabel.Location = new System.Drawing.Point(6, 171);
            this.G9_OptionalLabel.Name = "G9_OptionalLabel";
            this.G9_OptionalLabel.Size = new System.Drawing.Size(140, 13);
            this.G9_OptionalLabel.TabIndex = 22;
            this.G9_OptionalLabel.Text = "Optional (IT/English Writing)";
            // 
            // G9_ChemistryLabel
            // 
            this.G9_ChemistryLabel.AutoSize = true;
            this.G9_ChemistryLabel.Location = new System.Drawing.Point(6, 144);
            this.G9_ChemistryLabel.Name = "G9_ChemistryLabel";
            this.G9_ChemistryLabel.Size = new System.Drawing.Size(52, 13);
            this.G9_ChemistryLabel.TabIndex = 21;
            this.G9_ChemistryLabel.Text = "Chemistry";
            // 
            // G9_HistoryLabel
            // 
            this.G9_HistoryLabel.AutoSize = true;
            this.G9_HistoryLabel.Location = new System.Drawing.Point(6, 117);
            this.G9_HistoryLabel.Name = "G9_HistoryLabel";
            this.G9_HistoryLabel.Size = new System.Drawing.Size(39, 13);
            this.G9_HistoryLabel.TabIndex = 20;
            this.G9_HistoryLabel.Text = "History";
            // 
            // G9_PhysicsLabel
            // 
            this.G9_PhysicsLabel.AutoSize = true;
            this.G9_PhysicsLabel.Location = new System.Drawing.Point(6, 90);
            this.G9_PhysicsLabel.Name = "G9_PhysicsLabel";
            this.G9_PhysicsLabel.Size = new System.Drawing.Size(43, 13);
            this.G9_PhysicsLabel.TabIndex = 19;
            this.G9_PhysicsLabel.Text = "Physics";
            // 
            // G9_MathLabel
            // 
            this.G9_MathLabel.AutoSize = true;
            this.G9_MathLabel.Location = new System.Drawing.Point(6, 63);
            this.G9_MathLabel.Name = "G9_MathLabel";
            this.G9_MathLabel.Size = new System.Drawing.Size(31, 13);
            this.G9_MathLabel.TabIndex = 18;
            this.G9_MathLabel.Text = "Math";
            // 
            // G9_EnglishLabel
            // 
            this.G9_EnglishLabel.AutoSize = true;
            this.G9_EnglishLabel.Location = new System.Drawing.Point(6, 36);
            this.G9_EnglishLabel.Name = "G9_EnglishLabel";
            this.G9_EnglishLabel.Size = new System.Drawing.Size(41, 13);
            this.G9_EnglishLabel.TabIndex = 17;
            this.G9_EnglishLabel.Text = "English";
            // 
            // G9_ChineseLabel
            // 
            this.G9_ChineseLabel.AutoSize = true;
            this.G9_ChineseLabel.Location = new System.Drawing.Point(6, 9);
            this.G9_ChineseLabel.Name = "G9_ChineseLabel";
            this.G9_ChineseLabel.Size = new System.Drawing.Size(45, 13);
            this.G9_ChineseLabel.TabIndex = 16;
            this.G9_ChineseLabel.Text = "Chinese";
            // 
            // G9_OptionalScoreTextBox
            // 
            this.G9_OptionalScoreTextBox.Location = new System.Drawing.Point(261, 168);
            this.G9_OptionalScoreTextBox.MaxLength = 3;
            this.G9_OptionalScoreTextBox.Name = "G9_OptionalScoreTextBox";
            this.G9_OptionalScoreTextBox.ShortcutsEnabled = false;
            this.G9_OptionalScoreTextBox.Size = new System.Drawing.Size(25, 20);
            this.G9_OptionalScoreTextBox.TabIndex = 15;
            this.G9_OptionalScoreTextBox.TabStop = false;
            this.G9_OptionalScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.G9_OptionalScoreTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.G9_OptionalScoreTextBox.GotFocus += new System.EventHandler(this.TextBox_GotFocus);
            this.G9_OptionalScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.G9_OptionalScoreTextBox.LostFocus += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // G9_ChemistryScoreTextBox
            // 
            this.G9_ChemistryScoreTextBox.Location = new System.Drawing.Point(261, 141);
            this.G9_ChemistryScoreTextBox.MaxLength = 3;
            this.G9_ChemistryScoreTextBox.Name = "G9_ChemistryScoreTextBox";
            this.G9_ChemistryScoreTextBox.ShortcutsEnabled = false;
            this.G9_ChemistryScoreTextBox.Size = new System.Drawing.Size(25, 20);
            this.G9_ChemistryScoreTextBox.TabIndex = 14;
            this.G9_ChemistryScoreTextBox.TabStop = false;
            this.G9_ChemistryScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.G9_ChemistryScoreTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.G9_ChemistryScoreTextBox.GotFocus += new System.EventHandler(this.TextBox_GotFocus);
            this.G9_ChemistryScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.G9_ChemistryScoreTextBox.LostFocus += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // G9_HistoryScoreTextBox
            // 
            this.G9_HistoryScoreTextBox.Location = new System.Drawing.Point(261, 114);
            this.G9_HistoryScoreTextBox.MaxLength = 3;
            this.G9_HistoryScoreTextBox.Name = "G9_HistoryScoreTextBox";
            this.G9_HistoryScoreTextBox.ShortcutsEnabled = false;
            this.G9_HistoryScoreTextBox.Size = new System.Drawing.Size(25, 20);
            this.G9_HistoryScoreTextBox.TabIndex = 13;
            this.G9_HistoryScoreTextBox.TabStop = false;
            this.G9_HistoryScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.G9_HistoryScoreTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.G9_HistoryScoreTextBox.GotFocus += new System.EventHandler(this.TextBox_GotFocus);
            this.G9_HistoryScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.G9_HistoryScoreTextBox.LostFocus += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // G9_PhysicsScoreTextBox
            // 
            this.G9_PhysicsScoreTextBox.Location = new System.Drawing.Point(261, 87);
            this.G9_PhysicsScoreTextBox.MaxLength = 3;
            this.G9_PhysicsScoreTextBox.Name = "G9_PhysicsScoreTextBox";
            this.G9_PhysicsScoreTextBox.ShortcutsEnabled = false;
            this.G9_PhysicsScoreTextBox.Size = new System.Drawing.Size(25, 20);
            this.G9_PhysicsScoreTextBox.TabIndex = 12;
            this.G9_PhysicsScoreTextBox.TabStop = false;
            this.G9_PhysicsScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.G9_PhysicsScoreTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.G9_PhysicsScoreTextBox.GotFocus += new System.EventHandler(this.TextBox_GotFocus);
            this.G9_PhysicsScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.G9_PhysicsScoreTextBox.LostFocus += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // G9_MathScoreTextBox
            // 
            this.G9_MathScoreTextBox.Location = new System.Drawing.Point(261, 60);
            this.G9_MathScoreTextBox.MaxLength = 3;
            this.G9_MathScoreTextBox.Name = "G9_MathScoreTextBox";
            this.G9_MathScoreTextBox.ShortcutsEnabled = false;
            this.G9_MathScoreTextBox.Size = new System.Drawing.Size(25, 20);
            this.G9_MathScoreTextBox.TabIndex = 11;
            this.G9_MathScoreTextBox.TabStop = false;
            this.G9_MathScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.G9_MathScoreTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.G9_MathScoreTextBox.GotFocus += new System.EventHandler(this.TextBox_GotFocus);
            this.G9_MathScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.G9_MathScoreTextBox.LostFocus += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // G9_EnglishScoreTextBox
            // 
            this.G9_EnglishScoreTextBox.Location = new System.Drawing.Point(261, 33);
            this.G9_EnglishScoreTextBox.MaxLength = 3;
            this.G9_EnglishScoreTextBox.Name = "G9_EnglishScoreTextBox";
            this.G9_EnglishScoreTextBox.ShortcutsEnabled = false;
            this.G9_EnglishScoreTextBox.Size = new System.Drawing.Size(25, 20);
            this.G9_EnglishScoreTextBox.TabIndex = 10;
            this.G9_EnglishScoreTextBox.TabStop = false;
            this.G9_EnglishScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.G9_EnglishScoreTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.G9_EnglishScoreTextBox.GotFocus += new System.EventHandler(this.TextBox_GotFocus);
            this.G9_EnglishScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.G9_EnglishScoreTextBox.LostFocus += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // G9_ChineseScoreTextBox
            // 
            this.G9_ChineseScoreTextBox.Location = new System.Drawing.Point(261, 6);
            this.G9_ChineseScoreTextBox.MaxLength = 3;
            this.G9_ChineseScoreTextBox.Name = "G9_ChineseScoreTextBox";
            this.G9_ChineseScoreTextBox.ShortcutsEnabled = false;
            this.G9_ChineseScoreTextBox.Size = new System.Drawing.Size(25, 20);
            this.G9_ChineseScoreTextBox.TabIndex = 9;
            this.G9_ChineseScoreTextBox.TabStop = false;
            this.G9_ChineseScoreTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.G9_ChineseScoreTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.G9_ChineseScoreTextBox.GotFocus += new System.EventHandler(this.TextBox_GotFocus);
            this.G9_ChineseScoreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.G9_ChineseScoreTextBox.LostFocus += new System.EventHandler(this.TextBox_LostFocus);
            // 
            // G9_ChemistryLevelComboBox
            // 
            this.G9_ChemistryLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.G9_ChemistryLevelComboBox.FormattingEnabled = true;
            this.G9_ChemistryLevelComboBox.Items.AddRange(new object[] {
            "S",
            "S+",
            "H"});
            this.G9_ChemistryLevelComboBox.Location = new System.Drawing.Point(165, 141);
            this.G9_ChemistryLevelComboBox.Name = "G9_ChemistryLevelComboBox";
            this.G9_ChemistryLevelComboBox.Size = new System.Drawing.Size(90, 21);
            this.G9_ChemistryLevelComboBox.TabIndex = 7;
            this.G9_ChemistryLevelComboBox.TabStop = false;
            // 
            // G9_HistoryLevelComboBox
            // 
            this.G9_HistoryLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.G9_HistoryLevelComboBox.FormattingEnabled = true;
            this.G9_HistoryLevelComboBox.Items.AddRange(new object[] {
            "S",
            "S+",
            "H"});
            this.G9_HistoryLevelComboBox.Location = new System.Drawing.Point(165, 114);
            this.G9_HistoryLevelComboBox.Name = "G9_HistoryLevelComboBox";
            this.G9_HistoryLevelComboBox.Size = new System.Drawing.Size(90, 21);
            this.G9_HistoryLevelComboBox.TabIndex = 6;
            this.G9_HistoryLevelComboBox.TabStop = false;
            // 
            // G9_PhysicsLevelComboBox
            // 
            this.G9_PhysicsLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.G9_PhysicsLevelComboBox.FormattingEnabled = true;
            this.G9_PhysicsLevelComboBox.Items.AddRange(new object[] {
            "S",
            "S+",
            "H"});
            this.G9_PhysicsLevelComboBox.Location = new System.Drawing.Point(165, 87);
            this.G9_PhysicsLevelComboBox.Name = "G9_PhysicsLevelComboBox";
            this.G9_PhysicsLevelComboBox.Size = new System.Drawing.Size(90, 21);
            this.G9_PhysicsLevelComboBox.TabIndex = 5;
            this.G9_PhysicsLevelComboBox.TabStop = false;
            // 
            // G9_MathLevelComboBox
            // 
            this.G9_MathLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.G9_MathLevelComboBox.FormattingEnabled = true;
            this.G9_MathLevelComboBox.Items.AddRange(new object[] {
            "S",
            "S+",
            "H"});
            this.G9_MathLevelComboBox.Location = new System.Drawing.Point(165, 60);
            this.G9_MathLevelComboBox.Name = "G9_MathLevelComboBox";
            this.G9_MathLevelComboBox.Size = new System.Drawing.Size(90, 21);
            this.G9_MathLevelComboBox.TabIndex = 4;
            this.G9_MathLevelComboBox.TabStop = false;
            // 
            // G9_EnglishLevelComboBox
            // 
            this.G9_EnglishLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.G9_EnglishLevelComboBox.FormattingEnabled = true;
            this.G9_EnglishLevelComboBox.Location = new System.Drawing.Point(165, 33);
            this.G9_EnglishLevelComboBox.Name = "G9_EnglishLevelComboBox";
            this.G9_EnglishLevelComboBox.Size = new System.Drawing.Size(90, 21);
            this.G9_EnglishLevelComboBox.TabIndex = 3;
            this.G9_EnglishLevelComboBox.TabStop = false;
            // 
            // G9_ChineseLevelComboBox
            // 
            this.G9_ChineseLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.G9_ChineseLevelComboBox.FormattingEnabled = true;
            this.G9_ChineseLevelComboBox.Location = new System.Drawing.Point(165, 6);
            this.G9_ChineseLevelComboBox.Name = "G9_ChineseLevelComboBox";
            this.G9_ChineseLevelComboBox.Size = new System.Drawing.Size(90, 21);
            this.G9_ChineseLevelComboBox.TabIndex = 2;
            this.G9_ChineseLevelComboBox.TabStop = false;
            // 
            // G9_EnglishNativeComboBox
            // 
            this.G9_EnglishNativeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.G9_EnglishNativeComboBox.FormattingEnabled = true;
            this.G9_EnglishNativeComboBox.Items.AddRange(new object[] {
            "Native",
            "Non-Native"});
            this.G9_EnglishNativeComboBox.Location = new System.Drawing.Point(79, 33);
            this.G9_EnglishNativeComboBox.Name = "G9_EnglishNativeComboBox";
            this.G9_EnglishNativeComboBox.Size = new System.Drawing.Size(80, 21);
            this.G9_EnglishNativeComboBox.TabIndex = 1;
            this.G9_EnglishNativeComboBox.TabStop = false;
            this.G9_EnglishNativeComboBox.SelectedIndexChanged += new System.EventHandler(this.G9_EnglishNativeComboBox_SelectedIndexChanged);
            // 
            // G9_ChineseNativeComboBox
            // 
            this.G9_ChineseNativeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.G9_ChineseNativeComboBox.FormattingEnabled = true;
            this.G9_ChineseNativeComboBox.Items.AddRange(new object[] {
            "Native",
            "Non-Native"});
            this.G9_ChineseNativeComboBox.Location = new System.Drawing.Point(79, 6);
            this.G9_ChineseNativeComboBox.Name = "G9_ChineseNativeComboBox";
            this.G9_ChineseNativeComboBox.Size = new System.Drawing.Size(80, 21);
            this.G9_ChineseNativeComboBox.TabIndex = 0;
            this.G9_ChineseNativeComboBox.TabStop = false;
            this.G9_ChineseNativeComboBox.SelectedIndexChanged += new System.EventHandler(this.G9_ChineseNativeComboBox_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(292, 194);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grade 10";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GPALabel
            // 
            this.GPALabel.AutoSize = true;
            this.GPALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPALabel.Location = new System.Drawing.Point(12, 235);
            this.GPALabel.Name = "GPALabel";
            this.GPALabel.Size = new System.Drawing.Size(122, 16);
            this.GPALabel.TabIndex = 1;
            this.GPALabel.Text = "Your GPA is: [GPA]";
            // 
            // CopyGPAButton
            // 
            this.CopyGPAButton.Location = new System.Drawing.Point(12, 255);
            this.CopyGPAButton.Name = "CopyGPAButton";
            this.CopyGPAButton.Size = new System.Drawing.Size(147, 23);
            this.CopyGPAButton.TabIndex = 2;
            this.CopyGPAButton.Text = "Copy to clipboard";
            this.CopyGPAButton.UseVisualStyleBackColor = true;
            this.CopyGPAButton.Click += new System.EventHandler(this.CopyGPAButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(165, 255);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(147, 23);
            this.AboutButton.TabIndex = 3;
            this.AboutButton.Text = "About EzGPA";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // SaveScoresCheckBox
            // 
            this.SaveScoresCheckBox.AutoSize = true;
            this.SaveScoresCheckBox.Location = new System.Drawing.Point(12, 285);
            this.SaveScoresCheckBox.Name = "SaveScoresCheckBox";
            this.SaveScoresCheckBox.Size = new System.Drawing.Size(172, 17);
            this.SaveScoresCheckBox.TabIndex = 4;
            this.SaveScoresCheckBox.Text = "Save scores between sessions";
            this.SaveScoresCheckBox.UseVisualStyleBackColor = true;
            // 
            // AutoClearCheckBox
            // 
            this.AutoClearCheckBox.AutoSize = true;
            this.AutoClearCheckBox.Location = new System.Drawing.Point(12, 308);
            this.AutoClearCheckBox.Name = "AutoClearCheckBox";
            this.AutoClearCheckBox.Size = new System.Drawing.Size(214, 17);
            this.AutoClearCheckBox.TabIndex = 5;
            this.AutoClearCheckBox.Text = "Automatically clear scores when clicked";
            this.AutoClearCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 337);
            this.Controls.Add(this.AutoClearCheckBox);
            this.Controls.Add(this.SaveScoresCheckBox);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.CopyGPAButton);
            this.Controls.Add(this.GPALabel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EzGPA";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox G9_OptionalScoreTextBox;
        private System.Windows.Forms.TextBox G9_ChemistryScoreTextBox;
        private System.Windows.Forms.TextBox G9_HistoryScoreTextBox;
        private System.Windows.Forms.TextBox G9_PhysicsScoreTextBox;
        private System.Windows.Forms.TextBox G9_MathScoreTextBox;
        private System.Windows.Forms.TextBox G9_EnglishScoreTextBox;
        private System.Windows.Forms.TextBox G9_ChineseScoreTextBox;
        private System.Windows.Forms.ComboBox G9_ChemistryLevelComboBox;
        private System.Windows.Forms.ComboBox G9_HistoryLevelComboBox;
        private System.Windows.Forms.ComboBox G9_PhysicsLevelComboBox;
        private System.Windows.Forms.ComboBox G9_MathLevelComboBox;
        private System.Windows.Forms.ComboBox G9_EnglishLevelComboBox;
        private System.Windows.Forms.ComboBox G9_ChineseLevelComboBox;
        private System.Windows.Forms.ComboBox G9_EnglishNativeComboBox;
        private System.Windows.Forms.ComboBox G9_ChineseNativeComboBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label G9_OptionalLabel;
        private System.Windows.Forms.Label G9_ChemistryLabel;
        private System.Windows.Forms.Label G9_HistoryLabel;
        private System.Windows.Forms.Label G9_PhysicsLabel;
        private System.Windows.Forms.Label G9_MathLabel;
        private System.Windows.Forms.Label G9_EnglishLabel;
        private System.Windows.Forms.Label G9_ChineseLabel;
        private System.Windows.Forms.Label GPALabel;
        private System.Windows.Forms.Button CopyGPAButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.CheckBox SaveScoresCheckBox;
        private System.Windows.Forms.CheckBox AutoClearCheckBox;

    }
}

