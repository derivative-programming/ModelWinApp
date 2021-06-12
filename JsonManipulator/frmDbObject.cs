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
            ObjectMap objectMap = new ObjectMap {
                name = txtName.Text,
                parentObjectName = txtOwner.Text
            };
            Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Add(objectMap);
            ((Form1)Application.OpenForms["Form1"]).AddToTree(objectMap);
            ((Form1)Application.OpenForms["Form1"]).showMessage("object " + objectMap.name + " saved successfully to " + objectMap.parentObjectName);
            this.Close();
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
    }
}
