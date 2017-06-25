using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMoleApp
{
    public interface IDifficulty
    {
        GameDifficultyTypes GameDifficulty { get; }
        TimeSpan GameDuration { get; }
        TimeSpan GameTickInterval { get; }
        double ShowChance { get; }
        TimeSpan ShowDuration { get; }
        TimeSpan HitDuration { get; }
        TimeSpan MissDuration { get; }
        double PointsPerHit { get; }
        double PointsLossPerMiss { get; }
    }

    public class Difficulty : IDifficulty
    {
        public GameDifficultyTypes GameDifficulty { get; private set; }
        public TimeSpan GameDuration { get; private set; }
        public TimeSpan GameTickInterval { get; private set; }
        public double ShowChance { get; private set; }
        public TimeSpan ShowDuration { get; private set; }
        public TimeSpan HitDuration { get; private set; }
        public TimeSpan MissDuration { get; private set; }
        public double PointsPerHit { get; private set; }
        public double PointsLossPerMiss { get; private set; }

        public Difficulty()
        {
            GameDifficulty = GameDifficultyTypes.NORMAL;
            GameDuration = TimeSpan.FromMinutes(1);
            GameTickInterval = TimeSpan.FromSeconds(1); // Normally, every 1 second.
            ShowChance = 10d.PercOf(100);
            ShowDuration = TimeSpan.FromSeconds(5);
            HitDuration = TimeSpan.FromSeconds(1);
            MissDuration = TimeSpan.FromSeconds(1);

            PointsPerHit = 10;
            PointsLossPerMiss = 5;
        }


        public static Difficulty FromType(GameDifficultyTypes gameType)
        {
            var diff = new Difficulty()
            {
                GameDifficulty = gameType
            };


            switch (diff.GameDifficulty)
            {
                case GameDifficultyTypes.EASY:
                    diff.ShowChance = 20d.PercOf(100);
                    diff.ShowDuration = TimeSpan.FromSeconds(7);
                    break;
                case GameDifficultyTypes.HARD:
                    diff.ShowDuration = TimeSpan.FromMilliseconds(800);
                    diff.GameTickInterval = TimeSpan.FromMilliseconds(800);
                    break;
                case GameDifficultyTypes.INSANE:
                    diff.ShowDuration = TimeSpan.FromMilliseconds(700);
                    diff.GameTickInterval = TimeSpan.FromMilliseconds(700);
                    break;
                case GameDifficultyTypes.NIGHTMARE:
                    diff.ShowDuration = TimeSpan.FromMilliseconds(600);
                    diff.GameTickInterval = TimeSpan.FromMilliseconds(600);
                    break;
                case GameDifficultyTypes.HELL:

                    var ts = TimeSpan.FromMilliseconds(500);

                    diff.ShowDuration = ts;
                    diff.MissDuration = ts;
                    diff.HitDuration = ts;
                    diff.GameTickInterval = ts;
                    break;

                case GameDifficultyTypes.NORMAL:
                default:
                    // Nothing, we're already set
                    break;
            }


            return diff;
        }

    }

}
