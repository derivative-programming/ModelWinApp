
namespace JsonManipulator
{
    partial class frmServicesApiChangeRptRequestDetail
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnCancelRequest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(180, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&OK";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDownloadInitialModel
            // 
            this.btnDownloadInitialModel.Location = new System.Drawing.Point(12, 187);
            this.btnDownloadInitialModel.Name = "btnDownloadInitialModel";
            this.btnDownloadInitialModel.Size = new System.Drawing.Size(243, 23);
            this.btnDownloadInitialModel.TabIndex = 7;
            this.btnDownloadInitialModel.Text = "Download and load Initial Model";
            this.btnDownloadInitialModel.UseVisualStyleBackColor = true;
            this.btnDownloadInitialModel.Click += new System.EventHandler(this.btnDownloadInitialModel_Click);
            // 
            // btnDownloadReport
            // 
            this.btnDownloadReport.Location = new System.Drawing.Point(12, 217);
            this.btnDownloadReport.Name = "btnDownloadReport";
            this.btnDownloadReport.Size = new System.Drawing.Size(243, 23);
            this.btnDownloadReport.TabIndex = 8;
            this.btnDownloadReport.Text = "Download Report";
            this.btnDownloadReport.UseVisualStyleBackColor = true;
            this.btnDownloadReport.Click += new System.EventHandler(this.btnDownloadReport_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(242, 140);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // btnCancelRequest
            // 
            this.btnCancelRequest.Location = new System.Drawing.Point(12, 158);
            this.btnCancelRequest.Name = "btnCancelRequest";
            this.btnCancelRequest.Size = new System.Drawing.Size(243, 23);
            this.btnCancelRequest.TabIndex = 16;
            this.btnCancelRequest.Text = "Cancel Request";
            this.btnCancelRequest.UseVisualStyleBackColor = true;
            this.btnCancelRequest.Click += new System.EventHandler(this.btnCancelRequest_Click);
            // 
            // frmServicesApiChangeRptRequestDetail
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(269, 288);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelRequest);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnDownloadReport);
            this.Controls.Add(this.btnDownloadInitialModel);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmServicesApiChangeRptRequestDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDownloadInitialModel;
        private System.Windows.Forms.Button btnDownloadReport;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnCancelRequest;
    }
}