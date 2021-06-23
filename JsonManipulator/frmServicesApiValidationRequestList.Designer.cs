
namespace JsonManipulator
{
    partial class frmServicesApiValidationRequestList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAddRequest = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridRequestList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRequestList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnAddRequest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 62);
            this.panel1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(729, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(648, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAddRequest
            // 
            this.btnAddRequest.Location = new System.Drawing.Point(536, 20);
            this.btnAddRequest.Name = "btnAddRequest";
            this.btnAddRequest.Size = new System.Drawing.Size(106, 23);
            this.btnAddRequest.TabIndex = 0;
            this.btnAddRequest.Text = "&Add Request";
            this.btnAddRequest.UseVisualStyleBackColor = true;
            this.btnAddRequest.Click += new System.EventHandler(this.btnAddRequest_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridRequestList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(816, 266);
            this.panel2.TabIndex = 1;
            // 
            // gridRequestList
            // 
            this.gridRequestList.AllowUserToAddRows = false;
            this.gridRequestList.AllowUserToDeleteRows = false;
            this.gridRequestList.AllowUserToOrderColumns = true;
            this.gridRequestList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRequestList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRequestList.Location = new System.Drawing.Point(0, 0);
            this.gridRequestList.Name = "gridRequestList";
            this.gridRequestList.ReadOnly = true;
            this.gridRequestList.RowHeadersWidth = 51;
            this.gridRequestList.RowTemplate.Height = 24;
            this.gridRequestList.Size = new System.Drawing.Size(816, 266);
            this.gridRequestList.TabIndex = 0;
            this.gridRequestList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRequestList_CellClick);
            // 
            // frmServicesApiLValidationRequestList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(816, 328);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmServicesApiLValidationRequestList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Validation Processing Requests";
            this.Load += new System.EventHandler(this.frmForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRequestList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridRequestList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.Button btnOK;
    }
}