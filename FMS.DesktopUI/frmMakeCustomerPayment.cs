using FMS.Model;
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
    public partial class frmMakeCustomerPayment : Form
    {
        public frmMakeCustomerPayment()
        {
            InitializeComponent();
        }

        public frmMakeCustomerPayment(CustomerPayment pay)
        {
            InitializeComponent();

            txtOrderId.Text = "";
           
        }
    }
}
