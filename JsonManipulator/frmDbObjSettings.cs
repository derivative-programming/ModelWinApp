using JsonManipulator.Enums;
using JsonManipulator.Models;
using Newtonsoft.Json;
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
        ObjectMap _map;
        public frmDbObjSettings(ObjectMap mapObject)
        {
            InitializeComponent();
            this._map = mapObject;
        }

        private void frmDbObjSettings_Load(object sender, EventArgs e)
        {
            if(_map.isLookup is null || _map.isLookup == "false")
            {
                tabControl1.TabPages.RemoveByKey("tabLookupItems");
            }
            setSetting();
            setPropertieList();
            setPropSubList();
            setLookupItemList();
            setModelServiceSubList();
            grpBoxMain.Text = _map.name;
            splitter1.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmDbObjSettings.splitter1.SplitPosition", "200"));

            splitter2.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmDbObjSettings.splitter2.SplitPosition", "200"));

            splitter3.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmDbObjSettings.splitter3.SplitPosition", "200"));
            
            splitter4.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmDbObjSettings.splitter4.SplitPosition", "200"));

            tabControl1.SelectedIndex = System.Convert.ToInt32(LocalStorage.GetValue("frmDbObjSettings.tabControl1.SelectedIndex", "0"));
        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            dataProperties.Columns.Clear();
            List<string> ignoreList = Utils.GetDBObjPropertiesToIgnore();
            foreach (var prop in _map.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                if (ignoreList.Contains(prop.Name.ToLower()))
                    continue;
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(_map) ?? "").ToString() }); ;
            }
            dataProperties.DataSource = propertyValues;
            if(dataProperties.Columns.Count > 0)
            {
                dataProperties.Columns[0].ReadOnly = true;
            }
        }
        public void setPropertieList()
        {
            if(_map!=null)
            {
                if (_map.property == null)
                    _map.property = new List<property>();
                lstProperties.Items.Clear();
                foreach (var prop in _map.property)
                {
                    lstProperties.Items.Add(prop.name);
                }
                lstProperties.SelectedIndex = lstProperties.Items.Count - 1;
            }
            
        }


        public void setLookupItemList()
        {
            if (_map != null)
            {
                if (_map.lookupItem == null)
                    _map.lookupItem = new List<lookupItem>();
                lstLookupItems.Items.Clear();
                foreach (var prop in _map.lookupItem)
                {
                    lstLookupItems.Items.Add(prop.enumValue);
                }
                lstLookupItems.SelectedIndex = lstLookupItems.Items.Count - 1;
            }

        }


        public void setPropSubList()
        {
            if (_map != null)
            {
                if (_map.propSubscription == null)
                    _map.propSubscription = new List<propSubscription>();
                lstPropSubs.Items.Clear();
                foreach (var prop in _map.propSubscription)
                {
                    lstPropSubs.Items.Add(prop.destinationTargetName);
                }
                lstPropSubs.SelectedIndex = lstPropSubs.Items.Count - 1;
            }

        }


        public void setModelServiceSubList()
        {
            if (_map != null)
            {
                if (_map.modelPkg == null)
                    _map.modelPkg = new List<modelPkg>();
                lstModelServiceSubs.Items.Clear();
                foreach (var prop in _map.modelPkg)
                {
                    if (prop.isSubscriptionAllowed != "true")
                        continue;
                    lstModelServiceSubs.Items.Add(prop.name);
                }
                lstModelServiceSubs.SelectedIndex = lstModelServiceSubs.Items.Count - 1;
            }

        }
        private void lstProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstProperties.SelectedItem!=null)
            {
                gridPropertiesProp.Columns.Clear();
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String propname = lstProperties.SelectedItem.ToString();
                property prpty = _map.property.Where(x => x.name == propname).FirstOrDefault();
                List<string> ignoreList = Utils.GetDBObjPropPropertiesToIgnore();
                foreach (var prop in prpty.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
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
            string objectname = _map.name;
            frmAddObjProp frmProp = new frmAddObjProp(objectname);
            frmProp.ShowDialog();
        }

        private void dataProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataProperties.DataSource != null)
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
                typeof(ObjectMap).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x=>x.name == _map.name).FirstOrDefault(), value);
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
                if (propertyName.StartsWith("is")) //isLookup
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
                if (propertyName.StartsWith("is"))
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
                string value = string.Empty;
                if(gridPropertiesProp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridPropertiesProp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                string property = gridPropertiesProp.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstProperties.SelectedIndex;
                    typeof(property).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().property.ElementAt(lstProperties.SelectedIndex), value) ;
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
         

        private void dataProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridPropertiesProp_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridPropertiesProp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDbObjSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

            LocalStorage.SetValue("frmDbObjSettings.splitter1.SplitPosition", splitter1.SplitPosition.ToString());
            LocalStorage.SetValue("frmDbObjSettings.splitter2.SplitPosition", splitter2.SplitPosition.ToString());
            LocalStorage.SetValue("frmDbObjSettings.splitter3.SplitPosition", splitter3.SplitPosition.ToString());
            LocalStorage.SetValue("frmDbObjSettings.tabControl1.SelectedIndex", tabControl1.SelectedIndex.ToString());
            LocalStorage.Save();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lstModelServiceSubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstModelServiceSubs.SelectedItem != null)
            {
                gridModelServiceSubProperties.Columns.Clear();
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String propname = lstModelServiceSubs.SelectedItem.ToString();
                modelPkg prpty = _map.modelPkg.Where(x => x.name == propname).FirstOrDefault();
                List<string> ignoreList = Utils.GetDBObjModelServiceSubPropertiesToIgnore();
                foreach (var prop in prpty.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(prpty) ?? "").ToString() });
                }

                gridModelServiceSubProperties.DataSource = propertyValues;

                if (gridModelServiceSubProperties.Columns.Count > 0)
                {
                    gridModelServiceSubProperties.Columns[0].ReadOnly = true;
                }
            }
        }

        private void lstPropSubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPropSubs.SelectedItem != null)
            {
                gridPropSubProperties.Columns.Clear();
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String propname = lstPropSubs.SelectedItem.ToString();
                propSubscription prpty = _map.propSubscription.Where(x => x.destinationTargetName == propname).FirstOrDefault();
                List<string> ignoreList = Utils.GetDBObjPropSubPropertiesToIgnore();
                foreach (var prop in prpty.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(prpty) ?? "").ToString() });
                }

                gridPropSubProperties.DataSource = propertyValues;

                if (gridPropSubProperties.Columns.Count > 0)
                {
                    gridPropSubProperties.Columns[0].ReadOnly = true;
                }
            }
        }
            
        private void gridPropSubProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPropSubProperties.DataSource != null)
            {
                string value = string.Empty;
                if (gridPropSubProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridPropSubProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                string property = gridPropSubProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstPropSubs.SelectedIndex;
                typeof(propSubscription).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().propSubscription.ElementAt(lstPropSubs.SelectedIndex), value);
                setPropertieList();
                lstPropSubs.SetSelected(index, true);
                gridPropSubProperties.CurrentCell.Selected = false;
            }
        }

        private void gridModelServiceSubProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridModelServiceSubProperties.DataSource != null)
            {
                string value = string.Empty;
                if (gridModelServiceSubProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridModelServiceSubProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                string property = gridModelServiceSubProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstModelServiceSubs.SelectedIndex;
                typeof(modelPkg).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().modelPkg.ElementAt(lstModelServiceSubs.SelectedIndex), value);
                setPropertieList();
                lstModelServiceSubs.SetSelected(index, true);
                gridModelServiceSubProperties.CurrentCell.Selected = false;
            }
        }

        private void gridModelServiceSubProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridModelServiceSubProperties.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.   
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridModelServiceSubProperties[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                } 

            }
        }

        private void gridPropSubProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridPropSubProperties.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.   
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridPropSubProperties[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }

            }
        }

        private void gridPropSubProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridModelServiceSubProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void lstLookupItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstLookupItems.SelectedItem != null)
            {
                gridLookupItem.Columns.Clear();
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String propname = lstLookupItems.SelectedItem.ToString();
                lookupItem prpty = _map.lookupItem.Where(x => x.enumValue == propname).FirstOrDefault();
                List<string> ignoreList = Utils.GetDBObjLookupItemPropertiesToIgnore();
                foreach (var prop in prpty.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(prpty) ?? "").ToString() });
                }

                gridLookupItem.DataSource = propertyValues;

                if (gridLookupItem.Columns.Count > 0)
                {
                    gridLookupItem.Columns[0].ReadOnly = true;
                }
            }
        }

        private void btnLookupItem_Click(object sender, EventArgs e)
        {

            string objectname = _map.name;
            frmAddObjLookupItem frmProp = new frmAddObjLookupItem(objectname);
            frmProp.ShowDialog();
        }

        private void btnLookupItemUp_Click(object sender, EventArgs e)
        {
            if (lstLookupItems.SelectedItem != null)
            {
                int selectedIndex = lstLookupItems.SelectedIndex;
                lookupItem item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.Insert(newIndex, item);
                setLookupItemList();
                lstLookupItems.SetSelected(newIndex, true);
            }
        }

        private void btnLookupItemDown_Click(object sender, EventArgs e)
        {
            if (lstLookupItems.SelectedItem != null)
            {
                int selectedIndex = lstLookupItems.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.Count;
                lookupItem item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.Insert(newIndex, item);
                setLookupItemList();
                lstLookupItems.SetSelected(newIndex, true);
            }
        }

        private void gridLookupItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridLookupItem.DataSource != null)
            {
                string value = string.Empty;
                if (gridLookupItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridLookupItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                string property = gridLookupItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstLookupItems.SelectedIndex;
                typeof(lookupItem).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _map.name).FirstOrDefault().lookupItem.ElementAt(lstLookupItems.SelectedIndex), value);
                setLookupItemList();
                lstLookupItems.SetSelected(index, true);
                gridLookupItem.CurrentCell.Selected = false;
            }
        }

        private void gridLookupItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridLookupItem.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.   
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridLookupItem[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                } 
            }
        }

        private void gridLookupItem_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void rtbJSON_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtbJSON_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            rtbJSON.Text = JsonConvert.SerializeObject(this._map, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
