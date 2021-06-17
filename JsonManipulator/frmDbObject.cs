using JsonManipulator.Enums;
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
    public partial class frmDbObject : Form
    {
        public frmDbObject()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = Utils.Capitalize(txtName.Text).Replace(" ", "");
            
            if (txtName.Text.Trim().Length == 0)
            {
                ShowValidationError("Name Required.");
                return;
            }

            if (txtOwner.Text.Trim().Length == 0)
            {
                ShowValidationError("Parent Object Name Required.");
                return;
            }

            List<string> objectNames = Utils.GetDBObjectNameList();
            if (objectNames.Where(x => x.ToLower().Equals(txtName.Text.Trim().ToLower())).ToList().Count > 0)
            {
                ShowValidationError("Name already exists.");
                return;
            }
            ObjectMap objectMap = new ObjectMap {
                name = txtName.Text.Trim(),
                parentObjectName = txtOwner.Text.Trim()
            };

            objectMap.property = new List<property>();

            Models.property property = new property();
            property.name = objectMap.parentObjectName + "ID";
            property.isFK = "true"; 
            property.isNotPublishedToSubscriptions = "true";
            property.sqlServerDBDataType = "int";

            objectMap.property.Add(property);

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Add(objectMap);
            ((Form1)Application.OpenForms["Form1"]).AddToTree(objectMap);
            ((Form1)Application.OpenForms["Form1"]).showMessage("object " + objectMap.name + " saved successfully to " + objectMap.parentObjectName);
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }

        private void btnOwner_Click(object sender, EventArgs e)
        {
            ObjectsList parentList = new ObjectsList(FormObjects.DBBJECT_ADD);
            parentList.ShowDialog();
        }
        public void setParent(string parent)
        {
            txtOwner.Text = parent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDbObject_Load(object sender, EventArgs e)
        {
            ShowValidationError("");
        }
    }
}
