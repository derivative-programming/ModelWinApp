using JsonManipulator.Enums;
using JsonManipulator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonManipulator
{
    public partial class frmDbObjSettings : Form
    {
        ObjectMap map;
        public frmDbObjSettings(ObjectMap mapObject)
        {
            InitializeComponent();
            this.map = mapObject;
        }

        private void frmDbObjSettings_Load(object sender, EventArgs e)
        {
            setSetting();
            setPropertieList();
            grpBoxMain.Text = map.name;
        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            dataProperties.Columns.Clear();
            foreach (var prop in map.GetType().GetProperties())
            {
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(map) ?? "").ToString() }); ;
            }
            dataProperties.DataSource = propertyValues;
            if(dataProperties.Columns.Count > 0)
            {
                dataProperties.Columns[0].ReadOnly = true;
            }
        }
        public void setPropertieList()
        {
            if(map!=null)
            {
                if (map.property == null)
                    map.property = new List<property>();
                lstProperties.Items.Clear();
                foreach (var prop in map.property)
                {
                    lstProperties.Items.Add(prop.name);
                }
                lstProperties.SelectedIndex = lstProperties.Items.Count - 1;
            }
            
        }

        private void lstProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstProperties.SelectedItem!=null)
            {
                gridPropertiesProp.Columns.Clear();
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String propname = lstProperties.SelectedItem.ToString();
                property prpty = map.property.Where(x => x.name == propname).FirstOrDefault();
                foreach (var prop in prpty.GetType().GetProperties())
                {
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(prpty) ?? "").ToString() });
                }
                
                gridPropertiesProp.DataSource = propertyValues;

                if (gridPropertiesProp.Columns.Count > 0)
                {
                    gridPropertiesProp.Columns[0].ReadOnly = true;
                }
            }
           
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            string objectname = map.name;
            frmAddObjProp frmProp = new frmAddObjProp(objectname);
            frmProp.ShowDialog();
        }

        private void dataProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataProperties.DataSource != null)
            {
                string property = dataProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = dataProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                
                typeof(ObjectMap).GetProperty(property).SetValue(Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x=>x.name == map.name).FirstOrDefault(), value);
                if(property.Equals("name",StringComparison.OrdinalIgnoreCase))
                {
                    ((Form1)Application.OpenForms["Form1"]).updateTree(value, 0);
                }
                   
            }
        }

        private void dataProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = dataProperties.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.Equals("isLookup") )
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    dataProperties[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if(propertyName.Equals("parentObjectName"))
                {
                    ObjectsList parentList = new ObjectsList(FormObjects.OBJECT_EDIT,e.RowIndex,e.ColumnIndex);
                    parentList.ShowDialog();
                }

            }
        }
        

        

        private void gridPropertiesProp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridPropertiesProp.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.Equals("IsFK",StringComparison.OrdinalIgnoreCase)|| propertyName.Equals("forceDBColumnIndex", StringComparison.OrdinalIgnoreCase) || propertyName.Equals("IsEncrypted", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridPropertiesProp[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("sqlServerDBDataType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridPropertiesProp[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getDataTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }

            }
        }

        private void gridPropertiesProp_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPropertiesProp.DataSource != null)
            {
                string value = gridPropertiesProp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                string property = gridPropertiesProp.Rows[e.RowIndex].Cells[0].Value.ToString();
                int index = lstProperties.SelectedIndex;
                    typeof(property).GetProperty(property).SetValue(Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == map.name).FirstOrDefault().property.ElementAt(lstProperties.SelectedIndex), value) ;
                setPropertieList();
                lstProperties.SetSelected(index, true);
                gridPropertiesProp.CurrentCell.Selected = false;
            }
           
        }
        public void setData(string value,int row,int column)
        {
            dataProperties.Rows[row].Cells[column].Value = value;
            dataProperties.RefreshEdit();
        }

      
    }
}
