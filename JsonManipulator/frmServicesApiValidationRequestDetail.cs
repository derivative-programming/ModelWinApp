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
    public partial class frmServicesApiValidationRequestDetail : Form
    {
        private ValidationRequestListModelItem _requestItem = null;

        public frmServicesApiValidationRequestDetail(ValidationRequestListModelItem requestItem)
        {
            _requestItem = requestItem;
            InitializeComponent();
        } 
         
         
        private void frmForm_Load(object sender, EventArgs e)
        { 
            if(_requestItem.ModelValidationRequestIsSuccessful)
            {
                this.btnDownloadInitialModel.Enabled = true;
                this.btnDownloadReport.Enabled = true;
                this.btnCancelRequest.Enabled = false;
            }
            else
            {
                this.btnDownloadInitialModel.Enabled = false;
                this.btnDownloadReport.Enabled = false;
                this.btnCancelRequest.Enabled = false;
                if (!_requestItem.ModelValidationRequestIsCompleted &&
                    !_requestItem.ModelValidationRequestIsCanceled)
                {
                    this.btnCancelRequest.Enabled = true;
                }
            }

            string details = "Requested by:" + _requestItem.ModelValidationRequestRequestedBy + Environment.NewLine;
            if(_requestItem.ModelValidationRequestIsCanceled)
            {
                details += "Canceled by:" + _requestItem.ModelValidationRequestCanceledBy + Environment.NewLine;
            }
            if (_requestItem.ModelValidationRequestIsSuccessful)
            {
                details += "Completed Successfully";
            }
            if (_requestItem.ModelValidationRequestIsCompleted && !_requestItem.ModelValidationRequestIsSuccessful)
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
            using (var form = new frmDownloadFile(_requestItem.ModelValidationRequestInitialModelUrl,destinationFilePath))
            {
                var result = form.ShowDialog();
                ((Form1)Application.OpenForms["Form1"]).LoadModelFile(destinationFilePath);
                MessageBox.Show("Initial model downloaded and loaded successfully.");
            }
        }

        private void btnDownloadReport_Click(object sender, EventArgs e)
        {

            string destinationFilePath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".log";
            using (var form = new frmDownloadFile(_requestItem.ModelValidationRequestReportUrl, destinationFilePath))
            {
                var result = form.ShowDialog();
                Process.Start("notepad.exe", destinationFilePath);
            }
        }

        private async void btnCancelRequest_Click(object sender, EventArgs e)
        {

            await OpenAPIs.ApiManager.CancelValidationRequestAsync(_requestItem.ModelValidationRequestCode);
            this.Close();
        }
    }

    

}
