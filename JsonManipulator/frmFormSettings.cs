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
    public partial class frmFormSettings : Form
    {
        objectWorkflow _form;
        ObjectMap _ownerObject;
        List<objectWorkflowParam> _controls;
        List<objectWorkflowButton> _buttons;
        List<objectWorkflowOutputVar> _outputVars;
        bool _isLoadingPropSubscriptions = false;
        public frmFormSettings(string objWFName)
        {
            InitializeComponent();
            this._form = Utils.GetObjWFModelItem(objWFName);
            this._ownerObject = Utils.GetOwnerObject(objWFName);
        }

        private void frmFormSettings_Load(object sender, EventArgs e)
        {
            _controls = new List<objectWorkflowParam>();
            _buttons = new List<objectWorkflowButton>();
            _outputVars = new List<objectWorkflowOutputVar>();
            if(Utils.IsObjectWorkflowAForm(this._form))
            { 
                tabControl1.TabPages["tabControls"].Text = "Controls";
            }
            if (Utils.IsObjectWorkflowAFlow(this._form))
            {
                tabControl1.TabPages.RemoveByKey("tabButtons");
                tabControl1.TabPages["tabControls"].Text = "Input";
            }
            setSetting();
            grpMain.Text = _form.Name;
            setControlsList();
            SetPropSubscriptionCheckboxes();

            splitter1.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.splitter1.SplitPosition", "200"));
            if (Utils.IsObjectWorkflowAForm(this._form))
            {
                setButtonsList();
                splitter2.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.splitter2.SplitPosition", "200"));
            }

            setOutputVarList();
            splitter3.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.splitter3.SplitPosition", "200"));
            

            if(System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.tabControl1.SelectedIndex", "0")) <= tabControl1.TabPages.Count)
                tabControl1.SelectedIndex = System.Convert.ToInt32(LocalStorage.GetValue("frmFormSettings.tabControl1.SelectedIndex", "0"));
        }
        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            List<string> ignoreList = new List<string>();
            if (Utils.IsObjectWorkflowAForm(this._form))
            {
                ignoreList = Utils.GetFormPropertiesToIgnore();
            }
            if (Utils.IsObjectWorkflowAFlow(this._form))
            {
                ignoreList = Utils.GetFlowPropertiesToIgnore();
            }
            foreach (var prop in _form.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                if (ignoreList.Contains(prop.Name.ToLower()))
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

        public void SetPropSubscriptionCheckboxes()
        {
            _isLoadingPropSubscriptions = true;
            chkSubscribeToOwnerObject.Checked = Utils.IsPropSubscriptionEnabledFor(_ownerObject, _form.Name);
            if (_form.targetChildObject != null &&
                _form.targetChildObject.Length > 0)
            {
                Models.ObjectMap objectMap = Utils.GetObjectModelItem(_form.targetChildObject);
                chkSubscribeToTargetChild.Enabled = true;
                chkSubscribeToTargetChild.Checked = Utils.IsPropSubscriptionEnabledFor(objectMap, _form.Name);
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
            if(_form.objectWorkflowButton!=null)
            {
                foreach (var param in _form.objectWorkflowButton)
                {
                    string buttonText = string.Empty;
                    if(param.buttonText != null)
                    {
                        buttonText = param.buttonText;
                    }
                    lstButtons.Items.Add(buttonText);
                    _buttons.Add(param);
                }
                if (lstButtons.Items.Count > 0)
                    lstButtons.SelectedIndex = lstButtons.Items.Count - 1;
            }
            
        }

        public void setOutputVarList()
        { 
            lstOutputVars.Items.Clear();
            if (_form.objectWorkflowOutputVar != null)
            {
                foreach (var param in _form.objectWorkflowOutputVar)
                {
                    lstOutputVars.Items.Add(param.name);
                    _outputVars.Add(param);
                }
                if (lstOutputVars.Items.Count > 0)
                    lstOutputVars.SelectedIndex = lstOutputVars.Items.Count - 1;
            }
        }

        private void lstControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstControl.SelectedItem!=null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String controlName = lstControl.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetFormParamPropertiesToIgnore();
                objectWorkflowParam frmControl = _form.objectWorkflowParam.Where(x => x.name == controlName).FirstOrDefault();
                foreach (var prop in frmControl.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
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
                List<string> ignoreList = Utils.GetFormButtonPropertiesToIgnore();
                objectWorkflowButton frmControl = _form.objectWorkflowButton.Where(x => x.buttonText == buttonName).FirstOrDefault();
                foreach (var prop in frmControl.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
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
        private void lstOutputVars_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstOutputVars.SelectedItem != null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String itemName = lstOutputVars.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetFormOutputVarPropertiesToIgnore();
                objectWorkflowOutputVar frmControl = _form.objectWorkflowOutputVar.Where(x => x.name == itemName).FirstOrDefault();
                foreach (var prop in frmControl.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(frmControl) ?? "").ToString() });
                }
                gridOutput.Columns.Clear();
                gridOutput.DataSource = propertyValues;
                if (gridOutput.Columns.Count > 0)
                {
                    gridOutput.Columns[0].ReadOnly = true;
                }
            }
        }

        private void btnControls_Click(object sender, EventArgs e)
        {
            FrmAddControl frmControl = new FrmAddControl(_form.Name, _ownerObject.name);
            frmControl.ShowDialog();
        }

        private void btnControlUp_Click(object sender, EventArgs e)
        {
            if(lstControl.SelectedItem!=null)
            {
                int selectedIndex = lstControl.SelectedIndex;
                objectWorkflowParam item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Insert(newIndex, item);
                setControlsList();
                lstControl.SetSelected(newIndex, true);
            }
           
        }

        private void btnControlDown_Click(object sender, EventArgs e)
        {
            if (lstControl.SelectedItem != null)
            {
                int selectedIndex = lstControl.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Count;
                objectWorkflowParam item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.Insert(newIndex, item);
                setControlsList();
                lstControl.SetSelected(newIndex,true);
            }
                
        }

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            FrmAddButton frmAddButton = new FrmAddButton(_form.Name, _ownerObject.name, ButtonType.FORM);
            frmAddButton.ShowDialog();
        }


        private void btnOutputVar_Click(object sender, EventArgs e)
        {
            FrmAddOutputVar frmControl = new FrmAddOutputVar(_form.Name, _ownerObject.name);
            frmControl.ShowDialog();

        }

        private void btnOutputVarUp_Click(object sender, EventArgs e)
        {

            if (lstOutputVars.SelectedItem != null)
            {
                int selectedIndex = lstOutputVars.SelectedIndex;
                objectWorkflowOutputVar item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.Insert(newIndex, item);
                setOutputVarList();
                lstOutputVars.SetSelected(newIndex, true);
            }
        }

        private void btnOutputVarDown_Click(object sender, EventArgs e)
        {

            if (lstOutputVars.SelectedItem != null)
            {
                int selectedIndex = lstOutputVars.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.Count;
                objectWorkflowOutputVar item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.Insert(newIndex, item);
                setOutputVarList();
                lstOutputVars.SetSelected(newIndex, true);
            }
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
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                objectWorkflow temp = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault(); 
                typeof(objectWorkflow).GetProperty(property).SetValue(temp, value);
                //if (Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow == null)
                //    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow = new List<objectWorkflow>();
                //Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == temp.OwnerObject).FirstOrDefault().objectWorkflow.Add(temp);
                if (property.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    ((Form1)Application.OpenForms["Form1"]).updateTree(value, 1);
                }
                if (property.Equals("OwnerObject") || property.Equals("targetChildObject"))
                {
                    SetPropSubscriptionCheckboxes();
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
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstControl.SelectedIndex;
                typeof(objectWorkflowParam).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowParam.ElementAt(lstControl.SelectedIndex), value); ;
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
                        gridButtons.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    typeof(objectWorkflowButton).GetProperty("destinationContextObjectName").SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(lstButtons.SelectedIndex), destinationOwnerObject.name); ;

                }
                int index = lstButtons.SelectedIndex;
                typeof(objectWorkflowButton).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(lstButtons.SelectedIndex), value); ;
                setButtonsList();
                lstButtons.SetSelected(index, true);
            }
        }
         
        private void gridOutput_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridOutput.DataSource != null && lstOutputVars.SelectedItem != null)
            {
                string property = gridOutput.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridOutput.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridOutput.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstOutputVars.SelectedIndex;
                typeof(objectWorkflowOutputVar).GetProperty(property).SetValue(
                    Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowOutputVar.ElementAt(lstOutputVars.SelectedIndex), value); ;
                setOutputVarList();
                lstOutputVars.SetSelected(index, true);
            }
        }

        private void gridProperties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell(); 
                string propertyName = gridProperties.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                
                if (propertyName.Equals("RoleRequired", StringComparison.OrdinalIgnoreCase))
                {
                    using (var form = new RoleList())
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.Equals("OwnerObject", StringComparison.OrdinalIgnoreCase) ||
                    propertyName.Equals("targetChildObject", StringComparison.OrdinalIgnoreCase))
                {
                    using (var form = new ObjectsList())
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridProperties[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
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
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridControls[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("dataType", StringComparison.OrdinalIgnoreCase))
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
                    // On click of datagridview cell, attched combobox with this click cell of datagridview   
                    using (var form = new FormsList())
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
        public void setButtonData(string value, int row, int column)
        {
            gridButtons.Rows[row].Cells[column].Value = value;
            gridButtons.RefreshEdit();
        }


        private void gridOutput_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridOutput.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.   
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridOutput[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                } 
                if (propertyName.Equals("dataType", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridOutput[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getDataTypes(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
            }
        }
        public void setOutputData(string value, int row, int column)
        {
            gridOutput.Rows[row].Cells[column].Value = value;
            gridOutput.RefreshEdit();
        }

        private void gridProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControls_CellEnter(object sender, DataGridViewCellEventArgs e)
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
        private void gridOutput_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridControls_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridButtons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmFormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            LocalStorage.SetValue("frmFormSettings.splitter1.SplitPosition", splitter1.SplitPosition.ToString());



            LocalStorage.SetValue("frmFormSettings.tabControl1.SelectedIndex", tabControl1.SelectedIndex.ToString());

            if (Utils.IsObjectWorkflowAForm(this._form))
            {
                LocalStorage.SetValue("frmFormSettings.splitter2.SplitPosition", splitter2.SplitPosition.ToString());
            }
             
            LocalStorage.SetValue("frmFormSettings.splitter3.SplitPosition", splitter3.SplitPosition.ToString());
            
            LocalStorage.Save();

        }

        private void btnButtonUp_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem != null)
            {
                int selectedIndex = lstButtons.SelectedIndex;
                objectWorkflowButton item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.Insert(newIndex, item);
                setButtonsList();
                lstButtons.SetSelected(newIndex, true);
            }
        }

        private void btnButtonDown_Click(object sender, EventArgs e)
        {
            if (lstButtons.SelectedItem != null)
            {
                int selectedIndex = lstButtons.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.Count;
                objectWorkflowButton item = Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().ObjectMap.Where(x => x.name == _ownerObject.name).FirstOrDefault().objectWorkflow.Where(x => x.Name == _form.Name).FirstOrDefault().objectWorkflowButton.Insert(newIndex, item);
                setButtonsList();
                lstButtons.SetSelected(newIndex, true);
            }
        }

        private void rtbJSON_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbJSON.Text = JsonConvert.SerializeObject(this._form, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

        }

        private void chkSubscribeToOwnerObject_CheckedChanged(object sender, EventArgs e)
        { 
            if (_isLoadingPropSubscriptions)
                return;
            if (chkSubscribeToOwnerObject.Checked)
            {
                Utils.AddPropSubscriptionFor(_ownerObject, _form.Name);
            }
            else
            {
                Utils.RemovePropSubscriptionFor(_ownerObject, _form.Name);
            }
        }

        private void chkSubscribeToTargetChild_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingPropSubscriptions)
                return;
            Models.ObjectMap objectMap = Utils.GetObjectModelItem(_form.targetChildObject);
            if (chkSubscribeToTargetChild.Checked)
            {
                Utils.AddPropSubscriptionFor(objectMap, _form.Name);
            }
            else
            {
                Utils.RemovePropSubscriptionFor(objectMap, _form.Name);
            }
        }
    }
}
