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
    public partial class FrmAddColumn : Form
    {
        string _name, _parent;
        string targetObjectName = string.Empty;
        public FrmAddColumn(string name, string parent)
        {
            InitializeComponent();
            this._name = name;
            this._parent = parent;
            targetObjectName = Utils.GetReportModelItem(name).TargetChildObject;
            if(targetObjectName == null || targetObjectName.Trim().Length == 0)
            {
                targetObjectName = _parent;
            }

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

            if (txtName.Text.Trim().Length == 0)
            {
                ShowValidationError("Name is required");
                return;
            }

            if (txtName.Text.Trim().Length > 100)
            {
                ShowValidationError("The name length cannot exceed 100 characters.");
                return;
            }

            Models.reportColumn reportColumn = new reportColumn();
            reportColumn.name = txtName.Text.Trim();
            reportColumn.isButton = "false";
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

        private void btnBulk_Click(object sender, EventArgs e)
        {
            using (var form = new FrmBulkAdd(this.targetObjectName, true))
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

                        Models.ObjectMap nextSourceObj = null;
                        if (items[i].Contains(","))
                        {
                            string lineage = items[i].Split(",".ToCharArray())[1];
                            if(lineage.StartsWith("Lineage:"))
                            {
                                lineage = lineage.Remove(0, "Lineage:".Length);
                            }
                            if (sourceObj == null && lineage.StartsWith(this.targetObjectName + "."))
                            {
                                sourceObjProp = Utils.GetObjectPropListSelection(this.targetObjectName, lineage);
                                sourceObj = Utils.GetObjectPropListSelectionParentObj(this.targetObjectName, lineage);
                            }
                            else
                            { 
                                sourceObjProp = Utils.GetObjectPropListSelection(this._parent, lineage);
                                sourceObj = Utils.GetObjectPropListSelectionParentObj(this._parent, lineage);
                            }
                            //sourceObjProp = Utils.GetObjectPropListSelection(this._parent, lineage);
                            //sourceObj = Utils.GetObjectPropListSelectionParentObj(this._parent, lineage);
                            if(sourceObj != null && sourceObj.isLookup == "true")
                            {
                                string nextLineage = lineage.Substring(0, lineage.Length - sourceObj.name.Length - sourceObjProp.name.Length - 2) + ".Code";
                                nextSourceObj = Utils.GetObjectPropListSelectionParentObj(this._parent, nextLineage);
                            }
                        }
                        if (itemName.Length > 0 && !ItemExists(itemName))
                        {
                            Models.reportColumn reportColumn = new reportColumn();
                            reportColumn.name = itemName;
                            reportColumn.isButton = "false";
                            if (sourceObj != null)
                            {
                                reportColumn.sourceObjectName = sourceObj.name; 
                            }
                            if (nextSourceObj != null)
                            {
                                reportColumn.sourceLookupObjImplementationObjName = nextSourceObj.name; 
                            }
                            if (sourceObjProp != null)
                            {
                                reportColumn.dataType = sourceObjProp.dataType;
                                reportColumn.headerText = sourceObjProp.labelText;
                                reportColumn.sourcePropertyName = sourceObjProp.name;
                                }
                            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportColumn.Add(reportColumn);
                        }
                        }
                     ((Form1)Application.OpenForms["Form1"]).showMessage("Column created successfully");
                    ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
                    ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setColumnsList();
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
