﻿using JsonManipulator.Enums;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (_type)
            {
                case ButtonType.FORM:
                    if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowButton == null)
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowButton = new List<objectWorkflowButton>();
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().objectWorkflow.Where(x => x.Name == _name).FirstOrDefault().objectWorkflowButton.Add(new objectWorkflowButton { buttonText = txtName.Text, buttonType = "Other"});
                    ((Form1)Application.OpenForms["Form1"]).showMessage("Button created successfully");
                    ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setButtonsList();
                        this.Close();
                 
                    break;
                case ButtonType.REPORT:
                    if(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton == null)
                    {
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton = new List<reportButton>();
                    }
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _parent).FirstOrDefault().report.Where(x => x.name == _name).FirstOrDefault().reportButton.Add(new reportButton { buttonName = txtName.Text, buttonType = "Other"});
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmAddButton_Load(object sender, EventArgs e)
        {
            
        }
    }
}
