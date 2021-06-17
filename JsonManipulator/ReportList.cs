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
    public partial class ReportList : Form
    {
        FormObjects _frmObj;
        int _row, _column;
        public ReportList(FormObjects formObjects, int row = 0, int column = 0)
        {
            InitializeComponent();
            this._frmObj = formObjects;
            this._row = row;
            this._column = column;
        }

        private void ObjectsList_Load(object sender, EventArgs e)
        {
            listObjects.Items.Clear();
            List<string> nameList = Utils.GetNameList(false, true, false, false, false);
            foreach(string name in nameList)
            {
                listObjects.Items.Add(name);
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listObjects.Items.Clear();

            List<string> nameList = Utils.GetNameList(false, true, false, false, false);
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
                    case FormObjects.API_ENDPOINT:
                        ((frmAPISettings)Application.OpenForms["frmAPISettings"]).setEndPointData(listObjects.SelectedItem.ToString(), _row, _column);
                        break;
                }
            }
            this.Close();
        }
    }
}
