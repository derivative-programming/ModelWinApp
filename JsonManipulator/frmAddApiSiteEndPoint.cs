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
    public partial class frmAddApiSiteEndPoint : Form
    {
        string _name;

        public frmAddApiSiteEndPoint(string apiSiteName)
        {
            InitializeComponent();
            this._name = apiSiteName;

            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _name).FirstOrDefault().apiEndPoint == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _name).FirstOrDefault().apiEndPoint = new List<apiEndPoint>();

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

            Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _name).FirstOrDefault().apiEndPoint.Add(new apiEndPoint { name = txtName.Text.Trim() });
            ((Form1)Application.OpenForms["Form1"]).showMessage("EndPoint created successfully");
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
            ((frmAPISettings)Application.OpenForms["frmAPISettings"]).setEndPointsList();
            this.Close();
             
        }

        private bool ItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _name).FirstOrDefault().apiEndPoint.Where(x => x.name == name).ToList().Count > 0)
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
