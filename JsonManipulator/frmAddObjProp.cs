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
    public partial class frmAddObjProp : Form
    {
        string _name;

        List<string> _names = new List<string>();

        bool _isMultiAdd = false;

        public frmAddObjProp(string name)
        {
            InitializeComponent();
            this._name = name;

            if(name.Trim().Length == 0)
            {
                this._isMultiAdd = true;
                this._names = ((Form1)Application.OpenForms["Form1"]).GetNavDBObjectNames();
            }

            if(this._isMultiAdd)
            {
                this.Text += " To All DB Objects in Search Results";
                foreach (var itemName in this._names)
                {

                    if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == itemName).FirstOrDefault().property == null)
                    {
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == itemName).FirstOrDefault().property = new List<property>();
                    }
                }

            }
            else
            {
                if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property == null)
                {
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property = new List<property>();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            

            txtName.Text = Utils.Capitalize(txtName.Text).Trim();
            if (!this._isMultiAdd && ItemExists(txtName.Text))
            {
                ShowValidationError("Name already exists.");
                return;
            }

            if (txtName.Text.Trim().Contains(" "))
            {
                ShowValidationError("Remove Spaces from name.");
                return;
            }
            if (txtName.Text.Trim().Length > 50)
            {
                ShowValidationError("Max property name length is 50.");
                return;
            }

            if(!this._isMultiAdd)
            {
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property.Add(new property { name = txtName.Text });
            }
            else
            {
                foreach (var itemName in this._names)
                {
                    if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == itemName).FirstOrDefault().property.Where(x => x.name == txtName.Text).ToList().Count == 0)
                    {
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == itemName).FirstOrDefault().property.Add(new property { name = txtName.Text });
                    }
                } 
            }
            ((Form1)Application.OpenForms["Form1"]).showMessage("Property created successfully");
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
            if (((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]) != null)
            {
                ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).setPropertieList();
            }
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

        private void frmAddObjProp_Load(object sender, EventArgs e)
        {

            ShowValidationError("");
        }

        private void btnBulk_Click(object sender, EventArgs e)
        {
            using (var form = new FrmBulkAdd(this._name,false))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    List<string> items = new List<string>();
                    items.AddRange(val.Split("\n,".ToCharArray()));
                    for(int i = 0;i < items.Count;i++)
                    {
                        string itemName = Utils.Capitalize(items[i]).Trim();
                        if (itemName.Length > 0)
                        {
                            if (!this._isMultiAdd)
                            {
                                if (!ItemExists(itemName))
                                {
                                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property.Add(new property { name = itemName });
                                }
                            }
                            else
                            {
                                foreach (var name in this._names)
                                {
                                    if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == name).FirstOrDefault().property.Where(x => x.name == itemName).ToList().Count == 0)
                                    {
                                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == name).FirstOrDefault().property.Add(new property { name = itemName });
                                    }
                                }
                            }
                        }
                    }
                   
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Property created successfully");
                    ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges(); 
                    if (((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]) != null)
                    {
                        ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).setPropertieList();
                    }
                }
            }
            this.Close();
        }
    }
}
