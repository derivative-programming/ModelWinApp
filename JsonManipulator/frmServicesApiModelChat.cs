using JsonManipulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{
    public partial class frmServicesApiModelChat : Form
    {
        public string ReturnValue { get; set; }

        public frmServicesApiModelChat()
        {
            InitializeComponent(); 
        }
         

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length == 0)
            {
                return;
            }

            btnAccept.Enabled = false;

            string queryText = textBox1.Text;

            textBox1.Text = ""; 

            AppendTextAndScroll(DateTime.Now.ToLongTimeString() + ": " + queryText);

            string projectCodeVal = Form1._model.root.ProjectCode;

            Guid projectCode = Guid.Parse(projectCodeVal);
            string responseText = await OpenAPIs.ApiManager.AddModelChatQueryAsync(queryText, projectCode);
             

            AppendTextAndScroll(DateTime.Now.ToLongTimeString() + ": " + responseText);

            btnAccept.Enabled = true;

            textBox1.Focus();
        }

        private async void FrmAddColumn_Load(object sender, EventArgs e)
        {

            string projectCodeVal = Form1._model.root.ProjectCode;

            Guid projectCode = Guid.Parse(projectCodeVal);
            string responseText = await OpenAPIs.ApiManager.AddModelChatQueryAsync("new thread", projectCode);


            AppendTextAndScroll(DateTime.Now.ToLongTimeString() + ": " + responseText);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the ding sound when pressing enter
                e.SuppressKeyPress = true;
                // Trigger the button click
                btnAccept.PerformClick();
            }
        }

        private void AppendTextAndScroll(string text)
        {
            // Suspend layout to prevent flickering
            richTextBox1.SuspendLayout();

            // Save the current selection start and length
            int selStart = richTextBox1.SelectionStart;
            int selLength = richTextBox1.SelectionLength;

            // Set the selection to the end of the existing text
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;

            // Insert the text at the current selection, which is the end
            richTextBox1.SelectedText = Environment.NewLine + Environment.NewLine + text;

            // Scroll to the caret position, which is at the end after appending
            richTextBox1.ScrollToCaret();

            // Restore the previous selection
            richTextBox1.SelectionStart = selStart;
            richTextBox1.SelectionLength = selLength;

            // Resume layout to update the UI
            richTextBox1.ResumeLayout();
        }
    }
}
