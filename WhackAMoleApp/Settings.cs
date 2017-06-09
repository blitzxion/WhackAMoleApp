using System;
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

            btnCancel.Click += (o, args) => 
            {
                Close();
            };

        }

        void ClearHighScores()
        {

        }

        void LoadFromSettings()
        {
            var settings = AppSettings.Load();
            cmbDifficulty.SelectedItem = settings.Difficulty.ToString();
            txtPlayerName.Text = settings.PlayerName;
        }

        void SaveSettings()
        {
            var settings = AppSettings.Load();
            settings.Difficulty = cmbDifficulty.SelectedItem.ToEnumOrDefault(GameDifficultyTypes.NORMAL);
            settings.PlayerName = txtPlayerName.Text;
            settings.Save();
        }

    }
}
