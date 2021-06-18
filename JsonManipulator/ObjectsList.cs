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
        FormObjects _frmObj;
        int _row, _col;
        string _currentvalue;
        public ObjectsList(FormObjects formObjects, int row = 0, int column = 0,string currentValue = "")
        {
            InitializeComponent();
            this._frmObj = formObjects;
            this._row = row;
            this._col = column;
            this._currentvalue = currentValue;
        }

        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();

            List<string> nameList = Utils.GetDBObjectNameList(); 
            foreach (string name in nameList)
            {
                listObjects.Items.Add(name);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listObjects.Items.Clear();

            List<string> nameList = Utils.GetDBObjectNameList();
            if (txtFilter.Text.Trim().Length > 0)
            {
                string filter = txtFilter.Text.Trim().ToLower();
                nameList = nameList.Where(x => x.ToLower().Contains(filter)).ToList();
            }
            foreach (string name in nameList)
            {
                listObjects.Items.Add(name);
            } 
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listObjects.SelectedItem!=null)
            {
                switch(_frmObj)
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
                    case FormObjects.ADD_API_GET_REPORT:
                        ((frmAddApiGetReport)Application.OpenForms["frmAddApiGetReport"]).setOwner(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.REPORT_CHILD:
                        ((frmReportGrid)Application.OpenForms["frmReportGrid"]).setChild(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.ADD_API_GET_REPORT_CHILD:
                        ((frmAddApiGetReport)Application.OpenForms["frmAddApiGetReport"]).setChild(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.DBOBJECT_RPT_DETAIL:
                        ((frmReportDetail)Application.OpenForms["frmReportDetail"]).setOwner(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.DBBJECT_EDIT:
                        ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setData(listObjects.SelectedItem.ToString(),_row,_col);
                        break;
                    case FormObjects.DBBJECT_ADD:
                        ((frmDbObject)Application.OpenForms["frmDbObject"]).setParent(listObjects.SelectedItem.ToString());
                        break;
                    case FormObjects.REPORT_SETT:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setData(listObjects.SelectedItem.ToString(),_row,_col);
                        break;
                    case FormObjects.REPORT_BUTTON:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setButtonData(listObjects.SelectedItem.ToString(), _row, _col);
                        break;
                    case FormObjects.REPORT_COLUMNS:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setColumnData(listObjects.SelectedItem.ToString(), _row, _col);
                        break;
                    case FormObjects.OBJECT_EDIT:
                        ((frmDbObjSettings)Application.OpenForms["frmDbObjSettings"]).setData(listObjects.SelectedItem.ToString(), _row, _col);
                        break;
                    case FormObjects.ADD_FLOW:
                        ((frmAddFlow)Application.OpenForms["frmAddFlow"]).setOwner(listObjects.SelectedItem.ToString());
                        break;
                }
            }
            this.Close();
        }
    }
}
