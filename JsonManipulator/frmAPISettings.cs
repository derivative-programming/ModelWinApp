using JsonManipulator.Enums;
using JsonManipulator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace JsonManipulator
{
    public partial class frmAPISettings : Form
    {
        Models.apiSite _apiSite = new Models.apiSite();
        public frmAPISettings(string apiSiteName)
        {
            InitializeComponent();
            this._apiSite = Utils.GetApiSiteModelItem(apiSiteName);
            this.grpMain.Text = _apiSite.name;
        }

        private void frmReportSettings_Load(object sender, EventArgs e)
        {
            setSetting();
            setEnvironmentsList();
            setEndPointsList();
            splitter1.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmAPISettings.splitter1.SplitPosition", "200"));
            splitter2.SplitPosition = System.Convert.ToInt32(LocalStorage.GetValue("frmAPISettings.splitter2.SplitPosition", "200"));

            tabControl1.SelectedIndex = System.Convert.ToInt32(LocalStorage.GetValue("frmAPISettings.tabControl1.SelectedIndex", "0"));
            
        }


        private void setSetting()
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            dataProperties.Columns.Clear();
            List<string> ignoreList = Utils.GetApiSitePropertiesToIgnore();
            foreach (var prop in _apiSite.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                if (ignoreList.Contains(prop.Name.ToLower()))
                    continue;
                // Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(_apiSite) ?? "").ToString() }); ;
            }
            dataProperties.DataSource = propertyValues;
            if (dataProperties.Columns.Count > 0)
            {
                dataProperties.Columns[0].ReadOnly = true;
            }
        }
        public void setEnvironmentsList()
        {
            lstEnvironments.Items.Clear();
            if (_apiSite.apiEnvironment == null)
            {
                _apiSite.apiEnvironment = new List<apiEnvironment>();
            }
            foreach (var param in _apiSite.apiEnvironment)
            {
                lstEnvironments.Items.Add(param.name);
            }
            if (lstEnvironments.Items.Count > 0)
                lstEnvironments.SelectedIndex = lstEnvironments.Items.Count - 1;
        }
        public void setEndPointsList()
        {
            lstEndPoints.Items.Clear();
            if (_apiSite.apiEndPoint == null)
            {
                _apiSite.apiEndPoint = new List<apiEndPoint>();
            }
            foreach (var item in _apiSite.apiEndPoint)
            {
                lstEndPoints.Items.Add(item.name);
            }
            if (lstEndPoints.Items.Count > 0)
                lstEndPoints.SelectedIndex = lstEndPoints.Items.Count - 1;
        }
        private void lstEnvironments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEnvironments.SelectedItem != null)
            {
                List<PropertyValue> propertyValues = new List<PropertyValue>();
                String filterName = lstEnvironments.SelectedItem.ToString();
                List<string> ignoreList = Utils.GetApiSiteEnvironmentPropertiesToIgnore();
                Models.apiEnvironment rptParam = _apiSite.apiEnvironment.Where(x => x.name == filterName).FirstOrDefault();
                foreach (var prop in rptParam.GetType().GetProperties().OrderBy(x => x.Name).ToList())
                {
                    if (ignoreList.Contains(prop.Name.ToLower()))
                        continue;
                    if (!prop.PropertyType.IsGenericType)
                        propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(rptParam) ?? "").ToString() });
                }
                gridEnvironments.Columns.Clear();
                gridEnvironments.DataSource = propertyValues;
                if (gridEnvironments.Columns.Count > 0)
                {
                    gridEnvironments.Columns[0].ReadOnly = true;
                }
            }

        }

        private void lstEndPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<PropertyValue> propertyValues = new List<PropertyValue>();
            String filterName = lstEndPoints.SelectedItem.ToString();
            List<string> ignoreList = Utils.GetApiSiteEndPointPropertiesToIgnore();
            Models.apiEndPoint apiEndPoint = _apiSite.apiEndPoint.Where(x => x.name == filterName).FirstOrDefault();
            foreach (var prop in apiEndPoint.GetType().GetProperties().OrderBy(x => x.Name).ToList())
            {
                if (ignoreList.Contains(prop.Name.ToLower(),StringComparer.OrdinalIgnoreCase))
                    continue;
                if (!prop.PropertyType.IsGenericType)
                    propertyValues.Add(new PropertyValue { Property = prop.Name, Value = (prop.GetValue(apiEndPoint) ?? "").ToString() });
            }
            gridEndPoints.Columns.Clear();
            gridEndPoints.DataSource = propertyValues;
            if (gridEndPoints.Columns.Count > 0)
            {
                gridEndPoints.Columns[0].ReadOnly = true;
            }
        }

        private void btnAddEnvironment_Click(object sender, EventArgs e)
        {
            frmAddApiSiteEnvironment form = new frmAddApiSiteEnvironment(_apiSite.name);
            form.ShowDialog();
        }

        private void btnColumnsAdd_Click(object sender, EventArgs e)
        {
            frmAddApiSiteEndPoint form = new frmAddApiSiteEndPoint(_apiSite.name);
            form.ShowDialog();
        }

        private void btnColumnsMoveUp_Click(object sender, EventArgs e)
        {
            if (lstEndPoints.SelectedItem != null)
            {
                int selectedIndex = lstEndPoints.SelectedIndex;
                apiEndPoint item = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.Insert(newIndex, item);
                setEndPointsList();
                lstEndPoints.SetSelected(newIndex, true);
            }
        }

        private void btnColumnsMoveDown_Click(object sender, EventArgs e)
        {
            if (lstEndPoints.SelectedItem != null)
            {
                int selectedIndex = lstEndPoints.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.Count;
                apiEndPoint item = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.Insert(newIndex, item);
                setEndPointsList();
                lstEndPoints.SetSelected(newIndex, true);
            }
        }

        private void btnEnvironmentMoveUp_Click(object sender, EventArgs e)
        {
            if (lstEnvironments.SelectedItem != null)
            {
                int selectedIndex = lstEnvironments.SelectedIndex;
                apiEnvironment item = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == 0)
                {
                    newIndex = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.Count - 1;
                }
                else
                {
                    newIndex = selectedIndex - 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.Insert(newIndex, item);
                setEnvironmentsList();
                lstEnvironments.SetSelected(newIndex, true);
            }
        }

        private void btnEnvironmentMoveDown_Click(object sender, EventArgs e)
        {
            if (lstEnvironments.SelectedItem != null)
            {
                int selectedIndex = lstEnvironments.SelectedIndex;
                int count = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.Count;
                apiEnvironment item = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.ElementAt(selectedIndex);
                int newIndex = 0;
                if (selectedIndex == count - 1)
                {
                    newIndex = 0;
                }
                else
                {
                    newIndex = selectedIndex + 1;
                }
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.RemoveAt(selectedIndex);
                Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.Insert(newIndex, item);
                setEnvironmentsList();
                lstEnvironments.SetSelected(newIndex, true);
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
                apiSite temp = Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault(); 
                typeof(apiSite).GetProperty(property).SetValue(temp, value);

                if (property.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    ((Form1)Application.OpenForms["Form1"]).updateTree(value, 2);
                }
            }

        }

        private void gridEnvironments_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (gridEnvironments.DataSource != null && lstEnvironments.SelectedItem != null)
            {
                string property = gridEnvironments.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridEnvironments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridEnvironments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                int index = lstEnvironments.SelectedIndex;
                typeof(apiEnvironment).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEnvironment.ElementAt(lstEnvironments.SelectedIndex), value); ;
                setEnvironmentsList();
                lstEnvironments.SetSelected(index, true);
            }
        }

        private void gridEndPoints_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridEndPoints.DataSource != null && lstEndPoints.SelectedItem != null)
            {
                string property = gridEndPoints.Rows[e.RowIndex].Cells[0].Value.ToString();
                string value = string.Empty;
                if (gridEndPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    value = gridEndPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }

                if (property.StartsWith("is"))
                {
                    if (value != null && !Utils.getBooleanList().Contains(value))
                    {
                        return;
                    }
                }
                if (property.ToLower() == "apiGetContextTargetName".ToLower())
                {
                    Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(value);
                    if (destinationOwnerObject == null)
                    {
                        gridEndPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    typeof(apiEndPoint).GetProperty("apiGetContextObjectName").SetValue(
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.ElementAt(lstEndPoints.SelectedIndex), destinationOwnerObject.name);
                }

                if (property.ToLower() == "apiPostContextTargetName".ToLower())
                {
                    Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(value);
                    if (destinationOwnerObject == null)
                    {
                        gridEndPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    typeof(apiEndPoint).GetProperty("apiPostContextObjectName").SetValue(
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.ElementAt(lstEndPoints.SelectedIndex), destinationOwnerObject.name);
                }

                if (property.ToLower() == "apiPutContextTargetName".ToLower())
                {
                    Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(value);
                    if (destinationOwnerObject == null)
                    {
                        gridEndPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    typeof(apiEndPoint).GetProperty("apiPutContextObjectName").SetValue(
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.ElementAt(lstEndPoints.SelectedIndex), destinationOwnerObject.name);
                }

                if (property.ToLower() == "apiDeleteContextTargetName".ToLower())
                {
                    Models.ObjectMap destinationOwnerObject = Utils.GetOwnerObject(value);
                    if (destinationOwnerObject == null)
                    {
                        gridEndPoints.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        return;
                    }
                    typeof(apiEndPoint).GetProperty("apiDeleteContextObjectName").SetValue(
                        Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.ElementAt(lstEndPoints.SelectedIndex), destinationOwnerObject.name);
                }


                int index = lstEndPoints.SelectedIndex;

                typeof(apiEndPoint).GetProperty(property).SetValue(Form1._model.root.NameSpaceObjects.FirstOrDefault().apiSite.Where(x => x.name == _apiSite.name).FirstOrDefault().apiEndPoint.ElementAt(lstEndPoints.SelectedIndex), value);
                setEndPointsList();
                lstEndPoints.SetSelected(index, true);
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

            }
        }

        private void gridEnvironments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridEnvironments.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridEnvironments[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
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
        public void setEndPointData(string value, int row, int column)
        {
            gridEndPoints.Rows[row].Cells[column].Value = value;
            gridEndPoints.RefreshEdit();
        }


        private void gridEndPoints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {

                // Bind grid cell with combobox and than bind combobox with datasource.  
                DataGridViewComboBoxCell l_objGridDropbox = new DataGridViewComboBoxCell();
                string propertyName = gridEndPoints.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
                // Check the column  cell, in which it click.  
                if (propertyName.StartsWith("is"))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  
                    gridEndPoints[e.ColumnIndex, e.RowIndex] = l_objGridDropbox;
                    l_objGridDropbox.DataSource = Utils.getBooleans(); // Bind combobox with datasource.  
                    l_objGridDropbox.ValueMember = "Value";
                    l_objGridDropbox.DisplayMember = "Display";
                    l_objGridDropbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                }
                if (propertyName.Equals("apiGetContextTargetName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview   
                    using (var form = new frmModelSearch(ModelSearchOptions.REPORTS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setEndPointData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                if (propertyName.Equals("apiPostContextTargetName", StringComparison.OrdinalIgnoreCase) ||
                    propertyName.Equals("apiDeleteContextTargetName", StringComparison.OrdinalIgnoreCase) ||
                    propertyName.Equals("apiPutContextTargetName", StringComparison.OrdinalIgnoreCase))
                {
                    // On click of datagridview cell, attched combobox with this click cell of datagridview  

                    using (var form = new frmModelSearch(ModelSearchOptions.FLOWS))
                    {
                        var result = form.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string val = form.ReturnValue;
                            setEndPointData(val, e.RowIndex, e.ColumnIndex);
                        }
                    }
                }
                 
            }
        }




        private void dataProperties_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridEnvironments_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridEndPoints_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void gridEndPoints_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                SendKeys.Send("{TAB}");
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAPISettings_FormClosing(object sender, FormClosingEventArgs e)
        {

            LocalStorage.SetValue("frmAPISettings.splitter1.SplitPosition", splitter1.SplitPosition.ToString());

            LocalStorage.SetValue("frmAPISettings.splitter2.SplitPosition", splitter2.SplitPosition.ToString());

            LocalStorage.SetValue("frmAPISettings.tabControl1.SelectedIndex", tabControl1.SelectedIndex.ToString());

            LocalStorage.Save();
        }

        private void rtbJSON_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbJSON.Text = JsonConvert.SerializeObject(_apiSite, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            this._apiSite.apiEndPoint = this._apiSite.apiEndPoint.OrderBy(x => x.name).ToList();
            setEndPointsList();
        }
    }
}
