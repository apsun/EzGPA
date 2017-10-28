using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public sealed class CoursePanel : Panel
    {
        private readonly Course _course;
        private readonly INameControl _nameControl;
        private readonly ComboBox _groupComboBox;
        private readonly ComboBox _levelComboBox;
        private readonly IScoreControl _scoreControl;

        private bool _suppressUpdate;
        private bool _suppressEvents;

        public event EventHandler<EventArgs> GpaUpdated;

        private void OnGpaUpdated(object sender, EventArgs e)
        {
            if (_suppressEvents) return;
            Debug.WriteLine("GPA update event fired");
            EventHandler<EventArgs> handler = GpaUpdated;
            if (handler != null) handler(sender, e);
        }

        private void OnEnabledUpdated(object sender, EventArgs e)
        {
            if (_suppressUpdate) return;
            Debug.WriteLine("Enabled status event fired");
            _course.Enabled = _nameControl.Checked;
            OnGpaUpdated(sender, e);
        }

        private void OnGroupUpdated(object sender, EventArgs e)
        {
            if (_suppressUpdate) return;
            Debug.WriteLine("Group update event fired");
            GroupWrapper prevGroup = _course.SelectedGroup;
            GroupWrapper newGroup = (GroupWrapper)_groupComboBox.SelectedItem;
            if (prevGroup == newGroup) return;
            _course.SelectedGroup = newGroup;
            _levelComboBox.Items.Clear();
            // ReSharper disable once CoVariantArrayConversion
            _levelComboBox.Items.AddRange(_course.SelectedGroup.Levels);
            _suppressEvents = true;
            _levelComboBox.SelectedIndex = 0;
            _suppressEvents = false;
            OnGpaUpdated(sender, e);
        }

        private void OnLevelUpdated(object sender, EventArgs e)
        {
            if (_suppressUpdate) return;
            Debug.WriteLine("Level update event fired");
            LevelWrapper prevLevel = _course.SelectedLevel;
            LevelWrapper newLevel = (LevelWrapper)_levelComboBox.SelectedItem;
            if (prevLevel == newLevel) return;
            _course.SelectedLevel = newLevel;
            OnGpaUpdated(sender, e);
        }

        private void OnScoreUpdated(object sender, EventArgs e)
        {
            if (_suppressUpdate) return;
            Debug.WriteLine("Score update event fired");
            // ReSharper disable once PossibleInvalidOperationException
            _course.Score = _scoreTextBox.Value;
            OnGpaUpdated(sender, e);
        }

        public CoursePanel(Course course)
        {
            CheckBox enabledCheckBox = new CheckBox();
            ComboBox groupComboBox = course.HasGroups ? new ComboBox() : null;
            ComboBox levelComboBox = course.HasLevels ? new ComboBox() : null;
            IntegerTextBox scoreTextBox = new IntegerTextBox();
            CoursePanel panel = new CoursePanel(course, enabledCheckBox, groupComboBox, levelComboBox, scoreTextBox);

            panel.SuspendLayout();
            panel.Location = new Point(3, 3);
            panel.Size = new Size(346, 27);

            enabledCheckBox.AutoSize = true;
            enabledCheckBox.Location = new Point(3, 3);
            enabledCheckBox.TabStop = false;
            enabledCheckBox.UseVisualStyleBackColor = true;
            panel.Controls.Add(enabledCheckBox);

            if (groupComboBox != null)
            {
                groupComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                groupComboBox.Location = new Point(106, 3);
                groupComboBox.Size = new Size(100, 21);
                groupComboBox.TabStop = false;
                panel.Controls.Add(groupComboBox);
            }

            if (levelComboBox != null)
            {
                levelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                levelComboBox.Location = new Point(212, 3);
                levelComboBox.Size = new Size(100, 21);
                levelComboBox.TabStop = false;
                panel.Controls.Add(levelComboBox);
            }

            scoreTextBox.Location = new Point(318, 3);
            scoreTextBox.Size = new Size(25, 20);
            scoreTextBox.TabStop = true;
            scoreTextBox.TextAlign = HorizontalAlignment.Center;
            scoreTextBox.AutoClear = true;
            scoreTextBox.MinValue = 0;
            scoreTextBox.MaxValue = 100;
            panel.Controls.Add(scoreTextBox);

            panel.ResumeLayout(false);
            panel.PerformLayout();

            _course = new CourseWrapper(course);
            _nameControl = enabledCheckBox;
            _groupComboBox = groupComboBox;
            _levelComboBox = levelComboBox;
            _scoreTextBox = scoreTextBox;

            // ReSharper disable once CoVariantArrayConversion
            if (course.HasGroups) _groupComboBox.Items.AddRange(_course.Groups);

            enabledCheckBox.CheckedChanged += OnEnabledUpdated;
            if (groupComboBox != null) groupComboBox.SelectedIndexChanged += OnGroupUpdated;
            if (levelComboBox != null) levelComboBox.SelectedIndexChanged += OnLevelUpdated;
            scoreTextBox.TextChanged += OnScoreUpdated;

            //Now we can load the dataz!
            _suppressUpdate = true;

            enabledCheckBox.Checked = _course.Enabled;
            scoreTextBox.Text = _course.Score.ToString();

            if (groupComboBox != null)
            {
                if (_course.SelectedGroup == null)
                {
                    //Default to first group if there is no group selected 
                    //and there are groups available
                    _course.SelectedGroup = _course.Groups[0];
                }
                groupComboBox.SelectedItem = _course.SelectedGroup;
            }
            else if (levelComboBox != null)
            {
                _course.SelectedGroup = _course.Groups[0];
            }

            if (levelComboBox != null)
            {
                _levelComboBox.Items.Clear();
                // ReSharper disable once CoVariantArrayConversion
                _levelComboBox.Items.AddRange(_course.SelectedGroup.Levels);
                if (_course.SelectedLevel == null)
                {
                    _course.SelectedLevel = _course.SelectedGroup.Levels[0];
                }
                levelComboBox.SelectedItem = _course.SelectedLevel;
            }

            _suppressUpdate = false;
        }

        public void UpdateLocalization(Localization localizationData)
        {
            _suppressUpdate = true;
            if (_groupComboBox != null)
            {
                _groupComboBox.DisplayMember = null;
                _groupComboBox.DisplayMember = "Name";
            }
            if (_levelComboBox != null)
            {
                _levelComboBox.DisplayMember = null;
                _levelComboBox.DisplayMember = "Name";
            }
            _suppressUpdate = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _nameControl.CheckedChanged -= OnEnabledUpdated;
                if (_groupComboBox != null) _groupComboBox.SelectedIndexChanged -= OnGroupUpdated;
                if (_levelComboBox != null) _levelComboBox.SelectedIndexChanged -= OnLevelUpdated;
                _scoreTextBox.TextChanged -= OnScoreUpdated;
            }

            base.Dispose(disposing);
        }
    }
}