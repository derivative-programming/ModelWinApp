
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
            this.chkLayoutName = new System.Windows.Forms.CheckBox();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.rbAnd = new System.Windows.Forms.RadioButton();
            this.rbOr = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRoleRequired = new System.Windows.Forms.TextBox();
            this.chkReport = new System.Windows.Forms.CheckBox();
            this.chkObjWF = new System.Windows.Forms.CheckBox();
            this.chkDBObj = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(571, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(490, 490);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 14;
            this.btnAccept.Text = "&OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Location = new System.Drawing.Point(507, 59);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(67, 21);
            this.chkName.TabIndex = 5;
            this.chkName.Text = "Name";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkObjProp
            // 
            this.chkObjProp.AutoSize = true;
            this.chkObjProp.Location = new System.Drawing.Point(507, 331);
            this.chkObjProp.Name = "chkObjProp";
            this.chkObjProp.Size = new System.Drawing.Size(128, 21);
            this.chkObjProp.TabIndex = 12;
            this.chkObjProp.Text = "DB Object Prop";
            this.chkObjProp.UseVisualStyleBackColor = true;
            this.chkObjProp.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkObjWfOutputVar
            // 
            this.chkObjWfOutputVar.AutoSize = true;
            this.chkObjWfOutputVar.Location = new System.Drawing.Point(507, 224);
            this.chkObjWfOutputVar.Name = "chkObjWfOutputVar";
            this.chkObjWfOutputVar.Size = new System.Drawing.Size(146, 21);
            this.chkObjWfOutputVar.TabIndex = 9;
            this.chkObjWfOutputVar.Text = "ObjWF Output Var";
            this.chkObjWfOutputVar.UseVisualStyleBackColor = true;
            // 
            // chkObjWfParam
            // 
            this.chkObjWfParam.AutoSize = true;
            this.chkObjWfParam.Location = new System.Drawing.Point(507, 278);
            this.chkObjWfParam.Name = "chkObjWfParam";
            this.chkObjWfParam.Size = new System.Drawing.Size(118, 21);
            this.chkObjWfParam.TabIndex = 11;
            this.chkObjWfParam.Text = "ObjWF Param";
            this.chkObjWfParam.UseVisualStyleBackColor = true;
            // 
            // chkReportColumn
            // 
            this.chkReportColumn.AutoSize = true;
            this.chkReportColumn.Location = new System.Drawing.Point(507, 140);
            this.chkReportColumn.Name = "chkReportColumn";
            this.chkReportColumn.Size = new System.Drawing.Size(124, 21);
            this.chkReportColumn.TabIndex = 7;
            this.chkReportColumn.Text = "Report Column";
            this.chkReportColumn.UseVisualStyleBackColor = true;
            // 
            // chkReportFilter
            // 
            this.chkReportFilter.AutoSize = true;
            this.chkReportFilter.Location = new System.Drawing.Point(507, 113);
            this.chkReportFilter.Name = "chkReportFilter";
            this.chkReportFilter.Size = new System.Drawing.Size(108, 21);
            this.chkReportFilter.TabIndex = 6;
            this.chkReportFilter.Text = "Report Filter";
            this.chkReportFilter.UseVisualStyleBackColor = true;
            // 
            // chkReportButton
            // 
            this.chkReportButton.AutoSize = true;
            this.chkReportButton.Location = new System.Drawing.Point(507, 167);
            this.chkReportButton.Name = "chkReportButton";
            this.chkReportButton.Size = new System.Drawing.Size(118, 21);
            this.chkReportButton.TabIndex = 8;
            this.chkReportButton.Text = "Report Button";
            this.chkReportButton.UseVisualStyleBackColor = true;
            // 
            // chkObjWfButton
            // 
            this.chkObjWfButton.AutoSize = true;
            this.chkObjWfButton.Location = new System.Drawing.Point(507, 251);
            this.chkObjWfButton.Name = "chkObjWfButton";
            this.chkObjWfButton.Size = new System.Drawing.Size(118, 21);
            this.chkObjWfButton.TabIndex = 10;
            this.chkObjWfButton.Text = "ObjWF Button";
            this.chkObjWfButton.UseVisualStyleBackColor = true;
            // 
            // chkLayoutName
            // 
            this.chkLayoutName.AutoSize = true;
            this.chkLayoutName.Location = new System.Drawing.Point(507, 358);
            this.chkLayoutName.Name = "chkLayoutName";
            this.chkLayoutName.Size = new System.Drawing.Size(114, 21);
            this.chkLayoutName.TabIndex = 13;
            this.chkLayoutName.Text = "Layout Name";
            this.chkLayoutName.UseVisualStyleBackColor = true;
            // 
            // rtbSearch
            // 
            this.rtbSearch.Location = new System.Drawing.Point(13, 39);
            this.rtbSearch.Name = "rtbSearch";
            this.rtbSearch.Size = new System.Drawing.Size(479, 313);
            this.rtbSearch.TabIndex = 0;
            this.rtbSearch.Text = "";
            this.rtbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbSearch_KeyPress);
            // 
            // rbAnd
            // 
            this.rbAnd.AutoSize = true;
            this.rbAnd.Location = new System.Drawing.Point(13, 427);
            this.rbAnd.Name = "rbAnd";
            this.rbAnd.Size = new System.Drawing.Size(134, 21);
            this.rbAnd.TabIndex = 2;
            this.rbAnd.Text = "Use &AND search";
            this.rbAnd.UseVisualStyleBackColor = true;
            // 
            // rbOr
            // 
            this.rbOr.AutoSize = true;
            this.rbOr.Checked = true;
            this.rbOr.Location = new System.Drawing.Point(13, 358);
            this.rbOr.Name = "rbOr";
            this.rbOr.Size = new System.Drawing.Size(126, 21);
            this.rbOr.TabIndex = 1;
            this.rbOr.TabStop = true;
            this.rbOr.Text = "Use O&R search";
            this.rbOr.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Search For Text (Each line is a unique search)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "ex. [Line1] matches on at least one data point]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Search Data Points...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = " OR [Line2] matches at least one data point";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 469);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 17);
            this.label5.TabIndex = 31;
            this.label5.Text = "Role Re&quired (Optional):";
            // 
            // txtRoleRequired
            // 
            this.txtRoleRequired.Location = new System.Drawing.Point(13, 489);
            this.txtRoleRequired.Name = "txtRoleRequired";
            this.txtRoleRequired.Size = new System.Drawing.Size(183, 22);
            this.txtRoleRequired.TabIndex = 3;
            // 
            // chkReport
            // 
            this.chkReport.AutoSize = true;
            this.chkReport.Location = new System.Drawing.Point(507, 86);
            this.chkReport.Name = "chkReport";
            this.chkReport.Size = new System.Drawing.Size(73, 21);
            this.chkReport.TabIndex = 32;
            this.chkReport.Text = "Report";
            this.chkReport.UseVisualStyleBackColor = true;
            // 
            // chkObjWF
            // 
            this.chkObjWF.AutoSize = true;
            this.chkObjWF.Location = new System.Drawing.Point(507, 197);
            this.chkObjWF.Name = "chkObjWF";
            this.chkObjWF.Size = new System.Drawing.Size(73, 21);
            this.chkObjWF.TabIndex = 33;
            this.chkObjWF.Text = "ObjWF";
            this.chkObjWF.UseVisualStyleBackColor = true;
            // 
            // chkDBObj
            // 
            this.chkDBObj.AutoSize = true;
            this.chkDBObj.Location = new System.Drawing.Point(507, 304);
            this.chkDBObj.Name = "chkDBObj";
            this.chkDBObj.Size = new System.Drawing.Size(94, 21);
            this.chkDBObj.TabIndex = 34;
            this.chkDBObj.Text = "DB Object";
            this.chkDBObj.UseVisualStyleBackColor = true;
            // 
            // FrmSearchOptions
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(654, 525);
            this.ControlBox = false;
            this.Controls.Add(this.chkDBObj);
            this.Controls.Add(this.chkObjWF);
            this.Controls.Add(this.chkReport);
            this.Controls.Add(this.txtRoleRequired);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbOr);
            this.Controls.Add(this.rbAnd);
            this.Controls.Add(this.rtbSearch);
            this.Controls.Add(this.chkLayoutName);
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
        private System.Windows.Forms.CheckBox chkLayoutName;
        private System.Windows.Forms.RichTextBox rtbSearch;
        private System.Windows.Forms.RadioButton rbAnd;
        private System.Windows.Forms.RadioButton rbOr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRoleRequired;
        private System.Windows.Forms.CheckBox chkReport;
        private System.Windows.Forms.CheckBox chkObjWF;
        private System.Windows.Forms.CheckBox chkDBObj;
    }
}