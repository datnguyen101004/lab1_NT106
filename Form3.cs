using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1, num2, num3, min, max;
            try
            {

                {
                    String val1 = textBox1.Text.Trim();
                    String val2 = textBox2.Text.Trim();
                    String val3 = textBox3.Text.Trim();

                    if (double.TryParse(val1, out num1) && double.TryParse(val2, out num2) && double.TryParse(val3, out num3))
                    {
                        num1 = double.Parse(Convert.ToDouble(textBox1.Text, new CultureInfo("uk-UA")).ToString(new CultureInfo("en-US")));
                        num2 = double.Parse(Convert.ToDouble(textBox2.Text, new CultureInfo("uk-UA")).ToString(new CultureInfo("en-US")));
                        num3 = double.Parse(Convert.ToDouble(textBox3.Text, new CultureInfo("uk-UA")).ToString(new CultureInfo("en-US")));
                        min = Math.Min(num1, num2);
                        min = Math.Min(min, num3);
                        max = Math.Max(num1, num2);
                        max = Math.Max(max, num3);
                        textBox4.Text = min.ToString();
                        textBox5.Text = max.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid input");
                    }
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
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
