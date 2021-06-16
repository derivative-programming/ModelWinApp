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
    public partial class frmSettings : Form
    {
        root _root = new root();
        public frmSettings(root _root)
        {
            InitializeComponent();
            this._root = _root;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        { 
            _root.CodeNameSpaceSecondaryName = Form1._model.root.NameSpaceObjects.FirstOrDefault().name;
            setSetting();

        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            dataProperties.Columns.Clear();
            List<string> ignoreList = Utils.GetRootPropertiesToIgnore();
            foreach (var prop   in _root.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (ignoreList.Contains(prop.Name.ToLower()))
                    continue;

                if (!prop.PropertyType.IsGenericType)
                propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(_root) ?? "").ToString() }); ;
            }
            dataProperties.DataSource = propertyValues;
            if (dataProperties.Columns.Count > 0)
            {
                dataProperties.Columns[0].ReadOnly = true;
            } 
        }

        private void dataProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(dataProperties.DataSource!=null)
            {
                string property = dataProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (dataProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = dataProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                if (property == "CodeNameSpaceSecondaryName")
                { 
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().name = value;
                    _root.CodeNameSpaceSecondaryName = Form1._model.root.NameSpaceObjects.FirstOrDefault().name;
                    setSetting();
                }
                else
                {
                    
                    typeof(root).GetProperty(property).SetValue(Form1._model.root, value);
                }

                ((Form1)Application.OpenForms["Form1"]).populateProjectDetails();
            }
           
        }

        private void dataProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
