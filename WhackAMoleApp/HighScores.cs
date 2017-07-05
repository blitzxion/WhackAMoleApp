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
    public partial class HighScores : BaseForm
    {
        public HighScores()
        {
            InitializeComponent();
            SetupControls();
            CenterToScreen();
        }

        void SetupControls()
        {
            using (var context = new HighScoreContext())
            {
                var scores = context.HighScores.OrderByDescending(x => x.Id).ToList();
                scores.ForEach(score => {
                    dataGrid.Rows.Add(score.Entered.ToShortDateString(), score.Name, score.Difficulty, score.TotalMoles, score.TotalHit, score.TotalMissed, score.Score);
                });
            }

        }

    }
}
