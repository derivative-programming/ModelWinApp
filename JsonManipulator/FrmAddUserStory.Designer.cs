
namespace JsonManipulator
{
    partial class FrmAddUserStory
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblValidationError = new System.Windows.Forms.Label();
            this.btnBulk = new System.Windows.Forms.Button();
            this.txtUserStory = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(487, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(406, 131);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "&OK";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(106, 17);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "&User Story Text";
            // 
            // lblValidationError
            // 
            this.lblValidationError.ForeColor = System.Drawing.Color.Red;
            this.lblValidationError.Location = new System.Drawing.Point(9, 101);
            this.lblValidationError.Name = "lblValidationError";
            this.lblValidationError.Size = new System.Drawing.Size(300, 27);
            this.lblValidationError.TabIndex = 20;
            this.lblValidationError.Text = "Test Valiation Error Display On to the Second line Of This Validation Error Text " +
    "Label";
            // 
            // btnBulk
            // 
            this.btnBulk.Location = new System.Drawing.Point(12, 131);
            this.btnBulk.Name = "btnBulk";
            this.btnBulk.Size = new System.Drawing.Size(80, 23);
            this.btnBulk.TabIndex = 1;
            this.btnBulk.Text = "&Bulk Add";
            this.btnBulk.UseVisualStyleBackColor = true;
            this.btnBulk.Click += new System.EventHandler(this.btnBulk_Click);
            // 
            // txtUserStory
            // 
            this.txtUserStory.Location = new System.Drawing.Point(15, 48);
            this.txtUserStory.Name = "txtUserStory";
            this.txtUserStory.Size = new System.Drawing.Size(547, 50);
            this.txtUserStory.TabIndex = 0;
            this.txtUserStory.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Format... \'A [Role name] wants to [View all, view, add, update, delete] a [object" +
    " name]\'";
            // 
            // FrmAddUserStory
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(574, 166);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserStory);
            this.Controls.Add(this.btnBulk);
            this.Controls.Add(this.lblValidationError);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmAddUserStory";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add User Story";
            this.Load += new System.EventHandler(this.FrmAddUserStory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblValidationError;
        private System.Windows.Forms.Button btnBulk;
        private System.Windows.Forms.RichTextBox txtUserStory;
        private System.Windows.Forms.Label label1;
    }
}