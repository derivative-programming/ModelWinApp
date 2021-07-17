
namespace JsonManipulator
{
    partial class FrmAddColumnAsyncButton
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblValidationError = new System.Windows.Forms.Label();
            this.txtButtonText = new System.Windows.Forms.TextBox();
            this.lblButtonText = new System.Windows.Forms.Label();
            this.txtButtonDestination = new System.Windows.Forms.TextBox();
            this.btnDestinationLookup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(237, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(156, 157);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "&OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 103);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 20);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 87);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "&Name";
            // 
            // lblValidationError
            // 
            this.lblValidationError.ForeColor = System.Drawing.Color.Red;
            this.lblValidationError.Location = new System.Drawing.Point(12, 127);
            this.lblValidationError.Name = "lblValidationError";
            this.lblValidationError.Size = new System.Drawing.Size(300, 27);
            this.lblValidationError.TabIndex = 20;
            this.lblValidationError.Text = "Test Valiation Error Display";
            // 
            // txtButtonText
            // 
            this.txtButtonText.Location = new System.Drawing.Point(12, 25);
            this.txtButtonText.Name = "txtButtonText";
            this.txtButtonText.Size = new System.Drawing.Size(300, 20);
            this.txtButtonText.TabIndex = 0;
            this.txtButtonText.TextChanged += new System.EventHandler(this.txtButtonText_TextChanged);
            // 
            // lblButtonText
            // 
            this.lblButtonText.AutoSize = true;
            this.lblButtonText.Location = new System.Drawing.Point(12, 9);
            this.lblButtonText.Name = "lblButtonText";
            this.lblButtonText.Size = new System.Drawing.Size(62, 13);
            this.lblButtonText.TabIndex = 21;
            this.lblButtonText.Text = "&Button Text";
            // 
            // txtButtonDestination
            // 
            this.txtButtonDestination.Location = new System.Drawing.Point(12, 64);
            this.txtButtonDestination.Name = "txtButtonDestination";
            this.txtButtonDestination.ReadOnly = true;
            this.txtButtonDestination.Size = new System.Drawing.Size(264, 20);
            this.txtButtonDestination.TabIndex = 25;
            this.txtButtonDestination.TabStop = false;
            // 
            // btnDestinationLookup
            // 
            this.btnDestinationLookup.Location = new System.Drawing.Point(282, 64);
            this.btnDestinationLookup.Name = "btnDestinationLookup";
            this.btnDestinationLookup.Size = new System.Drawing.Size(30, 23);
            this.btnDestinationLookup.TabIndex = 1;
            this.btnDestinationLookup.Text = "...";
            this.btnDestinationLookup.UseVisualStyleBackColor = true;
            this.btnDestinationLookup.Click += new System.EventHandler(this.btnDestinationLookup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Async Flow";
            // 
            // FrmAddColumnAsyncButton
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(329, 193);
            this.ControlBox = false;
            this.Controls.Add(this.txtButtonDestination);
            this.Controls.Add(this.btnDestinationLookup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtButtonText);
            this.Controls.Add(this.lblButtonText);
            this.Controls.Add(this.lblValidationError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmAddColumnAsyncButton";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Column Async Button";
            this.Load += new System.EventHandler(this.FrmAddColumn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblValidationError;
        private System.Windows.Forms.TextBox txtButtonText;
        private System.Windows.Forms.Label lblButtonText;
        private System.Windows.Forms.TextBox txtButtonDestination;
        private System.Windows.Forms.Button btnDestinationLookup;
        private System.Windows.Forms.Label label1;
    }
}