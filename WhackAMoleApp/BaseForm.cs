using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhackAMoleApp
{
    public abstract class BaseForm : Form
    {
        public BaseForm()
        {
            this.Icon = Properties.Resources.mole;
        }
    }
}
