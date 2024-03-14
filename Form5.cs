using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private String decimalToBinary(long decNumber)
        {
            foreach (char c in decNumber.ToString())
            {
                if (!char.IsDigit(c))
                {
                    throw new Exception("Invalid input");
                }
            }
            if (decNumber == 0)
                return "0";

            String binary = "";
            while (decNumber > 0)
            {
                long remainder = decNumber % 2;
                binary = remainder + binary;
                decNumber /= 2;
            }
            return binary;
        }

        private String decimalToBinary4bits(int decNumber)
        {
            String binary = "";
            String subBinary1 = "";
            String subBinary2 = "";
            subBinary1 = decimalToBinary(decNumber);
            if (subBinary1.Length != 4)
            {
                int length1 = 4 - (int)subBinary1.Length;
                for (int i = 0; i < length1; i++)
                {
                    subBinary2 += "0";
                }
            }
            binary = subBinary2 + subBinary1;
            return binary;
        }

        private String hexToBinary(String hex)
        {
            char[] arrChar = { 'A', 'B', 'C', 'D', 'E', 'F' };
            String binary = "";
            foreach (char c in hex)
            {
                int number1;
                String subBinary = "";
                if (int.TryParse(c.ToString(), out number1))
                {
                    number1 = Int32.Parse(c.ToString());
                    if (number1 >= 0 && number1 <= 9)
                    {
                        subBinary = decimalToBinary4bits(number1);
                        binary += subBinary;
                    }
                    else
                    {
                        throw new Exception("Invalid input");
                    }
                }
                else
                {
                    if (arrChar.Contains(c))
                    {
                        int index = Array.IndexOf(arrChar, c) + 10;
                        subBinary = decimalToBinary4bits(index);
                        binary += subBinary;
                    }
                    else
                    {
                        throw new Exception("Invalid input");
                    }
                }
            }
            return binary;
        }

        private double binaryToDecimal(String binary)
        {
            int number = 0;
            double result = 0;

            //Check valid input
            foreach (char c in binary)
            {
                if (char.IsDigit(c))
                {
                    number = Int32.Parse(c.ToString());
                    if (number != 0 && number != 1)
                    {
                        throw new Exception("Invalid input");
                    }
                }
                else
                {
                    throw new Exception("Invalid input");
                }
            }

            int lengthBi = binary.Length;
            foreach (char c in binary)
            {
                number = Int32.Parse(c.ToString());
                result += number * (Math.Pow(2, lengthBi-1));
                lengthBi--;
            }
            return result;
        }

        private String binaryToHex(String binary)
        {
            char[] arrChar = { 'A', 'B', 'C', 'D', 'E', 'F' };
            String hex = "";
            int number;

            //Check valid input
            foreach (char c in binary)
            {
                if (char.IsDigit(c))
                {
                    number = Int32.Parse(c.ToString());
                    if (number != 0 && number != 1)
                    {
                        throw new Exception("Invalid input");
                    }
                }
                else
                {
                    throw new Exception("Invalid input");
                }
            }

            //split binary to 4 bits element and convert it to 1 bit hex
            String subBinary = "";
            String subHex = "";
            int remainder = binary.Length % 4;
            for (int i = remainder; i < binary.Length; i += 4)
            {
                subBinary = binary[i].ToString() + binary[i+1].ToString() + binary[i + 2].ToString() + binary[i + 3].ToString();
                subHex = binaryToDecimal(subBinary).ToString();
                if (Int32.Parse(subHex) > 9)
                {
                    subHex = arrChar[Int32.Parse(subHex) - 10].ToString();
                }
                hex += subHex;
            }
            if (remainder == 0)
            {
                return hex;
            }
            subBinary = binary.Substring(0, remainder);
            subHex = binaryToDecimal(subBinary).ToString();
            hex = subHex + hex;
            return hex;
        }

        private String binaryToBinary(String binary)
        {
            int number;

            foreach (char c in binary)
            {
                if (char.IsDigit(c))
                {
                    number = Int32.Parse(c.ToString());
                    if (number != 0 && number != 1)
                    {
                        throw new Exception("Invalid input");
                    }
                }
                else
                {
                    throw new Exception("Invalid input");
                }
            }

            return binary;
        }

        private String decimalToDecimal(String dec)
        {
            foreach (char c in dec)
            {
                if (!char.IsDigit(c))
                {
                    throw new Exception("Invalid input");
                }
            }

            return dec;
        }

        private String hexToHex(String hex)
        {
            char[] arrChar = { 'A', 'B', 'C', 'D', 'E', 'F' };
            foreach (char c in hex)
            {
                if (!char.IsDigit(c) && !arrChar.Contains(c))
                {
                    throw new Exception("Invalid input");
                }
            }

            return hex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String result = "";
            String combo1 = comboBox1.Text.Trim().ToLower();
            String combo2 = comboBox2.Text.Trim().ToLower();
            String val1 = textBox1.Text.Trim();
            if (combo1 == "decimal" && combo2 == "binary")
            {
                try
                {
                    result = decimalToBinary(Int32.Parse(val1));
                    textBox2.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (combo1 == "hex" && combo2 == "binary")
            {
                try 
                {
                    val1 = val1.ToUpper();
                    result = hexToBinary(val1);
                    textBox2.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

            if (combo1 == "binary" && combo2 == "binary")
            {
                try
                {
                    result = binaryToBinary(val1);
                    textBox2.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (combo1 == "binary" && combo2 == "decimal")
            {
                try
                {
                    result = binaryToDecimal(val1).ToString();
                    textBox2.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (combo1 == "hex" && combo2 == "decimal")
            {
                try
                {
                    val1 = val1.ToUpper();
                    result = hexToBinary(val1);
                    result = binaryToDecimal(result).ToString();
                    textBox2.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (combo1 == "decimal" && combo2 == "decimal")
            {
                try
                {
                    result = decimalToDecimal(val1);
                    textBox2.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message) ;
                }
            }

            if (combo1 == "binary" && combo2 == "hex")
            {
                try
                {
                    result = binaryToHex(val1);
                    textBox2.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (combo1 == "decimal" && combo2 == "hex")
            {
                try
                {
                    result = decimalToBinary(Int32.Parse(val1));
                    result = binaryToHex(result);
                    textBox2.Text = result;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (combo1 == "hex" && combo2 == "hex")
            {
                try
                {
                    val1 = val1.ToUpper();
                    result = hexToHex(val1);
                    textBox2.Text = result;
                }                  
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
