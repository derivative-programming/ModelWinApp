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
    public partial class FrmAddNavButton : Form
    { 
        public FrmAddNavButton()
        {
            InitializeComponent(); 
            if (Form1._model.root.navButton == null)
            {
                Form1._model.root.navButton = new List<navButton>();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            txtName.Text = Utils.Capitalize(txtName.Text).Trim();
            if (ItemExists(txtName.Text))
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



            Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(txtButtonDestination.Text);

            if(destinationOwnerObject == null)
            {
                ShowValidationError("Please select a destination.");
                return;
            }
            Models.navButton navBtn = new navButton();
            navBtn.buttonName = txtName.Text.Trim(); 
            navBtn.isVisible = "true";
            navBtn.destinationContextObjectName = destinationOwnerObject.name;
            navBtn.destinationTargetName = txtButtonDestination.Text.Trim(); 
            navBtn.buttonText = txtButtonText.Text.Trim();
            navBtn.buttonType = "primary";
            navBtn.isEnabled = "true";


            Form1._model.root.navButton.Add(navBtn);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Nav Button created successfully");
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
            ((frmSettings)Application.OpenForms["frmSettings"]).setNavButtonsList();
            this.Close();
        }
        private bool ItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.navButton.Where(x => x.buttonName == name).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }

        private void FrmAddColumn_Load(object sender, EventArgs e)
        {

            ShowValidationError("");
        }
         

        private void btnDestinationLookup_Click(object sender, EventArgs e)
        { 
            using (var form = new frmModelSearch(ModelSearchOptions.FORMS))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    SetDestination(val);
                }
            }
        }

        public void SetDestination(string name)
        {
            txtButtonDestination.Text = name;
            Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(name);
            txtName.Text = Utils.Capitalize(txtButtonText.Text).Replace(" ", "") + "Link" + destinationOwnerObject.name + "Code";
        }

        private void txtButtonText_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = Utils.Capitalize(txtButtonText.Text).Replace(" ","") + "Link";
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
    }
}
