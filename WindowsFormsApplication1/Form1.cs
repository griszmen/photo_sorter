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
                    string filename = Path.GetFileName(file);
                    string filename_dir = Path.GetDirectoryName(file);
                    richTextBox1.Text = richTextBox1.Text + file + "\n";
                    DateTime creationDate = File.GetLastWriteTime(file);
                    int monthNumber = creationDate.Month;
                    string newPath = path + "\\" + monthNumber;
                    string sourceFile = Path.Combine(filename_dir, filename);
                    string destFile = Path.Combine(newPath, filename);
                    MessageBox.Show(filename_dir);
                    MessageBox.Show(sourceFile);
                    MessageBox.Show(destFile);
                    richTextBox1.Text = richTextBox1.Text + creationDate + " " + monthNumber + " newpath: " + newPath + " sourceFile: " + sourceFile + " destfile: " + destFile +  "\n";                   
                   
                     if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }

                     string createdFile = newPath + "\\" + filename;
                     if (!File.Exists(createdFile))
                     {
                         File.Copy(sourceFile, destFile);
                     }                                            

                }

            }

        }
    }
}
