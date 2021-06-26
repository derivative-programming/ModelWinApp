using JsonManipulator.Enums;
using JsonManipulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{
    public partial class frmServicesApiPrepRequestDetail : Form
    {
        private PrepRequestListModelItem _requestItem = null;

        public frmServicesApiPrepRequestDetail(PrepRequestListModelItem requestItem)
        {
            _requestItem = requestItem;
            InitializeComponent();
        } 
         
         
        private void frmForm_Load(object sender, EventArgs e)
        { 
            if(_requestItem.ModelPrepRequestIsCompleted && _requestItem.ModelPrepRequestIsSuccessful)
            {
                this.btnDownloadInitialModel.Enabled = true;
                this.btnDownloadReport.Enabled = true;
                this.btnDownloadResults.Enabled = true;
                this.btnCancelRequest.Enabled = false;
            }
            else
            {
                this.btnDownloadInitialModel.Enabled = false;
                this.btnDownloadReport.Enabled = false;
                this.btnDownloadResults.Enabled = false;
                this.btnCancelRequest.Enabled = false;
                if (!_requestItem.ModelPrepRequestIsCompleted &&
                    !_requestItem.ModelPrepRequestIsCanceled)
                {
                    this.btnCancelRequest.Enabled = true;
                }
            }

            string details = "Requested by:" + _requestItem.ModelPrepRequestRequestedBy + Environment.NewLine;
            if(_requestItem.ModelPrepRequestIsCanceled)
            {
                details += "Canceled by:" + _requestItem.ModelPrepRequestCanceledBy + Environment.NewLine;
            }
            if (_requestItem.ModelPrepRequestIsCompleted && _requestItem.ModelPrepRequestIsSuccessful)
            {
                details += "Completed Successfully";
            }
            if (_requestItem.ModelPrepRequestIsCompleted && !_requestItem.ModelPrepRequestIsSuccessful)
            {
                details += "Completed with error";
            }
            richTextBox1.Text = details;
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownloadInitialModel_Click(object sender, EventArgs e)
        {
            string destinationFilePath = ((Form1)Application.OpenForms["Form1"]).GetModelPath();
            using (var form = new frmDownloadFile(_requestItem.ModelPrepRequestInitialModelUrl,destinationFilePath))
            {
                var result = form.ShowDialog();
                ((Form1)Application.OpenForms["Form1"]).LoadModelFile(destinationFilePath);
                MessageBox.Show("Initial model downloaded and loaded successfully.");
            }
        }

        private void btnDownloadReport_Click(object sender, EventArgs e)
        {

            string destinationFilePath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".log";
            using (var form = new frmDownloadFile(_requestItem.ModelPrepRequestReportUrl, destinationFilePath))
            {
                var result = form.ShowDialog();
                Process.Start("notepad.exe", destinationFilePath);
            }
        }

        private void btnDownloadResults_Click(object sender, EventArgs e)
        {

            string destinationFilePath = ((Form1)Application.OpenForms["Form1"]).GetModelPath();
            using (var form = new frmDownloadFile(_requestItem.ModelPrepRequestResultModelUrl, destinationFilePath))
            {
                var result = form.ShowDialog();
                ((Form1)Application.OpenForms["Form1"]).LoadModelFile(destinationFilePath);
                MessageBox.Show("Result model downloaded and loaded successfully.");
            }
        }

        private async void btnCancelRequest_Click(object sender, EventArgs e)
        {

            await OpenAPIs.ApiManager.CancelPrepRequestAsync(_requestItem.ModelPrepRequestCode);
            this.Close();
        }
    }

    

}
