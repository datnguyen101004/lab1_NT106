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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String[] arrRes = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            int num1;
            try
            {
                String val1 = textBox1.Text.Trim();
                if (Int32.TryParse(val1, out num1) )
                {
                    num1 = Int32.Parse(val1);
                    if ((num1>=0) && (num1 <= 9))
                    {
                        textBox2.Text = arrRes[num1];
                    }
                    else
                    {
                        MessageBox.Show("Nhập số từ 0 đến 9");
                    }
                }
                else
                {
                    MessageBox.Show("invalid input");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
