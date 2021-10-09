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
    public partial class frmAddDynaFlowTask : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public string ReturnValue { get; set; }
        public frmAddDynaFlowTask()
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
             

            List<string> existingNames = Utils.GetNameList(false,true,true,true,true);
            if (existingNames.Where(x => x.ToLower().Equals(txtName.Text.Trim().ToLower())).ToList().Count > 0)
            {
                ShowValidationError("Name already exists.");
                return;
            }
             


            objectWorkflow form = new objectWorkflow();
            form.Name = txtName.Text.Trim(); 
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == "DynaFlowTask").FirstOrDefault().objectWorkflow == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == "DynaFlowTask").FirstOrDefault().objectWorkflow = new List<objectWorkflow>();
             

            form.objectWorkflowButton = new List<objectWorkflowButton>(); 
            form.isPage = "false";
            form.isDynaFlowTask = "true"; 



            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x=>x.name== "DynaFlowTask").FirstOrDefault().objectWorkflow.Add(form);

            this.ReturnValue = form.Name;
            this.DialogResult = DialogResult.OK;

            ((Form1)Application.OpenForms["Form1"]).AddToTree(form);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Dyna Flow Task added successfully");
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }

        private void frmForm_Load(object sender, EventArgs e)
        {
            ShowValidationError("");
            txtName.Text = "DynaFlowTask";
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
    }

    

}
