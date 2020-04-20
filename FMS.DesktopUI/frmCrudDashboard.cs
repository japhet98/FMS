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
using FMS.Model;
using Zuby.ADGV;

namespace FMS.DesktopUI
{
    public partial class frmCrudDashboard : Form
    {
        //  Global variables for the various Controllers
        CustomerController customer;
        SecretaryController sec;
        CeoController ceo;
        CustomerTransactionController Ctransaction;
        FishTypeController fishtype;
        CannoeController cannoetype;

        // Global variable to reference the input table name from the Ctor
        public string table { get; set; }
        public frmCrudDashboard()
        {
            InitializeComponent();
            // Set the Data GridView with all the details from the Customer DB
             var customer = new CustomerController();
                adgvResult.DataSource = customer.GetCustomers();

           
        }

        // Two parameters Constructor to accept Table Name and 
        // Customer ID to view the Payments made by that customer
         public frmCrudDashboard(string Table,string custId="")
        {
           
            InitializeComponent();
          
          
            table = Table;
            customer = new CustomerController();
           sec = new SecretaryController();
            ceo = new CeoController();
            Ctransaction= new CustomerTransactionController();
            fishtype = new FishTypeController();
            cannoetype = new CannoeController();

            // Populate Colums;
            CreateColumns();
            // Populate the Data Grid View
            populateDataGridView();

        }

        void emptyGridView()
        {
            if (adgvResult.RowCount.Equals(0) )
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }
        public void CreateColumns()
        {

            adgvResult.AutoGenerateColumns = false;
            if (table == "customer")
            {
                txtTitle.Text = "CUSTOMERS AVAILABLE";
                adgvResult.Columns.Add("sn", "SN");
                adgvResult.Columns.Add("Name", "NAME");
                adgvResult.Columns.Add("Phone", "Phone Number");
                adgvResult.Columns.Add("Resident", "Residential Address");
                adgvResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgvResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgvResult.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          

            }
            else if (table == "secretary")
            {
                txtTitle.Text = "REGISTERED SECRETARIES";
                adgvResult.Columns.Add("sn", "SN");
                adgvResult.Columns.Add("Name", "NAME");
                adgvResult.Columns.Add("Phone", "Phone Number");
                adgvResult.Columns.Add("email", "Email Address");
                adgvResult.Columns.Add("resident", "Residential Address");
                adgvResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgvResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgvResult.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgvResult.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
               
              
            }
            else if (table == "ceo")
            {
                txtTitle.Text = "REGISTERED CEO'S";
                adgvResult.Columns.Add("sn", "SN");
                adgvResult.Columns.Add("Name", "NAME");
                adgvResult.Columns.Add("phone", "Phone Number");
                adgvResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                adgvResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
              
            }
            else if (table == "deptors")
            {
                txtTitle.Text = "CUSTOMERS WITH DEPT";
                adgvResult.Columns.Add("sn", "SN");
                adgvResult.Columns.Add("Name", "Customer Name");
                adgvResult.Columns.Add("dateOrdered", "Date Ordered");
                adgvResult.Columns.Add("fishType", "Type of Fish");
                adgvResult.Columns.Add("quantity", "Quantity Ordered");
                adgvResult.Columns.Add("unitPrice", "Unit Price");
                adgvResult.Columns.Add("totalAmount", "Total Price");
                adgvResult.Columns.Add("Balance", "Balance");
                adgvResult.Columns.Add("BoatNo", "Boat Type");
                adgvResult.Columns.Add("CannoeType", "Cannoe Type");
                adgvResult.Columns.Add("dateArrived", "Cannoe Arrival Date");
                adgvResult.Columns.Add("leaderName", "Cannoe Leader Name");

               
               
            }
            else if (table == "Cpayment")
            {
                txtTitle.Text = "PAYMENTS MADE BY CUSTOMERS";
                adgvResult.Columns.Add("sn", "SN");
                adgvResult.Columns.Add("Name", "Customer Name");
                adgvResult.Columns.Add("Date_Ordered", "Date Ordered");
                adgvResult.Columns.Add("Fish_Type", "Type of Fish");
                adgvResult.Columns.Add("Quantity", "Quantity Ordered");
                adgvResult.Columns.Add("Unit_Price", "Unit Price");
                adgvResult.Columns.Add("Total_Amount", "Total Price");
                adgvResult.Columns.Add("Amount_Paid", "Amount Paid");
                adgvResult.Columns.Add("Balance", "Balance");
                adgvResult.Columns.Add("Reciever_Name", "Receiver Name");
                adgvResult.Columns.Add("Date_Received", "Date Received");

              
            }
            else if (table == "fishtype")
            {
                txtTitle.Text = "FISHES AVAILABLE";
                adgvResult.Columns.Add("sn", "SN");
                adgvResult.Columns.Add("fishType1", "Fish Name");
                adgvResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


               
            }
            else if (table == "cannoetype")
            {
                txtTitle.Text = "CANNOES AVAILABLE";
                adgvResult.Columns.Add("sn", "SN");
                adgvResult.Columns.Add("cannoeType", "Cannoe Name");
                adgvResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

              
            }
            else if (table == "order")
            {
                txtTitle.Text = "ORDERS MADE BY CUSTOMERS";
                adgvResult.Columns.Add("sn", "SN");
                adgvResult.Columns.Add("customerId", "Customer ID");
                adgvResult.Columns.Add("dateOrdered", "Date Ordered");
                adgvResult.Columns.Add("fishType", "Type of Fish");
                adgvResult.Columns.Add("quantity", "Quantity Ordered");
                adgvResult.Columns.Add("unitPrice", "Unit Price");
                adgvResult.Columns.Add("totalAmount", "Total Price");
                adgvResult.Columns.Add("Balance", "Balance");
                adgvResult.Columns.Add("paidFull", "Fully Paid");
                adgvResult.Columns.Add("orderId", "Order Id");
                adgvResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

              
            }
        }


        // Method to populate the data grid view;
        public void populateDataGridView()
        {
           
            dgvResult.AutoGenerateColumns = false;
            if (table == "customer")
            {
                // Add all customers to data gridview
              /*  customer.GetCustomers().ForEach(cust =>
                {
                    adgvResult.Rows.Add(cust.sn, cust.Name, cust.Phone, cust.Resident);
                });*/
                for (int i = 0; i < 1; i++)
                {
                    customer.GetCustomers().ForEach(cust =>
                    {
                        adgvResult.Rows.Add(cust.sn, cust.Name, cust.Phone, cust.Resident);
                    });
                }
                emptyGridView();

            }
            else if (table == "secretary")
            {
               
                /* sec.GetSecretarys().ForEach(sec =>
                 {
                     adgvResult.Rows.Add(sec.sn, sec.Name, sec.Phone, sec.email, sec.residence);
                 });*/

                for (int i = 0; i < 10; i++)
                {
                    adgvResult.Rows.Add(i, "Name "+i,"Phone "+i,"Email " +i, "Residence " +i);
                }
                emptyGridView();
                btnPaySecretary.Visible = true;
                btnEdit.Visible = false;
            }
            else if (table == "ceo")
            {

                for (int i = 0; i < 100; i++)
                {
                    adgvResult.Rows.Add(i, "Name " + i, "Phone " + i);
                }

                /* ceo.GetCeo().ForEach(sec =>
                 {
                     adgvResult.Rows.Add(sec.sn, sec.Name, sec.phone);
                 });*/

                emptyGridView();
            }
            else if (table == "deptors")
            {
                HideButtons();
                btnAdd.Visible = true;
                btnAdd.Text = "Make Payment";

               

                for (int i = 0; i < 100; i++)
                {
                    adgvResult.Rows.Add(
                                       i, "Customer Name " + i, new DateTime().Date,
                                       "Fish Type " + i, i * 8,
                                      i * 6, (i * 6) * (i * 8),
                                      i * 20, i * 2, "Boat " + i, "Cannoe " + i,
                                        new DateTime().Date, "Leader " + i);
                }


                var sn = 0;
                /*  Ctransaction.GetCustomersWithDept().ForEach(sec =>
                  {
                      adgvResult.Rows.Add(sn, sec.Name, sec.dateOrdered, sec.fishType, sec.quatity,
                                          sec.unitPrice, sec.totalAmount, sec.Balance, sec.BoatNo, sec.CannoeType,
                                          sec.dateArrived, sec.leaderName);
                      sn++;
                  });
                  */
                emptyGridView();
            }
            else if (table == "Cpayment")
            {
                HideButtons();
               
                var sn = 0;
                for (int i = 0; i < 100; i++)
                {
                    adgvResult.Rows.Add(
                                        i, "Customer Name " + i, new DateTime().Date,
                                        "Fish Type " + i, i*8,
                                       i*6,(i*6)*(i*8),
                                       i * 20, i * 2, "Receiver Name " + i,
                                         new DateTime().Date);
                }
                /* Ctransaction.GetAllCustomerPayments().ForEach(sec =>
                 {
                     adgvResult.Rows.Add(sn, sec.Customer_Name, sec.Date_Ordered, sec.Fish_Type,
                                     sec.Quantity, sec.Unit_Price, sec.Total_Amount,
                                     sec.Amount_Paid, sec.Balance, sec.Reciever_Name,
                                     sec.Date_Received);
                     sn++;
                 });
                 */
                emptyGridView();
            }
            else if (table == "fishtype")
            {

                /*  fishtype.GetAddFishTypes().ForEach(sec =>
                  {
                      adgvResult.Rows.Add(sec.sn, sec.fishType1);

                  });
                  */

                for (int i = 0; i < 10; i++)
                {

                    adgvResult.Rows.Add(i, "Fish Name " + i);

                }
                emptyGridView();
            }
            else if (table == "cannoetype")
            {

                /* cannoetype.GetCannoes().ForEach(sec =>
                 {
                     adgvResult.Rows.Add(sec.sn, sec.cannoeType);

                 });

                 */
                for (int i = 0; i < 10; i++)
                {

                    adgvResult.Rows.Add(i, "Cannoe Name "+i );

                }
                emptyGridView();
            }
            else if (table == "order")
            {

                /*  Ctransaction.GetAllCustomerOrder().ForEach(sec =>
                  {
                      adgvResult.Rows.Add(sec.sn, sec.customerId, sec.shippingId, sec.dateOrdered,
                                           sec.fishType, sec.quatity, sec.unitPrice,
                                           sec.totalAmount, sec.Balance, sec.paidFull, sec.orderId
                                           );

                  });
                  */

                for (int i = 0; i < 100; i++)
                {
                    
                        adgvResult.Rows.Add(i, "customername " +i,"Shipping ID " +i, new DateTime().Date,
                                            "Fish Type " +i, i*12, i*6,(i*12)*(i*6),i*5,false,"Order ID "+i);
                   
                }
                emptyGridView();
              
            }
        }

        private void btnExitChild_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void HideButtons()
        {
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnEdit.Visible = false;
        }
        public void ShowButtons()
        {
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnEdit.Visible = true;
        }

       private void AddItem(string table)
        {
            if (table == "customer")
            {

                var cust = new frmRegisterCustomer();
                cust.ShowDialog();
                populateDataGridView();
            }
            else if (table == "secretary")
            {
                var sec = new frmRegisterSecretary();
                sec.ShowDialog();
              
            }
            else if (table == "ceo")
            {

                var ceo = new frmRegisterCeo();
                ceo.ShowDialog();
               
            }
           
            else if (table == "fishtype")
            {
                var type = new frmCreateFishCannoeType("Fish Type");
                type.ShowDialog();
              

            }
            else if (table == "cannoetype")
            {
                var type = new frmCreateFishCannoeType("Cannoe Type");
                type.ShowDialog();
             

            }
            else if (table == "deptors")
            {
                var pay = new frmMakeCustomerPayment();
                pay.ShowDialog();
              

            }
            else if (table == "order")
            {
                var selectedRows = adgvResult.SelectedRows[0].Cells;
                var customerId = selectedRows[1].Value.ToString();
                var order = new frmCustomerOrder(customerId);
                order.ShowDialog();
               

            }
        }
        private void CheckInputIsNull(int range)
        {
            for (int i = 0; i <range; i++)
            {
                if (adgvResult.SelectedRows[0].Cells[i].Value == null)
                {
                    adgvResult.SelectedRows[0].Cells[i].Value = " ";
                }
            }
           
        }

        private void UpdateItem(string table)
        {
            if (table == "customer")
            {
                if (adgvResult.CurrentRow.Index >= 0)
                {
                    var selectedRowCells = adgvResult.SelectedRows[0].Cells;
                    var C = new CustomerDetail();
                    CheckInputIsNull(adgvResult.ColumnCount);
                    C.Name = selectedRowCells[1].Value.ToString();
                    C.Phone = selectedRowCells[2].Value.ToString();
                    C.Resident = selectedRowCells[3].Value.ToString();
                    var cust = new frmRegisterCustomer(C);
                    cust.ShowDialog();
                    populateDataGridView();
                }
               
               
            }

            else if (table == "fishtype")
            {
                if (adgvResult.CurrentRow.Index >= 0)
                {
                    var selectedRowCells = adgvResult.SelectedRows[0].Cells;


                    CheckInputIsNull(adgvResult.ColumnCount);

                    var name = selectedRowCells[1].Value.ToString();
                    var type = new frmCreateFishCannoeType("fish", name);
                    type.ShowDialog();
                    populateDataGridView();
                }

            }
            else if (table == "cannoetype")
            {
                if (adgvResult.CurrentRow.Index >= 0)
                {
                    var selectedRowCells = adgvResult.SelectedRows[0].Cells;
                    CheckInputIsNull(adgvResult.ColumnCount);
                    var name = selectedRowCells[1].Value.ToString();
                    var type = new frmCreateFishCannoeType("cannoe",name);
                    type.ShowDialog();
                    populateDataGridView();
                }
            }
            else if (table == "deptors")
            {

                // No update for Deptor Yet !!
                if (adgvResult.CurrentRow.Index >= 0)
                {
                    CheckInputIsNull(adgvResult.ColumnCount);
                    var pay = new frmMakeCustomerPayment();
                    pay.ShowDialog();
                   

                }
            }
            else if (table == "order")
            {
                // No Update for Order Yet !!
                if (adgvResult.CurrentRow.Index >= 0)
                {
                    CheckInputIsNull(adgvResult.ColumnCount);
                    var order = new frmCustomerOrder();
                    order.ShowDialog();
                }
            }
        }

        private void DeleteItem(string table)
        {
            if (table == "customer")
            {
                if (adgvResult.CurrentRow.Index !=-1)
                {
                    Console.WriteLine(dgvResult.CurrentRow);
                    CheckInputIsNull(dgvResult.ColumnCount);
                    var selectedRowCells = adgvResult.SelectedRows[0].Cells;

                    var C = new CustomerDetail();
                    C.Name = selectedRowCells[1].Value.ToString();
                    C.Phone = selectedRowCells[2].Value.ToString();
                    C.Resident = selectedRowCells[3].Value.ToString();
                    adgvResult.Rows.Remove(dgvResult.SelectedRows[0]);
                    MessageBox.Show("Deleted");
                }
                else {
                    MessageBox.Show("Cant Delete from an empty table");
                }

                
            }

            else if (table == "fishtype")
            {
                if (adgvResult.CurrentRow.Index >= 0)
                {
                }

                }
            else if (table == "cannoetype")
            {
                if (adgvResult.CurrentRow.Index >= 0)
                {
                }

            }
            else if (table == "deptors")
            {
                if (adgvResult.CurrentRow.Index >= 0)
                {
                }

            }
            else if (table == "order")
            {
                if (adgvResult.CurrentRow.Index >= 0)
                {
                }

            }
        }

        private void SearchItem(string table,string searchName)
        {
            if (table == "customer")
            {
                
               // dgvResult.DataSource = customer.GetCustomers(searchName);
            
               
                
            }
            else if (table == "secretary")
            {
               

            }
            else if (table == "ceo")
            {

                
            }

            else if (table == "fishtype")
            {
                

            }
            else if (table == "cannotype")
            {
                

            }
            else if (table == "Cpayment")
            {
                var a = Ctransaction.GetAllCustomerPayments(searchName); 
                adgvResult.AutoGenerateColumns = false;
                adgvResult.DataSource = customer.GetCustomers(searchName);
            
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItem(table);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UpdateItem(table);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteItem(table);
        }

        private void frmCrudDashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text.Trim() != null)
            {
                var text = txtSearch.Text;
                SearchItem("customer", text);
               
            }
           
            
        }

        private void btnPaySecretary_Click(object sender, EventArgs e)
        {
            var pay = new frmMakeSecretaryPayment();
            pay.ShowDialog();
        }

        private void adgvResult_SortStringChanged(object sender, AdvancedDataGridView.SortEventArgs e)
        {
            
        }

        private void adgvResult_FilterStringChanged(object sender, AdvancedDataGridView.FilterEventArgs e)
        {

        }
    }
}
