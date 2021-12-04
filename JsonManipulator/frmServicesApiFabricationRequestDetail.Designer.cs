
namespace JsonManipulator
{
    partial class frmServicesApiFabricationRequestDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDownloadInitialModel = new System.Windows.Forms.Button();
            this.btnDownloadReport = new System.Windows.Forms.Button();
            this.btnDownloadResults = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFabricationFolder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelRequest = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCodeDistributionScript = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDistribute = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(180, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&OK";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDownloadInitialModel
            // 
            this.btnDownloadInitialModel.Location = new System.Drawing.Point(12, 189);
            this.btnDownloadInitialModel.Name = "btnDownloadInitialModel";
            this.btnDownloadInitialModel.Size = new System.Drawing.Size(243, 23);
            this.btnDownloadInitialModel.TabIndex = 7;
            this.btnDownloadInitialModel.Text = "Download and load Initial Model";
            this.btnDownloadInitialModel.UseVisualStyleBackColor = true;
            this.btnDownloadInitialModel.Click += new System.EventHandler(this.btnDownloadInitialModel_Click);
            // 
            // btnDownloadReport
            // 
            this.btnDownloadReport.Location = new System.Drawing.Point(12, 219);
            this.btnDownloadReport.Name = "btnDownloadReport";
            this.btnDownloadReport.Size = new System.Drawing.Size(243, 23);
            this.btnDownloadReport.TabIndex = 8;
            this.btnDownloadReport.Text = "Download Report";
            this.btnDownloadReport.UseVisualStyleBackColor = true;
            this.btnDownloadReport.Click += new System.EventHandler(this.btnDownloadReport_Click);
            // 
            // btnDownloadResults
            // 
            this.btnDownloadResults.Location = new System.Drawing.Point(12, 249);
            this.btnDownloadResults.Name = "btnDownloadResults";
            this.btnDownloadResults.Size = new System.Drawing.Size(243, 23);
            this.btnDownloadResults.TabIndex = 9;
            this.btnDownloadResults.Text = "Download and Load Results";
            this.btnDownloadResults.UseVisualStyleBackColor = true;
            this.btnDownloadResults.Click += new System.EventHandler(this.btnDownloadResults_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(242, 140);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Fabrication Destination Folder";
            // 
            // txtFabricationFolder
            // 
            this.txtFabricationFolder.Location = new System.Drawing.Point(15, 296);
            this.txtFabricationFolder.Name = "txtFabricationFolder";
            this.txtFabricationFolder.Size = new System.Drawing.Size(205, 20);
            this.txtFabricationFolder.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(227, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 13;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelRequest
            // 
            this.btnCancelRequest.Location = new System.Drawing.Point(15, 160);
            this.btnCancelRequest.Name = "btnCancelRequest";
            this.btnCancelRequest.Size = new System.Drawing.Size(240, 23);
            this.btnCancelRequest.TabIndex = 14;
            this.btnCancelRequest.Text = "Cancel Request";
            this.btnCancelRequest.UseVisualStyleBackColor = true;
            this.btnCancelRequest.Click += new System.EventHandler(this.btnCancelRequest_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 20);
            this.button2.TabIndex = 17;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCodeDistributionScript
            // 
            this.txtCodeDistributionScript.Location = new System.Drawing.Point(15, 336);
            this.txtCodeDistributionScript.Name = "txtCodeDistributionScript";
            this.txtCodeDistributionScript.Size = new System.Drawing.Size(205, 20);
            this.txtCodeDistributionScript.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Code Distribution Script";
            // 
            // btnDistribute
            // 
            this.btnDistribute.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDistribute.Enabled = false;
            this.btnDistribute.Location = new System.Drawing.Point(12, 364);
            this.btnDistribute.Name = "btnDistribute";
            this.btnDistribute.Size = new System.Drawing.Size(103, 24);
            this.btnDistribute.TabIndex = 18;
            this.btnDistribute.Text = "Distribute";
            this.btnDistribute.UseVisualStyleBackColor = true;
            this.btnDistribute.Click += new System.EventHandler(this.btnDistribute_Click);
            // 
            // frmServicesApiFabricationRequestDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(269, 403);
            this.ControlBox = false;
            this.Controls.Add(this.btnDistribute);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCodeDistributionScript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelRequest);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFabricationFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDownloadResults);
            this.Controls.Add(this.btnDownloadReport);
            this.Controls.Add(this.btnDownloadInitialModel);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmServicesApiFabricationRequestDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Request Details";
            this.Load += new System.EventHandler(this.frmForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDownloadInitialModel;
        private System.Windows.Forms.Button btnDownloadReport;
        private System.Windows.Forms.Button btnDownloadResults;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFabricationFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCancelRequest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtCodeDistributionScript;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDistribute;
    }
}