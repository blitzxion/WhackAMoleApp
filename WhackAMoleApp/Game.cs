using NAudio.Wave;
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

        //List<WaveSound> _sounds { get; set; } = new List<WaveSound>();
        IEnumerable<Stream> _sounds { get; set; } = new List<Stream>();

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
            
            Activated += (o, e) => MusicManager.GameMusic.Play();
            FormClosing += (o, e) => MusicManager.GameMusic.Stop();
        }

        void Reset()
        {
            _molesControls.ForEach(x => x.Reset());

            _gameStarted = DateTime.MinValue;
            _gameEndTime = DateTime.MinValue;

            _totalMolesHit = 0;
            _totalMolesMissed = 0;
            _totalMolesSeen = 0;

            _gameTimer.Tick -= GameWorker;

        }

        void Start()
        {
            _gameTimer.Tick += GameWorker;

            // Setup when we started and how long should we play for
            _gameStarted = DateTime.UtcNow;
            _gameEndTime = _gameStarted.Add(_difficulty.GameDuration);

            _gameTimer.Start();
        }

        void GameWorker(Object obj, EventArgs args)
        {
            TimeSpan remainingTime = _gameEndTime - DateTime.UtcNow;

            lblTime.Text = remainingTime.ToString("mm\\:ss");

            if (remainingTime < TimeSpan.Zero)
            {
                GameOver();
                return;
            }

            // This will control the actions of the mole, by chance
            _molesControls.ForEach(x =>
            {
                x.DoWork(_gameRNG);
            });
        }

        void UpdateTotals()
        {

            lblSeen.Text = _totalMolesSeen.ToString();
            lblScore.Text = TotalPoints.ToString();
            lblMissed.Text = _totalMolesMissed.ToString();
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

        void HitSound()
        {
            // _sounds[_gameRNG.Next(_sounds.Count)].Play();

            var newSound = new MemoryStream();
            var selectedSound = _sounds.ElementAt(_gameRNG.Next(_sounds.Count()));

            // Copy the sound to the selected sound
            selectedSound.CopyTo(newSound);

            // Must reset this, otherwise, crap happens.
            newSound.Position = 0;
            selectedSound.Position = 0;

            var wave = new WaveSound(newSound) { Volume = _settings.Volume / 100 };
            wave.OnPlaybackStopped += () => { wave.Dispose(); };
            wave.Play();
        }

        void GameOver()
        {
            _gameTimer.Stop();
            var scoreAsk = MessageBox.Show("Game over! Would you like to submit your score?", "Game Over!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            if (scoreAsk == DialogResult.Yes)
            {
                using (var context = new HighScoreContext())
                {
                    context.HighScores.Add(new HighScore()
                    {
                        Entered = DateTime.UtcNow,
                        Name = _settings.PlayerName,
                        Difficulty = _settings.Difficulty.ToString(),
                        Score = TotalPoints,
                        TotalMoles = _totalMolesSeen,
                        TotalHit = _totalMolesHit,
                        TotalMissed = _totalMolesMissed
                    });
                    context.SaveChanges();
                }

                var hsForm = new HighScores();
                hsForm.ShowDialog();
            }

            Close();
        }

        void Pause()
        {
            _gameTimer.Stop();

            PauseMenu _pauseMenu = new PauseMenu();
            _pauseMenu.FormClosing += (o, evt) => {

                if (_pauseMenu.WillQuit)
                {
                    GameOver();
                    return;
                }

                if (_pauseMenu.WillRestart)
                {
                    Reset();
                    Start();
                    return;
                }

                _gameTimer.Start();
            };

            _pauseMenu.ShowDialog();
            _pauseMenu.Focus();

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Pause();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }

}
