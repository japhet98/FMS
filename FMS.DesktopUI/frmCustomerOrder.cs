using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FMS.Repository;
using Zuby.ADGV;

namespace FMS.DesktopUI
{
 
    public partial class frmCustomerOrder : Form
    {
        private ShippingDetailController order { get; set; }
        public frmCustomerOrder()
        {
            InitializeComponent();
             order = new ShippingDetailController();
            CreateColums();
            PopulateDataGridView();
        }
        public frmCustomerOrder(string customerId)
        {
            InitializeComponent();
            order = new ShippingDetailController();
            CreateColums();
            PopulateDataGridView();
            PopulateTextBoxes(customerId);
        }

        private void PopulateTextBoxes(string customerId)
        {
           
              //  var selectedRows = dgvResult.SelectedRows[0].Cells;
               // txtShippingId.Text = selectedRows[1].Value.ToString();
                txtCustomerName.Text = customerId;
            
           
        }
        private void PopulateDataGridView()
        {
            for(int i=0; i<=100; i++)
            {
                adgvResult.Rows.Add(i,("boatno"+i +"cannoeno"+i + new DateTime().Date.ToShortDateString()),
                    "Boat No " + i, "Cannoe No " + i, new DateTime().Date.ToShortDateString(),
                                    (i + 1) * 5, (i + 1) * 2, (i + 1) * 2, (i + 1) * 10,"Leader Name "+i);
            }


          /*  order.GetShipping().ForEach(sec =>
            {
                adgvResult.Rows.Add(sec.sn, sec.shippingId, sec.BoatNo, sec.CannoeType, sec.dateArrived,
                                    sec.QmainFish, sec.QlogoFish, sec.QbrokenFish, sec.totalQuantity, sec.leaderName);

            });

    */
        }
        private void CreateColums()
        {
            adgvResult.Columns.Add("sn", "SN");
            adgvResult.Columns.Add("shippingId", "Shipping ID");
            adgvResult.Columns.Add("BoatNo", "Boat Number");
            adgvResult.Columns.Add("CannoeType", "Cannoe Name");
            adgvResult.Columns.Add("dateArrived", "Date Boat Arrived");
            adgvResult.Columns.Add("QmainFish", "Main Fish Quantity");
            adgvResult.Columns.Add("QlogoFish", "Logo Fish Quantity");
            adgvResult.Columns.Add("QbrokenFish", "Broken Fish Quantity");
            adgvResult.Columns.Add("totalQuantity", "Total Fish Quantity");
            adgvResult.Columns.Add("leaderName", "Cannoe Leader Name");
            adgvResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }

        private void btnExitChild_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool status = false;
        private void adgvResult_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            status = !status;
            if (status == true) {
                adgvResult.Sort(adgvResult.Columns[0], ListSortDirection.Ascending);
            }
            else
            {
                adgvResult.Sort(adgvResult.Columns[0], ListSortDirection.Descending);
            }

           
        }
        DataTable OriginalADGVdt = null;
        private void adgvResult_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            AdvancedDataGridView fdgv = adgvResult;
            DataTable dt = null;
            if(OriginalADGVdt == null)
            {
                OriginalADGVdt = (DataTable)fdgv.DataSource;

            }
            if (fdgv.FilterString.Length > 0)
            {
                dt = (DataTable)fdgv.DataSource;
            }
            else
            {
                dt = OriginalADGVdt;
            }
           
           // fdgv.DataSource = dt.Select(fdgv.FilterString).CopyToDataTable();
        }
    }
}
