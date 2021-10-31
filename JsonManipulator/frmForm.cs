﻿using JsonManipulator.Enums;
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
    public partial class frmForm : Form
    {
        ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
        ContextMenuStrip roleContextMenuStrip = new ContextMenuStrip();
        public frmForm()
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

            if (!txtName.Text.Trim().ToLower().StartsWith(txtOwner.Text.Trim().ToLower() + txtRole.Text.Trim().ToLower()))
            {
                ShowValidationError("Please modify the name to use the format " + Environment.NewLine + "[Owner Object Name][Role Name][Functional Name].");
                return;
            }

            if (txtPageTitle.Text.Trim().Length == 0)
            {
                ShowValidationError("Please enter a page title.");
                return;
            }

            if (txtName.Text.Trim().Length > 100)
            {
                ShowValidationError("The name length cannot exceed 100 characters.");
                return;
            }


            objectWorkflow form = new objectWorkflow();
            form.Name = txtName.Text.Trim();
            form.RoleRequired = txtRole.Text.Trim(); 
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault().objectWorkflow == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == txtOwner.Text.Trim()).FirstOrDefault().objectWorkflow = new List<objectWorkflow>();

            Models.objectWorkflowButton formButtonSubmit = new objectWorkflowButton();
            formButtonSubmit.buttonText = "OK";
            formButtonSubmit.buttonType = "submit";
            formButtonSubmit.isVisible = "true";


            Models.objectWorkflowButton formButtonCancel = new objectWorkflowButton();
            formButtonCancel.buttonText = "Cancel";
            formButtonCancel.buttonType = "cancel";
            formButtonCancel.isVisible = "true";

            form.objectWorkflowButton = new List<objectWorkflowButton>();
            form.objectWorkflowButton.Add(formButtonSubmit);
            form.objectWorkflowButton.Add(formButtonCancel);
            form.isPage = "true";
            //form.pageTitleText = Utils.ConvertPascalToSpaced(form.Name);
            form.pageTitleText = txtPageTitle.Text.Trim();
            form.layoutName = Utils.Capitalize(txtRole.Text.Trim()) + "Layout";



            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x=>x.name== txtOwner.Text.Trim()).FirstOrDefault().objectWorkflow.Add(form);
            ((Form1)Application.OpenForms["Form1"]).AddToTree(form);
            ((Form1)Application.OpenForms["Form1"]).showMessage("Form was added successfully");
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
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim();
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
            txtRole.Text = Role;
            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {

            txtName.Text = txtOwner.Text.Trim() + txtRole.Text.Trim();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPageTitle.Text = Utils.ConvertPascalToSpaced(txtName.Text);
        }
    }

    

}
