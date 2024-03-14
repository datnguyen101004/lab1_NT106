using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Form2 f2 = new Form2();
        Form3 f3 = new Form3();
        Form4 f4 = new Form4();
        Form5 f5 = new Form5();
        Form6 f6 = new Form6();
        Form7 f7 = new Form7();

        private void button1_Click(object sender, EventArgs e)
        {
            f2.Hide();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            f5.Hide();
            f5.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f3.Hide();
            f3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f4.Hide();
            f4.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            f6.Hide();
            f6.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            f7.Hide();
            f7.ShowDialog();
        }
    }
}
