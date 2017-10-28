using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EzGPA.Config;
using EzGPA.Core;
using EzGPA.Localization;

namespace EzGPA
{
    public sealed partial class Form1 : Form
    {
        private const string LocalizationXmlPath = "localization.xml";
        private const string DataXmlPath = "data.xml";
        private const string ConfigXmlPath = "config.xml";
        private const string TextEditorPath = "notepad.exe";

        private const int ExtraExpansionHeight = 14;
        private static readonly Version Version = new Version("3.1");

        private readonly LocalizationManager _localization;
        private readonly SettingsManager _settings;
        private readonly School _grades;
        private bool _optionsExpanded = true;
        private bool _suppressLocaleChange = false;
        private readonly bool _shouldSaveConfig = false;
        private readonly int _fullHeight;
        private readonly int _miniHeight;

        public Form1()
        {
            InitializeComponent();

            //Update strings everywhere
            RefreshControlLocalization();

            //Restore to "retracted" state
            _fullHeight = Height;
            _miniHeight = _fullHeight - settingsGroupBox.Height - ExtraExpansionHeight;
            ToggleOptions();

            //Add language options to language ComboBox
            PopulateLanguageComboBox();

            //If we got to this point without errors, enable config saving
            _shouldSaveConfig = true;
        }

        private void ConstructorSelfDestruct()
        {
            Load += (sender, e) => Close();
        }

        private void InfoMsgBox(string message)
        {
            string title = _localization == null ? "Info" : _localization.Info();
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ErrorMsgBox(string message)
        {
            string title = _localization == null ? "Error" : _localization.Error();
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DialogResult ErrorYesNoMsgBox(string message)
        {
            string title = _localization == null ? "Error" : _localization.Error();
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        private void RefreshControlLocalization()
        {
            Text = _localization.FullName(Version);
            gradesTabControl.UpdateLocalization(_localization);
            copyButton.Text = _localization.CopyToClipboard();
            optionsButton.Text = _localization.Options();
            aboutButton.Text = _localization.About();
            settingsGroupBox.Text = _localization.Settings();
            autoClearCheckBox.Text = _localization.AutoClear();
            autoCopyCheckBox.Text = _localization.AutoCopy();
            languageLabel.Text = _localization.Language();
            filesGroupBox.Text = _localization.Files();
            RefreshGpaLabel();
        }

        private static bool CopyGpaToClipboard(double gpa)
        {
            try
            {
                Clipboard.SetText(gpa.ToString(CultureInfo.InvariantCulture));
                return true;
            }
            catch (ExternalException)
            {
                return false;
            }
        }

        private void PopulateLanguageComboBox()
        {
            LanguageData[] locales;
            try
            {
                locales = Settings.GetAvailableLocales().ToArray();
            }
            catch (LocalizationLoadException ex)
            {
                ErrorMsgBox(_localization.LocaleRefreshFailMessage(ex));
                return;
            }
            _suppressLocaleChange = true;
            languageComboBox.Items.Clear();
            // ReSharper disable once CoVariantArrayConversion
            languageComboBox.Items.AddRange(locales);
            //FirstOrDefault will return null if the selected locale no longer exists.
            //That means that the user will see a blank ComboBox. This is better than 
            //the alternative, which is having their locale automatically changed.
            languageComboBox.SelectedItem = locales.FirstOrDefault(l => l.Key == _localization.LanguageKey);
            _suppressLocaleChange = false;
        }

        private void UpdateLocale()
        {
            if (_suppressLocaleChange) return;
            string locale = ((LanguageData)languageComboBox.SelectedItem).Key;
            try
            {
                _localization = Settings.GetLocalizationObject(locale);
            }
            catch (LocalizationLoadException ex)
            {
                ErrorMsgBox(_localization.LocaleChangeFailMessage(ex));
                var locales = languageComboBox.Items.Cast<LanguageData>();
                _suppressLocaleChange = true;
                languageComboBox.SelectedItem = locales.FirstOrDefault(l => l.Key == _localization.LanguageKey);
                _suppressLocaleChange = false;
                return;
            }
            RefreshControlLocalization();
        }

        private void RefreshGpaLabel()
        {
            if (!gradesTabControl.AllScoresEntered)
            {
                gpaLabel.Text = _localization.EnterAllScores();
                return;
            }
            if (!gradesTabControl.AllScoresValid)
            {
                gpaLabel.Text = _localization.EnterValidScores();
                return;
            }
            double gpa = gradesTabControl.Grades.SelectedGrade.FinalGpa;
            gpaLabel.Text = _localization.YourGpaIs(gpa);
        }

        private void CopyGpaSetButtonText(double gpa)
        {
            bool success = CopyGpaToClipboard(gpa);
            copyButton.Text = success ? _localization.CopiedToClipboard() : _localization.CopyFailed();
        }

        private void ToggleOptions()
        {
            if (_optionsExpanded)
            {
                Height = _miniHeight;
                _optionsExpanded = false;
            }
            else
            {
                Height = _fullHeight;
                _optionsExpanded = true;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_shouldSaveConfig)
            {
                Settings.SaveConfig(_grades, _localization, _settings);
            }
            base.OnClosing(e);
        }

        private void AboutButtonClick(object sender, EventArgs e)
        {
            InfoMsgBox(_localization.AboutMessage(Version));
        }

        private void CopyButtonMouseEnter(object sender, EventArgs e)
        {
            copyButton.Text = _localization.CopyToClipboard();
        }

        private void CopyButtonClick(object sender, MouseEventArgs e)
        {
            if (!gradesTabControl.AllScoresEntered) return;
            if (!gradesTabControl.AllScoresValid) return;
            double gpa = gradesTabControl.Grades.SelectedGrade.FinalGpa;
            CopyGpaSetButtonText(gpa);
        }

        private void OptionsButtonClick(object sender, EventArgs e)
        {
            ToggleOptions();
        }

        private void OpenTemplatesButtonClick(object sender, EventArgs e)
        {
            Process.Start(TextEditorPath, "templates.xml");
        }

        private void OpenCoursesButtonClick(object sender, EventArgs e)
        {
            Process.Start(TextEditorPath, "courses.xml");
        }

        private void OpenLocalizationButtonClick(object sender, EventArgs e)
        {
            Process.Start(TextEditorPath, "localization.xml");
        }

        private void LanguageComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLocale();
        }

        private void AutoClearCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            bool autoClear = autoClearCheckBox.Checked;
            _settings.AutoClear = autoClear;
            gradesTabControl.AutoClear = autoClear;
        }

        private void AutoCopyCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            bool autoCopy = autoCopyCheckBox.Checked;
            _settings.AutoCopy = autoCopy;
        }

        private void LanguageRefreshButtonClick(object sender, EventArgs e)
        {
            PopulateLanguageComboBox();
        }

        private void GpaUpdated(object sender, EventArgs e)
        {
            RefreshGpaLabel();
            if (gradesTabControl.AllScoresValid && _settings.AutoCopy)
            {
                double gpa = gradesTabControl.Grades.SelectedGrade.FinalGpa;
                CopyGpaSetButtonText(gpa);
            }
            else
            {
                copyButton.Text = _localization.CopyToClipboard();
            }
        }
    }
}