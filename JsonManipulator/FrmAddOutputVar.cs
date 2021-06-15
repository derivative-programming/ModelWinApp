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
    public partial class FrmAddOutputVar : Form
    {
        string _name, _parent;
        public FrmAddOutputVar(string name,string parent)
        {
            InitializeComponent();
            this._name = name;
            this._parent = parent;
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
            if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowOutputVar == null)
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowOutputVar = new List<objectWorkflowOutputVar>();
            Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowOutputVar.Add(new objectWorkflowOutputVar { name = txtName.Text });
            ((Form1)Application.OpenForms["Form1"]).showMessage("Output Var created successfully");
            ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setOutputVarList();
                this.Close();
        }
    }
}
