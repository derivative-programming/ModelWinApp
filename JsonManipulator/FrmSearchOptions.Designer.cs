
namespace JsonManipulator
{
    partial class FrmSearchOptions
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.chkObjProp = new System.Windows.Forms.CheckBox();
            this.chkObjWfOutputVar = new System.Windows.Forms.CheckBox();
            this.chkObjWfParam = new System.Windows.Forms.CheckBox();
            this.chkReportColumn = new System.Windows.Forms.CheckBox();
            this.chkReportFilter = new System.Windows.Forms.CheckBox();
            this.chkReportButton = new System.Windows.Forms.CheckBox();
            this.chkObjWfButton = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(237, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(156, 121);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "&OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(13, 13);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(67, 21);
            this.chkName.TabIndex = 12;
            this.chkName.Text = "Name";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkObjProp
            // 
            this.chkObjProp.AutoSize = true;
            this.chkObjProp.Location = new System.Drawing.Point(156, 94);
            this.chkObjProp.Name = "chkObjProp";
            this.chkObjProp.Size = new System.Drawing.Size(128, 21);
            this.chkObjProp.TabIndex = 13;
            this.chkObjProp.Text = "DB Object Prop";
            this.chkObjProp.UseVisualStyleBackColor = true;
            this.chkObjProp.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkObjWfOutputVar
            // 
            this.chkObjWfOutputVar.AutoSize = true;
            this.chkObjWfOutputVar.Location = new System.Drawing.Point(156, 13);
            this.chkObjWfOutputVar.Name = "chkObjWfOutputVar";
            this.chkObjWfOutputVar.Size = new System.Drawing.Size(146, 21);
            this.chkObjWfOutputVar.TabIndex = 14;
            this.chkObjWfOutputVar.Text = "ObjWF Output Var";
            this.chkObjWfOutputVar.UseVisualStyleBackColor = true;
            // 
            // chkObjWfParam
            // 
            this.chkObjWfParam.AutoSize = true;
            this.chkObjWfParam.Location = new System.Drawing.Point(156, 67);
            this.chkObjWfParam.Name = "chkObjWfParam";
            this.chkObjWfParam.Size = new System.Drawing.Size(118, 21);
            this.chkObjWfParam.TabIndex = 15;
            this.chkObjWfParam.Text = "ObjWF Param";
            this.chkObjWfParam.UseVisualStyleBackColor = true;
            // 
            // chkReportColumn
            // 
            this.chkReportColumn.AutoSize = true;
            this.chkReportColumn.Location = new System.Drawing.Point(12, 67);
            this.chkReportColumn.Name = "chkReportColumn";
            this.chkReportColumn.Size = new System.Drawing.Size(124, 21);
            this.chkReportColumn.TabIndex = 16;
            this.chkReportColumn.Text = "Report Column";
            this.chkReportColumn.UseVisualStyleBackColor = true;
            // 
            // chkReportFilter
            // 
            this.chkReportFilter.AutoSize = true;
            this.chkReportFilter.Location = new System.Drawing.Point(12, 40);
            this.chkReportFilter.Name = "chkReportFilter";
            this.chkReportFilter.Size = new System.Drawing.Size(108, 21);
            this.chkReportFilter.TabIndex = 17;
            this.chkReportFilter.Text = "Report Filter";
            this.chkReportFilter.UseVisualStyleBackColor = true;
            // 
            // chkReportButton
            // 
            this.chkReportButton.AutoSize = true;
            this.chkReportButton.Location = new System.Drawing.Point(12, 94);
            this.chkReportButton.Name = "chkReportButton";
            this.chkReportButton.Size = new System.Drawing.Size(118, 21);
            this.chkReportButton.TabIndex = 20;
            this.chkReportButton.Text = "Report Button";
            this.chkReportButton.UseVisualStyleBackColor = true;
            // 
            // chkObjWfButton
            // 
            this.chkObjWfButton.AutoSize = true;
            this.chkObjWfButton.Location = new System.Drawing.Point(156, 40);
            this.chkObjWfButton.Name = "chkObjWfButton";
            this.chkObjWfButton.Size = new System.Drawing.Size(118, 21);
            this.chkObjWfButton.TabIndex = 21;
            this.chkObjWfButton.Text = "ObjWF Button";
            this.chkObjWfButton.UseVisualStyleBackColor = true;
            // 
            // FrmSearchOptions
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 155);
            this.ControlBox = false;
            this.Controls.Add(this.chkObjWfButton);
            this.Controls.Add(this.chkReportButton);
            this.Controls.Add(this.chkReportFilter);
            this.Controls.Add(this.chkReportColumn);
            this.Controls.Add(this.chkObjWfParam);
            this.Controls.Add(this.chkObjWfOutputVar);
            this.Controls.Add(this.chkObjProp);
            this.Controls.Add(this.chkName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSearchOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Options";
            this.Load += new System.EventHandler(this.FrmSearchOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.CheckBox chkObjProp;
        private System.Windows.Forms.CheckBox chkObjWfOutputVar;
        private System.Windows.Forms.CheckBox chkObjWfParam;
        private System.Windows.Forms.CheckBox chkReportColumn;
        private System.Windows.Forms.CheckBox chkReportFilter;
        private System.Windows.Forms.CheckBox chkReportButton;
        private System.Windows.Forms.CheckBox chkObjWfButton;
    }
}