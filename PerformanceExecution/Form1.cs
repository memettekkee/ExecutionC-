using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerformanceExe
{
    public partial class Form1 : Form
    {
        private string selectedFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "C# Files (*.cs)|*.cs|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    textBox1.Text = selectedFilePath; 
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(selectedFilePath))
            {
                var stopwatch = new Stopwatch();

                stopwatch.Start();

                string fileContent = File.ReadAllText(selectedFilePath);
                textBox2.Text = fileContent;

                stopwatch.Stop();

                
                label2.Text = $"Time (ms) = {stopwatch.Elapsed.ToString()}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
               
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;
                    textBox1.Text = selectedFolderPath;

                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                    
                    string[] csFiles = Directory.GetFiles(selectedFolderPath, "*.cs");
                    StringBuilder allFileContent = new StringBuilder();

                    foreach (string csFile in csFiles)
                    {
                        string fileContent = File.ReadAllText(csFile);
                        allFileContent.AppendLine(fileContent);
                    }

                    textBox2.Text = allFileContent.ToString();

                    stopwatch.Stop();

                    
                    label2.Text = $"Time (ms) = {stopwatch.Elapsed.ToString()}";
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string destinationFilePath = saveFileDialog.FileName;

                    var stopwatch = new Stopwatch();
                    stopwatch.Start();

                   
                    File.WriteAllText(destinationFilePath, $"Waktu Ekspor (ms) = {stopwatch.Elapsed.ToString()}");

                    stopwatch.Stop();

                    label2.Text = $"Waktu Ekspor (ms) = {stopwatch.Elapsed.ToString()}";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void ShowHelp()
        {
            string help = OpenHelp();
            MessageBox.Show(help, "User Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string OpenHelp()
        {
            StringBuilder help = new StringBuilder();

            help.AppendLine("User Guide for Execution Time Application");
            help.AppendLine();
            help.AppendLine("1. Press the \"upload file\" option if you wish to insert an individual file with the .cs format.");
            help.AppendLine("2. Choose the \"upload folder\" option to include a folder containing .cs files.");
            help.AppendLine("3. Click the \"Count\" button to initiate the code execution calculation.");
            help.AppendLine("4. The application will display the successfully executed time on the \"time (ms)\" bar.");
            help.AppendLine("5. The recorded time is presented in milliseconds (ms).");
            help.AppendLine("6. Upon successful completion, you can download the execution results by pressing the \"export\" button. The downloaded result will be in .txt format.\r\n\r\n\r\n\r\n\r\n\r\n");

            return help.ToString();
        }

      
    }
}
