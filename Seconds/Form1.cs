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

namespace Seconds
{
    public partial class Form1 : Form
    {
        DateTime time = new DateTime();
        int rings = 1;
        string path = Application.StartupPath + $"\\{DateTime.Now.ToString("dd-mm-yyyy mm-ss")}.log";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += $"Круг #{rings++} - Время: {time.ToString("mm:ss:ff")}\r\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
            time = new DateTime();
            label_timer.Text = "00:00:00";
            rings = 1;

            if(textBox1.Text != "")
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    streamWriter.Write("Результаты секундомера:\n\n" + textBox1.Text);
                    textBox1.Text = null;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time = time.AddMilliseconds(10);
            label_timer.Text = time.ToString("mm:ss:ff");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                using (StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
                    streamWriter.Write("Результаты секундомера:\n\n" + textBox1.Text);
            }
        }
    }
}
