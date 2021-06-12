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
    public partial class RoleList : Form
    {
        FormObjects frmObj;
        int row, column;
        public RoleList(FormObjects formObjects,int row=0,int column=0)
        {
            InitializeComponent();
            this.frmObj = formObjects;
            this.row = row;
            this.column = column;
        }

        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            NameSpaceObject nameSpaceObject = Form1.model.root.NameSpaceObjects.Where(x => x.name == "Core").FirstOrDefault();
            foreach (var _dbObject in nameSpaceObject.ObjectMap)
            {
                if (_dbObject.objectWorkflow != null)
                {
                    foreach (var _object in _dbObject.objectWorkflow)
                    {
                        if(_object.RoleRequired!=null && !listObjects.Items.Contains(_object.RoleRequired))
                        listObjects.Items.Add(_object.RoleRequired);
                        
                    }
                }
                if (_dbObject.report != null)
                {
                    foreach (var _object in _dbObject.report)
                    {
                        if (_object.RoleRequired != null && !listObjects.Items.Contains(_object.RoleRequired))
                        listObjects.Items.Add(_object.RoleRequired);
                    }
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            NameSpaceObject nameSpaceObject = Form1.model.root.NameSpaceObjects.Where(x => x.name == "Core").FirstOrDefault();
            foreach (var _dbObject in nameSpaceObject.ObjectMap)
            {
                if (_dbObject.objectWorkflow != null)
                {
                    foreach (var _object in _dbObject.objectWorkflow)
                    {
                        if (_object.RoleRequired != null && !listObjects.Items.Contains(_object.RoleRequired) &&_object.RoleRequired.Contains(textBox1.Text))
                            listObjects.Items.Add(_object.RoleRequired);

                    }
                }
                if (_dbObject.report != null)
                {
                    foreach (var _object in _dbObject.report)
                    {
                        if (_object.RoleRequired != null && !listObjects.Items.Contains(_object.RoleRequired) && _object.RoleRequired.Contains(textBox1.Text))
                            listObjects.Items.Add(_object.RoleRequired);
                    }
                }

            }
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listObjects.SelectedItem!=null)
            {
                switch(frmObj)
                {
                    case FormObjects.FORM:
                        ((frmForm)Application.OpenForms["frmForm"]).setRole(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.REPORT:
                        ((frmReportGrid)Application.OpenForms["frmReportGrid"]).setRole(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.DBOBJECT_RPT_DETAIL:
                        ((frmReportDetail)Application.OpenForms["frmReportDetail"]).setRole(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.DBBJECT_EDIT:
                        ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setData(listObjects.SelectedItem.ToString(),row,column);
                        break;
                    case FormObjects.REPORT_ROLE:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setData(listObjects.SelectedItem.ToString(), row, column);
                        break;
                }
            }
            this.Close();
        }
    }
}
