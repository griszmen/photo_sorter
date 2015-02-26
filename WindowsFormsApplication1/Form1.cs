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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                textBox1.Text = path;
                string pattern = "*.txt";

                string[] files = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    richTextBox1.Text = richTextBox1.Text + file + "\n";
                    DateTime creationDate = File.GetCreationTime(file);
                    int monthNumber = creationDate.Month;
                    richTextBox1.Text = richTextBox1.Text + creationDate + " " + monthNumber + "\n";
                    
                    string newPath = path + "/" + monthNumber;
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                        File.Copy(Path.Combine(path,file), Path.Combine(newPath,file));
                    }

                }

            }

        }
    }
}
