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

                // Tempatkan kode pembacaan atau eksekusi file Anda di sisi sini.
                // Misalnya: Membaca isi file dan menampilkan di MessageBox.
                string fileContent = File.ReadAllText(selectedFilePath);
                textBox2.Text = fileContent;

                stopwatch.Stop();

                MessageBox.Show("Durasi Eksekusi: \n" + stopwatch.Elapsed.ToString());
                label2.Text = $"Waktu = {stopwatch.Elapsed.ToString()}";
            }
        }


    }
}
