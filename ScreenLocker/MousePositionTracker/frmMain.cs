using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MousePositionTracker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            lblXPosition.Text = MousePosition.X.ToString();
            lblYPosition.Text = MousePosition.Y.ToString();
        }
    }
}
