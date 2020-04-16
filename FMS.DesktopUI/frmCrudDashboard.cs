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
                dgvResult.DataSource = customer.GetCustomers();
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

            if (table == "customer")
            {
                var a = customer.GetCustomers();
                Console.Write(a);
                dgvResult.Columns.Add("sn", "SN");
                dgvResult.Columns.Add("Name", "NAME");

                //dgvResult.DataBindings.Add()

                dgvResult.DataSource = customer.GetCustomers();
               
            }
            else if(table == "secretary")
            {
              
                dgvResult.DataSource = sec.GetSecretarys();
                btnEdit.Visible = false;
            }
            else if(table == "ceo")
            {
               
                dgvResult.DataSource = ceo.GetCeo();
            }
            else if(table == "deptors")
            {
               HideButtons();
                btnAdd.Visible = true;
                btnAdd.Text = "Make Payment";
                dgvResult.DataSource = Ctransaction.GetCustomersWithDept();
                
            }
            else if(table == "Cpayment")
            {
                HideButtons();
               
                dgvResult.DataSource = Ctransaction.GetAllCustomerPayments();
            }
            else if(table == "fishtype")
            {
               
                dgvResult.DataSource = fishtype.GetAddFishTypes();
            }
            else if(table == "cannoetype")
            {
               
                dgvResult.DataSource = cannoetype.GetCannoes();
            }
            else if (table == "order")
            {

                dgvResult.DataSource = Ctransaction.GetAllCustomerOrder();
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
                var type = new frmCreateFishCannoeType();
                type.ShowDialog();
               
            }
            else if (table == "cannotype")
            {
                var type = new frmCreateFishCannoeType();
                type.ShowDialog();

            }
            else if (table == "deptors")
            {
                var pay = new frmMakeCustomerPayment();
                pay.ShowDialog();

            }
            else if (table == "order")
            {
                var order = new frmCustomerOrder();
                order.ShowDialog();

            }
        }

        private void UpdateItem(string table)
        {
            if (table == "customer")
            {
                var selectedRowCells =
                dgvResult.SelectedRows[0].Cells;
                var cust = new frmRegisterCustomer();
                cust.ShowDialog();
            }

            else if (table == "fishtype")
            {
                var type = new frmCreateFishCannoeType();
                type.ShowDialog();

            }
            else if (table == "cannotype")
            {
                var type = new frmCreateFishCannoeType();
                type.ShowDialog();

            }
            else if (table == "deptors")
            {
                var pay = new frmMakeCustomerPayment();
                pay.ShowDialog();

            }
            else if (table == "order")
            {
                var order = new frmCustomerOrder();
                order.ShowDialog();

            }
        }

        private void SearchItem(string table,string searchName)
        {
            if (table == "customer")
            {
                var a = customer.GetCustomers(searchName);
                Console.Write(a);
                dgvResult.AutoGenerateColumns = false;
               
                dgvResult.DataSource = customer.GetCustomers(searchName);
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
                dgvResult.AutoGenerateColumns = false;
                dgvResult.DataSource = customer.GetCustomers(searchName);

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

        }

        private void frmCrudDashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var text = txtSearch.Text;
            SearchItem("customer", text);
        }

        /*
        var selectedRowCells =
				dgvContactList.SelectedRows[0].Cells;

			var contactId = selectedRowCells[0].Value;
			var firstName = selectedRowCells[1].Value.ToString();
			var lastName = selectedRowCells[2].Value.ToString(); ;
			var otherName = selectedRowCells[3].Value.ToString(); ;
			var phoneNumber = selectedRowCells[4].Value.ToString(); ;
			var group = selectedRowCells[5].Value;
        */

    }
}
