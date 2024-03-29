﻿
namespace JsonManipulator
{
    partial class frmAddAPIFlow
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOwner = new System.Windows.Forms.Button();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.lblValidationError = new System.Windows.Forms.Label();
            this.chkSubscribeToOwnerObject = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAPIName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAPIVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 126);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 142);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 20);
            this.txtName.TabIndex = 3;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(92, 220);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "&OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.frmAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(173, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "O&wner Object Name";
            // 
            // btnOwner
            // 
            this.btnOwner.Location = new System.Drawing.Point(218, 25);
            this.btnOwner.Name = "btnOwner";
            this.btnOwner.Size = new System.Drawing.Size(30, 23);
            this.btnOwner.TabIndex = 0;
            this.btnOwner.Text = "...";
            this.btnOwner.UseVisualStyleBackColor = true;
            this.btnOwner.Click += new System.EventHandler(this.btnOwner_Click);
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(12, 25);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(200, 20);
            this.txtOwner.TabIndex = 6;
            this.txtOwner.TabStop = false;
            // 
            // lblValidationError
            // 
            this.lblValidationError.ForeColor = System.Drawing.Color.Red;
            this.lblValidationError.Location = new System.Drawing.Point(12, 188);
            this.lblValidationError.Name = "lblValidationError";
            this.lblValidationError.Size = new System.Drawing.Size(236, 29);
            this.lblValidationError.TabIndex = 11;
            this.lblValidationError.Text = "Test Valiation Error Display";
            // 
            // chkSubscribeToOwnerObject
            // 
            this.chkSubscribeToOwnerObject.AutoSize = true;
            this.chkSubscribeToOwnerObject.Location = new System.Drawing.Point(12, 168);
            this.chkSubscribeToOwnerObject.Name = "chkSubscribeToOwnerObject";
            this.chkSubscribeToOwnerObject.Size = new System.Drawing.Size(187, 17);
            this.chkSubscribeToOwnerObject.TabIndex = 4;
            this.chkSubscribeToOwnerObject.Text = "Subscribe To Owner Object Props";
            this.chkSubscribeToOwnerObject.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAPIName
            // 
            this.txtAPIName.Location = new System.Drawing.Point(12, 64);
            this.txtAPIName.Name = "txtAPIName";
            this.txtAPIName.ReadOnly = true;
            this.txtAPIName.Size = new System.Drawing.Size(200, 20);
            this.txtAPIName.TabIndex = 18;
            this.txtAPIName.TabStop = false;
            this.txtAPIName.TextChanged += new System.EventHandler(this.txtAPIName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "&API Name";
            // 
            // txtAPIVersion
            // 
            this.txtAPIVersion.Location = new System.Drawing.Point(12, 103);
            this.txtAPIVersion.Name = "txtAPIVersion";
            this.txtAPIVersion.Size = new System.Drawing.Size(236, 20);
            this.txtAPIVersion.TabIndex = 2;
            this.txtAPIVersion.TextChanged += new System.EventHandler(this.txtAPIVersion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "API Version (V#### format)";
            // 
            // frmAddAPIFlow
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(261, 257);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAPIName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAPIVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkSubscribeToOwnerObject);
            this.Controls.Add(this.lblValidationError);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.btnOwner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddAPIFlow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Flow";
            this.Load += new System.EventHandler(this.frmForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label lblValidationError;
        private System.Windows.Forms.CheckBox chkSubscribeToOwnerObject;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAPIName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAPIVersion;
        private System.Windows.Forms.Label label2;
    }
}