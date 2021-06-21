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
    public partial class frmReportGrid : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public frmReportGrid()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = Utils.Capitalize(txtName.Text).Replace(" ","");

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

            List<string> existingNames = Utils.GetNameList(false, true, true, true,true);
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

            if (!txtName.Text.Trim().ToLower().StartsWith(txtOwner.Text.Trim().ToLower() + txtRole.Text.Trim().ToLower()))
            {
                ShowValidationError("Please modify the name to use the format " + Environment.NewLine + "[Owner Object Name][Role Name][Functional Name].");
                return;
            }

            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault().report == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault().report = new List<Models.Report>();
            Report rpt = new Report { name = txtName.Text.Trim(), RoleRequired = txtRole.Text.Trim(), TargetChildObject = txtChild.Text.Trim(), visualizationType = "Grid"};
            rpt.isPage = "true";
            rpt.isCustomSqlUsed = "false";
            rpt.layoutName = Utils.Capitalize(txtRole.Text.Trim()) + "Layout";
            rpt.pageTitleText = Utils.ConvertPascalToSpaced(rpt.name);
            if (txtChild.Text.Length > 0)
            {
                rpt.pageTitleText = Utils.ConvertPascalToSpaced(txtChild.Text.Trim());

            }

            Models.reportButton reportButton = new reportButton();
            reportButton.buttonType = "back";
            reportButton.buttonText = "Back";
            reportButton.buttonName = "Back";

            rpt.reportButton = new List<reportButton>();
            rpt.reportButton.Add(reportButton);

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault().report.Add(rpt);

            if (chkSubscribeToOwnerObject.Checked)
            {
                Utils.AddPropSubscriptionFor(
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault(),
                    rpt.name);
            }
            if (txtChild.Text.Length > 0)
            {
                if (chkSubscribeToTargetChild.Checked)
                {
                    Utils.AddPropSubscriptionFor(
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtChild.Text.Trim()).FirstOrDefault(),
                        rpt.name);
                }
            }


            ((Form1)Application.OpenForms["Form1"]).showMessage("Report Grid was added successfully");
            ((Form1)Application.OpenForms["Form1"]).AddToTree(rpt);
            this.Close();
        }

        private void btnOwner_Click(object sender, EventArgs e)
        { 
            using (var form = new frmModelSearch(ModelSearchOptions.OBJECTS))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    setOwner(val);
                }
            }
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
        private void frmReportGrid_Load(object sender, EventArgs e)
        {
            ShowValidationError("");
        }
        public void setOwner(string Owner)
        {
            txtOwner.Text = Owner;
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim() + txtChild.Text.Trim() + "List";
        }
        public void setRole(string Role)
        {
            txtRole.Text = Role;
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim() + txtChild.Text.Trim() + "List";
        }
        public void setChild(string Child)
        {
            txtChild.Text = Child;
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim() + txtChild.Text.Trim() + "List";
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

        private void btnChild_Click(object sender, EventArgs e)
        {  
            using (var form = new frmModelSearch(ModelSearchOptions.OBJECTS))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    setChild(val);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim() + txtChild.Text.Trim() + "List";
        }

        private void txtChild_TextChanged(object sender, EventArgs e)
        {

            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim() + txtChild.Text.Trim() + "List";
        }
    }
}
