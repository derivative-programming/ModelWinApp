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

            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += DateTime.Now.ToLongTimeString() + ": " + queryText;

            string projectCodeVal = Form1._model.root.ProjectCode;

            Guid projectCode = Guid.Parse(projectCodeVal);
            string responseText = await OpenAPIs.ApiManager.AddModelChatQueryAsync(queryText, projectCode);

            richTextBox1.Text += Environment.NewLine;
            richTextBox1.Text += DateTime.Now.ToLongTimeString() + ": " + responseText;

            btnAccept.Enabled = true;

        }

        private void FrmAddColumn_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = ReturnValue;
        }
         
    }
}
