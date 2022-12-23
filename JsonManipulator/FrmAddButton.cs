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
    public partial class FrmAddButton : Form
    {
        string _name, _parent;
        ButtonType _type;
        public FrmAddButton(string name, string parent,ButtonType buttonType)
        {
            InitializeComponent();
            this._name = name;
            this._parent = parent;
            this._type = buttonType;
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case ButtonType.FORM:
                    if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowButton == null)
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowButton = new List<objectWorkflowButton>();


                    txtName.Text = Utils.Capitalize(txtName.Text).Trim();
                    if (FormButtonItemExists(txtName.Text))
                    {
                        ShowValidationError("Name already exists.");
                        return;
                    }

                    if (txtName.Text.Trim().Contains(" "))
                    {
                        ShowValidationError("Remove Spaces from name.");
                        return;
                    }

                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowButton.Add(new objectWorkflowButton { buttonText = txtName.Text.Trim(), buttonType = "other"});
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Button created successfully");
                    ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
                    ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setButtonsList();
                        this.Close();
                 
                    break;
                case ButtonType.REPORT:
                    
                    if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton == null)
                    {
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton = new List<reportButton>();
                    }

                    txtName.Text = Utils.Capitalize(txtName.Text).Trim();
                    if (ReportButtonItemExists(txtName.Text))
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

                    if (txtName.Text.Trim().ToLower() == "add")
                    {
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton.Add(new reportButton { buttonName = txtName.Text.Trim(),buttonText = "Add", buttonType = "add" });
                    }
                    else if (txtName.Text.Trim().ToLower().EndsWith("breadcrumb"))
                    {
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton.Add(new reportButton { buttonName = txtName.Text.Trim(), buttonType = "breadcrumb" });
                    }
                    else
                    {
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton.Add(new reportButton { buttonName = txtName.Text.Trim(), buttonType = "other", buttonText = Utils.ConvertPascalToSpaced(txtName.Text.Trim())  });
                    }
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Button created successfully");
                    ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
                    ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setButtonsList();
                    this.Close();
                    break;
                case ButtonType.NAV_BUTTON:

                    if (Form1._model.root.navButton == null)
                    {
                        Form1._model.root.navButton = new List<navButton>();
                    }

                    txtName.Text = Utils.Capitalize(txtName.Text).Trim();
                    if (NavButtonItemExists(txtName.Text))
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


                    Form1._model.root.navButton.Add(new navButton { buttonName = txtName.Text.Trim(), buttonType = "primary" });
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Nav Button created successfully");
                    ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
                    ((frmSettings)Application.OpenForms["frmSettings"]).setNavButtonsList();
                    this.Close();
                    break;
            }
            
        }


        private bool FormButtonItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowButton.Where(x => x.buttonText == name).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }
        private bool ReportButtonItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton.Where(x => x.buttonName == name).ToList().Count > 0)
            {
                result = true;
            }
            return result;
        }

        private bool NavButtonItemExists(string name)
        {
            bool result = false;
            if (Form1._model.root.navButton.Where(x => x.buttonName == name).ToList().Count > 0)
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
