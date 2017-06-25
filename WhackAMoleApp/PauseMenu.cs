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
    public partial class PauseMenu : Form
    {
        Settings _formSettings = new Settings();

        public bool WillQuit { get; set; } = false;
        public bool WillRestart { get; set; } = false;

        public PauseMenu()
        {
            InitializeComponent();
            CenterToScreen();
            SetupControls();
        }

        void SetupControls()
        {

            btnSettings.Click += (o, e) => {

                _formSettings.OnSettingsChanged += control =>
                {
                    if (control.GetType() == typeof(TrackBar))
                    {
                        TrackBar volCtr = control as TrackBar;
                        MusicManager.Volume = volCtr.Value / 100f;
                    }
                };

                _formSettings.ShowDialog();

            };

            btnRestart.Click += (o, e) => {
                WillRestart = true;
                Close();
            };

            btnQuit.Click += (o, e) => {
                WillQuit = true;
                Close();
            };

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
