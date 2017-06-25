using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace WhackAMoleApp
{
    public partial class Main : Form
    {
        FormSingleton<Game> _gameForm = new FormSingleton<Game>();
        HighScores _frmHighScores = new HighScores();
        Settings _formSettings = new Settings();

        public Main()
        {
            InitializeComponent();
            SetupControls();
            CenterToScreen();
        }

        public void SetupControls()
        {
            lnkAbout.Click += (e, v) => Process.Start("http://richardshaw.us");

            btnNewGame.Click += (e, v) =>
            {
                MusicManager.MenuMusic.Stop();
                Hide();
                var form = _gameForm.GetForm;
                form.Closed += (s, args) => Show();
                form.Show();
            };


            btnScores.Click += (e, v) =>
            {
                _frmHighScores.ShowDialog();
                _frmHighScores.Focus();
            };


            btnSettings.Click += (e, v) =>
            {
                _formSettings.ShowDialog();
                _formSettings.Focus();
            };

            // When the settings form makes a change, lets do something about it.
            _formSettings.OnSettingsChanged += control =>
            {
                if (control.GetType() == typeof(TrackBar))
                {
                    TrackBar volCtr = control as TrackBar;
                    MusicManager.Volume = volCtr.Value / 100f;
                }
            };

            // Do stuff with the music based off the status of our form
            Activated += (o, e) => MusicManager.MenuMusic.Play();
            FormClosing += (o, e) => MusicManager.MenuMusic.Stop();
        }

    }
}
