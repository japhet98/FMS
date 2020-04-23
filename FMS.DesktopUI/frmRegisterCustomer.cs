using FMS.Model;
using FMS.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMS.DesktopUI
{
    public partial class frmRegisterCustomer : Form
    {
        CustomerController Customer;
        public frmRegisterCustomer()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
            Customer = new CustomerController();
        }

        public frmRegisterCustomer(Customer customer)
        {
            InitializeComponent();
            btnRegister.Visible = false;
            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone;
            txtResident.Text = customer.Resident;
            Customer = new CustomerController();
        }

        private void btnExitChild_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check if Customer Already Exist;Customer.IfValidCustomer(txtName.Text);

            var IsValid = false;
       
            if(IsValid == true)
            {
              

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text ="";
            txtPhone.Text = "";
            txtResident.Text = "";
            txtIsActive.Text = "";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {


        }
    }
}
