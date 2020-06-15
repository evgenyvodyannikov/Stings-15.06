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

namespace Строки_15._06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string s;
        private void button1_Click(object sender, EventArgs e)
        {
             
            MessageBox.Show(s);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text, Encoding.GetEncoding("UTF-8"));
            }
        }

        private void проверкаНаГруппыБуквToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s = textBox1.Text;
            int countletters = 0;
            int countsigns = 0;
            int lettersinword = 0;
            int signsinword = 0;
            string[] split = s.Split(new Char[] { ' ', ',', '.', ':', ';', '(', ')', '=', '_', '\t' });
            for (int i = 0; i < split.Length; i++)
            {
                char[] ss = split[i].ToCharArray();
                for (int j = 0; j < ss.Length; j++)
                {
                    if ((ss[j] >= 'A' && ss[j] <= 'Z') || (ss[j] >= 'a' && ss[j] <= 'z'))
                    { lettersinword++; }
                    else if(ss[j] == '+' || ss[j] == '-' || ss[j] == '*')
                    { signsinword++; }
                    else
                    { break; }
                    if (lettersinword == ss.Length)
                    { countletters++; }
                    if (signsinword == ss.Length)
                    { countsigns++; }
                }
                lettersinword = 0;
                signsinword = 0;
            }
            MessageBox.Show("Кол-во групп букв: " + countletters + "\nКол-во груп знаков: " + countsigns, "Ответ:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void определитьДлинуГруппыЦифрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int k = 0;
            int max = 0;
            s = textBox1.Text;
            string[] split = s.Split(new Char[] { ' ', ',', '.', ':', ';', '(', ')', '=', '_', '\t' });
            for (int i = 0; i < split.Length; i++)
            {
                char[] ss = split[i].ToCharArray();
                for (int j = 0; j < ss.Length; j++)
                {
                    if (ss[j] >= '0' && ss[j] <= '9')
                    {
                        k++;
                    }
                    else
                    { break; }
                }
                if (k >= max)
                { max = k; }
                k = 0;
            }
            MessageBox.Show("Длина самой длинной группы цифр = " + max.ToString(),"Ответ:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void найтиЧислоГруппБуквToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int countletters = 0;
            int lettersinword = 0;
            s = textBox1.Text;
            string[] split = s.Split(new Char[] { ' ', ',', '.', ':', ';', '(', ')', '=', '_', '\t' });
            for (int i = 0; i < split.Length; i++)
            {
                char[] ss = split[i].ToCharArray();
                for (int j = 0; j < ss.Length; j++)
                {
                    if ((ss[j] >= 'A' && ss[j] <= 'Z') || (ss[j] >= 'a' && ss[j] <= 'z'))
                    {
                        lettersinword++;
                    }
                    else
                    { break; }
                    if (lettersinword == ss.Length)
                    {
                        if (ss[0] == ss[ss.Length - 1])
                        { countletters++; }
                    }
                }
                lettersinword = 0;
            }
            MessageBox.Show("Кол-во группы букв начинающихся и заканчивающихся одной и той же буквой = " + countletters.ToString(), "Ответ:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
