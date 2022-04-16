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
            if(targetObjectName.Trim().Length == 0)
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
                    items.AddRange(val.Split("\n,".ToCharArray()));
                    for (int i = 0; i < items.Count; i++)
                    {
                        string itemName = Utils.Capitalize(items[i]).Trim();
                        if (itemName.Length > 0 && !ItemExists(itemName))
                        {
                            Models.reportColumn reportColumn = new reportColumn();
                            reportColumn.name = itemName;
                            reportColumn.isButton = "false";
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
