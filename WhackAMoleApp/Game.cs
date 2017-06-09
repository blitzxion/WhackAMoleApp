﻿using NAudio.Wave;
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
    public partial class Game : Form
    {
        Random _gameRNG { get; set; } = new Random();

        AppSettings _settings => AppSettings.Load();
        IDifficulty _difficulty => Difficulty.FromType(_settings.Difficulty);
        List<MoleControl> _molesControls { get; set; } = new List<MoleControl>();
        Timer _gameTimer { get; set; }

        DateTime _gameStarted { get; set; } = DateTime.MinValue;
        DateTime _gameEndTime { get; set; } = DateTime.MinValue;
        int _totalMolesSeen { get; set; } = 0;
        int _totalMolesHit { get; set; } = 0;
        int _totalMolesMissed { get; set; } = 0;

        List<WaveSound> Sounds { get; set; }


        double TotalPoints
        {
            get
            {
                var points = (_totalMolesHit * _difficulty.PointsPerHit) -
                       (_totalMolesMissed * _difficulty.PointsLossPerMiss);

                return points > 0 ? points : 0; // Zero is the lowest here
            }
        }

        public Game()
        {
            InitializeComponent();
            CenterToScreen();

            SetupControls();
            Reset();
            Start();
        }

        void SetupControls()
        {
            LoadSounds();

            // Create the timer
            _gameTimer = new Timer()
            {
                Interval = (int)_difficulty.GameTickInterval.TotalMilliseconds,
            };

            // Clear all btnMoles and prepare them for work
            tableLayoutPanel1.Controls.OfType<PictureBox>().ForEach(x =>
            {
                var mole = new MoleControl(x)
                {
                    ChanceToShow = _difficulty.ShowChance,
                    DurationShow = _difficulty.ShowDuration.TotalSeconds,
                    DurationHit = _difficulty.HitDuration.TotalSeconds,
                    DurationMissed = _difficulty.MissDuration.TotalSeconds
                };

                mole.OnShow += () => { _totalMolesSeen++; UpdateTotals(); };
                mole.OnHit += () => { _totalMolesHit++; UpdateTotals(); HitSound(); };
                mole.OnMiss += () => { _totalMolesMissed++; UpdateTotals(); };

                _molesControls.Add(mole);
            });
        }

        void Reset()
        {
            _molesControls.ForEach(x => x.Reset());

            _gameStarted = DateTime.MinValue;
            _gameEndTime = DateTime.MinValue;

            _totalMolesHit = 0;
            _totalMolesMissed = 0;
            _totalMolesSeen = 0;
        }

        void Start()
        {
            _gameTimer.Tick += (obj, args) =>
            {

                TimeSpan remainingTime = _gameEndTime - DateTime.UtcNow;

                lblTime.Text = remainingTime.ToString("mm\\:ss");

                if (remainingTime < TimeSpan.Zero)
                {
                    // TODO: Place this in a method of its own, do something with scores, etc.
                    _gameTimer.Stop();
                    MessageBox.Show("Game Over!");
                    return;
                }

                // This will control the actions of the mole, by chance
                _molesControls.ForEach(x =>
                {
                    x.DoWork(_gameRNG);
                });
            };

            // Setup when we started and how long should we play for
            _gameStarted = DateTime.UtcNow;
            _gameEndTime = _gameStarted.Add(_difficulty.GameDuration);

            _gameTimer.Start();
        }

        void UpdateTotals()
        {

            lblSeen.Text = _totalMolesSeen.ToString();
            lblScore.Text = TotalPoints.ToString();
            lblMissed.Text = _totalMolesMissed.ToString();
        }

        void LoadSounds()
        {
            var sounds = new List<UnmanagedMemoryStream>() {
                Properties.Resources.Yipe,
                Properties.Resources.Yipe2,
                Properties.Resources.Yipe3,
                Properties.Resources.Ugh,
                Properties.Resources.Ugh2
            };

            Sounds = new List<WaveSound>();

            sounds.ForEach(x => {
                Sounds.Add(new WaveSound(x));
            });

        }

        void HitSound()
        {

            var rndIndex = _gameRNG.Next(Sounds.Count);

            Sounds[rndIndex].Play();

            //System.Media.SoundPlayer sp = new System.Media.SoundPlayer(sounds[rndIndex]);
            //sp.Play();
            

        }

    }

}
