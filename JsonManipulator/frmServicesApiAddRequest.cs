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
    public partial class frmServicesApiAddRequest : Form
    {
        public string ReturnValue { get; set; }

        public frmServicesApiAddRequest()
        {
            InitializeComponent(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ReturnValue = richTextBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        } 

        private void FrmAddColumn_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = ReturnValue;
        }
         
    }
}
