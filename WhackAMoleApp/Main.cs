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

namespace WhackAMoleApp
{
    public partial class Main : Form
    {
        FormSingleton<Game> GameForm { get; set; } = new FormSingleton<Game>();

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
                Hide();
                var form = GameForm.GetForm;
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
                form.ShowDialog();
                form.Focus();
            };


        }

    }
}
