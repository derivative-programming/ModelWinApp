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
    public partial class frmAddObjLookupItem : Form
    {
        string _name;
        public frmAddObjLookupItem(string name)
        {
            InitializeComponent();
            this._name = name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().lookupItem == null)
            {
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().lookupItem = new List<lookupItem>();
            }

            txtName.Text = Utils.Capitalize(txtName.Text).Trim();
            if (ItemExists(txtName.Text))
            {
                ShowValidationError("Name already exists.");
                return;
            }

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().lookupItem.Add(new lookupItem { enumValue = txtName.Text, name = txtName.Text , description = txtName.Text, isActive="true" });
            ((Form1)Application.OpenForms["Form1"]).showMessage("Lookup Item created successfully");
            ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).setLookupItemList();
                this.Close();
        }

        private bool ItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().lookupItem.Where(x => x.enumValue == name).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }
        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void frmAddObjProp_Load(object sender, EventArgs e)
        {

            ShowValidationError("");
        }
    }
}
