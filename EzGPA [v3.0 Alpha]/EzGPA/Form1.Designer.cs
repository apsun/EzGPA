using EzGPA.Controls;

namespace EzGPA
{
    sealed partial class Form1
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
            this.gpaLabel = new System.Windows.Forms.Label();
            this.copyButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.optionsButton = new System.Windows.Forms.Button();
            this.autoClearCheckBox = new System.Windows.Forms.CheckBox();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.autoCopyCheckBox = new System.Windows.Forms.CheckBox();
            this.filesGroupBox = new System.Windows.Forms.GroupBox();
            this.openLocalizationButton = new System.Windows.Forms.Button();
            this.openDataButton = new System.Windows.Forms.Button();
            this.openConfigButton = new System.Windows.Forms.Button();
            this.helpTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.controlPanel.SuspendLayout();
            this.settingsGroupBox.SuspendLayout();
            this.filesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpaLabel
            // 
            this.gpaLabel.AutoSize = true;
            this.gpaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpaLabel.Location = new System.Drawing.Point(-3, 0);
            this.gpaLabel.Name = "gpaLabel";
            this.gpaLabel.Size = new System.Drawing.Size(180, 16);
            this.gpaLabel.TabIndex = 2;
            this.gpaLabel.Text = "Your GPA is: 23.36664289109";
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(0, 19);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(158, 23);
            this.copyButton.TabIndex = 1;
            this.copyButton.TabStop = false;
            this.copyButton.Text = "Copy to clipboard";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CopyButtonClick);
            this.copyButton.MouseEnter += new System.EventHandler(this.CopyButtonMouseEnter);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(265, 19);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(95, 23);
            this.aboutButton.TabIndex = 0;
            this.aboutButton.TabStop = false;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.AboutButtonClick);
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.optionsButton);
            this.controlPanel.Controls.Add(this.gpaLabel);
            this.controlPanel.Controls.Add(this.aboutButton);
            this.controlPanel.Controls.Add(this.copyButton);
            this.controlPanel.Location = new System.Drawing.Point(12, 338);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(360, 42);
            this.controlPanel.TabIndex = 4;
            // 
            // optionsButton
            // 
            this.optionsButton.Location = new System.Drawing.Point(164, 19);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(95, 23);
            this.optionsButton.TabIndex = 3;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.OptionsButtonClick);
            // 
            // autoClearCheckBox
            // 
            this.autoClearCheckBox.AutoSize = true;
            this.autoClearCheckBox.Location = new System.Drawing.Point(11, 23);
            this.autoClearCheckBox.Name = "autoClearCheckBox";
            this.autoClearCheckBox.Size = new System.Drawing.Size(148, 17);
            this.autoClearCheckBox.TabIndex = 0;
            this.autoClearCheckBox.Text = "Automatically clear scores";
            this.autoClearCheckBox.UseVisualStyleBackColor = true;
            this.autoClearCheckBox.CheckedChanged += new System.EventHandler(this.AutoClearCheckBoxCheckedChanged);
            // 
            // languageComboBox
            // 
            this.languageComboBox.DisplayMember = "NameOrKey";
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Location = new System.Drawing.Point(91, 79);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(80, 21);
            this.languageComboBox.TabIndex = 2;
            this.languageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBoxSelectedIndexChanged);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.languageLabel);
            this.settingsGroupBox.Controls.Add(this.autoCopyCheckBox);
            this.settingsGroupBox.Controls.Add(this.languageComboBox);
            this.settingsGroupBox.Controls.Add(this.autoClearCheckBox);
            this.settingsGroupBox.Location = new System.Drawing.Point(12, 394);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(177, 106);
            this.settingsGroupBox.TabIndex = 6;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(6, 82);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(55, 13);
            this.languageLabel.TabIndex = 4;
            this.languageLabel.Text = "Language";
            // 
            // autoCopyCheckBox
            // 
            this.autoCopyCheckBox.AutoSize = true;
            this.autoCopyCheckBox.Location = new System.Drawing.Point(11, 48);
            this.autoCopyCheckBox.Name = "autoCopyCheckBox";
            this.autoCopyCheckBox.Size = new System.Drawing.Size(139, 17);
            this.autoCopyCheckBox.TabIndex = 3;
            this.autoCopyCheckBox.Text = "Automatically copy GPA";
            this.autoCopyCheckBox.UseVisualStyleBackColor = true;
            this.autoCopyCheckBox.CheckedChanged += new System.EventHandler(this.AutoCopyCheckBoxCheckedChanged);
            // 
            // filesGroupBox
            // 
            this.filesGroupBox.Controls.Add(this.openConfigButton);
            this.filesGroupBox.Controls.Add(this.openLocalizationButton);
            this.filesGroupBox.Controls.Add(this.openDataButton);
            this.filesGroupBox.Location = new System.Drawing.Point(195, 394);
            this.filesGroupBox.Name = "filesGroupBox";
            this.filesGroupBox.Size = new System.Drawing.Size(177, 106);
            this.filesGroupBox.TabIndex = 7;
            this.filesGroupBox.TabStop = false;
            this.filesGroupBox.Text = "Files (reload to see changes)";
            // 
            // openLocalizationButton
            // 
            this.openLocalizationButton.Location = new System.Drawing.Point(6, 48);
            this.openLocalizationButton.Name = "openLocalizationButton";
            this.openLocalizationButton.Size = new System.Drawing.Size(165, 23);
            this.openLocalizationButton.TabIndex = 2;
            this.openLocalizationButton.Text = "Localization";
            this.openLocalizationButton.UseVisualStyleBackColor = true;
            this.openLocalizationButton.Click += new System.EventHandler(this.OpenLocalizationButtonClick);
            // 
            // openDataButton
            // 
            this.openDataButton.Location = new System.Drawing.Point(6, 19);
            this.openDataButton.Name = "openDataButton";
            this.openDataButton.Size = new System.Drawing.Size(165, 23);
            this.openDataButton.TabIndex = 0;
            this.openDataButton.Text = "Data";
            this.openDataButton.UseVisualStyleBackColor = true;
            this.openDataButton.Click += new System.EventHandler(this.OpenTemplatesButtonClick);
            // 
            // openConfigButton
            // 
            this.openConfigButton.Location = new System.Drawing.Point(6, 77);
            this.openConfigButton.Name = "openConfigButton";
            this.openConfigButton.Size = new System.Drawing.Size(165, 23);
            this.openConfigButton.TabIndex = 3;
            this.openConfigButton.Text = "Config";
            this.openConfigButton.UseVisualStyleBackColor = true;
            // 
            // helpTooltip
            // 
            this.helpTooltip.IsBalloon = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(70, 124);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(91, 121);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 512);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.filesGroupBox);
            this.Controls.Add(this.settingsGroupBox);
            this.Controls.Add(this.controlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "EzGPA";
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.filesGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gpaLabel;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.CheckBox autoClearCheckBox;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.GroupBox filesGroupBox;
        private System.Windows.Forms.Button openLocalizationButton;
        private System.Windows.Forms.Button openDataButton;
        private System.Windows.Forms.CheckBox autoCopyCheckBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Button openConfigButton;
        private System.Windows.Forms.ToolTip helpTooltip;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}

