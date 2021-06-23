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
    public partial class frmServicesApiFabricationRequestList : Form
    {
        public class GridItem
        {
            public Guid RequestCode { get; set; }
            public DateTime RequestUTCDateTime { get; set; }
            public string Description { get; set; }
            public bool IsStarted { get; set; }
            public bool IsCompleted { get; set; }
            public bool IsSuccessful { get; set; }
            public bool IsCanceled { get; set; }
            public GridItem(FabricationRequestListModelItem item)
            {
                this.RequestCode = item.ModelFabricationRequestCode;
                this.RequestUTCDateTime = DateTime.Parse(item.ModelFabricationRequestRequestedUTCDateTime).ToLocalTime();
                this.IsStarted = item.ModelFabricationRequestIsStarted;
                this.IsCompleted = item.ModelFabricationRequestIsCompleted;
                this.IsSuccessful = item.ModelFabricationRequestIsSuccessful;
                this.IsCanceled = item.ModelFabricationRequestIsCanceled;
                this.Description = item.ModelFabricationRequestDescription;
            }
        }
        private List<GridItem> _itemList = new List<GridItem>();
        private FabricationRequestListModel _result = null;

        private BindingSource _BindingSource = null;
        private BindingList<GridItem> _BindingList = null;
        public frmServicesApiFabricationRequestList()
        {
            InitializeComponent();
        }
         

        private async Task LoadItemsAsync()
        {
            _result = await OpenAPIs.ApiManager.GetFabricationRequestListAsync();

            if (_result == null)
                return;

            _itemList.Clear();
            foreach(FabricationRequestListModelItem item in _result.Items)
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
                using (var form = new frmServicesApiFabricationRequestDetail(item))
                {
                    var result = form.ShowDialog();
                    await RefresListAsync();

                }
            }
        }

        private FabricationRequestListModelItem GetItem(Guid requestCode)
        {
            FabricationRequestListModelItem result = null;
            foreach (FabricationRequestListModelItem item in _result.Items)
            {
                if(item.ModelFabricationRequestCode == requestCode)
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

        private async Task RefresListAsync()
        {
            _result = await OpenAPIs.ApiManager.GetFabricationRequestListAsync();

            if (_result == null)
                return;

            _itemList.Clear();
            foreach (FabricationRequestListModelItem item in _result.Items)
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

            using (var form = new frmServicesApiAddRequest())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue;
                     
                    Form1 parentForm = ((Form1)Application.OpenForms["Form1"]);
                    parentForm.SaveModel();
                    string modelPath = parentForm.GetModelPath();
                    await OpenAPIs.ApiManager.AddFabricationRequestAsync(val, modelPath);
                    await RefresListAsync();

                    ((Form1)Application.OpenForms["Form1"]).showMessage("Fabrication request added successfully"); 
                }
            }
            

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await RefresListAsync();
        }
    }

    

}
