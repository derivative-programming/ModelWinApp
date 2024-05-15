
namespace JsonManipulator
{
    partial class frmServicesApiModelChat
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkVoiceOutput = new System.Windows.Forms.CheckBox();
            this.chkVoiceInput = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAccept.Location = new System.Drawing.Point(584, 0);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 49);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "&Send";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(659, 269);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 269);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkVoiceOutput);
            this.panel2.Controls.Add(this.chkVoiceInput);
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnAccept);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 269);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 49);
            this.panel2.TabIndex = 4;
            // 
            // chkVoiceOutput
            // 
            this.chkVoiceOutput.AutoSize = true;
            this.chkVoiceOutput.Checked = true;
            this.chkVoiceOutput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVoiceOutput.Location = new System.Drawing.Point(466, 3);
            this.chkVoiceOutput.Name = "chkVoiceOutput";
            this.chkVoiceOutput.Size = new System.Drawing.Size(112, 21);
            this.chkVoiceOutput.TabIndex = 4;
            this.chkVoiceOutput.Text = "Voice Output";
            this.chkVoiceOutput.UseVisualStyleBackColor = true;
            // 
            // chkVoiceInput
            // 
            this.chkVoiceInput.AutoSize = true;
            this.chkVoiceInput.Checked = true;
            this.chkVoiceInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVoiceInput.Location = new System.Drawing.Point(360, 3);
            this.chkVoiceInput.Name = "chkVoiceInput";
            this.chkVoiceInput.Size = new System.Drawing.Size(100, 21);
            this.chkVoiceInput.TabIndex = 3;
            this.chkVoiceInput.Text = "Voice Input";
            this.chkVoiceInput.UseVisualStyleBackColor = true;
            this.chkVoiceInput.CheckedChanged += new System.EventHandler(this.chkVoiceInput_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(575, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // frmServicesApiModelChat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(659, 318);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmServicesApiModelChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model AI Chat";
            this.Load += new System.EventHandler(this.FrmAddColumn_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkVoiceOutput;
        private System.Windows.Forms.CheckBox chkVoiceInput;
    }
}