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
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        Form3 form3 = new Form3();
        Form4 form4 = new Form4();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if(btn_Cho.Checked == true)
            {
                this.Hide();
                form2.ShowDialog();
                this.Close();
                form3.Close();
                form4.Close();
            }
            else if(btn_Jung.Checked == true)
            {
                this.Hide();
                form3.ShowDialog();
                this.Close();
                form2.Close();
                form4.Close();
            }
            else
            {
                this.Hide();
                form4.ShowDialog();
                this.Close();
                form2.Close();
                form3.Close();
            }
        }
    }
}
