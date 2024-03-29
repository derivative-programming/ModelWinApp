﻿using JsonManipulator.Enums;
using JsonManipulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{
    public partial class frmServicesApiFabricationRequestDetail : Form
    {
        private FabricationRequestListModelItem _requestItem = null;

        public frmServicesApiFabricationRequestDetail(FabricationRequestListModelItem requestItem)
        {
            _requestItem = requestItem;
            InitializeComponent();
        } 
         
         
        private void frmForm_Load(object sender, EventArgs e)
        { 
            if(_requestItem.ModelFabricationRequestIsCompleted && _requestItem.ModelFabricationRequestIsSuccessful)
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
                if (!_requestItem.ModelFabricationRequestIsCompleted &&
                    !_requestItem.ModelFabricationRequestIsCanceled)
                {
                    this.btnCancelRequest.Enabled = true;
                }
            }

            string details = "Requested by:" + _requestItem.ModelFabricationRequestRequestedBy + Environment.NewLine;
            if(_requestItem.ModelFabricationRequestIsCanceled)
            {
                details += "Canceled by:" + _requestItem.ModelFabricationRequestCanceledBy + Environment.NewLine;
            }
            if (_requestItem.ModelFabricationRequestIsCompleted && _requestItem.ModelFabricationRequestIsSuccessful)
            {
                details += "Completed Successfully" + Environment.NewLine;
                if(_requestItem.ModelFabricationRequestCodeSizeInMB > 0)
                {
                    details += _requestItem.ModelFabricationRequestCodeSizeInMB.ToString() + " MB Generated" + Environment.NewLine;
                }
            }
            if (_requestItem.ModelFabricationRequestIsCompleted && !_requestItem.ModelFabricationRequestIsSuccessful)
            {
                details += "Completed with error";
            }
            richTextBox1.Text = details;

            txtFabricationFolder.Text = LocalStorage.GetValue("FabricationFolder", "");
            txtCodeDistributionScript.Text = LocalStorage.GetValue("CodeDistributionScript", "");
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownloadInitialModel_Click(object sender, EventArgs e)
        {
            string destinationFilePath = ((Form1)Application.OpenForms["Form1"]).GetModelPath();
            using (var form = new frmDownloadFile(_requestItem.ModelFabricationRequestInitialModelUrl,destinationFilePath))
            {
                var result = form.ShowDialog();
                ((Form1)Application.OpenForms["Form1"]).LoadModelFile(destinationFilePath);
                MessageBox.Show("Initial model downloaded and loaded successfully.");
            }
        }

        private void btnDownloadReport_Click(object sender, EventArgs e)
        {

            string destinationFilePath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".log";
            using (var form = new frmDownloadFile(_requestItem.ModelFabricationRequestReportUrl, destinationFilePath))
            {
                var result = form.ShowDialog();
                Process.Start("notepad.exe", destinationFilePath);
            }
        }

        private void btnDownloadResults_Click(object sender, EventArgs e)
        {

            string destinationFilePath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".zip";
            using (var form = new frmDownloadFile(_requestItem.ModelFabricationRequestResultUrl, destinationFilePath))
            {
                var result = form.ShowDialog();
            }

            this.UseWaitCursor = true;
            using (var form2 = new frmUnzipFile(destinationFilePath, txtFabricationFolder.Text))
            {
                form2.ShowDialog();
            }

            string projectVersionNumber = Form1._model.root.projectVersionNumber;

            int majorVersion = 0;
            int minorVersion = 0;
            int buildVersion = 0;
            Int32.TryParse(projectVersionNumber.Split('.')[0], out majorVersion);
            if (projectVersionNumber.Split('.').Length > 1)
            {
                Int32.TryParse(projectVersionNumber.Split('.')[1], out minorVersion);
            }
            if (projectVersionNumber.Split('.').Length > 2)
            {
                Int32.TryParse(projectVersionNumber.Split('.')[2], out buildVersion);
            }
            projectVersionNumber = majorVersion.ToString() + "." + minorVersion.ToString() + "." + (buildVersion + 1).ToString();

            Form1._model.root.projectVersionNumber = projectVersionNumber;
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();

            this.UseWaitCursor = false;
            MessageBox.Show("Fabrication results downloaded and extracted to destination folder successfully.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txtFabricationFolder.Text = fbd.SelectedPath;
                    LocalStorage.SetValue("FabricationFolder", txtFabricationFolder.Text.Trim());
                    LocalStorage.Save();

                }
            }
               
        }

        private async void btnCancelRequest_Click(object sender, EventArgs e)
        {
            await OpenAPIs.ApiManager.CancelFabricationRequestAsync(_requestItem.ModelFabricationRequestCode);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new System.Windows.Forms.OpenFileDialog())
            {
                fbd.Title = "Open A Code Distribution Script file";
                fbd.CheckFileExists = false;
                fbd.CheckPathExists = true;
                fbd.DefaultExt = "bat";
                fbd.Filter = "bat files (*.bat)|*.bat";
                fbd.FilterIndex = 2;
                fbd.RestoreDirectory = true;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtCodeDistributionScript.Text = fbd.FileName;
                    LocalStorage.SetValue("CodeDistributionScript", txtCodeDistributionScript.Text.Trim());
                    LocalStorage.Save();

                }
            }

        }

        private void btnDistribute_Click(object sender, EventArgs e)
        { 

            if(txtCodeDistributionScript.Text.Trim().Length == 0)
            {
                return;
            }

            if (!System.IO.File.Exists(txtCodeDistributionScript.Text.Trim()))
                return; 

            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = txtCodeDistributionScript.Text;

            try
            {
                System.Diagnostics.Process.Start(psi);
            }
            catch (System.Exception)
            {

            }
        }
    }

    

}
