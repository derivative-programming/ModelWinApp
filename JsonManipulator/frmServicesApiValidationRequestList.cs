﻿using JsonManipulator.Enums;
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
    public partial class frmServicesApiValidationRequestList : Form
    {
        public class GridItem : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName) 
            { 
                if (null != PropertyChanged) 
                { 
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
                } 
            }

            public Guid RequestCode { get; set; }
            public DateTime RequestUTCDateTime { get; set; }
            public string Description { get; set; }
            public bool IsStarted { get; set; }
            public bool IsCompleted { get; set; }
            public bool IsSuccessful { get; set; }
            public bool IsCanceled { get; set; }
            public GridItem(ValidationRequestListModelItem item)
            {
                this.RequestCode = item.ModelValidationRequestCode;
                this.RequestUTCDateTime = DateTime.Parse(item.ModelValidationRequestRequestedUTCDateTime).ToLocalTime();
                this.IsStarted = item.ModelValidationRequestIsStarted;
                this.IsCompleted = item.ModelValidationRequestIsCompleted;
                this.IsSuccessful = item.ModelValidationRequestIsSuccessful;
                this.IsCanceled = item.ModelValidationRequestIsCanceled;
                this.Description = item.ModelValidationRequestDescription;
            }
        }
        private List<GridItem> _itemList = new List<GridItem>();
        private ValidationRequestListModel _result = null; 
        public frmServicesApiValidationRequestList()
        {
            InitializeComponent();
        }

        private async Task LoadItemsAsync()
        {
            _result = await OpenAPIs.ApiManager.GetValidationRequestListAsync();

            if (_result == null)
                return;

            this.UseWaitCursor = true;
            _itemList.Clear();
            foreach(ValidationRequestListModelItem item in _result.Items)
            {

                _itemList.Add(new GridItem(item));
            }
            _itemList = _itemList.OrderByDescending(x => x.RequestUTCDateTime).ToList(); 

            //gridRequestList.Rows.Clear();
            gridRequestList.Columns.Clear();  

            gridRequestList.DataSource = null;
            gridRequestList.DataSource = ToDataTable(_itemList);
             

            var col = gridRequestList.Columns["RequestCode"];
            col.Visible = false;

            DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn();
            detailButtonColumn.Name = "detail_button_column";
            detailButtonColumn.Text = "Details";
            detailButtonColumn.HeaderText = "";
            detailButtonColumn.UseColumnTextForButtonValue = true;

            gridRequestList.Columns.Add(detailButtonColumn);

            //foreach (DataGridViewColumn column in gridRequestList.Columns)
            //{
            //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //    int widthCol = column.Width;
            //    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    column.Width = widthCol;
            //}
            this.UseWaitCursor = false;
        }
         

        private async void ViewItem(Guid requestCode)
        {
            var item = GetItem(requestCode);
            if(item != null)
            {
                using (var form = new frmServicesApiValidationRequestDetail(item))
                {
                    var result = form.ShowDialog();
                    await LoadItemsAsync();
                }
            }
        }

        private ValidationRequestListModelItem GetItem(Guid requestCode)
        {
            ValidationRequestListModelItem result = null;
            foreach (ValidationRequestListModelItem item in _result.Items)
            {
                if(item.ModelValidationRequestCode == requestCode)
                {
                    result = item;
                    break;
                } 
            }
            return result;
        } 

        private async void frmForm_Load(object sender, EventArgs e)
        {
            await LoadItemsAsync();
            timer1.Enabled = true;
        }

        private void gridRequestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridRequestList.Columns["detail_button_column"].Index)
            {
                Guid requestCode = Guid.Parse(gridRequestList.Rows[e.RowIndex].Cells[0].Value.ToString());
                ViewItem(requestCode);
            }
        }
         
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadItemsAsync();
        }

        private async void btnAddRequest_Click(object sender, EventArgs e)
        {
            using (var form = new frmServicesApiAddRequest())
            {
                form.ReturnValue = "Project: " + Utils.GetProjectName();
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;

                    Form1 parentForm = ((Form1)Application.OpenForms["Form1"]);
                    parentForm.SaveModel();
                    string modelPath = parentForm.GetModelPath();
                    this.UseWaitCursor = true;
                    await OpenAPIs.ApiManager.AddValidationRequestAsync(val, modelPath);
                    this.UseWaitCursor = false;
                    await LoadItemsAsync();

                    ((Form1)Application.OpenForms["Form1"]).showMessage("Validation request added successfully"); 
                }
            }
             

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await LoadItemsAsync();
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }

    

}
