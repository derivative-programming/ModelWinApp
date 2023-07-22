using JsonManipulator.Enums;
using JsonManipulator.Models;
using Newtonsoft.Json.Linq;
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

        private List<ChangeRequest> _changeRequests = null;

        public frmServicesApiValidationRequestDetail(ValidationRequestListModelItem requestItem)
        {
            _requestItem = requestItem;
            InitializeComponent();
        } 
         
         
        private void frmForm_Load(object sender, EventArgs e)
        { 
            if(_requestItem.ModelValidationRequestIsCompleted)// && _requestItem.ModelValidationRequestIsSuccessful)
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
            if(_requestItem.ModelValidationRequestReportUrl.Trim().Length == 0)
            {
                btnDownloadReport.Enabled = false;
            }

            string details = "Requested by:" + _requestItem.ModelValidationRequestRequestedBy + Environment.NewLine;
            if(_requestItem.ModelValidationRequestIsCanceled)
            {
                details += "Canceled by:" + _requestItem.ModelValidationRequestCanceledBy + Environment.NewLine;
            }
            if (_requestItem.ModelValidationRequestIsCompleted && _requestItem.ModelValidationRequestIsSuccessful)
            {
                details += "Completed Successfully";
            }
            if (_requestItem.ModelValidationRequestIsCompleted && !_requestItem.ModelValidationRequestIsSuccessful)
            {
                details += "Completed with error";
            }
            richTextBox1.Text = details;

            btnProcessChangeRequests.Enabled = false;
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

                this._changeRequests = BuildChangeRequestList(destinationFilePath);

                Process.Start("notepad.exe", destinationFilePath);
            }
        }

        private async void btnCancelRequest_Click(object sender, EventArgs e)
        {

            await OpenAPIs.ApiManager.CancelValidationRequestAsync(_requestItem.ModelValidationRequestCode);
            this.Close();
        }

        private List<ChangeRequest> BuildChangeRequestList(string reportPath)
        {
            List<ChangeRequest> result = new List<ChangeRequest>();

            string fileData = System.IO.File.ReadAllText(reportPath);

            if(!fileData.Contains("GENChangeRequestArrayStart"))
            {
                return result;
            }

            fileData = fileData.Remove(0,
                fileData.IndexOf("GENChangeRequestArrayStart") + "GENChangeRequestArrayStart".Length);

            fileData = fileData.Substring(0,
                fileData.IndexOf("GENChangeRequestArrayEnd"));

            ChangeRequest[] changeRequestArray = Newtonsoft.Json.JsonConvert.DeserializeObject<ChangeRequest[]>(fileData);

            result.AddRange(changeRequestArray);

            if(result.Count > 0)
            {
                btnProcessChangeRequests.Enabled = true;
            }

            return result;
        }

        private void btnProcessChangeRequests_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            Form1 parentForm = ((Form1)Application.OpenForms["Form1"]);
            parentForm.SaveModel();
            string modelPath = parentForm.GetModelPath();

            string initialModel = System.IO.File.ReadAllText(modelPath);
            var model = JObject.Parse(initialModel);
            JObject fullModel = JObject.Parse(model.ToString());

            for (int i = 0;i < this._changeRequests.Count;i++)
            {
                ChangeRequest changeRequest = this._changeRequests[i];

                if(!changeRequest.IsAutomatedChangeAvailable)
                {
                    continue;
                }

                //string currentValue = Utils.GetPropertyValue(ref fullModel,
                //    changeRequest.ModelXPath,
                //    changeRequest.PropertyName);

                foreach (JToken jToken in fullModel.SelectTokens(changeRequest.ModelXPath, true))
                {
                    string currentValue =  ((JObject)jToken).Property(changeRequest.PropertyName).Value.ToString();


                    if (currentValue == changeRequest.OldValue)
                    {
                        ((JObject)jToken).Property(changeRequest.PropertyName).Value = changeRequest.NewValue;
                    }
                }

                //JToken jToken = fullModel.SelectToken(xpath, true);

                //result = ((JObject)jTokenResult).Property(propertyName).Value.ToString();



                //if (currentValue != changeRequest.OldValue)
                //{
                //    continue;
                //}

                //Utils.UpdatePropertyValue(ref fullModel,
                //    changeRequest.ModelXPath,
                //    changeRequest.PropertyName,
                //    changeRequest.NewValue);

            }
               
            System.IO.File.WriteAllText(modelPath, fullModel.ToString());
            parentForm.LoadModelFile(modelPath);
            MessageBox.Show("Change Request Processing Complete.");
            btnProcessChangeRequests.Enabled = false;
            this._changeRequests.Clear();
            this.UseWaitCursor = false;
        }
    }


    class ChangeRequest
    {
        public Guid Code { get; set; }
        public DateTime CreatedUTCDateTime { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public string ModelXPath { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public Guid ProjectCode { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompletedUTCDateTime { get; set; }
        public bool IsRejected { get; set; }
        public DateTime RejectedUTCDateTime { get; set; }
        public string RejectedBy { get; set; }
        public string RejectionReason { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedUTCDateTime { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime ProcessedUTCDateTime { get; set; }
        public bool IsSuccessful { get; set; }
        public bool IsAutomatedChangeAvailable { get; set; }

        public void Initialize()
        {

            this.ApprovedBy = string.Empty;
            this.ApprovedUTCDateTime = DateTime.UtcNow;
            this.Code = Guid.NewGuid();
            this.CompletedUTCDateTime = DateTime.UtcNow;
            this.CreatedBy = string.Empty;
            this.CreatedUTCDateTime = DateTime.UtcNow;
            this.Description = string.Empty;
            this.IsApproved = false;
            this.IsAutomatedChangeAvailable = false;
            this.IsCompleted = false;
            this.IsProcessed = false;
            this.IsRejected = false;
            this.IsSuccessful = false;
            this.ModelXPath = string.Empty;
            this.NewValue = string.Empty;
            this.OldValue = string.Empty;
            this.ProcessedUTCDateTime = DateTime.UtcNow;
            this.ProjectCode = Guid.NewGuid();
            this.RejectedBy = string.Empty;
            this.RejectedUTCDateTime = DateTime.UtcNow;
            this.RejectionReason = string.Empty;
        }

    }

}
