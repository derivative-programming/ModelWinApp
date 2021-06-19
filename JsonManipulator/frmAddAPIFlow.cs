using JsonManipulator.Enums;
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
    public partial class frmAddAPIFlow : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public frmAddAPIFlow()
        {
            InitializeComponent();
        }

        private void frmAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = Utils.Capitalize(txtName.Text).Replace(" ", "");

            if (txtName.Text.Trim().Length == 0)
            {
                ShowValidationError("Name Required.");
                return;
            }

            if (txtOwner.Text.Trim().Length == 0)
            {
                ShowValidationError("Owner Object Name Required.");
                return;
            }

            List<string> existingNames = Utils.GetNameList(false,true,true,true,true);
            if (existingNames.Where(x => x.ToLower().Equals(txtName.Text.Trim().ToLower())).ToList().Count > 0)
            {
                ShowValidationError("Name already exists.");
                return;
            }

            List<string> existingDBObjects = Utils.GetNameList(true, false, false, false, false);
            if (existingDBObjects.Where(x => x.ToLower().Equals(txtOwner.Text.Trim().ToLower())).ToList().Count == 0)
            {
                ShowValidationError("Owner Object Not Found.");
                return;
            }

            if (!txtName.Text.Trim().ToLower().StartsWith(txtOwner.Text.Trim().ToLower() + txtAPIName.Text.Trim().ToLower() + txtAPIVersion.Text.Trim().ToLower()))
            {
                ShowValidationError("Please modify the name to use the format " + Environment.NewLine + "[Owner Object Name][API Name][API Version][Functional Name].");
                return;
            }


            objectWorkflow form = new objectWorkflow();
            form.Name = txtName.Text.Trim();
            form.RoleRequired = ""; 
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault().objectWorkflow == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault().objectWorkflow = new List<objectWorkflow>();
             

            form.objectWorkflowButton = new List<objectWorkflowButton>(); 
            form.IsPage = "false";



            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x=>x.name== txtOwner.Text.Trim()).FirstOrDefault().objectWorkflow.Add(form);


            if (chkSubscribeToOwnerObject.Checked)
            {
                Utils.AddPropSubscriptionFor(
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault(),
                    form.Name);
            }

            ((Form1)Application.OpenForms["Form1"]).AddToTree(form);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Flow was added successfully");
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }

        private void frmForm_Load(object sender, EventArgs e)
        {
            ShowValidationError("");
        }
        public void setOwner(string Owner)
        {
            txtOwner.Text =Owner;
            txtName.Text = txtOwner.Text.Trim() + txtAPIName.Text.Trim() + txtAPIVersion.Text.Trim();
        }
        private void btnOwner_Click(object sender, EventArgs e)
        {
             
            using (var form = new ObjectsList())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    setOwner(val);
                }
            }
        }
         
        public void setAPISite(string name)
        {
            txtAPIName.Text = name;
            txtName.Text = txtOwner.Text.Trim() + txtAPIName.Text.Trim() + txtAPIVersion.Text.Trim();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         

        private void txtAPIName_TextChanged(object sender, EventArgs e)
        {

            txtName.Text = txtOwner.Text.Trim() + txtAPIName.Text.Trim() + txtAPIVersion.Text.Trim();
        }

        private void txtAPIVersion_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = txtOwner.Text.Trim() + txtAPIName.Text.Trim() + txtAPIVersion.Text.Trim();

        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            using (var form = new APISiteList())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    setAPISite(val); 
                }
            }
        }
    }

    

}
