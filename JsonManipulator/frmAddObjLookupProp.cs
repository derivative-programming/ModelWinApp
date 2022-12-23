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
    public partial class frmAddObjLookupProp : Form
    {
        string _name;
        public frmAddObjLookupProp(string name)
        {
            InitializeComponent();
            this._name = name;

            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property == null)
            {
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property = new List<property>();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!txtName.Text.ToUpper().EndsWith("ID"))
            {
                txtName.Text = txtName.Text + "ID";
            }

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

            string fkObjName = txtName.Text.Substring(0, txtName.Text.Length - 2);

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property.Add(new property { name =txtName.Text, isFKLookup = "true", isFK = "true", fKObjectName = fkObjName, fKObjectPropertyName = fkObjName + "ID"});
            ((Form1)Application.OpenForms["Form1"]).showMessage("Property created successfully");
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
            ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).setPropertieList();
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
        private bool ItemExists(string name)
        {
            bool result = false;
            if(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property.Where(x => x.name == name).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void frmAddObjLookupProp_Load(object sender, EventArgs e)
        {

            ShowValidationError("");
        } 
    }
}
