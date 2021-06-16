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
    public partial class frmAddApiSiteEnvironment : Form
    {
        string _name;

        public frmAddApiSiteEnvironment(string apiSiteName)
        {
            InitializeComponent();
            this._name = apiSiteName;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _name).FirstOrDefault().apiEnvironment == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _name).FirstOrDefault().apiEnvironment = new List<apiEnvironment>();

        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            txtName.Text = Utils.Capitalize(txtName.Text).Trim();
            if (ItemExists(txtName.Text))
            {
                ShowValidationError("Name already exists.");
                return;
            }
            
            Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _name).FirstOrDefault().apiEnvironment.Add(new apiEnvironment { name = txtName.Text});
            ((Form1)Application.OpenForms["Form1"]).showMessage("Environment created successfully");
            ((frmAPISettings)Application.OpenForms["frmAPISettings"]).setEnvironmentsList();
            this.Close();
             
        }

        private bool ItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _name).FirstOrDefault().apiEnvironment.Where(x => x.name == name).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmAddButton_Load(object sender, EventArgs e)
        {

            ShowValidationError("");
        }
    }
}
