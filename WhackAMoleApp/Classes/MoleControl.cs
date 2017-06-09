using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhackAMoleApp
{
    public class MoleControl
    {
        public readonly PictureBox Control;

        public MoleStates State { get; private set; }

        DateTime InStateSince { get; set; }

        public double ChanceToShow { get; set; } = 1;
        public double DurationShow { get; set; } = 2;
        public double DurationHit { get; set; } = 1;
        public double DurationMissed { get; set; } = 1;

        public event Action OnHit;
        public event Action OnMiss;
        public event Action OnShow;

        public MoleControl(PictureBox control)
        {
            Control = control;

            Control.Click += Control_Click;

            ChangeMoleState(MoleStates.Hiding);
        }

        private void Control_Click(object sender, EventArgs e)
        {

            switch (State)
            {
                case MoleStates.Hiding:
                case MoleStates.Hit:
                case MoleStates.Missed:
                default:
                    break;
                case MoleStates.Shown:

                    ChangeMoleState(MoleStates.Hit);

                    break;
            }

        }

        public void Reset()
        {
            ChangeMoleState(MoleStates.Hiding);
        }

        public void DoWork(Random _random)
        {
            switch (State)
            {
                case MoleStates.Hiding:

                    // If you're less than our chance, then i'll show
                    if (_random.NextDouble() < ChanceToShow)
                        ChangeMoleState(MoleStates.Shown);

                    break;
                case MoleStates.Shown:

                    if ((DateTime.Now - InStateSince).TotalSeconds < DurationShow)
                        return;

                    ChangeMoleState(MoleStates.Missed);

                    break;
                case MoleStates.Hit:

                    if ((DateTime.Now - InStateSince).TotalSeconds < DurationHit)
                        return;

                    ChangeMoleState(MoleStates.Hiding);

                    break;
                case MoleStates.Missed:

                    if ((DateTime.Now - InStateSince).TotalSeconds < DurationMissed)
                        return;

                    ChangeMoleState(MoleStates.Hiding);

                    break;
                default:
                    break;
            }

        }

        public void ChangeMoleState(MoleStates state)
        {
            var previousState = State;
            State = state;

            switch (state)
            {
                case MoleStates.Hiding:

                    SetImage(Properties.Resources.holeNoMole);

                    break;
                case MoleStates.Shown:

                    SetImage(Properties.Resources.holeWithMole);
                    OnShow?.Invoke();

                    break;
                case MoleStates.Hit:

                    SetImage(Properties.Resources.holeWithMoleHit);
                    OnHit?.Invoke();

                    break;
                case MoleStates.Missed:

                    SetImage(Properties.Resources.holeMissed);
                    OnMiss?.Invoke();

                    break;
                default:
                    break;
            }

            InStateSince = DateTime.Now;

        }

        void SetImage(Image image)
        {
            Control.BackgroundImage = image;
        }

    }
}
