using JsonManipulator.Enums;
using JsonManipulator.Models;
using Newtonsoft.Json;
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
    public partial class frmAddApiSite : Form
    {
        public frmAddApiSite()
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
             

            List<string> objectNames = Utils.GetApiSiteNameList();
            if (objectNames.Where(x => x.ToLower().Equals(txtName.Text.Trim().ToLower())).ToList().Count > 0)
            {
                ShowValidationError("Name already exists.");
                return;
            }
            Models.apiSite apiSite = new apiSite
            {
                name = txtName.Text.Trim()
            };
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite = new List<Models.apiSite>();
            Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Add(apiSite);
            ((Form1)Application.OpenForms["Form1"]).AddToTree(apiSite);
            ((Form1)Application.OpenForms["Form1"]).showMessage("API Site " + apiSite.name + " saved successfully");
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
         

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDbObject_Load(object sender, EventArgs e)
        {
            ShowValidationError("");
        }
    }
}
