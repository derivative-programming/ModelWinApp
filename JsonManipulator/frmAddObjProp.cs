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
        public frmAddObjProp(string name)
        {
            InitializeComponent();
            this._name = name;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _name).FirstOrDefault().property.Add(new property { name =txtName.Text});
            ((Form1)Application.OpenForms["Form1"]).showMessage("Property created successfully");
            ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).setPropertieList();
                this.Close();
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

        }
    }
}
