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
    public partial class FrmSelectObjProps : Form
    {
        private string _targetObjectName = string.Empty;
        private bool _includeLineage = false;

        public List<string> results { get; set; }

        public FrmSelectObjProps(string targetObjectName, bool includeLineage)
        {
            InitializeComponent();
            this._targetObjectName = targetObjectName;
            this._includeLineage = includeLineage;
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

        private void FrmSelectObjProps_Load(object sender, EventArgs e)
        {
            List<string> props = Utils.GetObjectPropList(this._targetObjectName, this._includeLineage);
            props.Reverse();
            lbAvailableObjProps.Items.Add("No Value");
            for (int i = 0;i < props.Count;i++)
            {
                lbAvailableObjProps.Items.Add(props[i]);

            }


        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        { 
            if (txtFilter.Text.Length > 2 || txtFilter.Text.Length == 0)
            {
                lbAvailableObjProps.Items.Clear();
                List<string> props = Utils.GetObjectPropList(this._targetObjectName, this._includeLineage);
                lbAvailableObjProps.Items.Add("No Value");
                for (int i = 0; i < props.Count; i++)
                {
                    if(props[i].ToString().ToLower().Contains(txtFilter.Text.ToLower()))
                        lbAvailableObjProps.Items.Add(props[i]);

                }
            }
        }
    }
}
