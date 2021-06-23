﻿using JsonManipulator.Enums;
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
    public partial class frmServicesApiPrepRequestList : Form
    {
        public class GridItem
        {
            public Guid RequestCode { get; set; }
            public DateTime RequestUTCDateTime { get; set; }
            public bool IsStarted { get; set; }
            public bool IsCompleted { get; set; }
            public bool IsSuccessful { get; set; }
            public bool IsCanceled { get; set; }
            public GridItem(PrepRequestListModelItem item)
            {
                this.RequestCode = item.ModelPrepRequestCode;
                this.RequestUTCDateTime = DateTime.Parse(item.ModelPrepRequestRequestedUTCDateTime);
                this.IsStarted = item.ModelPrepRequestIsStarted;
                this.IsCompleted = item.ModelPrepRequestIsCompleted;
                this.IsSuccessful = item.ModelPrepRequestIsSuccessful;
                this.IsCanceled = item.ModelPrepRequestIsCanceled;
            }
        }
        private List<GridItem> _itemList = new List<GridItem>();
        private PrepRequestListModel _result = null;

        private BindingSource _BindingSource = null;
        private BindingList<GridItem> _BindingList = null;
        public frmServicesApiPrepRequestList()
        {
            InitializeComponent();
        }

        private async Task LoadItemsAsync()
        {
            _result = await OpenAPIs.ApiManager.GetPrepRequestListAsync();

            if (_result == null)
                return;

            _itemList.Clear();
            foreach(PrepRequestListModelItem item in _result.Items)
            {

                _itemList.Add(new GridItem(item));
            }
            _itemList = _itemList.OrderByDescending(x => x.RequestUTCDateTime).ToList(); 

            gridRequestList.Rows.Clear();
            gridRequestList.Columns.Clear();

            _BindingList = new BindingList<GridItem>(_itemList);
            _BindingSource = new BindingSource(_BindingList, null);
              

            gridRequestList.DataSource = null;
            gridRequestList.DataSource = _BindingSource;
             

            var col = gridRequestList.Columns["RequestCode"];
            col.Visible = false;

            DataGridViewButtonColumn detailButtonColumn = new DataGridViewButtonColumn();
            detailButtonColumn.Name = "detail_button_column";
            detailButtonColumn.Text = "Details";
            detailButtonColumn.HeaderText = "";
            detailButtonColumn.UseColumnTextForButtonValue = true;

            gridRequestList.Columns.Add(detailButtonColumn);

            foreach (DataGridViewColumn column in gridRequestList.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int widthCol = column.Width;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Width = widthCol;
            } 
        }
         

        private async void ViewItem(Guid requestCode)
        {
            var item = GetItem(requestCode);
            if(item != null)
            { 
                using (var form = new frmServicesApiPrepRequestDetail(item))
                {
                    var result = form.ShowDialog();
                    await RefresListAsync();
                }
            }
        }

        private PrepRequestListModelItem GetItem(Guid requestCode)
        {
            PrepRequestListModelItem result = null;
            foreach (PrepRequestListModelItem item in _result.Items)
            {
                if(item.ModelPrepRequestCode == requestCode)
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
        }

        private void gridRequestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridRequestList.Columns["detail_button_column"].Index)
            {
                Guid requestCode = Guid.Parse(gridRequestList.Rows[e.RowIndex].Cells[0].Value.ToString());
                ViewItem(requestCode);
            }
        }

        private async Task RefresListAsync()
        {
            _result = await OpenAPIs.ApiManager.GetPrepRequestListAsync();

            if (_result == null)
                return;

            _itemList.Clear();
            foreach (PrepRequestListModelItem item in _result.Items)
            {

                _itemList.Add(new GridItem(item));
            }
            _itemList = _itemList.OrderByDescending(x => x.RequestUTCDateTime).ToList();
            _BindingList.OrderByDescending(x => x.RequestUTCDateTime);
            _BindingSource.ResetBindings(false);
        }
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefresListAsync();
        }

        private async void btnAddRequest_Click(object sender, EventArgs e)
        {
            Form1 parentForm = ((Form1)Application.OpenForms["Form1"]);
            parentForm.SaveModel();
            string modelPath = parentForm.GetModelPath();
            await OpenAPIs.ApiManager.AddPrepRequestAsync(modelPath);
            await RefresListAsync();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }

    

}