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
    public partial class Main : BaseForm
    {        
        public Main()
        {
            InitializeComponent();
            SetupControls();
            CenterToScreen();
        }

        public void SetupControls()
        {
            lnkAbout.Click += (e, v) => Process.Start("http://richardshaw.us");

            btnScores.Click += (e, v) => (new HighScores()).ShowDialog();

            btnSettings.Click += (e, v) => (new Settings()).ShowDialog();

            btnNewGame.Click += (e, v) =>
            {
                MusicManager.MenuMusic.Stop();
                Hide();

                var gameForm = new Game();

                gameForm.Closed += (s, args) => Show();
                gameForm.ShowDialog();

                gameForm = null;
            };

            

            // Do stuff with the music based off the status of our form
            Activated += (o, e) => MusicManager.MenuMusic.Play(true);
            FormClosing += (o, e) => MusicManager.MenuMusic.Stop();
        }

    }
}
