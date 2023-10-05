using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace lab5_files
{
    public partial class Form1 : Form
    {
        List<string> words = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] separators = new char[] { ' ', '.', ',', '!', '…', ';', ':', '-', '—', '«', '»', '(', ')', '\"', '\'' };
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                string all_text = File.ReadAllText(openFileDialog1.FileName);
                words = all_text.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

                stopWatch.Stop();
                label1.Text = "Время загрузки и созранения в список: " + Convert.ToString(stopWatch.ElapsedMilliseconds) + " мс.";
            }
            else
                MessageBox.Show("Файл не выбран");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string find_word = textBox1.Text;
            if (words.Contains(find_word))
            {
                stopWatch.Stop();
                label4.Text = "Слово найдено. \nВремя поиска: " + Convert.ToString(stopWatch.Elapsed.TotalMilliseconds * 1000) + " мкс.";
                listBox1.Items.Add(find_word);
            }
            else
                label4.Text = "Слово не найдено";
        }
    }
}