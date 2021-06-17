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
    public partial class frmReportDetail : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public frmReportDetail()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

            List<string> existingNames = Utils.GetNameList(false, true, true, true);
            if (existingNames.Where(x => x.ToLower().Equals(txtName.Text.Trim().ToLower())).ToList().Count > 0)
            {
                ShowValidationError("Name already exists.");
                return;
            }

            List<string> existingDBObjects = Utils.GetNameList(true, false, false, false);
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
            Report rpt = new Report { name = txtName.Text, RoleRequired = txtRole.Text, visualizationType = "DetailThreeColumn"};
            rpt.isPage = "true";

            Models.reportButton reportButton = new reportButton();
            reportButton.buttonType = "back";
            reportButton.buttonText = "Back";
            reportButton.buttonName = "Back";

            rpt.reportButton = new List<reportButton>();
            rpt.reportButton.Add(reportButton);

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault().report.Add(rpt);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Report Detail was added successfully");
            ((Form1)Application.OpenForms["Form1"]).AddToTree(rpt);
            this.Close();
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            ObjectsList objectsList = new ObjectsList(FormObjects.DBOBJECT_RPT_DETAIL);
            objectsList.ShowDialog();
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
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim() + "Detail";
        }
        public void setRole(string Role)
        {
            txtRole.Text = Role;
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim() + "Detail";
        }
        private void btnRoles_Click(object sender, EventArgs e)
        {
            RoleList objectsList = new RoleList(FormObjects.DBOBJECT_RPT_DETAIL);
            objectsList.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        { 
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim() + "Detail"; ;
        }
    }
}
