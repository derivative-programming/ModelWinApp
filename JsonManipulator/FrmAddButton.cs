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
        string name, parent;
        ButtonType type;
        public FrmAddButton(string name, string parent,ButtonType buttonType)
        {
            InitializeComponent();
            this.name = name;
            this.parent = parent;
            this.type = buttonType;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case ButtonType.FORM:
                    if (Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == name).FirstOrDefault().objectWorkflowButton == null)
                        Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == name).FirstOrDefault().objectWorkflowButton = new List<objectWorkflowButton>();
                    Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == name).FirstOrDefault().objectWorkflowButton.Add(new objectWorkflowButton { buttonText = txtName.Text, buttonType = "Other"});
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Button created successfully");
                    ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setButtonsList();
                        this.Close();
                 
                    break;
                case ButtonType.REPORT:
                    if(Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().report.Where(x => x.name == name).FirstOrDefault().reportButton == null)
                    {
                        Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().report.Where(x => x.name == name).FirstOrDefault().reportButton = new List<reportButton>();
                    }
                    Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == parent).FirstOrDefault().report.Where(x => x.name == name).FirstOrDefault().reportButton.Add(new reportButton { buttonName = txtName.Text, buttonType = "Other"});
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Button created successfully");
                    ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setButtonsList();
                    this.Close();
                    break;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddButton_Load(object sender, EventArgs e)
        {
            
        }
    }
}
