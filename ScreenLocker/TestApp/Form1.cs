using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TestApp
{
    public partial class Form1 : Form
    {

        String pass = String.Empty;
        string sourcePass = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                if (String.Equals(pass, sourcePass))
                {
                    this.Close();
                }
                else
                {
                    pass = "";
                }
            }
            else if (e.KeyChar==(char)Keys.Escape)
            {
                e.Handled = true;
                pass = "";
            }
            else
            {
                string value = e.KeyChar.ToString();
                pass += value;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("Log.txt"))
            {
                File.Create("Log.txt");
            }

            using (StreamReader sr=new StreamReader(@"Log.txt"))
            {
                sourcePass = sr.ReadToEnd();
            }
        }
    }
}
