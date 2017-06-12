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
        FormSingleton<Game> _gameForm { get; set; } = new FormSingleton<Game>();

        Mp3Sound _menuMusic { get; set; }

        public Main()
        {
            InitializeComponent();
            SetupControls();
            CenterToScreen();
        }

        public void SetupControls()
        {
            lnkAbout.Click += (e, v) => {
                Process.Start("http://richardshaw.us");
            };

            btnNewGame.Click += (e,v) => {

                _menuMusic.Stop();

                Hide();
                var form = _gameForm.GetForm;
                form.Closed += (s, args) => Show();
                form.Show();
            };

            btnScores.Click += (e, v) =>
            {
                var form = new HighScores();
                form.ShowDialog();
                form.Focus();
            };

            btnSettings.Click += (e, v) => {
                var form = new Settings();

                form.OnSettingsChanged += control => {
                    if(control.GetType() == typeof(TrackBar))
                    {
                        TrackBar volCtr = control as TrackBar;
                        _menuMusic.Volume = volCtr.Value / 100;
                    }
                };

                form.ShowDialog();
                form.Focus();
            };


            _menuMusic = new Mp3Sound(new MemoryStream(Properties.Resources.menu)) {
                EnableLoop = true,
                Volume = (AppSettings.Load().Volume / 100)
            };

            Activated += (o, e) => _menuMusic.Play();
            FormClosing += (o, e) => _menuMusic.Stop();
        }

    }
}
