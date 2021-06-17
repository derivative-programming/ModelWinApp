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
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().lookupItem == null)
            {
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().lookupItem = new List<lookupItem>();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            txtName.Text = Utils.Capitalize(txtName.Text).Trim();
            if (ItemExists(txtName.Text))
            {
                ShowValidationError("Name already exists.");
                return;
            }

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().lookupItem.Add(new lookupItem { enumValue = txtName.Text.Trim(), name = txtName.Text.Trim(), description = txtName.Text.Trim(), isActive="true" });
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

        private void btnBulk_Click(object sender, EventArgs e)
        {
            using (var form = new FrmBulkAdd())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    List<string> items = new List<string>();
                    items.AddRange(val.Split("\n,".ToCharArray()));
                    for (int i = 0; i < items.Count; i++)
                    {
                        string itemName = Utils.Capitalize(items[i]).Trim();
                        if (itemName.Length > 0 && !ItemExists(itemName))
                        {
                            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().lookupItem.Add(new lookupItem { enumValue = itemName, name = itemName, description = itemName, isActive = "true" });
                        }
                    }
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Lookup Item created successfully");
                    ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).setLookupItemList();
                }
            }
            this.Close();
        }
    }
}
