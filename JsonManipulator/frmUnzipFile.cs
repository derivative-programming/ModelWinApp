using JsonManipulator.Enums;
using JsonManipulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace JsonManipulator
{
    public partial class frmUnzipFile : Form
    {    
        private Stopwatch _sw = new Stopwatch();

        public string ZipFilePath { get; set; }
        public string DestinationFolderPath { get; set; }

        public frmUnzipFile(string zipFilePath, string destinationFolderPath)
        {
            this.ZipFilePath = zipFilePath;
            this.DestinationFolderPath = destinationFolderPath;
            InitializeComponent();
        }
         
        private void frmForm_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true;
        } 
        private void btnCancel_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        public    void ProcessFile(string zipFilePath, string destinationFolderPath)
        {

            if (System.IO.Directory.Exists(destinationFolderPath))
            {
                System.IO.Directory.Delete(destinationFolderPath, true);
            }
            System.IO.Directory.CreateDirectory(destinationFolderPath);
            System.IO.Compression.ZipArchive zip = ZipFile.OpenRead(zipFilePath);

            progressBar1.Maximum = zip.Entries.Count;
            for (int i = 0; i < zip.Entries.Count; i++)
            {
                string destinationSingleFilePath = destinationFolderPath + @"\" + zip.Entries[i].FullName;
                if (destinationSingleFilePath.EndsWith("/"))
                    continue;
                if (destinationSingleFilePath.EndsWith(@"\"))
                    continue;
                string directoryName = System.IO.Path.GetDirectoryName(destinationSingleFilePath);
                if (!System.IO.Directory.Exists(directoryName))
                    System.IO.Directory.CreateDirectory(directoryName);
                zip.Entries[i].ExtractToFile(destinationSingleFilePath);
                progressBar1.Value = i;
                Application.DoEvents();
            }
            zip.Dispose();
            // ZipFile.ExtractToDirectory(destinationFilePath, destinationFolderPath);
            System.IO.File.Delete(zipFilePath);
            this.Close();
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        { 
            // Update the progressbar percentage only when the value is not the same.
            progressBar1.Value = e.ProgressPercentage; 
             
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ProcessFile(this.ZipFilePath, this.DestinationFolderPath); 
        }
    }

    

}
