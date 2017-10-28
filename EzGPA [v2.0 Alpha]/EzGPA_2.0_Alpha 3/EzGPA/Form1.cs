using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace EzGPA
{
    public partial class Form1 : Form
    {
        //Debug constant (set to true for extra messages)
        const bool DEBUG_MODE = true;
        //Registry constants
        const int REG_READ = 1;
        const int REG_WRITE = 2;
        //Check if app crashed to avoid writing registry keys on form closing
        bool AppCrashed = false;
        //Version-specific constants
        const string Version = "2.0 [Alpha 3]";
        const string MajorVersion = "b";
        const string Changelog = "Twilight Sparkle is best pony!";

        private double CalcSubjectGPA(int score)
        {
            if (score >= 93)
            {
                return 4;
            }
            else if (score >= 88 && score < 93)
            {
                return 3.7;
            }
            else if (score >= 83 && score < 88)
            {
                return 3.4;
            }
            else if (score >= 78 && score < 83)
            {
                return 3.1;
            }
            else if (score >= 73 && score < 78)
            {
                return 2.8;
            }
            else if (score >= 68 && score < 73)
            {
                return 2.5;
            }
            else if (score >= 60 && score < 68)
            {
                return 2.1;
            }
            else
            {
                return 0;
            }
        }
        private double CalcFinalGPA()
        {
            if (tabControl1.SelectedIndex == 0) //Grade 9
            {
                double ChineseExtraGPA = 0;
                double EnglishExtraGPA = 0;
                //if (G9_ChineseNativeComboBox.SelectedItem.ToString() == "Native")
                {
                    if (G9_ChineseLevelComboBox.SelectedItem.ToString() == "S")
                    {
                        ChineseExtraGPA = 0.3;
                    }
                    else if (G9_ChineseLevelComboBox.SelectedItem.ToString() == "H")
                    {
                        ChineseExtraGPA = 0.4;
                    }
                }
                //else if (G9_ChineseNativeComboBox.SelectedItem.ToString() == "Non-Native")
                {
                    if (G9_ChineseLevelComboBox.SelectedItem.ToString() == "初级/入门")
                    {
                        ChineseExtraGPA = 0;
                    }
                    else if (G9_ChineseLevelComboBox.SelectedItem.ToString() == "中级/准中级")
                    {
                        ChineseExtraGPA = 0.1;
                    }
                    else if (G9_ChineseLevelComboBox.SelectedItem.ToString() == "高级/读写")
                    {
                        ChineseExtraGPA = 0.2;
                    }
                }
                //if (G9_EnglishNativeComboBox.SelectedItem.ToString() == "Native")
                {
                    if (G9_EnglishLevelComboBox.SelectedItem.ToString() == "H")
                    {
                        EnglishExtraGPA = 0.3;
                    }
                    else if (G9_EnglishLevelComboBox.SelectedItem.ToString() == "H+")
                    {
                        EnglishExtraGPA = 0.4;
                    }
                }
                //else if (G9_ChineseNativeComboBox.SelectedItem.ToString() == "Non-Native")
                {
                    if (G9_EnglishLevelComboBox.SelectedItem.ToString() == "S")
                    {
                        EnglishExtraGPA = 0;
                    }
                    else if (G9_EnglishLevelComboBox.SelectedItem.ToString() == "S+")
                    {
                        EnglishExtraGPA = 0.2;
                    }
                }
                //                     |----------------------Base Subject GPA--------------------|     |--------------Bonus subject GPA-------------|   |--------------(Only give bonus GPA if user passed)---------------|
                double ChineseGPA =   (CalcSubjectGPA(Convert.ToInt32(G9_ChineseScoreTextBox.Text))   + ChineseExtraGPA                                * Convert.ToInt32(Convert.ToInt32(G9_ChineseScoreTextBox.Text) >= 60))   * G9.ChineseCredits;
                double EnglishGPA =   (CalcSubjectGPA(Convert.ToInt32(G9_EnglishScoreTextBox.Text))   + EnglishExtraGPA                                * Convert.ToInt32(Convert.ToInt32(G9_EnglishScoreTextBox.Text) >= 60))   * G9.EnglishCredits;
                double MathGPA =      (CalcSubjectGPA(Convert.ToInt32(G9_MathScoreTextBox.Text))      + G9_MathLevelComboBox.SelectedIndex      * 0.15 * Convert.ToInt32(Convert.ToInt32(G9_MathScoreTextBox.Text) >= 60))      * G9.MathCredits;
                double PhysicsGPA =   (CalcSubjectGPA(Convert.ToInt32(G9_PhysicsScoreTextBox.Text))   + G9_PhysicsLevelComboBox.SelectedIndex   * 0.15 * Convert.ToInt32(Convert.ToInt32(G9_PhysicsScoreTextBox.Text) >= 60))   * G9.PhysicsCredits;
                double HistoryGPA =   (CalcSubjectGPA(Convert.ToInt32(G9_HistoryScoreTextBox.Text))   + G9_HistoryLevelComboBox.SelectedIndex   * 0.15 * Convert.ToInt32(Convert.ToInt32(G9_HistoryScoreTextBox.Text) >= 60))   * G9.HistoryCredits;
                double ChemistryGPA = (CalcSubjectGPA(Convert.ToInt32(G9_ChemistryScoreTextBox.Text)) + G9_ChemistryLevelComboBox.SelectedIndex * 0.15 * Convert.ToInt32(Convert.ToInt32(G9_ChemistryScoreTextBox.Text) >= 60)) * G9.ChemistryCredits;
                double OptionalGPA =   CalcSubjectGPA(Convert.ToInt32(G9_OptionalScoreTextBox.Text))                                                                                                                            * G9.OptionalCredits;
                return (ChineseGPA + EnglishGPA + MathGPA + PhysicsGPA + HistoryGPA + ChemistryGPA + OptionalGPA) / G9.TotalCredits;
            }
            else if (tabControl1.SelectedIndex == 1) //Grade 10
            {
                //Do stuff here!
            }
            return 42; //We should never have to return this, but it's required to compile, so...
        }
        private DateTime BuildTime()
        {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }
            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
            return dt;
        }
        private void DebugMsgBox(string msg)
        {
            if (DEBUG_MODE)
            {
                MessageBox.Show(msg, "Debug Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ReadWriteRegistryKeys(int action)
        {
            //Check for previous crashes
            if (action == REG_READ)
            {
                RegistryKey temp = Registry.CurrentUser.OpenSubKey("Software\\EzGPA");
                if (temp != null)
                {
                    if (Convert.ToInt32(temp.GetValue("CrashedOnStartup", 0)) == 1)
                    {
                        DialogResult dr = MessageBox.Show("It appears that EzGPA crashed the last time it tried to load user settings. " +
                                                          "Do you want to reset all settings to their default values to try and fix the issue?", "EzGPA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            Registry.CurrentUser.DeleteSubKeyTree("Software\\EzGPA");
                            DebugMsgBox("Deleted Software\\EzGPA.");
                        }
                        else
                        {
                            Registry.CurrentUser.OpenSubKey("Software\\EzGPA", true).SetValue("CrashedOnStartup", 0);
                            DebugMsgBox("Set CrashedOnStartup to 0.");
                        }
                    }
                    temp.Close();
                }
            }

            RegistryKey RegKeyMain = Registry.CurrentUser.OpenSubKey("Software\\EzGPA", true);
            //If the key doesn't exist, create it!
            if (RegKeyMain == null)
            {
                DebugMsgBox("Software\\EzGPA does not exist.");
                RegKeyMain = Registry.CurrentUser.CreateSubKey("Software\\EzGPA");
                DebugMsgBox("Created Software\\EzGPA.");
                RegKeyMain.SetValue("MajorVersion", MajorVersion);
                DebugMsgBox("Set MajorVersion to " + MajorVersion + ".");
            }

            //We have a major update! Delete old values to avoid conflicting data!
            else if (Convert.ToString(RegKeyMain.GetValue("MajorVersion", "")) != MajorVersion)
            {
                DebugMsgBox("Old value of MajorVersion (Registry): " + Convert.ToString(RegKeyMain.GetValue("MajorVersion", "")) + Environment.NewLine +
                            "New value of MajorVersion (Application): " + MajorVersion);

                Registry.CurrentUser.DeleteSubKeyTree("Software\\EzGPA");
                DebugMsgBox("Deleted Software\\EzGPA.");
                RegKeyMain = Registry.CurrentUser.CreateSubKey("Software\\EzGPA");
                DebugMsgBox("Created Software\\EzGPA.");
                RegKeyMain.SetValue("MajorVersion", MajorVersion);
                DebugMsgBox("Set MajorVersion to " + MajorVersion + ".");
                MessageBox.Show("An older/newer version of EzGPA that conflicts with the current version has been detected." +
                                "To prevent crashes, all settings have been reset to their default values.", "EzGPA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (action == REG_READ)
            {
                try
                {
                    DebugMsgBox("Loading user settings...");
                    //Global settings
                    SaveScoresCheckBox.Checked = Convert.ToBoolean(RegKeyMain.GetValue("SaveScores", 1));
                    AutoClearCheckBox.Checked = Convert.ToBoolean(RegKeyMain.GetValue("AutoClear", 1));
                    //Grade 9 settings
                    RegistryKey RegKeyG9 = RegKeyMain.CreateSubKey("G9");
                    DebugMsgBox("Opened SubKey EzGPA\\G9.");
                    G9_ChineseNativeComboBox.SelectedIndex = Convert.ToInt32(RegKeyG9.GetValue("ChineseNative", 0));
                    G9_EnglishNativeComboBox.SelectedIndex = Convert.ToInt32(RegKeyG9.GetValue("EnglishNative", 0));
                    G9_ChineseLevelComboBox.SelectedIndex = Convert.ToInt32(RegKeyG9.GetValue("ChineseLevel", 0));
                    G9_EnglishLevelComboBox.SelectedIndex = Convert.ToInt32(RegKeyG9.GetValue("EnglishLevel", 0));
                    G9_MathLevelComboBox.SelectedIndex = Convert.ToInt32(RegKeyG9.GetValue("MathLevel", 0));
                    G9_PhysicsLevelComboBox.SelectedIndex = Convert.ToInt32(RegKeyG9.GetValue("PhysicsLevel", 0));
                    G9_HistoryLevelComboBox.SelectedIndex = Convert.ToInt32(RegKeyG9.GetValue("HistoryLevel", 0));
                    G9_ChemistryLevelComboBox.SelectedIndex = Convert.ToInt32(RegKeyG9.GetValue("ChemistryLevel", 0));
                    if (SaveScoresCheckBox.Checked)
                    {
                        DebugMsgBox("Loading scores...");
                        G9_ChineseScoreTextBox.Text = Convert.ToString(RegKeyG9.GetValue("ChineseScore", ""));
                        G9_EnglishScoreTextBox.Text = Convert.ToString(RegKeyG9.GetValue("EnglishScore", ""));
                        G9_MathScoreTextBox.Text = Convert.ToString(RegKeyG9.GetValue("MathScore", ""));
                        G9_PhysicsScoreTextBox.Text = Convert.ToString(RegKeyG9.GetValue("PhysicsScore", ""));
                        G9_HistoryScoreTextBox.Text = Convert.ToString(RegKeyG9.GetValue("HistoryScore", ""));
                        G9_ChemistryScoreTextBox.Text = Convert.ToString(RegKeyG9.GetValue("ChemistryScore", ""));
                        G9_OptionalScoreTextBox.Text = Convert.ToString(RegKeyG9.GetValue("OptionalScore", ""));
                        DebugMsgBox("Scores have been loaded.");
                    }
                    RegKeyG9.Close();
                    DebugMsgBox("Closed SubKey EzGPA\\G9.");
                    //End grade 9 settings
                    DebugMsgBox("User settings have been loaded.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while loading user settings: " + Environment.NewLine + Environment.NewLine +
                                    ex.GetType().ToString() + Environment.NewLine +
                                    ex.Message + Environment.NewLine + Environment.NewLine +
                                    "If you keep getting this error, read the readme.txt file for solutions.", "EzGPA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RegKeyMain.SetValue("CrashedOnStartup", 1);
                    DebugMsgBox("Set CrashedOnStartup to 1.");
                    AppCrashed = true;
                    Application.Exit();
                }
            }
            if (action == REG_WRITE)
            {
                try
                {
                    DebugMsgBox("Saving user settings...");
                    //Global settings
                    RegKeyMain.SetValue("SaveScores", Convert.ToInt32(SaveScoresCheckBox.Checked));
                    RegKeyMain.SetValue("AutoClear", Convert.ToInt32(AutoClearCheckBox.Checked));
                    //Grade 9 settings
                    RegistryKey RegKeyG9 = RegKeyMain.CreateSubKey("G9");
                    DebugMsgBox("Opened SubKey EzGPA\\G9.");
                    RegKeyG9.SetValue("ChineseNative", G9_ChineseNativeComboBox.SelectedIndex);
                    RegKeyG9.SetValue("EnglishNative", G9_EnglishNativeComboBox.SelectedIndex);
                    RegKeyG9.SetValue("ChineseLevel", G9_ChineseLevelComboBox.SelectedIndex);
                    RegKeyG9.SetValue("EnglishLevel", G9_EnglishLevelComboBox.SelectedIndex);
                    RegKeyG9.SetValue("MathLevel", G9_MathLevelComboBox.SelectedIndex);
                    RegKeyG9.SetValue("PhysicsLevel", G9_PhysicsLevelComboBox.SelectedIndex);
                    RegKeyG9.SetValue("HistoryLevel", G9_HistoryLevelComboBox.SelectedIndex);
                    RegKeyG9.SetValue("ChemistryLevel", G9_ChemistryLevelComboBox.SelectedIndex);
                    if (SaveScoresCheckBox.Checked)
                    {
                        DebugMsgBox("Saving scores...");
                        RegKeyG9.SetValue("ChineseScore", G9_ChineseScoreTextBox.Text);
                        RegKeyG9.SetValue("EnglishScore", G9_EnglishScoreTextBox.Text);
                        RegKeyG9.SetValue("MathScore", G9_MathScoreTextBox.Text);
                        RegKeyG9.SetValue("PhysicsScore", G9_PhysicsScoreTextBox.Text);
                        RegKeyG9.SetValue("HistoryScore", G9_HistoryScoreTextBox.Text);
                        RegKeyG9.SetValue("ChemistryScore", G9_ChemistryScoreTextBox.Text);
                        RegKeyG9.SetValue("OptionalScore", G9_OptionalScoreTextBox.Text);
                        DebugMsgBox("Scores have been saved.");
                    }
                    RegKeyG9.Close();
                    DebugMsgBox("Closed SubKey EzGPA\\G9.");
                    //End grade 9 settings
                    DebugMsgBox("User settings have been saved.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured while saving user settings: " + Environment.NewLine + Environment.NewLine +
                                    ex.GetType().ToString() + Environment.NewLine +
                                    ex.Message + Environment.NewLine + Environment.NewLine +
                                    "If you keep getting this error, read the readme.txt file for solutions.", "EzGPA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            RegKeyMain.Close();
        }
        public Form1() //Can't touch this! (No, seriously, don't touch it.)
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadWriteRegistryKeys(REG_READ);
            Text = "EzGPA v" + Version;
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!AppCrashed)
            {
                ReadWriteRegistryKeys(REG_WRITE);
            }
        }
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            //Automatically clear the text in the textbox
            if (AutoClearCheckBox.Checked)
            {
                TextBox s = (TextBox)sender;
                s.Text = "";
            }
        }
        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            //Remove all leading 0s
            TextBox s = (TextBox)sender;
            if (s.Text != "")
            {
                s.Text = Convert.ToInt32(s.Text).ToString();
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            //If the score is greater than 100, set it to 100
            TextBox s = (TextBox)sender;
            if (s.Text != "")
            {
                if (Convert.ToInt32(s.Text) > 100)
                {
                    s.Text = "100";
                    s.SelectionStart = s.TextLength;
                }
            }
        }
        private void TextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Only allow the user to input numbers in the textbox
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void G9_ChineseNativeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G9_ChineseNativeComboBox.SelectedItem.ToString() == "Native")
            {
                G9_ChineseLevelComboBox.Items.Clear();
                G9_ChineseLevelComboBox.Items.Add("S");
                G9_ChineseLevelComboBox.Items.Add("H");
            }
            else if (G9_ChineseNativeComboBox.SelectedItem.ToString() == "Non-Native")
            {
                G9_ChineseLevelComboBox.Items.Clear();
                G9_ChineseLevelComboBox.Items.Add("初级/入门");
                G9_ChineseLevelComboBox.Items.Add("中级/准中级");
                G9_ChineseLevelComboBox.Items.Add("高级/读写");
            }
            G9_ChineseLevelComboBox.SelectedIndex = 0;
        }
        private void G9_EnglishNativeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G9_EnglishNativeComboBox.SelectedItem.ToString() == "Native")
            {
                G9_EnglishLevelComboBox.Items.Clear();
                G9_EnglishLevelComboBox.Items.Add("H");
                G9_EnglishLevelComboBox.Items.Add("H+");
            }
            else if (G9_EnglishNativeComboBox.SelectedItem.ToString() == "Non-Native")
            {
                G9_EnglishLevelComboBox.Items.Clear();
                G9_EnglishLevelComboBox.Items.Add("S");
                G9_EnglishLevelComboBox.Items.Add("S+");
            }
            G9_EnglishLevelComboBox.SelectedIndex = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //If any textbox is empty, ask for input
            if (tabControl1.SelectedIndex == 0 && (G9_ChineseScoreTextBox.Text == "" || G9_EnglishScoreTextBox.Text == "" || 
                G9_MathScoreTextBox.Text == "" || G9_PhysicsScoreTextBox.Text == "" || G9_HistoryScoreTextBox.Text == "" || 
                G9_ChemistryScoreTextBox.Text == "" || G9_OptionalScoreTextBox.Text == "") || 
                tabControl1.SelectedIndex == 1 && (1==0))
            {
                GPALabel.Text = "Please enter all of your scores!";
            }
            else
            {
                GPALabel.Text = "Your GPA is: " + CalcFinalGPA().ToString();
            }
        }   
        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EzGPA v" + Version + Environment.NewLine +
                            "Copyright © 2011-2012 Andrew Sun <crossbowffs@live.com>" + Environment.NewLine +
                            "Built on: " + BuildTime() + Environment.NewLine + Environment.NewLine +
                            "v" + Version + " changelog: " + Changelog, "EzGPA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CopyGPAButton_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(CalcFinalGPA().ToString());
            }
            catch (Exception ex)
            {
                //It doesn't really matter that an exception was thrown here, but I'll put this here in case
                DebugMsgBox("Exception occured:" + Environment.NewLine +
                            ex.GetType().ToString() + Environment.NewLine +
                            ex.Message);
            }
        }
    }

    internal static class G9
    {
        internal const double ChineseCredits =    4.5;
        internal const double EnglishCredits =    7.5;
        internal const double MathCredits =       7;
        internal const double PhysicsCredits =    4;
        internal const double HistoryCredits =    3.5;
        internal const double ChemistryCredits =  3;
        internal const double OptionalCredits =   1.5;
        internal const double TotalCredits =      31;
    }
    internal static class G10
    {
        //I'm 15 and what is this?
    }
}