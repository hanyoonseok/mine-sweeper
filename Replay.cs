using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid
{
    public partial class Replay : Form
    {
        string text;
        Form1 form1 = new Form1();
        public Replay(string isWin)
        {
            InitializeComponent();
            this.text = isWin;
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {}

        private void Replay_Load(object sender, EventArgs e)
        {
            label2.Text = text;
        }
    }
}
