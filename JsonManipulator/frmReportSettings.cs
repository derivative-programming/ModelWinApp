using JsonManipulator.Enums;
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
    public partial class frmReportSettings : Form
    {
        Report _rpt = new Report();
        ObjectMap _ownerObject;
        bool _isLoadingPropSubscriptions = false;
        public frmReportSettings(string reportName)
        {
            InitializeComponent();
            this._rpt = Utils.GetReportModelItem(reportName);
            this._ownerObject = Utils.GetOwnerObject(_rpt.name);
            this.grpMain.Text = _rpt.name;
        }

        private void frmReportSettings_Load(object sender, EventArgs e)
        {
            setSetting();
            setFiltersList();
            setColumnsList();
            SetPropSubscriptionCheckboxes();
            setButtonsList();
            splitter1.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmReportSettings.splitter1.SplitPosition", "200"));
            splitter2.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmReportSettings.splitter2.SplitPosition", "200"));
            splitter3.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmReportSettings.splitter3.SplitPosition", "200"));

            tabControl1.SelectedIndex = System.Convert.ToInt32(LocalStorage.GetValue("frmReportSettings.tabControl1.SelectedIndex", "0")); 
        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            dataProperties.Columns.Clear();
            List<string> ignoreList = Utils.GetReportPropertiesToIgnore();
            foreach (var prop in _rpt.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                if (ignoreList.Contains(prop.Name.ToLower()))
                    continue;
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(_rpt) ?? "").ToString() }); ;
            }
            dataProperties.DataSource = propertyValues;
            if (dataProperties.Columns.Count > 0)
            {
                dataProperties.Columns[0].ReadOnly = true; 
            }
        }
        public void setFiltersList()
        {
            lstFilters.Items.Clear();
            if(_rpt.reportParam==null)
            {
                _rpt.reportParam = new List<reportParam>();
            }
            foreach (var param in _rpt.reportParam)
            {
                lstFilters.Items.Add(param.name);
            }
            if (lstFilters.Items.Count > 0)
                lstFilters.SelectedIndex = lstFilters.Items.Count - 1;
        }
        public void setColumnsList()
        {
            lstColumns.Items.Clear();
            if (_rpt.reportColumn == null)
            {
                _rpt.reportColumn = new List<reportColumn>();
            }
            foreach (var column in _rpt.reportColumn)
            {
                lstColumns.Items.Add(column.name);
            }
            if (lstColumns.Items.Count > 0)
                lstColumns.SelectedIndex = lstColumns.Items.Count - 1;
             
        }

        public void SetPropSubscriptionCheckboxes()
        {
            _isLoadingPropSubscriptions = true;
            chkSubscribeToOwnerObject.Checked = Utils.IsPropSubscriptionEnabledFor(_ownerObject, _rpt.name);
            if (_rpt.TargetChildObject != null &&
                _rpt.TargetChildObject.Length > 0)
            {
                Models.ObjectMap objectMap = Utils.GetObjectModelItem(_rpt.TargetChildObject);
                chkSubscribeToTargetChild.Enabled = true;
                chkSubscribeToTargetChild.Checked = Utils.IsPropSubscriptionEnabledFor(objectMap, _rpt.name);
            }
            else
            {
                chkSubscribeToTargetChild.Enabled = false;
                chkSubscribeToTargetChild.Checked = false;
            }
            _isLoadingPropSubscriptions = false;
        }

        public void setButtonsList()
        {
            lstButtons.Items.Clear();
            if (_rpt.reportButton == null)
            {
                _rpt.reportButton = new List<reportButton>();
            }
            foreach (var button in _rpt.reportButton)
            {
                if (button.buttonName == null)
                    button.buttonName = "";
                lstButtons.Items.Add(button.buttonName);
            }
            if (lstButtons.Items.Count > 0)
                lstButtons.SelectedIndex = lstButtons.Items.Count - 1;
        }
        private void lstFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstFilters.SelectedItem!=null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String filterName = lstFilters.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetReportFilterPropertiesToIgnore();
                reportParam rptParam = _rpt.reportParam.Where(x => x.name == filterName).FirstOrDefault();
                foreach (var prop in rptParam.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(rptParam) ?? "").ToString() });
                }
                gridFilters.Columns.Clear();
                gridFilters.DataSource = propertyValues;
                if (gridFilters.Columns.Count > 0)
                {
                    gridFilters.Columns[0].ReadOnly = true;
                }
            }
          
        }

        private void lstColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            String columnMane = lstColumns.SelectedItem.ToString();
            List<string> ignoreList = Utils.GetReportColumnPropertiesToIgnore();
            reportColumn rptColumn = _rpt.reportColumn.Where(x => x.name == columnMane).FirstOrDefault();
            foreach (var prop in rptColumn.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                if (ignoreList.Contains(prop.Name.ToLower()))
                    continue;
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(rptColumn) ?? "").ToString() });
            }
            gridColumns.Columns.Clear();
            gridColumns.DataSource = propertyValues;
            if (gridColumns.Columns.Count > 0)
            {
                gridColumns.Columns[0].ReadOnly = true;
            }
        }

        private void lstButtons_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            String buttonName = lstButtons.SelectedItem.ToString();
            List<string> ignoreList = Utils.GetReportButtonPropertiesToIgnore();
            reportButton rptButton = _rpt.reportButton.Where(x => x.buttonName == buttonName).FirstOrDefault();
            foreach (var prop in rptButton.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                if (ignoreList.Contains(prop.Name.ToLower()))
                    continue;
                propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(rptButton) ?? "").ToString() });
            }
            gridButtons.Columns.Clear();
            gridButtons.DataSource = propertyValues;
            if (gridButtons.Columns.Count > 0)
            {
                gridButtons.Columns[0].ReadOnly = true;
            }
        }

        private void btnButtonAdd_Click(object sender, EventArgs e)
        {
            FrmAddButton frmAddButton = new FrmAddButton(_rpt.name, _ownerObject.name, ButtonType.REPORT);
            frmAddButton.ShowDialog();
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            FrmAddFilter frmAddFilter = new FrmAddFilter(_rpt.name, _ownerObject.name);
            frmAddFilter.ShowDialog();
        }

        private void btnColumnsAdd_Click(object sender, EventArgs e)
        {
            FrmAddColumn frmAddColumn = new FrmAddColumn(_rpt.name, _ownerObject.name);
            frmAddColumn.ShowDialog();
        }

        private void btnColumnsMoveUp_Click(object sender, EventArgs e)
        {
            if (lstColumns.SelectedItem != null)
            {
                int selectedIndex = lstColumns.SelectedIndex;
                reportColumn item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.Insert(newIndex, item);
                setColumnsList();
                lstColumns.SetSelected(newIndex, true);
            }
        }

        private void btnColumnsMoveDown_Click(object sender, EventArgs e)
        {
            if (lstColumns.SelectedItem != null)
            {
                int selectedIndex = lstColumns.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.Count;
                reportColumn item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.Insert(newIndex, item);
                setColumnsList();
                lstColumns.SetSelected(newIndex,true);
            }
        }

        private void btnFilterMoveUp_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItem != null)
            {
                int selectedIndex = lstFilters.SelectedIndex;
                reportParam item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.Insert(newIndex, item);
                setFiltersList();
                lstFilters.SetSelected(newIndex, true);
            }
        }

        private void btnFilterMoveDown_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItem != null)
            {
                int selectedIndex = lstFilters.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.Count;
                reportParam item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.Insert(newIndex, item);
                setFiltersList();
                lstFilters.SetSelected(newIndex, true);
            }
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
                Report temp = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault(); 
                typeof(Report).GetProperty(property).SetValue(temp, value);
                //if (Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().report == null)
                //    Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().report = new List<Report>();
                //Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().report.Add(temp);
                
                if (property.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    ((Form1)Application.OpenForms["Form1"]).updateTree(value, 2);
                }
                if (property.Equals("OwnerObject") || property.Equals("TargetChildObject"))
                {
                    SetPropSubscriptionCheckboxes();
                }
            }
           
        }

        private void gridFilters_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (gridFilters.DataSource != null && lstFilters.SelectedItem!=null)
            {
                string property = gridFilters.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridFilters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridFilters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstFilters.SelectedIndex;
                typeof(reportParam).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportParam.ElementAt(lstFilters.SelectedIndex), value); ;
                setFiltersList();
                lstFilters.SetSelected(index, true);
            }
        }

        private void gridColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridColumns.DataSource != null && lstColumns.SelectedItem!=null)
            {
                string property = gridColumns.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridColumns.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridColumns.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                if (property.ToLower() == "buttonDestinationTargetName".ToLower())
                {
                    Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(value);
                    if (destinationOwnerObject == null)
                    {
                        gridColumns.Rows[gridButtons.CurrentCell.RowIndex].Cells[gridButtons.CurrentCell.ColumnIndex].Value = "";
                        return;
                    }
                    typeof(reportColumn).GetProperty("buttonDestinationContextObjectName").SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.ElementAt(lstColumns.SelectedIndex), destinationOwnerObject.name);

                }
                int index = lstColumns.SelectedIndex;
              
                typeof(reportColumn).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportColumn.ElementAt(lstColumns.SelectedIndex), value); 
                setColumnsList();
                lstColumns.SetSelected(index, true);
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
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    dataProperties[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("visualizationType", StringComparison.OrdinalIgnoreCase) )
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    dataProperties[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getVisualizationTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("OwnerObject") || propertyName.Equals("TargetChildObject"))
                { 
                    using (var form = new frmModelSearch(ModelSearchOptions.OBJECTS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.Equals("RoleRequired", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview   
                    using (var form = new frmModelSearch(ModelSearchOptions.ROLES))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }

            }
        }

        private void gridFilters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridFilters.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridFilters[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("dataType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridFilters[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getDataTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }

            }
        }
        public void setData(string value, int row, int column, string previous = "")
        {
            //check if ownerobject name
            dataProperties.Rows[row].Cells[column].Value = value;
            dataProperties.RefreshEdit();
        }
        public void setButtonData(string value, int row, int column)
        {
            gridButtons.Rows[row].Cells[column].Value = value;
            gridButtons.RefreshEdit();
        }
        public void setColumnData(string value, int row, int column)
        {
            gridColumns.Rows[row].Cells[column].Value = value;
            gridColumns.RefreshEdit();
        }
        private void gridButtons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridButtons.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.Equals("ButtonType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridButtons[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getReportButtons(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                } 
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridButtons[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("destinationTargetName", StringComparison.OrdinalIgnoreCase))
                {
                    if(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.ElementAt(lstButtons.SelectedIndex).buttonType == "multiselectProcessing")
                    {
                        // On click of datagridview cell, attched combobox with this click cell of datagridview  
                        using (var form = new frmModelSearch(ModelSearchOptions.FLOWS))
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                string val = form.ReturnValue;
                                setButtonData(val, e.RowIndex, e.ColumnIndex);
                            }
                        }
                    }
                    else
                    { 
                        // On click of datagridview cell, attched combobox with this click cell of datagridview  
                        using (var form = new frmModelSearch(ModelSearchOptions.FORMS))
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                string val = form.ReturnValue;
                                setButtonData(val, e.RowIndex, e.ColumnIndex);
                            }
                        }
                    }
                }
            }
        }

        private void gridColumns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridColumns.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridColumns[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                } 
                if (propertyName.Equals("dataType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridColumns[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getDataTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("SourceObjectName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview   
                    using (var form = new frmModelSearch(ModelSearchOptions.OBJECTS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setColumnData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.Equals("buttonDestinationTargetName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    using (var form = new frmModelSearch(ModelSearchOptions.FORMS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setColumnData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
            }
        }

        

        private void gridButtons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridButtons.DataSource != null && lstButtons.SelectedItem != null)
            {
                string property = gridButtons.Rows[gridButtons.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridButtons.Rows[gridButtons.CurrentCell.RowIndex].Cells[gridButtons.CurrentCell.ColumnIndex].Value != null)
                {
                    value = gridButtons.Rows[gridButtons.CurrentCell.RowIndex].Cells[gridButtons.CurrentCell.ColumnIndex].Value.ToString();
                }

                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                if (property.ToLower() == "destinationTargetName".ToLower())
                {
                    Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(value);
                    if (destinationOwnerObject == null)
                    {
                        gridButtons.Rows[gridButtons.CurrentCell.RowIndex].Cells[gridButtons.CurrentCell.ColumnIndex].Value = "";
                        return;
                    } 
                    typeof(reportButton).GetProperty("destinationContextObjectName").SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.ElementAt(lstButtons.SelectedIndex), destinationOwnerObject.name);

                }
                if (property.StartsWith("is"))
                { 
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    } 
                }
                int index = lstButtons.SelectedIndex;
                typeof(reportButton).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.ElementAt(lstButtons.SelectedIndex), value);
                setButtonsList();
                lstButtons.SetSelected(index, true);
            }
        }

        private void dataProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridFilters_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridColumns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridButtons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridColumns_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridButtons_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmReportSettings_FormClosing(object sender, FormClosingEventArgs e)
        {

            LocalStorage.SetValue("frmReportSettings.splitter1.SplitPosition", splitter1.SplitPosition.ToString());

            LocalStorage.SetValue("frmReportSettings.splitter2.SplitPosition", splitter2.SplitPosition.ToString());

            LocalStorage.SetValue("frmReportSettings.splitter3.SplitPosition", splitter3.SplitPosition.ToString());
             
            LocalStorage.SetValue("frmReportSettings.tabControl1.SelectedIndex", tabControl1.SelectedIndex.ToString());

            LocalStorage.Save();
            }

        private void btnButtonMoveUp_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem != null)
            {
                int selectedIndex = lstButtons.SelectedIndex;
                reportButton item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.Insert(newIndex, item);
                setButtonsList();
                lstButtons.SetSelected(newIndex, true);
            }
        }

        private void btnButtonMoveDown_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem != null)
            {
                int selectedIndex = lstButtons.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.Count;
                reportButton item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().report.Where(x => x.name == _rpt.name).FirstOrDefault().reportButton.Insert(newIndex, item);
                setButtonsList();
                lstButtons.SetSelected(newIndex, true);
            }
        }

        private void rtbJSON_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            rtbJSON.Text = JsonConvert.SerializeObject(this._rpt, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        private void btnAddColumnButton_Click(object sender, EventArgs e)
        {

            FrmAddColumnDestinationButton frmAddColumnDestinationButton = new FrmAddColumnDestinationButton(_rpt.name, _ownerObject.name);
            frmAddColumnDestinationButton.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FrmAddColumnAsyncButton frmAddColumnAsyncButton = new FrmAddColumnAsyncButton(_rpt.name, _ownerObject.name);
            frmAddColumnAsyncButton.ShowDialog();
        }

        private void chkSubscribeToOwnerObject_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingPropSubscriptions)
                return;
            if(chkSubscribeToOwnerObject.Checked)
            {
                Utils.AddPropSubscriptionFor(_ownerObject, _rpt.name);
            }
            else
            {
                Utils.RemovePropSubscriptionFor(_ownerObject, _rpt.name);
            } 
        }

        private void chkSubscribeToTargetChild_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingPropSubscriptions)
                return;
            Models.ObjectMap objectMap = Utils.GetObjectModelItem(_rpt.TargetChildObject);
            if (chkSubscribeToTargetChild.Checked)
            { 
                Utils.AddPropSubscriptionFor(objectMap, _rpt.name);
            }
            else
            {
                Utils.RemovePropSubscriptionFor(objectMap, _rpt.name); 
            }
        }

        private void ShowUnsavedChanges()
        {
            ((Form1)Application.OpenForms["Form1"]).ShowUnsavedChanges();
        }
    }
}
