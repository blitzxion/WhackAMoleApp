﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhackAMoleApp
{
    public partial class Settings : Form
    {
        public event Action<Control> OnSettingsChanged;
        public event Action<AppSettings> OnSettingsSaved;


        public Settings()
        {
            InitializeComponent();
            CenterToParent();

            SetupControls();
            LoadFromSettings();
        }

        public void SetupControls()
        {
            cmbDifficulty.DataSource = new BindingSource(Enum.GetNames(typeof(GameDifficultyTypes)), null);

            btnClearScores.Click += (o, args) =>
            {
                if (MessageBox.Show(this, "Are you sure you want to clear all high scores?", "Clear High Scores", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    ClearHighScores();
            };

            btnSave.Click += (o, args) =>
            {
                SaveSettings();
                Close();
            };

            btnCancel.Click += (o, args) => Close();

            cmbDifficulty.SelectedValueChanged += (o, e) => { OnSettingsChanged?.Invoke(cmbDifficulty); };

            txtPlayerName.TextChanged += (o, e) => OnSettingsChanged?.Invoke(txtPlayerName);

            tbVolume.ValueChanged += (o, e) =>
            {
                OnSettingsChanged?.Invoke(tbVolume);
                MusicManager.Volume = tbVolume.Value / 100f;
            };
        }

        void ClearHighScores()
        {
            // This is by far the worst way of doing this.
            using (var context = new HighScoreContext())
            {
                var entities = context.HighScores;
                context.HighScores.RemoveRange(entities);
                context.SaveChanges(); 
            }
        }

        void LoadFromSettings()
        {
            var settings = AppSettings.Load();
            cmbDifficulty.SelectedItem = settings.Difficulty.ToString();
            txtPlayerName.Text = settings.PlayerName;
            tbVolume.Value = (int)settings.Volume;
        }

        void SaveSettings()
        {
            var settings = AppSettings.Load();
            settings.Difficulty = cmbDifficulty.SelectedItem.ToEnumOrDefault(GameDifficultyTypes.NORMAL);
            settings.PlayerName = txtPlayerName.Text;
            settings.Volume = tbVolume.Value;
            settings.Save();

            OnSettingsSaved?.Invoke(settings);
        }

    }
}
