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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        String[] arrRes = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        private String readOneDigit(int number)
        {
            return arrRes[number];
        }

        private String readTwoDigit(int number)
        {
            String result = "";
            String subResult1 = "";
            String subResult2 = "";
            int subNum1 = number / 10;
            int subNum2 = number % 10;
            String str = "mốt";

            if (number == 10)
            {
                return result = "mười";
            }

            if (subNum1 == 1)
            {
                subResult1 = "mười ";
                subResult2 = readOneDigit(subNum2);
                result = subResult1 + subResult2;
            }
            else
            {
                subResult1 = readOneDigit(subNum1) + " mươi ";

                if (subNum2 == 1)
                {
                    result = subResult1 + str;
                    return result;
                }

                if (subNum2 == 0)
                {
                    result = subResult1;
                    return result;
                }

                if (subNum2 == 5)
                {
                    result = subResult1 + "lăm";
                    return result;
                }

                subResult2 = readOneDigit(subNum2);
                result = subResult1 + subResult2;

                return result;
            }   

            return result;
        }

        private String readThreeDigit(int number) {
            String result = "";
            String subResult1 = "";
            String subResult2 = "";

            int subNum1 = number / 100;
            int subNum2 = number - subNum1*100;
            subResult1 = readOneDigit(subNum1);

            if (subNum2 == 0)
            {
                result = subResult1 + " trăm";
            }

            if (subNum2.ToString().Length == 1)
            {
                subResult2 = readOneDigit(subNum2);
                result = subResult1 + " trăm lẻ " + subResult2;
                return result;
            }

            subResult2 = readTwoDigit(subNum2);
            result = subResult1 + " trăm " + subResult2;

            return result;
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String[] arr1 = {"nghìn", "triệu"};
                String val = textBox1.Text.Trim();
                int checkInt, num;
                String result;

                if (Int32.TryParse(val, out checkInt))
                {
                    num = int.Parse(val);

                    if (num.ToString().Length == 1)
                    {
                        result = readOneDigit(num);
                        textBox2.Text = result;
                    }

                    if (num.ToString().Length == 2) {
                        result = readTwoDigit(num);
                        textBox2.Text = result;
                    }

                    if (num.ToString().Length == 3)
                    {
                        result = readThreeDigit(num);
                        textBox2.Text = result;
                    }

                    if (num.ToString().Length == 4)
                    {
                        int subNum = num / 1000;
                        if (subNum * 1000 == num)
                        {
                            result = readOneDigit(subNum) + " nghìn";
                            textBox2.Text = result;
                        }
                        else
                        {
                            result = readOneDigit(subNum) + " nghìn " + readThreeDigit(num - subNum * 1000);
                            textBox2.Text = result;
                        }
                    } 
                else
                {
                    throw new Exception("Invalid input");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
