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
    public partial class FrmSelectRptCols : Form
    {
        private string _targetReportName = string.Empty; 

        public List<string> results { get; set; }

        public FrmSelectRptCols(string targetReportName)
        {
            InitializeComponent();
            this._targetReportName = targetReportName; 
        }
         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            results = new List<string>();
            foreach(var item in lbAvailableObjProps.SelectedItems)
            {
                if (item.Equals("No Value"))
                    continue;
                results.Add(item.ToString());
            }
            this.DialogResult = DialogResult.OK;
        }

         
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmSelectRptCols_Load(object sender, EventArgs e)
        {
            lbAvailableObjProps.Items.Add("No Value");
            List<string> props = Utils.GetReportColList(this._targetReportName);
            for(int i = 0;i < props.Count;i++)
            {
                lbAvailableObjProps.Items.Add(props[i]);

            }
        }
    }
}
