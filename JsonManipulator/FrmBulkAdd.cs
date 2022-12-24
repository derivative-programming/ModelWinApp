using JsonManipulator.Models;
using Newtonsoft.Json;
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
    public partial class FrmBulkAdd : Form
    {
        public string ReturnValue { get; set; }
        private string _targetObjectName = string.Empty;

        public FrmBulkAdd(string targetObjectName, bool allowPropSelection)
        {
            InitializeComponent();
            this._targetObjectName = targetObjectName;
            if(!allowPropSelection)
            {
                this.button1.Visible = false;
            }
            else
            { 
                this.button1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ReturnValue = richTextBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        } 

        private void FrmAddColumn_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new FrmSelectObjProps(_targetObjectName,true))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string propList = string.Empty;
                    for(int i = 0;i < form.results.Count;i++)
                    {
                        string item = form.results[i];
                        string lineage = item;
                        if(item.StartsWith(_targetObjectName + "."))
                        {
                            item = item.Remove(0, (_targetObjectName + ".").Length);
                            propList = propList + item.Replace(".","") + ",Lineage:" + lineage + Environment.NewLine;
                        }
                        else
                        {
                            propList = propList + item.Replace(".","") + ",Lineage:" + lineage + Environment.NewLine;
                        }
                    }
                    this.richTextBox1.Text = propList;
                }
            }
        }
    }
}
