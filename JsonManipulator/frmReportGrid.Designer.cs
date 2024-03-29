﻿
namespace JsonManipulator
{
    partial class frmReportGrid
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
            this.txtRole = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOwner = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnChild = new System.Windows.Forms.Button();
            this.txtChild = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblValidationError = new System.Windows.Forms.Label();
            this.chkSubscribeToOwnerObject = new System.Windows.Forms.CheckBox();
            this.chkSubscribeToTargetChild = new System.Windows.Forms.CheckBox();
            this.txtPageTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.txtName.Size = new System.Drawing.Size(243, 20);
            this.txtName.TabIndex = 6;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(12, 64);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(200, 20);
            this.txtRole.TabIndex = 2;
            this.txtRole.TextChanged += new System.EventHandler(this.txtRole_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Role Required";
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(99, 288);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "&OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(180, 288);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(12, 25);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.ReadOnly = true;
            this.txtOwner.Size = new System.Drawing.Size(200, 20);
            this.txtOwner.TabIndex = 0;
            this.txtOwner.TabStop = false;
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
            this.btnOwner.Size = new System.Drawing.Size(37, 23);
            this.btnOwner.TabIndex = 1;
            this.btnOwner.Text = "...";
            this.btnOwner.UseVisualStyleBackColor = true;
            this.btnOwner.Click += new System.EventHandler(this.btnOwner_Click);
            // 
            // btnRoles
            // 
            this.btnRoles.Location = new System.Drawing.Point(218, 64);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(37, 23);
            this.btnRoles.TabIndex = 3;
            this.btnRoles.Text = "...";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnChild
            // 
            this.btnChild.Location = new System.Drawing.Point(218, 103);
            this.btnChild.Name = "btnChild";
            this.btnChild.Size = new System.Drawing.Size(37, 23);
            this.btnChild.TabIndex = 5;
            this.btnChild.Text = "...";
            this.btnChild.UseVisualStyleBackColor = true;
            this.btnChild.Click += new System.EventHandler(this.btnChild_Click);
            // 
            // txtChild
            // 
            this.txtChild.Location = new System.Drawing.Point(12, 103);
            this.txtChild.Name = "txtChild";
            this.txtChild.ReadOnly = true;
            this.txtChild.Size = new System.Drawing.Size(200, 20);
            this.txtChild.TabIndex = 4;
            this.txtChild.TabStop = false;
            this.txtChild.TextChanged += new System.EventHandler(this.txtChild_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "&Target Child Name";
            // 
            // lblValidationError
            // 
            this.lblValidationError.ForeColor = System.Drawing.Color.Red;
            this.lblValidationError.Location = new System.Drawing.Point(12, 250);
            this.lblValidationError.Name = "lblValidationError";
            this.lblValidationError.Size = new System.Drawing.Size(243, 35);
            this.lblValidationError.TabIndex = 14;
            this.lblValidationError.Text = "Test Valiation Error Display";
            // 
            // chkSubscribeToOwnerObject
            // 
            this.chkSubscribeToOwnerObject.AutoSize = true;
            this.chkSubscribeToOwnerObject.Location = new System.Drawing.Point(12, 207);
            this.chkSubscribeToOwnerObject.Name = "chkSubscribeToOwnerObject";
            this.chkSubscribeToOwnerObject.Size = new System.Drawing.Size(187, 17);
            this.chkSubscribeToOwnerObject.TabIndex = 8;
            this.chkSubscribeToOwnerObject.Text = "Subscribe To Owner Object Props";
            this.chkSubscribeToOwnerObject.UseVisualStyleBackColor = true;
            // 
            // chkSubscribeToTargetChild
            // 
            this.chkSubscribeToTargetChild.AutoSize = true;
            this.chkSubscribeToTargetChild.Location = new System.Drawing.Point(12, 230);
            this.chkSubscribeToTargetChild.Name = "chkSubscribeToTargetChild";
            this.chkSubscribeToTargetChild.Size = new System.Drawing.Size(213, 17);
            this.chkSubscribeToTargetChild.TabIndex = 9;
            this.chkSubscribeToTargetChild.Text = "Subscribe To Target Child Object Props";
            this.chkSubscribeToTargetChild.UseVisualStyleBackColor = true;
            // 
            // txtPageTitle
            // 
            this.txtPageTitle.Location = new System.Drawing.Point(12, 181);
            this.txtPageTitle.Name = "txtPageTitle";
            this.txtPageTitle.Size = new System.Drawing.Size(243, 20);
            this.txtPageTitle.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "&Page Title";
            // 
            // frmReportGrid
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(263, 328);
            this.ControlBox = false;
            this.Controls.Add(this.txtPageTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkSubscribeToOwnerObject);
            this.Controls.Add(this.chkSubscribeToTargetChild);
            this.Controls.Add(this.lblValidationError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnChild);
            this.Controls.Add(this.txtChild);
            this.Controls.Add(this.btnRoles);
            this.Controls.Add(this.btnOwner);
            this.Controls.Add(this.txtOwner);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmReportGrid";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Report Grid";
            this.Load += new System.EventHandler(this.frmReportGrid_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOwner;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnChild;
        private System.Windows.Forms.TextBox txtChild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValidationError;
        private System.Windows.Forms.CheckBox chkSubscribeToOwnerObject;
        private System.Windows.Forms.CheckBox chkSubscribeToTargetChild;
        private System.Windows.Forms.TextBox txtPageTitle;
        private System.Windows.Forms.Label label4;
    }
}