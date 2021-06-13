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
    public partial class frmReportSettings : Form
    {
        Report rpt = new Report();
        String ownerObject;
        public frmReportSettings(Report report)
        {
            InitializeComponent();
            this.rpt = report;
            this.ownerObject = rpt.OwnerObject;
        }

        private void frmReportSettings_Load(object sender, EventArgs e)
        {
            setSetting();
            setFiltersList();
            setColumnsList();
            setButtonsList();
        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            dataProperties.Columns.Clear();
            foreach (var prop in rpt.GetType().GetProperties())
            {
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(rpt) ?? "").ToString() }); ;
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
            if(rpt.reportParam==null)
            {
                rpt.reportParam = new List<reportParam>();
            }
            foreach (var param in rpt.reportParam)
            {
                lstFilters.Items.Add(param.name);
            }
            if (lstFilters.Items.Count > 0)
                lstFilters.SelectedIndex = lstFilters.Items.Count - 1;
        }
        public void setColumnsList()
        {
            lstColumns.Items.Clear();
            if (rpt.reportColumn == null)
            {
                rpt.reportColumn = new List<reportColumn>();
            }
            foreach (var column in rpt.reportColumn)
            {
                lstColumns.Items.Add(column.name);
            }
            if (lstColumns.Items.Count > 0)
                lstColumns.SelectedIndex = lstColumns.Items.Count - 1;
        }
        public void setButtonsList()
        {
            lstButtons.Items.Clear();
            if (rpt.reportButton == null)
            {
                rpt.reportButton = new List<reportButton>();
            }
            foreach (var button in rpt.reportButton)
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
                reportParam rptParam = rpt.reportParam.Where(x => x.name == filterName).FirstOrDefault();
                foreach (var prop in rptParam.GetType().GetProperties())
                {
                    if(!prop.PropertyType.IsGenericType)
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
            reportColumn rptColumn = rpt.reportColumn.Where(x => x.name == columnMane).FirstOrDefault();
            foreach (var prop in rptColumn.GetType().GetProperties())
            {
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
            reportButton rptButton = rpt.reportButton.Where(x => x.buttonName == buttonName).FirstOrDefault();
            foreach (var prop in rptButton.GetType().GetProperties())
            {
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
            FrmAddButton frmAddButton = new FrmAddButton(rpt.name,rpt.OwnerObject, ButtonType.REPORT);
            frmAddButton.ShowDialog();
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            FrmAddFilter frmAddFilter = new FrmAddFilter(rpt.name, rpt.OwnerObject);
            frmAddFilter.ShowDialog();
        }

        private void btnColumnsAdd_Click(object sender, EventArgs e)
        {
            FrmAddColumn frmAddColumn = new FrmAddColumn(rpt.name, rpt.OwnerObject);
            frmAddColumn.ShowDialog();
        }

        private void btnColumnsMoveUp_Click(object sender, EventArgs e)
        {
            if (lstColumns.SelectedItem != null)
            {
                int selectedIndex = lstColumns.SelectedIndex;
                reportColumn item = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.RemoveAt(selectedIndex);
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.Insert(newIndex, item);
                setColumnsList();
                lstColumns.SetSelected(newIndex, true);
            }
        }

        private void btnColumnsMoveDown_Click(object sender, EventArgs e)
        {
            if (lstColumns.SelectedItem != null)
            {
                int selectedIndex = lstColumns.SelectedIndex;
                int count = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.Count;
                reportColumn item = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.RemoveAt(selectedIndex);
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.Insert(newIndex, item);
                setColumnsList();
                lstColumns.SetSelected(newIndex,true);
            }
        }

        private void btnFilterMoveUp_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItem != null)
            {
                int selectedIndex = lstFilters.SelectedIndex;
                reportParam item = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.RemoveAt(selectedIndex);
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.Insert(newIndex, item);
                setFiltersList();
                lstFilters.SetSelected(newIndex, true);
            }
        }

        private void btnFilterMoveDown_Click(object sender, EventArgs e)
        {
            if (lstFilters.SelectedItem != null)
            {
                int selectedIndex = lstFilters.SelectedIndex;
                int count = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.Count;
                reportParam item = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.RemoveAt(selectedIndex);
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.Insert(newIndex, item);
                setFiltersList();
                lstFilters.SetSelected(newIndex, true);
            }
        }

        private void dataProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataProperties.DataSource != null)
            {
                string property = dataProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = dataProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                Report temp = Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault();
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.RemoveAll(x => x.name == rpt.name);
                typeof(Report).GetProperty(property).SetValue(temp, value);
                if (Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().report == null)
                    Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().report = new List<Report>();
                Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().report.Add(temp);
                
                if (property.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    ((Form1)Application.OpenForms["Form1"]).updateTree(value, 2);
                }
            }
           
        }

        private void gridFilters_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (gridFilters.DataSource != null && lstFilters.SelectedItem!=null)
            {
                string property = gridFilters.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = gridFilters.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int index = lstFilters.SelectedIndex;
                typeof(reportParam).GetProperty(property).SetValue(Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportParam.ElementAt(lstFilters.SelectedIndex), value); ;
                setFiltersList();
                lstFilters.SetSelected(index, true);
            }
        }

        private void gridColumns_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridColumns.DataSource != null && lstColumns.SelectedItem!=null)
            {
                string property = gridColumns.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = gridColumns.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                int index = lstColumns.SelectedIndex;
              
                typeof(reportColumn).GetProperty(property).SetValue(Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportColumn.ElementAt(lstColumns.SelectedIndex), value); 
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
                if (propertyName.Equals("isCustomSQlUsed",StringComparison.OrdinalIgnoreCase) || propertyName.Equals("IsPagingAvailable", StringComparison.OrdinalIgnoreCase)|| propertyName.Equals("IsExportButtonHidden", StringComparison.OrdinalIgnoreCase))
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
                    ObjectsList parentList = new ObjectsList(FormObjects.REPORT_SETT, e.RowIndex, e.ColumnIndex);
                    parentList.ShowDialog();
                }
                if (propertyName.Equals("RoleRequired", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    RoleList formsList = new RoleList(FormObjects.REPORT_ROLE, e.RowIndex, e.ColumnIndex);
                    formsList.ShowDialog();
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
                if (propertyName.Equals("IsVisible", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridFilters[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("sqlServerDBDataType", StringComparison.OrdinalIgnoreCase))
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
            if (propertyName.Equals("IsVisible", StringComparison.OrdinalIgnoreCase)|| propertyName.Equals("IsButtonCallToAction", StringComparison.OrdinalIgnoreCase))
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
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    FormsList formsList = new FormsList(ParentType.REPORT_BUTTON, e.RowIndex, e.ColumnIndex);
                formsList.ShowDialog();
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
                if (propertyName.Equals("IsVisible", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridColumns[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("sqlServerDBDataType", StringComparison.OrdinalIgnoreCase))
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
                    ObjectsList formsList = new ObjectsList(FormObjects.REPORT_COLUMNS, e.RowIndex, e.ColumnIndex);
                    formsList.ShowDialog();
                }
            }
        }

        

        private void gridButtons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridButtons.DataSource != null && lstButtons.SelectedItem != null)
            {
                string property = gridButtons.Rows[gridButtons.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string value = gridButtons.Rows[gridButtons.CurrentCell.RowIndex].Cells[gridButtons.CurrentCell.ColumnIndex].Value.ToString();
                int index = lstButtons.SelectedIndex;
                typeof(reportButton).GetProperty(property).SetValue(Form1.model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == rpt.OwnerObject).FirstOrDefault().report.Where(x => x.name == rpt.name).FirstOrDefault().reportButton.ElementAt(lstButtons.SelectedIndex), value);
                setButtonsList();
                lstButtons.SetSelected(index, true);
            }
        }
    }
}
