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
    public partial class FlowList : Form
    {
        FormObjects _frmObj;
        ParentType _type;
        int _row, _col;
        public FlowList(ParentType type = ParentType.ADD,int row=0,int col=0)
        {
            InitializeComponent();
            this._type = type;
            this._row = row;
            this._col = col;
        }
        private void populateFlows(string filter)
        {
            listObjects.Items.Clear();

            List<string> fullList = Utils.GetNameList(false, false, false, true,false);
            if (filter.Trim().Length > 0)
            {
                fullList = fullList.Where(x => x.ToLower().Contains(filter.ToLower().Trim())).ToList();
            }
            foreach (string name in fullList)
            {
                listObjects.Items.Add(name);
            } 
            listObjects.Sorted = true;

        }
        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            populateFlows("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                populateFlows(txtFilter.Text);
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listObjects.SelectedItem!=null)
            {
                switch(_type)
                {
                    case ParentType.ADD:
                        ((frmDbObject)Application.OpenForms["frmDbObject"]).setParent(listObjects.SelectedItem.ToString());
                        break;
                    case ParentType.EDIT:
                        ((frmFormSettings)Application.OpenForms["frmFormSettings"]).setButtonData(listObjects.SelectedItem.ToString(),_row,_col);
                        break;
                    case ParentType.REPORT_BUTTON:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setButtonData(listObjects.SelectedItem.ToString(), _row, _col);
                        break;
                    case ParentType.REPORT_COLUMN:
                        ((frmReportSettings)Application.OpenForms["frmReportSettings"]).setColumnData(listObjects.SelectedItem.ToString(), _row, _col);
                        break;
                    case ParentType.REPORT_COLUMN_DESTINATION_BUTTON:
                        ((FrmAddColumnDestinationButton)Application.OpenForms["FrmAddColumnDestinationButton"]).SetDestination(listObjects.SelectedItem.ToString());
                        break;
                    case ParentType.REPORT_COLUMN_ASYNC_BUTTON:
                        ((FrmAddColumnAsyncButton)Application.OpenForms["FrmAddColumnAsyncButton"]).SetDestination(listObjects.SelectedItem.ToString());
                        break;
                }
                  
            }
            this.Close();
        }
    }
}
