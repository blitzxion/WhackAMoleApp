using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        Random _rnd { get; set; } = new Random();

        IEnumerable<Stream> _sounds { get; set; } = new List<Stream>();

        public Settings()
        {
            InitializeComponent();
            CenterToParent();

            SetupControls();
            LoadFromSettings(AppSettings.Load());
        }

        public void SetupControls()
        {
            LoadSounds();

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

            tbBGMVolume.ValueChanged += (o, e) =>
            {
                OnSettingsChanged?.Invoke(tbBGMVolume);
                MusicManager.BGMVolume = tbBGMVolume.Value / 100f;
            };

            tbSFXVolume.ValueChanged += (o, e) =>
            {
                OnSettingsChanged?.Invoke(tbSFXVolume);
                MusicManager.SFXVolume = tbSFXVolume.Value / 100f;
            };

            tbSFXVolume.MouseUp += (o, e) => {
                var rndSound = _sounds.ElementAt(_rnd.Next(_sounds.Count()));
                MusicManager.GetSound(rndSound).Play();
            };

            lnkLoadDefaults.Click += (o, e) => LoadFromSettings(new AppSettings());

            // Always make sure we apply the latest changes when leaving settings
            FormClosing += (o, e) => LoadFromSettings(AppSettings.Load());

        }

        void LoadSounds()
        {
            _sounds = new List<Stream>() {
                Properties.Resources.Yipe,
                Properties.Resources.Yipe2,
                Properties.Resources.Yipe3,
                Properties.Resources.Ugh,
                Properties.Resources.Ugh2
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

        void LoadFromSettings(AppSettings settings)
        {
            cmbDifficulty.SelectedItem = settings.Difficulty.ToString();
            txtPlayerName.Text = settings.PlayerName;
            tbBGMVolume.Value = (int)settings.BGMVolume;
            tbSFXVolume.Value = (int)settings.SFXVolume;
        }

        void SaveSettings()
        {
            var settings = AppSettings.Load();
            settings.Difficulty = cmbDifficulty.SelectedItem.ToEnumOrDefault(GameDifficultyTypes.NORMAL);
            settings.PlayerName = txtPlayerName.Text;
            settings.BGMVolume = tbBGMVolume.Value;
            settings.SFXVolume = tbSFXVolume.Value;
            settings.Save();

            OnSettingsSaved?.Invoke(settings);
        }

    }
}
