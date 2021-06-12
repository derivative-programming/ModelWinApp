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
    public partial class FormsList : Form
    {
        FormObjects frmObj;
        ParentType type;
        int row, col;
        public FormsList(ParentType type = ParentType.ADD,int row=0,int col=0)
        {
            InitializeComponent();
            this.type = type;
            this.row = row;
            this.col = col;
        }
        private void populateForms(string filter)
        {
            listObjects.Items.Clear();
            NameSpaceObject nameSpaceObject = Form1.model.root.NameSpaceObjects.FirstOrDefault();
            foreach (var _dbObject in nameSpaceObject.ObjectMap)
            {
                if (_dbObject.objectWorkflow != null)
                {
                    foreach (var _object in _dbObject.objectWorkflow.Where(x => x.Name.Contains(filter)))
                    {
                        listObjects.Items.Add(_object.Name);
                    }
                }
                if (_dbObject.report != null)
                {
                    foreach (var _object in _dbObject.report.Where(x => x.name.Contains(filter)))
                    {
                        listObjects.Items.Add(_object.name);
                    }
                }

            }
            listObjects.Sorted = true;

        }
        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            populateForms("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                populateForms(textBox1.Text);
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listObjects.SelectedItem!=null)
            {
                switch(type)
                {
                    case ParentType.ADD:
                        ((frmDbObject)Application.OpenForms["frmDbObject"]).setParent(listObjects.SelectedItem.ToString());
                        break;
                    case ParentType.EDIT:
                        ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setButtonData(listObjects.SelectedItem.ToString(),row,col);
                        break;
                    case ParentType.REPORT_BUTTON:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setButtonData(listObjects.SelectedItem.ToString(), row, col);
                        break;
                }
                  
            }
            this.Close();
        }
    }
}
