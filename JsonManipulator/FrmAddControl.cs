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
    public partial class FrmAddControl : Form
    {
        string _name, _parent;
        public FrmAddControl(string name,string parent)
        {
            InitializeComponent();
            this._name = name;
            this._parent = parent;
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
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowParam == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowParam = new List<objectWorkflowParam>();


            txtName.Text = Utils.Capitalize(txtName.Text).Trim();
            if (ItemExists(txtName.Text))
            {
                ShowValidationError("Name already exists.");
                return;
            }

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowParam.Add(new objectWorkflowParam { name = txtName.Text });
            ((Form1)Application.OpenForms["Form1"]).showMessage("Control created successfully");
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
        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }
    }
}
