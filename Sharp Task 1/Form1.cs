using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sharp_Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton1 = (RadioButton)sender;

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton2 = (RadioButton)sender;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                task1();
            }

            if (radioButton2.Checked)
            {
                task2();
            }
        }
        public void task1()
        {
            int N = Convert.ToInt32(textBox4.Text); //кол-во слагаемых
            int x = Convert.ToInt32(textBox5.Text); // аргумент

            textBox2.Text = (frac(N, x)).ToString(); //частичная сумма ряда
            textBox3.Text = (last(N, x)).ToString(); //последнее слагаемое
            textBox1.Text = (perf(x)).ToString(); //точное значение функции
            textBox6.Text = (pogr(frac(N, x), perf(x))).ToString(); //абсолютная погрешность
            textBox7.Text = (sravn((pogr(frac(N, x), perf(x))), (last(N, x))).ToString());
        }

        public void task2()
        {
            double E = Convert.ToDouble(textBox8.Text); //кол-во слагаемых
            if (E > 1)
            {
                MessageBox.Show("Ошибка! Число Е должно быть меньше 1");
            }
            double x = Convert.ToDouble(textBox5.Text); // аргумент

            textBox9.Text = (frac1(E, x)).ToString(); //Сумма членов ряда по абсолютной величине больших Е
            textBox10.Text = (kolvo(E, x)).ToString(); //Кол-во членов ряда
            textBox11.Text = (fracE2(E, x)).ToString();//Сумма членов ряда по абсолютной величине больших Е'
        }

        public double frac(int N, int x)
        {

            double sum = 1;

            for (int i = 1; i < N; i++)
            {
                sum += Math.Pow(-x, i);

            }
            return sum;
        }
        public double frac1(double E, double x)
        {

            double sum = 0;
            int count = 0;
            int count1 = 0;
            for (int i = 0;  ; i++)
            {
                double v = Math.Pow(-x, i);
                if (Math.Abs(v) > E)
                {
                    sum += Math.Pow(-x, i);
                    count ++;
                }
                count1++;
                if (count != count1)
                {
                    break;
                }
            }
            return sum;
        }

        public double kolvo(double E, double x)
        {

            double sum = 0;
            int count = 0;
            int count1 = 0;
            for (int i = 0;  ; i++)
            {
                double v = Math.Pow(-x, i);
                if (Math.Abs(v) > E)
                {
                    sum += Math.Pow(-x, i);
                    count++;
                }
                count1++;
                if (count != count1)
                {
                    break;
                }
            }
            return count;
        }

        public double fracE2(double E, double x)
        {

            double sum = 0;
            int count = 0;
            int count1 = 0;
            for (int i = 0; ; i++)
            {
                double v = Math.Pow(-x, i);
                if (Math.Abs(v) > E/10)
                {
                    sum += Math.Pow(-x, i);
                    count++;
                }
                count1++;
                if (count != count1)
                {
                    break;
                }
            }
            return sum;
        }

        public double perf(double x)
        {
            double perf = 1 / (1 + x);
            return perf;
        }

        public double pogr(double sum, double perf)
        {
            double p = Math.Abs(perf - sum);
            return p;
        }

        public double last(int x, int N)
        {
            double last = Math.Pow(-x, N);
            return last;
        }

        public string sravn(double p, double last)
        {
            string с;
            if (p < Math.Abs(last))
            {
                string m = "Абсолютная погрешность меньше абсолютной велечины последнего члена";
                return m;
            }

            if (p > Math.Abs(last))
            {
                string m = "Абсолютная погрешность больше абсолютной велечины последнего члена";
                return m;
            }

            if (p == Math.Abs(last))
            {
                string m = "Абсолютная погрешность равна абсолютной велечины последнего члена";
                return m;
            }
            else return с = "Ошибка";
        }

    
    }
}
