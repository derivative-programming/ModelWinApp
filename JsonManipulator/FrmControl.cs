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
    public partial class FrmControl : Form
    {
        string name,parent;
        public FrmControl(string name,string parent)
        {
            InitializeComponent();
            this.name = name;
            this.parent = parent;
        }

        private void FrmControl_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == name).FirstOrDefault().objectWorkflowParam == null)
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == name).FirstOrDefault().objectWorkflowParam = new List<objectWorkflowParam>();
            Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == name).FirstOrDefault().objectWorkflowParam.Add(new objectWorkflowParam { name = txtName.Text });
            ((Form1)Application.OpenForms["Form1"]).showMessage("Control created successfully");
            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setControlsList();
                this.Close();
        }
    }
}
