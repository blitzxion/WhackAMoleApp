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
    public partial class Game : BaseForm
    {

        bool IsClosing { get; set; } = false;
        bool IsPausing { get; set; } = false;
        bool IsGameOver { get; set; } = false;

        Random _gameRNG { get; set; } = new Random();

        AppSettings _settings => AppSettings.Load();
        IDifficulty _difficulty => Difficulty.FromType(_settings.Difficulty);
        List<MoleControl> _molesControls { get; set; } = new List<MoleControl>();
        Timer _gameTimer { get; set; }
        Timer _actionTimer { get; set; }

        int _secondsSpentInGame { get; set; }
        int _totalMolesSeen { get; set; } = 0;
        int _totalMolesHit { get; set; } = 0;
        int _totalMolesMissed { get; set; } = 0;

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
            SetupControls();
            CenterToScreen();

            Reset();
            Start();
        }

        void SetupControls()
        {
            LoadSounds();

            // Create the game timer
            _gameTimer = new Timer()
            {
                Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds
            };

            // Create the action timer
            _actionTimer = new Timer()
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

            Activated += (o, e) => StartUp();
            FormClosing += (o, e) => Shutdown();
            Deactivate += (o, e) => Pause();
        }

        void Reset()
        {
            _molesControls.ForEach(x => x.Reset());

            _secondsSpentInGame = 0;

            _totalMolesHit = 0;
            _totalMolesMissed = 0;
            _totalMolesSeen = 0;

            _gameTimer.Tick -= GameTimerWorker;
            _actionTimer.Tick -= ActionTimerWorker;

        }

        void Start()
        {
            _gameTimer.Tick += GameTimerWorker;
            _actionTimer.Tick += ActionTimerWorker;

            _secondsSpentInGame = 0;

            _gameTimer.Start();
            _actionTimer.Start();
        }

        void GameTimerWorker(Object obj, EventArgs args)
        {
            _secondsSpentInGame++;

            TimeSpan remainingTime = _difficulty.GameDuration.Subtract(TimeSpan.FromSeconds(_secondsSpentInGame));

            lblTime.Text = remainingTime.ToString("mm\\:ss");

            if (remainingTime <= TimeSpan.Zero)
            {
                GameOver();
                return;
            }

        }

        void ActionTimerWorker(Object obj, EventArgs args)
        {
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
            var rndSound = _sounds.ElementAt(_gameRNG.Next(_sounds.Count()));
            MusicManager.GetSound(rndSound).Play();
        }

        void GameOver()
        {
            IsGameOver = true;

            _gameTimer.Stop();
            _actionTimer.Stop();

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
            if (IsPausing || IsClosing || IsGameOver)
                return;

            IsPausing = true;

            _gameTimer.Stop();
            _actionTimer.Stop();

            var pauseMenu = new PauseMenu();
            pauseMenu.FormClosing += (o, evt) =>
            {

                if (pauseMenu.WillQuit)
                {
                    GameOver();
                    return;
                }

                if (pauseMenu.WillRestart)
                {
                    Reset();
                    Start();
                    return;
                }

                IsPausing = false;

                _gameTimer.Start();
                _actionTimer.Start();
            };

            pauseMenu.ShowDialog();

        }

        void StartUp()
        {
            MusicManager.GameMusic.Play(true);
        }

        void Shutdown()
        {
            IsClosing = true;

            MusicManager.GameMusic.Stop();

            _gameTimer.Stop();
            _actionTimer.Stop();

            _gameTimer.Dispose();
            _actionTimer.Dispose();

            _gameTimer = null;
            _actionTimer = null;

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
