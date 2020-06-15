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
            int k = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= 'A' && s[i] <= 'Z')
                    k++;
                else
                    countletters++;
            }
            MessageBox.Show(countletters.ToString());
        }
    }
}
