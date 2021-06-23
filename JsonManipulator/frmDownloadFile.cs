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

namespace JsonManipulator
{
    public partial class frmDownloadFile : Form
    {
        private WebClient _webClient;               
        private Stopwatch _sw = new Stopwatch();

        public string SourceUrl { get; set; }
        public string DestinationFilePath { get; set; }

        public frmDownloadFile(string sourceUrl, string destinationFilePath)
        {
            this.SourceUrl = sourceUrl;
            this.DestinationFilePath = destinationFilePath;
            InitializeComponent();
        }
         
        private void frmForm_Load(object sender, EventArgs e)
        {
            if(this.SourceUrl.ToLower().StartsWith("c:"))
            {
                if(System.IO.File.Exists(this.DestinationFilePath))
                {
                    System.IO.File.Delete(this.DestinationFilePath);
                }
                System.IO.File.Copy(this.SourceUrl, this.DestinationFilePath);
                MessageBox.Show("Download completed!");
                this.Close();
            }
            else
            {
                DownloadFile(this.SourceUrl, this.DestinationFilePath);
            }
        } 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            _webClient.CancelAsync();
            this.Close();
        }

        public async  void DownloadFile(string urlAddress, string location)
        {
            using (_webClient = new WebClient())
            {
                _webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = new Uri( urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                _sw.Start();

                try
                {
                    // Start downloading the file
                      await _webClient.DownloadFileTaskAsync(URL, location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        { 
            // Update the progressbar percentage only when the value is not the same.
            progressBar1.Value = e.ProgressPercentage; 
             
        }

        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            _sw.Reset();

            if (e.Cancelled == true)
            { 
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }

    

}
