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
    public partial class frmAddDBObjectLookup : Form
    {
        public frmAddDBObjectLookup()
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
            if (txtName.Text.Trim().ToLower().Contains("lookup"))
            {
                ShowValidationError("It is not necessary to have 'lookup' in the name.");
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
                isLookup = "true",
                parentObjectName = txtOwner.Text.Trim()
            };
            objectMap.property = new List<property>();

            Models.property property = new property();
            property.name = "PacID";
            property.isFK = "true";
            property.isFKLookup = "true";
            property.isNotPublishedToSubscriptions = "true";
            property.dataType = "int"; 


            Models.lookupItem lookupItem = new lookupItem();
            lookupItem.name = "Unknown";
            lookupItem.displayName = "";
            lookupItem.description = "";
            lookupItem.isActive = "true";

            objectMap.lookupItem = new List<lookupItem>();
            objectMap.lookupItem.Add(lookupItem);

            objectMap.property.Add(property);

            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Add(objectMap);
            ((Form1)Application.OpenForms["Form1"]).AddToTree(objectMap);
            ((Form1)Application.OpenForms["Form1"]).showMessage("object " + objectMap.name + " saved successfully to " + objectMap.parentObjectName);
            ((Form1)Application.OpenForms["Form1"]).DisplayDBObjectLookupValuesTab(objectMap.name);
            this.Close();
        }

        private void ShowValidationError(string errorText)
        {
            lblValidationError.Text = errorText;
        }

        private void btnOwner_Click(object sender, EventArgs e)
        { 
            using (var form = new frmModelSearch(ModelSearchOptions.OBJECTS))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                    setParent(val);
                }
            }
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
