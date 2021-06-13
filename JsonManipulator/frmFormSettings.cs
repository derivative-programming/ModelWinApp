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
    public partial class frmFormSettings : Form
    {
        objectWorkflow _form;
        List<objectWorkflowParam> _controls;
        List<objectWorkflowButton> _buttons;
        public frmFormSettings(objectWorkflow frm)
        {
            InitializeComponent();
            this._form = frm;
        }

        private void frmFormSettings_Load(object sender, EventArgs e)
        {
            _controls = new List<objectWorkflowParam>();
            _buttons = new List<objectWorkflowButton>();
            setSetting();
            grpMain.Text = _form.Name;
            setControlsList();
            setButtonsList();
        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            List<string> ignoreList = Utils.GetFormPropertiesToIgnore();
            foreach (var prop in _form.GetType().GetProperties())
            {
                if (ignoreList.Contains(prop.Name))
                    continue;
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(_form) ?? "").ToString() }); ;
            }
            gridProperties.Columns.Clear();
            gridProperties.DataSource = propertyValues;
            if (gridProperties.Columns.Count > 0)
            {
                gridProperties.Columns[0].ReadOnly = true;
            }
        }
        public void setControlsList()
        {
            lstControl.Items.Clear();
            if(_form.objectWorkflowParam!=null)
            {
                foreach (var param in _form.objectWorkflowParam)
                {
                    lstControl.Items.Add(param.name);
                    _controls.Add(param);
                }
                if (lstControl.Items.Count > 0)
                    lstControl.SelectedIndex = lstControl.Items.Count - 1;
            }
           
        }
        public void setButtonsList()
        {
            lstButtons.Items.Clear();
            if(_form.objectWorkflowButton!=null)
            {
                foreach (var param in _form.objectWorkflowButton)
                {
                    lstButtons.Items.Add(param.buttonText);
                    _buttons.Add(param);
                }
                if (lstButtons.Items.Count > 0)
                    lstButtons.SelectedIndex = lstButtons.Items.Count - 1;
            }
            
        }

        private void lstControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstControl.SelectedItem!=null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String controlName = lstControl.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetFormPropertiesToIgnore();
                objectWorkflowParam frmControl = _form.objectWorkflowParam.Where(x => x.name == controlName).FirstOrDefault();
                foreach (var prop in frmControl.GetType().GetProperties())
                {
                    if (ignoreList.Contains(prop.Name))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(frmControl) ?? "").ToString() });
                }
                gridControls.Columns.Clear();
                gridControls.DataSource = propertyValues;
                if (gridControls.Columns.Count > 0)
                {
                    gridControls.Columns[0].ReadOnly = true;
                }
            }
            
        }

        private void lstButtons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstButtons.SelectedItem!=null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String buttonName = lstButtons.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetFormPropertiesToIgnore();
                objectWorkflowButton frmControl = _form.objectWorkflowButton.Where(x => x.buttonText == buttonName).FirstOrDefault();
                foreach (var prop in frmControl.GetType().GetProperties())
                {
                    if (ignoreList.Contains(prop.Name))
                        continue;
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(frmControl) ?? "").ToString() });
                }
                gridButtons.Columns.Clear();
                gridButtons.DataSource = propertyValues;
                if (gridButtons.Columns.Count > 0)
                {
                    gridButtons.Columns[0].ReadOnly = true;
                }
            }
            
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            FrmControl frmControl = new FrmControl(_form.Name, _form.OwnerObject);
            frmControl.ShowDialog();
        }

        private void btnControlUp_Click(object sender, EventArgs e)
        {
            if(lstControl.SelectedItem!=null)
            {
                int selectedIndex = lstControl.SelectedIndex;
                objectWorkflowParam item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Insert(newIndex, item);
                setControlsList();
                lstControl.SetSelected(newIndex, true);
            }
           
        }

        private void btnControlDown_Click(object sender, EventArgs e)
        {
            if (lstControl.SelectedItem != null)
            {
                int selectedIndex = lstControl.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Count;
                objectWorkflowParam item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Insert(newIndex, item);
                setControlsList();
                lstControl.SetSelected(newIndex,true);
            }
                
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            FrmAddButton frmAddButton = new FrmAddButton(_form.Name, _form.OwnerObject, ButtonType.FORM);
            frmAddButton.ShowDialog();
        }

        private void gridProperties_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridProperties.DataSource != null)
            {
                string property = gridProperties.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridProperties.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                objectWorkflow temp = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault();
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow.RemoveAll(x => x.Name == _form.Name);
                typeof(objectWorkflow).GetProperty(property).SetValue(temp, value);
                if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow == null)
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow = new List<objectWorkflow>();
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow.Add(temp);
                if (property.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    ((Form1)Application.OpenForms["Form1"]).updateTree(value, 1);
                }
            }
        }

        private void gridControls_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridControls.DataSource != null && lstControl.SelectedItem!=null)
            {
                string property = gridControls.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridControls.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridControls.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                int index = lstControl.SelectedIndex;
                typeof(objectWorkflowParam).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(lstControl.SelectedIndex), value); ;
                setControlsList();
                lstControl.SetSelected(index, true);
            }
        }

        private void gridButtons_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridButtons.DataSource != null && lstButtons.SelectedItem!=null)
            {
                string property = gridButtons.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridButtons.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridButtons.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                int index = lstButtons.SelectedIndex;
                typeof(objectWorkflowButton).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _form.OwnerObject).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(lstButtons.SelectedIndex), value); ;
                setButtonsList();
                lstButtons.SetSelected(index, true);
            }
        }

        private void gridProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                string propertyName = gridProperties.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                
                if (propertyName.Equals("RoleRequired", StringComparison.OrdinalIgnoreCase))
                {
                    RoleList roleList = new RoleList(FormObjects.DBBJECT_EDIT,e.RowIndex,e.ColumnIndex);
                    roleList.ShowDialog();
                }
                if (propertyName.Equals("OwnerObject", StringComparison.OrdinalIgnoreCase))
                {
                    ObjectsList roleList = new ObjectsList(FormObjects.DBBJECT_EDIT, e.RowIndex, e.ColumnIndex);
                    roleList.ShowDialog();
                }
            }
        }
        public void setData(string value,int row,int cell)
        {
           
            gridProperties.Rows[row].Cells[cell].Value = value;
            gridProperties.RefreshEdit();
        }

        private void gridControls_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >0)
            {
                
                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridControls.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.Equals("IsVisible", StringComparison.OrdinalIgnoreCase) || propertyName.Equals("forceDBColumnIndex", StringComparison.OrdinalIgnoreCase) || propertyName.Equals("IsEncrypted", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridControls[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("sqlServerDBDataType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridControls[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getDataTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }

            }
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
                    l_objGridDropbox.DataSource = Utils.getButtons(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("IsVisible", StringComparison.OrdinalIgnoreCase))
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
                    FormsList formsList = new FormsList(ParentType.EDIT,e.RowIndex,e.ColumnIndex);
                    formsList.ShowDialog();
                }
            }

        }
        public void setButtonData(string value, int row, int column)
        {
            gridButtons.Rows[row].Cells[column].Value = value;
            gridButtons.RefreshEdit();
        }

        
    }
}
