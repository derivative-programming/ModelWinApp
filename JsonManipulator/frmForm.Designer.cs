﻿
namespace JsonManipulator
{
    partial class frmForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOwner = new System.Windows.Forms.Button();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.btnRoles = new System.Windows.Forms.Button();
            this.lblValidationError = new System.Windows.Forms.Label();
            this.chkSubscribeToOwnerObject = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPageTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 87);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 17);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "&Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 103);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 22);
            this.txtName.TabIndex = 4;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(92, 225);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "&OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.frmAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(173, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Role Required";
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(12, 64);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(200, 22);
            this.txtRole.TabIndex = 2;
            this.txtRole.TextChanged += new System.EventHandler(this.txtRole_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "O&wner Object Name";
            // 
            // btnOwner
            // 
            this.btnOwner.Location = new System.Drawing.Point(218, 25);
            this.btnOwner.Name = "btnOwner";
            this.btnOwner.Size = new System.Drawing.Size(30, 23);
            this.btnOwner.TabIndex = 1;
            this.btnOwner.Text = "...";
            this.btnOwner.UseVisualStyleBackColor = true;
            this.btnOwner.Click += new System.EventHandler(this.btnOwner_Click);
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(12, 25);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(200, 22);
            this.txtOwner.TabIndex = 0;
            this.txtOwner.TabStop = false;
            // 
            // btnRoles
            // 
            this.btnRoles.Location = new System.Drawing.Point(218, 64);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(30, 23);
            this.btnRoles.TabIndex = 3;
            this.btnRoles.Text = "...";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // lblValidationError
            // 
            this.lblValidationError.ForeColor = System.Drawing.Color.Red;
            this.lblValidationError.Location = new System.Drawing.Point(12, 188);
            this.lblValidationError.Name = "lblValidationError";
            this.lblValidationError.Size = new System.Drawing.Size(234, 34);
            this.lblValidationError.TabIndex = 11;
            this.lblValidationError.Text = "Test Valiation Error Display";
            // 
            // chkSubscribeToOwnerObject
            // 
            this.chkSubscribeToOwnerObject.AutoSize = true;
            this.chkSubscribeToOwnerObject.Location = new System.Drawing.Point(12, 168);
            this.chkSubscribeToOwnerObject.Name = "chkSubscribeToOwnerObject";
            this.chkSubscribeToOwnerObject.Size = new System.Drawing.Size(245, 21);
            this.chkSubscribeToOwnerObject.TabIndex = 6;
            this.chkSubscribeToOwnerObject.Text = "Subscribe To Owner Object Props";
            this.chkSubscribeToOwnerObject.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "&Page Title";
            // 
            // txtPageTitle
            // 
            this.txtPageTitle.Location = new System.Drawing.Point(12, 142);
            this.txtPageTitle.Name = "txtPageTitle";
            this.txtPageTitle.Size = new System.Drawing.Size(236, 22);
            this.txtPageTitle.TabIndex = 5;
            // 
            // frmForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(258, 259);
            this.ControlBox = false;
            this.Controls.Add(this.txtPageTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkSubscribeToOwnerObject);
            this.Controls.Add(this.lblValidationError);
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.btnOwner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Form Page";
            this.Load += new System.EventHandler(this.frmForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOwner;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Label lblValidationError;
        private System.Windows.Forms.CheckBox chkSubscribeToOwnerObject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPageTitle;
    }
}