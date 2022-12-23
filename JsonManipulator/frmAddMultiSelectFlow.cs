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
    public partial class frmAddMultiSelectFlow : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();

        private string _reportOwnerObjectName = string.Empty;
        private string _reportTargetChildObjectName = string.Empty;

        public frmAddMultiSelectFlow(string defaultReportName)
        {
            InitializeComponent();
            if(defaultReportName.Trim().Length > 0)
            {
                txtOwner.Text = defaultReportName;
                setOwner(defaultReportName);
            }
        }

        private void frmAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = Utils.Capitalize(txtName.Text).Replace(" ", "");

            if (txtName.Text.Trim().Length == 0)
            {
                ShowValidationError("Name Required.");
                return;
            }
            if (txtName.Text.Trim().Contains(" "))
            {
                ShowValidationError("Remove Spaces from name.");
                return;
            }

            if (txtOwner.Text.Trim().Length == 0)
            {
                ShowValidationError("Report Name Required.");
                return;
            }

            List<string> existingNames = Utils.GetNameList(false,true,true,true,true);
            if (existingNames.Where(x => x.ToLower().Equals(txtName.Text.Trim().ToLower())).ToList().Count > 0)
            {
                ShowValidationError("Name already exists.");
                return;
            }

            List<string> existingDBObjects = Utils.GetNameList(false, true, false, false, false);
            if (existingDBObjects.Where(x => x.ToLower().Equals(txtOwner.Text.Trim().ToLower())).ToList().Count == 0)
            {
                ShowValidationError("Report Not Found.");
                return;
            }
            setOwner(txtOwner.Text.Trim());

            if (!txtName.Text.Trim().ToLower().StartsWith(this._reportTargetChildObjectName.Trim().ToLower() + txtRole.Text.Trim().ToLower()))
            {
                ShowValidationError("Please modify the name to use the format " + Environment.NewLine + "[Report Target Child Object Name][Role Name][Functional Name].");
                return;
            }

            if (txtName.Text.Trim().Length > 100)
            {
                ShowValidationError("The name length cannot exceed 100 characters.");
                return;
            }

            string functionName = txtName.Text.Trim().Remove(0, (this._reportTargetChildObjectName.Trim() + txtRole.Text.Trim()).Length);


            objectWorkflow form = new objectWorkflow();
            form.Name = txtName.Text.Trim();
            form.RoleRequired = txtRole.Text.Trim(); 
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == this._reportTargetChildObjectName.Trim()).FirstOrDefault().objectWorkflow == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == this._reportTargetChildObjectName.Trim()).FirstOrDefault().objectWorkflow = new List<objectWorkflow>();
             

            form.objectWorkflowButton = new List<objectWorkflowButton>(); 
            form.isPage = "false"; 


            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x=>x.name== this._reportTargetChildObjectName.Trim()).FirstOrDefault().objectWorkflow.Add(form);

            AddReportMulitSelectButton(functionName);

            ((Form1)Application.OpenForms["Form1"]).AddToTree(form);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Flow was added successfully");
            this.Close();
        }

        private bool ReportButtonItemExists(string buttonName)
        {
            Report report = Utils.GetReport(txtOwner.Text);
            bool result = false;
            if (report.reportButton.Where(x => x.buttonName == buttonName).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }
        private void AddReportMulitSelectButton(string buttonName)
        {
            Report report = Utils.GetReport(txtOwner.Text);
            ObjectMap objectMap = Utils.GetReportOwnerObject(txtOwner.Text.Trim());
            if (report.reportButton == null)
            {
                report.reportButton = new List<reportButton>();
            }

            txtName.Text = Utils.Capitalize(txtName.Text).Trim();
            if (ReportButtonItemExists(txtName.Text))
            {
                ShowValidationError("Name already exists.");
                return;
            }

            if (txtName.Text.Trim().Contains(" "))
            {
                ShowValidationError("Remove Spaces from name.");
                return;
            }

            if (txtName.Text.Trim().Length > 100)
            {
                ShowValidationError("The name length cannot exceed 100 characters.");
                return;
            }

            report.reportButton.Add(new reportButton { buttonName = buttonName, destinationContextObjectName = objectMap.name, destinationTargetName= txtName.Text.Trim(), buttonType = "multiSelectProcessing", buttonText = Utils.ConvertPascalToSpaced(buttonName) });

            ((Form1)Application.OpenForms["Form1"]).showMessage("Button created successfully");
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges(); 
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }

        private void frmForm_Load(object sender, EventArgs e)
        {
            ShowValidationError("");
        }
        public void setOwner(string reportName)
        {
            Report report = Utils.GetReport(reportName);
            ObjectMap dbObject = Utils.GetReportOwnerObject(reportName);
            this._reportOwnerObjectName = dbObject.name;
            this._reportTargetChildObjectName = report.TargetChildObject;
            txtOwner.Text = reportName;
            txtName.Text = this._reportTargetChildObjectName + txtRole.Text.Trim();
        }
        private void btnOwner_Click(object sender, EventArgs e)
        {
             
            using (var form = new frmModelSearch(ModelSearchOptions.REPORTS))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    setOwner(val);
                }
            }
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            using (var form = new frmModelSearch(ModelSearchOptions.ROLES))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    setRole(val);
                }
            }
        }
        public void setRole(string Role)
        {
            txtRole.Text =Role;
            txtName.Text = this._reportTargetChildObjectName + txtRole.Text.Trim();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {

            txtName.Text = this._reportTargetChildObjectName  + txtRole.Text.Trim();
        }
    }

    

}
