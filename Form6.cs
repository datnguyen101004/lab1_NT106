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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String points = textBox1.Text.TrimEnd();
                String[] partPoints = points.Split(' ');
                double checkDouble;
                List<double> listPoint = new List<double>();
                foreach (String c in partPoints)
                {
                    if (!double.TryParse(c, out checkDouble))
                    {
                        throw new Exception("Điểm phải là số thập phân");
                    }
                }
                if (partPoints.Length < 12)
                {
                    throw new Exception("Không nhập đủ cột điểm");
                }

                if (partPoints.Length > 12)
                {
                    throw new Exception("Dư cột điểm hoặc dấu cách");
                }

                foreach (String s in partPoints)
                {
                    double num = double.Parse(s);
                    if (num < 0 || num > 10)
                    {
                        throw new Exception("Điểm nhập vào không hợp lệ");
                    }
                    listPoint.Add(num);
                }
                textBox2.Text = listPoint[0].ToString();
                textBox3.Text = listPoint[1].ToString();
                textBox4.Text = listPoint[2].ToString();
                textBox5.Text = listPoint[3].ToString();
                textBox6.Text = listPoint[4].ToString();
                textBox7.Text = listPoint[5].ToString();
                textBox8.Text = listPoint[6].ToString();
                textBox9.Text = listPoint[7].ToString();
                textBox10.Text = listPoint[8].ToString();
                textBox11.Text = listPoint[9].ToString();
                textBox12.Text = listPoint[10].ToString();
                textBox13.Text = listPoint[11].ToString();
                double diemTB = listPoint.Average();
                textBox14.Text = diemTB.ToString();
                if (diemTB >= 3.5 && diemTB <5 && listPoint.Min() >= 2)
                {
                    textBox17.Text = "Yếu";
                }
                else if (diemTB >=5 && diemTB <6.5 && listPoint.Min() >= 3.5)
                {
                    textBox17.Text = "TB";
                }
                else if (diemTB >= 5 && diemTB < 6.5 && listPoint.Min() < 3.5 && listPoint.Min() >=2)
                {
                    textBox17.Text = "Yếu";
                }
                else if (diemTB >= 6.5 && diemTB < 8 && listPoint.Min() >= 5)
                {
                    textBox17.Text = "Khá";
                }
                else if (diemTB >= 6.5 && diemTB < 8 && listPoint.Min() < 5 && listPoint.Min() >= 3.5)
                {
                    textBox17.Text = "TB";
                }
                else if (diemTB >= 6.5 && diemTB < 8 && listPoint.Min() < 3.5 && listPoint.Min() >= 2)
                {
                    textBox17.Text = "Yếu";
                }
                else if (diemTB >= 8 && listPoint.Min() >= 6.5)
                {
                    textBox17.Text = "Giỏi";
                }
                else if (diemTB >= 8 && listPoint.Min() < 6.5 && listPoint.Min() >= 5)
                {
                    textBox17.Text = "Khá";
                }
                else if (diemTB >= 8 && listPoint.Min() < 5 && listPoint.Min() >= 3.5)
                {
                    textBox17.Text = "TB";
                }
                else if (diemTB >= 8 && listPoint.Min() < 3.5 && listPoint.Min() >= 2)
                {
                    textBox17.Text = "Yếu";
                }
                else
                {
                    textBox17.Text = "Kém";
                }

                textBox15.Text = listPoint.Max().ToString();
                textBox16.Text = listPoint.Min().ToString();


                int flag = 0;
                foreach(double point in listPoint)
                {
                    if (point < 5) flag++;
                }

                textBox18.Text = (12 - flag).ToString();
                textBox19.Text = flag.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }    
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
        }
    }
}
