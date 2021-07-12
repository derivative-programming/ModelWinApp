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
    public partial class frmServicesApiChangeRptRequestDetail : Form
    {
        private ChangeRptRequestListModelItem _requestItem = null;

        public frmServicesApiChangeRptRequestDetail(ChangeRptRequestListModelItem requestItem)
        {
            _requestItem = requestItem;
            InitializeComponent();
        } 
         
         
        private void frmForm_Load(object sender, EventArgs e)
        { 
            if(_requestItem.ModelChangeRptRequestIsCompleted)// && _requestItem.ModelChangeRptRequestIsSuccessful)
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
                if (!_requestItem.ModelChangeRptRequestIsCompleted &&
                    !_requestItem.ModelChangeRptRequestIsCanceled)
                {
                    this.btnCancelRequest.Enabled = true;
                }
            }

            string details = "Requested by:" + _requestItem.ModelChangeRptRequestRequestedBy + Environment.NewLine;
            if(_requestItem.ModelChangeRptRequestIsCanceled)
            {
                details += "Canceled by:" + _requestItem.ModelChangeRptRequestCanceledBy + Environment.NewLine;
            }
            if (_requestItem.ModelChangeRptRequestIsCompleted && _requestItem.ModelChangeRptRequestIsSuccessful)
            {
                details += "Completed Successfully";
            }
            if (_requestItem.ModelChangeRptRequestIsCompleted && !_requestItem.ModelChangeRptRequestIsSuccessful)
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
            using (var form = new frmDownloadFile(_requestItem.ModelChangeRptRequestInitialModelUrl,destinationFilePath))
            {
                var result = form.ShowDialog();
                ((Form1)Application.OpenForms["Form1"]).LoadModelFile(destinationFilePath);
                MessageBox.Show("Initial model downloaded and loaded successfully.");
            }
        }

        private void btnDownloadReport_Click(object sender, EventArgs e)
        {

            string destinationFilePath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".log";
            using (var form = new frmDownloadFile(_requestItem.ModelChangeRptRequestReportUrl, destinationFilePath))
            {
                var result = form.ShowDialog();
                Process.Start("notepad.exe", destinationFilePath);
            }
        }

        private async void btnCancelRequest_Click(object sender, EventArgs e)
        {

            await OpenAPIs.ApiManager.CancelChangeRptRequestAsync(_requestItem.ModelChangeRptRequestCode);
            this.Close();
        }
    }

    

}
