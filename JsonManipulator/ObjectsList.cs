using JsonManipulator.Enums;
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
    public partial class ObjectsList : Form
    {
        FormObjects frmObj;
        int row, col;
        string currentvalue;
        public ObjectsList(FormObjects formObjects, int row = 0, int column = 0,string currentValue = "")
        {
            InitializeComponent();
            this.frmObj = formObjects;
            this.row = row;
            this.col = column;
            this.currentvalue = currentValue;
        }

        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();

            foreach (var objects in Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap)
            {
                listObjects.Items.Add(objects.name);
                //items.Add(new SelectListItem { Text = objects.name, Value = objects.name });
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            foreach (var objects in Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x=>x.name.Contains(textBox1.Text)))
            {
                listObjects.Items.Add(objects.name);
                //items.Add(new SelectListItem { Text = objects.name, Value = objects.name });
            }
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listObjects.SelectedItem!=null)
            {
                switch(frmObj)
                {
                    case FormObjects.FORM:
                        ((frmForm)Application.OpenForms["frmForm"]).setOwner(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.DBBJECT:
                        ((frmDbObject)Application.OpenForms["frmDbObject"]).setParent(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.REPORT:
                        ((frmReportGrid)Application.OpenForms["frmReportGrid"]).setOwner(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.REPORT_CHILD:
                        ((frmReportGrid)Application.OpenForms["frmReportGrid"]).setChild(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.DBOBJECT_RPT_DETAIL:
                        ((frmReportDetail)Application.OpenForms["frmReportDetail"]).setOwner(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.DBBJECT_EDIT:
                        ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setData(listObjects.SelectedItem.ToString(),row,col);
                        break;
                    case FormObjects.DBBJECT_ADD:
                        ((frmDbObject)Application.OpenForms["frmDbObject"]).setParent(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.REPORT_SETT:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setData(listObjects.SelectedItem.ToString(),row,col);
                        break;
                    case FormObjects.REPORT_BUTTON:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setButtonData(listObjects.SelectedItem.ToString(), row, col);
                        break;
                    case FormObjects.REPORT_COLUMNS:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setColumnData(listObjects.SelectedItem.ToString(), row, col);
                        break;
                    case FormObjects.OBJECT_EDIT:
                        ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).setData(listObjects.SelectedItem.ToString(), row, col);
                        break;
                }
            }
            this.Close();
        }
    }
}
