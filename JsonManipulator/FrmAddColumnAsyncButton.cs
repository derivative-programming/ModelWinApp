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
    public partial class FrmAddColumnAsyncButton : Form
    {
        string _name, _parent;
        public FrmAddColumnAsyncButton(string name, string parent)
        {
            InitializeComponent();
            this._name = name;
            this._parent = parent;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportColumn == null)
            {
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportColumn = new List<reportColumn>();
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


            Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(txtButtonDestination.Text);

            if(destinationOwnerObject == null)
            {
                ShowValidationError("Please select a destination.");
                return;
            }

            if (txtName.Text.Trim().Length > 100)
            {
                ShowValidationError("The name length cannot exceed 100 characters.");
                return;
            }

            Models.reportColumn reportColumn = new reportColumn();
            reportColumn.name = txtName.Text.Trim();
            reportColumn.isButton = "true";
            reportColumn.isVisible = "true";
            reportColumn.buttonDestinationContextObjectName = destinationOwnerObject.name;
            reportColumn.buttonDestinationTargetName = txtButtonDestination.Text.Trim();
            reportColumn.sourceObjectName = destinationOwnerObject.name;
            reportColumn.sourcePropertyName = "Code";
            reportColumn.dataType = "uniqueidentifier";
            reportColumn.buttonText = txtButtonText.Text.Trim();
            reportColumn.isButtonAsyncObjWF = "true";

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportColumn.Add(reportColumn);
             ((Form1)Application.OpenForms["Form1"]).showMessage("Column created successfully");
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
            ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setColumnsList();
            this.Close();
        }
        private bool ItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportColumn.Where(x => x.name == name).ToList().Count > 0)
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
            string defaultSearch = string.Empty;

            if (ReportTargetChildObjectExists())
            {
                defaultSearch = GetReportTargetChildObject();
            }

            using (var form = new frmModelSearch(ModelSearchOptions.FLOWS, defaultSearch))
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


        private bool ReportTargetChildObjectExists()
        {
            bool result = false;
            var report = Utils.GetReport(this._name);
            if (report.TargetChildObject != null &&
                report.TargetChildObject.Trim().Length > 0)
            {
                result = true;
            }
            return result;
        }
        private string GetReportTargetChildObject()
        {
            string result = string.Empty;
            var report = Utils.GetReport(this._name);
            if (report.TargetChildObject != null &&
                report.TargetChildObject.Trim().Length > 0)
            {
                result = report.TargetChildObject;
            }
            return result;
        }
    }
}
