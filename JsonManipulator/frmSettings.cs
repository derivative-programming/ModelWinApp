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
            _root.CodeNameSpaceRootName = Form1.model.root.Name;
            _root.CodeNameSpaceSecondaryName = Form1.model.root.NameSpaceObjects.FirstOrDefault().name;
            setSetting();

        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            dataProperties.Columns.Clear();
            foreach (var prop in _root.GetType().GetProperties())
            {
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));

                if(!prop.PropertyType.IsGenericType)
                propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(_root) ?? "").ToString() }); ;
            }
            dataProperties.DataSource = propertyValues;
        }

        private void dataProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(dataProperties.DataSource!=null)
            {
                string property = dataProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = dataProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (property == "CodeNameSpaceRootName" || property == "Name")
                {
                    Form1.model.root.Name = value;
                    Form1.model.root.CodeNameSpaceRootName = value;
                    setSetting();
                }
                else
                {
                    
                    typeof(root).GetProperty(property).SetValue(Form1.model.root, value);
                }
                
            }
           
        }
    }
}
