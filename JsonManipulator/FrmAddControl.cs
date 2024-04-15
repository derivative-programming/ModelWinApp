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
using Newtonsoft.Json;

namespace JsonManipulator
{
    public partial class FrmAddControl : Form
    {
        string _name, _parent;
        string targetObjectName = string.Empty;
        public FrmAddControl(string name,string parent)
        {
            InitializeComponent();
            this._name = name;
            this._parent = parent;
            targetObjectName = Utils.GetObjWFModelItem(name).targetChildObject;
            if (targetObjectName == null || targetObjectName.Trim().Length == 0)
            {
                targetObjectName = _parent;
            }
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowParam == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowParam = new List<objectWorkflowParam>();

        }

        private void FrmControl_Load(object sender, EventArgs e)
        {

            ShowValidationError("");
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


            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowParam.Add(new objectWorkflowParam { name = txtName.Text.Trim() });
            ((Form1)Application.OpenForms["Form1"]).showMessage("Control created successfully");
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setControlsList();
                this.Close();
        }
        private bool ItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowParam.Where(x => x.name == name).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }

        private void btnBulk_Click(object sender, EventArgs e)
        {
            using (var form = new FrmBulkAdd(this.targetObjectName,true))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    List<string> items = new List<string>();
                    items.AddRange(val.Split("\n".ToCharArray()));
                    for (int i = 0; i < items.Count; i++)
                    {
                        string itemName = Utils.Capitalize(items[i]).Trim().Split(",".ToCharArray())[0];
                        property sourceObjProp = null;
                        Models.ObjectMap sourceObj = null;
                        if (items[i].Contains(","))
                        {
                            string lineage = items[i].Split(",".ToCharArray())[1];
                            if (lineage.StartsWith("Lineage:"))
                            {
                                lineage = lineage.Remove(0, "Lineage:".Length);
                            }
                            sourceObjProp = Utils.GetObjectPropListSelection(this.targetObjectName, lineage);
                            sourceObj = Utils.GetObjectPropListSelectionParentObj(this.targetObjectName, lineage);
                        }
                        if (itemName.Length > 0 && !ItemExists(itemName))
                        {
                            objectWorkflowParam newItem = new objectWorkflowParam();
                            newItem.name = itemName;
                            if (sourceObj != null)
                            {
                                newItem.sourceObjectName = sourceObj.name;
                            }
                            if (sourceObjProp != null)
                            {
                                newItem.dataType = sourceObjProp.dataType;
                                newItem.labelText = sourceObjProp.labelText;
                                newItem.sourcePropertyName = sourceObjProp.name;
                            }
                            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowParam.Add(newItem);
                        }
                    }
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Control created successfully");
                    ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
                    ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setControlsList();
                }
            }
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
    }
}
