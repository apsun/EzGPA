/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * EzGPA: The worst GPA calculator in the world!               *
 * Written in C# by Andrew Sun <crossbowffs@live.com>          *
 *                                                             *
 * If you steal my code, you must really suck at programming.  *
 * Twilight Sparkle is best pony.                              *
 * You lost The Game.                                          *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace EzGPA
{
    public partial class Form1 : Form
    {
        //Debug constant (set to true for extra messages)
        const bool DEBUG_MODE = false;
        //Registry constants (why did I even make these?)
        const int REG_READ = 1;
        const int REG_WRITE = 2;
        //Variables used for internal checks
        bool AppCrashed = false; //Means the app crashed and we should not save registry settings
        bool AppClosing = false; //Means the app is closing (not crashing) and we should not clear scores
        //Version-specific strings
        const string Version = "2.0_Alpha 6";
        const string Changelog = "This is a changelog. No, it's definitely not a changeling. I hope.";

        private void DebugMsgBox(string msg)
        {
            if (DEBUG_MODE)
            {
                MessageBox.Show(msg, "Debug Message", MessageBoxButtons.OK);
            }
        }
        private void CrashMe(Exception ex)
        {
            MessageBox.Show("An unknown error occured: " + Environment.NewLine + Environment.NewLine +
                            ex.GetType().ToString() + Environment.NewLine +
                            ex.Message + Environment.NewLine + Environment.NewLine +
                            "If you keep getting this error, read the readme.txt file for solutions.", "EzGPA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            try
            {
                RegistryKey RegKeyMain = Registry.CurrentUser.CreateSubKey("Software\\EzGPA");
                RegKeyMain.SetValue("CrashedOnStartup", 1);
                DebugMsgBox("Set CrashedOnStartup to 1.");
            }
            catch (Exception ex2)
            {
                //This is a fail-safe for registry permission issues. This should never be reached in a bug-free build.
                DebugMsgBox("Error occured while setting CrashedOnStartup: " + Environment.NewLine + Environment.NewLine +
                            ex2.GetType().ToString() + Environment.NewLine +
                            ex2.Message);
            }
            AppCrashed = true;
            Application.Exit();
        }
        private void ReadWriteRegistryKeys(int action)
        {
            try
            {
                RegistryKey RegKeyMain = Registry.CurrentUser.CreateSubKey("Software\\EzGPA");

                if (action == REG_READ)
                {
                    DebugMsgBox("Loading user settings...");

                    //Check for previous crashes
                    if (Convert.ToInt32(RegKeyMain.GetValue("CrashedOnStartup", 0)) == 1)
                    {
                        DialogResult dr = MessageBox.Show("It appears that EzGPA crashed the last time it tried to load user settings. " +
                                                          "Do you want to reset all settings to their default values to try and fix the issue?", "EzGPA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            Registry.CurrentUser.DeleteSubKeyTree("Software\\EzGPA");
                            DebugMsgBox("Deleted Software\\EzGPA.");
                            RegKeyMain = Registry.CurrentUser.CreateSubKey("Software\\EzGPA");
                            DebugMsgBox("Created Software\\EzGPA.");
                        }
                        else
                        {
                            RegKeyMain.SetValue("CrashedOnStartup", 0);
                            DebugMsgBox("Set CrashedOnStartup to 0.");
                        }
                    }

                    //Grade 9 settings
                    RegistryKey RegKeyG9 = RegKeyMain.CreateSubKey("G9");
                    DebugMsgBox("Opened SubKey EzGPA\\G9.");

                    LoadRegistrySettings(RegKeyG9, "ChineseEnabled", 1, ref G9_ChineseEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG9, "EnglishEnabled", 1, ref G9_EnglishEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG9, "MathEnabled", 1, ref G9_MathEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG9, "PhysicsEnabled", 1, ref G9_PhysicsEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG9, "HistoryEnabled", 1, ref G9_HistoryEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG9, "ChemistryEnabled", 1, ref G9_ChemistryEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG9, "OptionalEnabled", 1, ref G9_OptionalEnabledCheckBox);
                    DebugMsgBox("Loaded G9 enabled subjects.");

                    LoadRegistrySettings(RegKeyG9, "ChineseNative", 0, ref G9_ChineseNativeComboBox);
                    LoadRegistrySettings(RegKeyG9, "EnglishNative", 0, ref G9_EnglishNativeComboBox);
                    DebugMsgBox("Loaded G9 native/non-native settings.");

                    LoadRegistrySettings(RegKeyG9, "ChineseLevel", 0, ref G9_ChineseLevelComboBox);
                    LoadRegistrySettings(RegKeyG9, "EnglishLevel", 0, ref G9_EnglishLevelComboBox);
                    LoadRegistrySettings(RegKeyG9, "MathLevel", 0, ref G9_MathLevelComboBox);
                    LoadRegistrySettings(RegKeyG9, "PhysicsLevel", 0, ref G9_PhysicsLevelComboBox);
                    LoadRegistrySettings(RegKeyG9, "HistoryLevel", 0, ref G9_HistoryLevelComboBox);
                    LoadRegistrySettings(RegKeyG9, "ChemistryLevel", 0, ref G9_ChemistryLevelComboBox);
                    DebugMsgBox("Loaded G9 levels.");

                    LoadRegistrySettings(RegKeyG9, "ChineseScore", "", ref G9_ChineseScoreTextBox);
                    LoadRegistrySettings(RegKeyG9, "EnglishScore", "", ref G9_EnglishScoreTextBox);
                    LoadRegistrySettings(RegKeyG9, "MathScore", "", ref G9_MathScoreTextBox);
                    LoadRegistrySettings(RegKeyG9, "PhysicsScore", "", ref G9_PhysicsScoreTextBox);
                    LoadRegistrySettings(RegKeyG9, "HistoryScore", "", ref G9_HistoryScoreTextBox);
                    LoadRegistrySettings(RegKeyG9, "ChemistryScore", "", ref G9_ChemistryScoreTextBox);
                    LoadRegistrySettings(RegKeyG9, "OptionalScore", "", ref G9_OptionalScoreTextBox);
                    DebugMsgBox("Loaded G9 scores.");

                    RegKeyG9.Close();
                    DebugMsgBox("Closed SubKey EzGPA\\G9.");

                    //Grade 10 settings
                    RegistryKey RegKeyG10 = RegKeyMain.CreateSubKey("G10");
                    DebugMsgBox("Opened SubKey EzGPA\\G10.");

                    LoadRegistrySettings(RegKeyG10, "ChineseEnabled", 1, ref G10_ChineseEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG10, "EnglishEnabled", 1, ref G10_EnglishEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG10, "MathEnabled", 1, ref G10_MathEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG10, "PhysicsEnabled", 1, ref G10_PhysicsEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG10, "ChemistryEnabled", 1, ref G10_ChemistryEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG10, "EconomicsEnabled", 1, ref G10_EconomicsEnabledCheckBox);
                    LoadRegistrySettings(RegKeyG10, "Optional1Enabled", 1, ref G10_Optional1EnabledCheckBox);
                    LoadRegistrySettings(RegKeyG10, "Optional2Enabled", 1, ref G10_Optional2EnabledCheckBox);
                    DebugMsgBox("Loaded G10 enabled subjects.");

                    LoadRegistrySettings(RegKeyG10, "ChineseNative", 0, ref G10_ChineseNativeComboBox);
                    LoadRegistrySettings(RegKeyG10, "EnglishNative", 0, ref G10_EnglishNativeComboBox);
                    DebugMsgBox("Loaded G10 native/non-native settings.");

                    LoadRegistrySettings(RegKeyG10, "ChineseLevel", 0, ref G10_ChineseLevelComboBox);
                    LoadRegistrySettings(RegKeyG10, "EnglishLevel", 0, ref G10_EnglishLevelComboBox);
                    LoadRegistrySettings(RegKeyG10, "MathLevel", 0, ref G10_MathLevelComboBox);
                    LoadRegistrySettings(RegKeyG10, "PhysicsLevel", 0, ref G10_PhysicsLevelComboBox);
                    LoadRegistrySettings(RegKeyG10, "ChemistryLevel", 0, ref G10_ChemistryLevelComboBox);
                    LoadRegistrySettings(RegKeyG10, "EconomicsLevel", 0, ref G10_EconomicsLevelComboBox);
                    DebugMsgBox("Loaded G10 levels.");

                    LoadRegistrySettings(RegKeyG10, "ChineseScore", "", ref G10_ChineseScoreTextBox);
                    LoadRegistrySettings(RegKeyG10, "EnglishScore", "", ref G10_EnglishScoreTextBox);
                    LoadRegistrySettings(RegKeyG10, "MathScore", "", ref G10_MathScoreTextBox);
                    LoadRegistrySettings(RegKeyG10, "PhysicsScore", "", ref G10_PhysicsScoreTextBox);
                    LoadRegistrySettings(RegKeyG10, "ChemistryScore", "", ref G10_ChemistryScoreTextBox);
                    LoadRegistrySettings(RegKeyG10, "EconomicsScore", "", ref G10_EconomicsScoreTextBox);
                    LoadRegistrySettings(RegKeyG10, "Optional1Score", "", ref G10_Optional1ScoreTextBox);
                    LoadRegistrySettings(RegKeyG10, "Optional2Score", "", ref G10_Optional2ScoreTextBox);
                    DebugMsgBox("Loaded G10 scores.");

                    RegKeyG10.Close();
                    DebugMsgBox("Closed SubKey EzGPA\\G10.");

                    DebugMsgBox("User settings have been loaded.");
                }
                if (action == REG_WRITE)
                {
                    DebugMsgBox("Saving user settings...");

                    //Grade 9 settings
                    RegistryKey RegKeyG9 = RegKeyMain.CreateSubKey("G9");
                    DebugMsgBox("Opened SubKey EzGPA\\G9.");

                    SaveRegistrySettings(RegKeyG9, "ChineseEnabled", Convert.ToInt32(G9_ChineseEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG9, "EnglishEnabled", Convert.ToInt32(G9_EnglishEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG9, "MathEnabled", Convert.ToInt32(G9_MathEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG9, "PhysicsEnabled", Convert.ToInt32(G9_PhysicsEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG9, "HistoryEnabled", Convert.ToInt32(G9_HistoryEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG9, "ChemistryEnabled", Convert.ToInt32(G9_ChemistryEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG9, "OptionalEnabled", Convert.ToInt32(G9_OptionalEnabledCheckBox.Checked));
                    DebugMsgBox("Saved G9 enabled subjects.");

                    SaveRegistrySettings(RegKeyG9, "ChineseNative", G9_ChineseNativeComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG9, "EnglishNative", G9_EnglishNativeComboBox.SelectedIndex);
                    DebugMsgBox("Saved G9 native/non-native settings.");

                    SaveRegistrySettings(RegKeyG9, "ChineseLevel", G9_ChineseLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG9, "EnglishLevel", G9_EnglishLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG9, "MathLevel", G9_MathLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG9, "PhysicsLevel", G9_PhysicsLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG9, "HistoryLevel", G9_HistoryLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG9, "ChemistryLevel", G9_ChemistryLevelComboBox.SelectedIndex);
                    DebugMsgBox("Saved G9 levels.");

                    SaveRegistrySettings(RegKeyG9, "ChineseScore", G9_ChineseScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG9, "EnglishScore", G9_EnglishScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG9, "MathScore", G9_MathScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG9, "PhysicsScore", G9_PhysicsScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG9, "HistoryScore", G9_HistoryScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG9, "ChemistryScore", G9_ChemistryScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG9, "OptionalScore", G9_OptionalScoreTextBox.Text);
                    DebugMsgBox("Saved G9 scores.");

                    RegKeyG9.Close();
                    DebugMsgBox("Closed SubKey EzGPA\\G9.");

                    //Grade 10 settings
                    RegistryKey RegKeyG10 = RegKeyMain.CreateSubKey("G10");
                    DebugMsgBox("Opened SubKey EzGPA\\G10.");

                    SaveRegistrySettings(RegKeyG10, "ChineseEnabled", Convert.ToInt32(G10_ChineseEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG10, "EnglishEnabled", Convert.ToInt32(G10_EnglishEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG10, "MathEnabled", Convert.ToInt32(G10_MathEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG10, "PhysicsEnabled", Convert.ToInt32(G10_PhysicsEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG10, "ChemistryEnabled", Convert.ToInt32(G10_ChemistryEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG10, "EconomicsEnabled", Convert.ToInt32(G10_EconomicsEnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG10, "Optional1Enabled", Convert.ToInt32(G10_Optional1EnabledCheckBox.Checked));
                    SaveRegistrySettings(RegKeyG10, "Optional2Enabled", Convert.ToInt32(G10_Optional2EnabledCheckBox.Checked));
                    DebugMsgBox("Saved G10 enabled subjects.");

                    SaveRegistrySettings(RegKeyG10, "ChineseNative", G10_ChineseNativeComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG10, "EnglishNative", G10_EnglishNativeComboBox.SelectedIndex);
                    DebugMsgBox("Saved G10 native/non-native settings.");

                    SaveRegistrySettings(RegKeyG10, "ChineseLevel", G10_ChineseLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG10, "EnglishLevel", G10_EnglishLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG10, "MathLevel", G10_MathLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG10, "PhysicsLevel", G10_PhysicsLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG10, "ChemistryLevel", G10_ChemistryLevelComboBox.SelectedIndex);
                    SaveRegistrySettings(RegKeyG10, "EconomicsLevel", G10_EconomicsLevelComboBox.SelectedIndex);
                    DebugMsgBox("Saved G10 levels.");

                    SaveRegistrySettings(RegKeyG10, "ChineseScore", G10_ChineseScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG10, "EnglishScore", G10_EnglishScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG10, "MathScore", G10_MathScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG10, "PhysicsScore", G10_PhysicsScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG10, "ChemistryScore", G10_ChemistryScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG10, "EconomicsScore", G10_EconomicsScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG10, "Optional1Score", G10_Optional1ScoreTextBox.Text);
                    SaveRegistrySettings(RegKeyG10, "Optional2Score", G10_Optional2ScoreTextBox.Text);
                    DebugMsgBox("Saved G10 scores.");

                    RegKeyG10.Close();
                    DebugMsgBox("Closed SubKey EzGPA\\G10.");

                    DebugMsgBox("User settings have been saved.");
                }
                RegKeyMain.Close();
            }
            catch (System.Security.SecurityException)
            {
                DebugMsgBox("System.Security.SecurityException");
                MessageBox.Show("You do not have permission to access the registry! " +
                                "Try running the app as an administrator or read the readme.txt file for more help.", "EzGPA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppCrashed = true;
                Application.Exit();
            }
            catch (System.UnauthorizedAccessException)
            {
                DebugMsgBox("System.UnauthorizedAccessException");
                MessageBox.Show("You do not have permission to access the registry! " +
                                "Try running the app as an administrator or read the readme.txt file for more help.", "EzGPA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AppCrashed = true;
                Application.Exit();
            }
            catch (Exception ex)
            {
                CrashMe(ex);
            }
        }
        private void LoadRegistrySettings(RegistryKey regKey, string value, string defaultValue, ref TextBox cont)
        {
            //TextBoxes
            try
            {
                cont.Text = Convert.ToString(regKey.GetValue(value, defaultValue));
            }
            catch (FormatException)
            {
                //Something other than numbers or invalid value type
                cont.Text = "";
                DebugMsgBox("FormatException: " + value);
            }
            catch (Exception ex)
            {
                CrashMe(ex);
            }
        }
        private void LoadRegistrySettings(RegistryKey regKey, string value, int defaultValue, ref ComboBox cont)
        {
            //ComboBoxes
            try
            {
                cont.SelectedIndex = Convert.ToInt32(regKey.GetValue(value, defaultValue));
            }
            catch (ArgumentOutOfRangeException)
            {
                //Value out of range (but it's still a number)
                cont.SelectedIndex = 0;
                DebugMsgBox("ArgumentOutOfRangeException: " + value);
            }
            catch (FormatException)
            {
                //Not a number or invalid value type
                cont.SelectedIndex = 0;
                DebugMsgBox("FormatException: " + value);
            }
            catch (Exception ex)
            {
                CrashMe(ex);
            }
        }
        private void LoadRegistrySettings(RegistryKey regKey, string value, int defaultValue, ref CheckBox cont)
        {
            //CheckBoxes
            try
            {
                cont.Checked = Convert.ToBoolean(regKey.GetValue(value, defaultValue));
            }
            catch //(Exception ex)
            {
                //To be honest, we don't need to crash the app for this one
                //CrashMe(ex);
            }
        }
        private void SaveRegistrySettings(RegistryKey regKey, string value, object data)
        {
            try
            {
                regKey.SetValue(value, data);
            }
            catch
            {
                //User probably modified registry permissions while the app was running...
                DebugMsgBox("Failed saving setting: " + value);
            }
        }
        private int ConvertToInt32(string value)
        {
            //This function was written for the CalcFinalGPA() method.
            //It is essentially the same as VB.NET's Val() function, except that it returns an integer.
            //Passing an empty string will return 0 instead of throwing an exception.
            if (value == "")
            {
                return 0;
            }
            return Convert.ToInt32(value);
        }
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
            //Grade 9
            if (tabControl1.SelectedIndex == 0)
            {
                double ChineseExtraGPA = 0;
                double EnglishExtraGPA = 0;

                //Native/non-native checking has been removed here.
                //This is because we are updating the text every tick,
                //and not after the user confirms their selection.
                //This will allow for 'GPA previewing'

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
                double ChineseGPA   = (CalcSubjectGPA(ConvertToInt32(G9_ChineseScoreTextBox.Text))   + ChineseExtraGPA                                * Convert.ToInt32(ConvertToInt32(G9_ChineseScoreTextBox.Text) >= 60))   * G9.ChineseCredits;
                double EnglishGPA   = (CalcSubjectGPA(ConvertToInt32(G9_EnglishScoreTextBox.Text))   + EnglishExtraGPA                                * Convert.ToInt32(ConvertToInt32(G9_EnglishScoreTextBox.Text) >= 60))   * G9.EnglishCredits;
                double MathGPA      = (CalcSubjectGPA(ConvertToInt32(G9_MathScoreTextBox.Text))      + G9_MathLevelComboBox.SelectedIndex      * 0.15 * Convert.ToInt32(ConvertToInt32(G9_MathScoreTextBox.Text) >= 60))      * G9.MathCredits;
                double PhysicsGPA   = (CalcSubjectGPA(ConvertToInt32(G9_PhysicsScoreTextBox.Text))   + G9_PhysicsLevelComboBox.SelectedIndex   * 0.15 * Convert.ToInt32(ConvertToInt32(G9_PhysicsScoreTextBox.Text) >= 60))   * G9.PhysicsCredits;
                double HistoryGPA   = (CalcSubjectGPA(ConvertToInt32(G9_HistoryScoreTextBox.Text))   + G9_HistoryLevelComboBox.SelectedIndex   * 0.15 * Convert.ToInt32(ConvertToInt32(G9_HistoryScoreTextBox.Text) >= 60))   * G9.HistoryCredits;
                double ChemistryGPA = (CalcSubjectGPA(ConvertToInt32(G9_ChemistryScoreTextBox.Text)) + G9_ChemistryLevelComboBox.SelectedIndex * 0.15 * Convert.ToInt32(ConvertToInt32(G9_ChemistryScoreTextBox.Text) >= 60)) * G9.ChemistryCredits;
                double OptionalGPA  =  CalcSubjectGPA(ConvertToInt32(G9_OptionalScoreTextBox.Text))                                                                                                                           * G9.OptionalCredits;
                
                return (ChineseGPA   * Convert.ToInt32(G9_ChineseEnabledCheckBox.Checked) 
                      + EnglishGPA   * Convert.ToInt32(G9_EnglishEnabledCheckBox.Checked)
                      + MathGPA      * Convert.ToInt32(G9_MathEnabledCheckBox.Checked)
                      + PhysicsGPA   * Convert.ToInt32(G9_PhysicsEnabledCheckBox.Checked)
                      + HistoryGPA   * Convert.ToInt32(G9_HistoryEnabledCheckBox.Checked)
                      + ChemistryGPA * Convert.ToInt32(G9_ChemistryEnabledCheckBox.Checked)
                      + OptionalGPA  * Convert.ToInt32(G9_OptionalEnabledCheckBox.Checked))

                      /
                      
                       (G9.ChineseCredits   * Convert.ToInt32(G9_ChineseEnabledCheckBox.Checked)
                      + G9.EnglishCredits   * Convert.ToInt32(G9_EnglishEnabledCheckBox.Checked)
                      + G9.MathCredits      * Convert.ToInt32(G9_MathEnabledCheckBox.Checked)
                      + G9.PhysicsCredits   * Convert.ToInt32(G9_PhysicsEnabledCheckBox.Checked)
                      + G9.HistoryCredits   * Convert.ToInt32(G9_HistoryEnabledCheckBox.Checked)
                      + G9.ChemistryCredits * Convert.ToInt32(G9_ChemistryEnabledCheckBox.Checked)
                      + G9.OptionalCredits  * Convert.ToInt32(G9_OptionalEnabledCheckBox.Checked));
            }

            //Grade 10
            else if (tabControl1.SelectedIndex == 1)
            {
                //Do stuff here!
            }
            return 42; //We should never have to return this, but it's required to compile, so...
        }
        private Boolean AllScoresEntered()
        {
            //Grade 9
            if (tabControl1.SelectedIndex == 0)
            {
                if ((G9_ChineseScoreTextBox.Text   == "" && G9_ChineseEnabledCheckBox.Checked)   ||
                    (G9_EnglishScoreTextBox.Text   == "" && G9_EnglishEnabledCheckBox.Checked)   ||
                    (G9_MathScoreTextBox.Text      == "" && G9_MathEnabledCheckBox.Checked)      ||
                    (G9_PhysicsScoreTextBox.Text   == "" && G9_PhysicsEnabledCheckBox.Checked)   ||
                    (G9_HistoryScoreTextBox.Text   == "" && G9_HistoryEnabledCheckBox.Checked)   ||
                    (G9_ChemistryScoreTextBox.Text == "" && G9_ChemistryEnabledCheckBox.Checked) ||
                    (G9_OptionalScoreTextBox.Text  == "" && G9_OptionalEnabledCheckBox.Checked))
                {
                    return false;
                }
            }

            //Grade 10
            else if (tabControl1.SelectedIndex == 1)
            {
                //Do stuff here!
            }
            return true;
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
        public Form1()
        {
            //Can't touch this! (No, seriously, don't touch it.)
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadWriteRegistryKeys(REG_READ);
            timer1_Tick(null, null);
            Text = "EzGPA v" + Version;
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!AppCrashed)
            {
                AppClosing = true;
                ReadWriteRegistryKeys(REG_WRITE);
            }
        }
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            //Automatically clear the text in the textbox
            if (!AppClosing && !AppCrashed)
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
        private void G10_ChineseNativeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G10_ChineseNativeComboBox.SelectedItem.ToString() == "Native")
            {
                G10_ChineseLevelComboBox.Items.Clear();
                G10_ChineseLevelComboBox.Items.Add("S");
                G10_ChineseLevelComboBox.Items.Add("H");
            }
            else if (G10_ChineseNativeComboBox.SelectedItem.ToString() == "Non-Native")
            {
                G10_ChineseLevelComboBox.Items.Clear();
                G10_ChineseLevelComboBox.Items.Add("初级/入门");
                G10_ChineseLevelComboBox.Items.Add("中级/准中级");
                G10_ChineseLevelComboBox.Items.Add("高级/读写");
            }
            G10_ChineseLevelComboBox.SelectedIndex = 0;
        }
        private void G10_EnglishNativeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (G10_EnglishNativeComboBox.SelectedItem.ToString() == "Native")
            {
                G10_EnglishLevelComboBox.Items.Clear();
                G10_EnglishLevelComboBox.Items.Add("H");
                G10_EnglishLevelComboBox.Items.Add("H+");
            }
            else if (G10_EnglishNativeComboBox.SelectedItem.ToString() == "Non-Native")
            {
                G10_EnglishLevelComboBox.Items.Clear();
                G10_EnglishLevelComboBox.Items.Add("S");
                G10_EnglishLevelComboBox.Items.Add("S+");
            }
            G10_EnglishLevelComboBox.SelectedIndex = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Calculate GPA only if all scores are entered
            if (!AllScoresEntered())
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
                            "Copyright © 2011-" + BuildTime().Year.ToString() + " Andrew Sun <crossbowffs@live.com>" + Environment.NewLine +
                            "Built on: " + BuildTime() + Environment.NewLine + Environment.NewLine +
                            "v" + Version + " changelog: " + Changelog, "EzGPA", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void CopyGPAButton_Click(object sender, EventArgs e)
        {
            if (AllScoresEntered())
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
            else
            {
                DebugMsgBox("Not all scores have been entered yet.");
            }
        }
    }

    internal static class G9
    {
        internal const double ChineseCredits   = 4.5;
        internal const double EnglishCredits   = 7.5;
        internal const double MathCredits      = 7;
        internal const double PhysicsCredits   = 4;
        internal const double HistoryCredits   = 3.5;
        internal const double ChemistryCredits = 3;
        internal const double OptionalCredits  = 1.5;
    }
    internal static class G10
    {
        internal const double ChineseCredits   = 3.5;
        internal const double EnglishCredits   = 7.5;
        internal const double MathCredits      = 7.5;
        internal const double PhysicsCredits   = 4;
        internal const double ChemistryCredits = 4;
        internal const double EconomicsCredits = 2.5;
        internal const double OptionalCredits  = 2.5;
    }
}