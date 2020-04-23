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
    public partial class frmRegisterCeo : Form
    {
        public frmRegisterCeo()
        {
            InitializeComponent();
            btnUpdate.Visible = false;
           
        }

        public frmRegisterCeo( CEO ceo)
        {
            InitializeComponent();
            txtName.Text = ceo.Name;
            txtPhone.Text = ceo.Phone;
            txtUsername.Text = ceo.Username;
            txtPassword.Text = ceo.Password;
            btnRegister.Visible = false;
           
        }

        private void ViewPassword()
        {
            if (chkViewPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
            }

        }
        private void frmRegisterCeo_Load(object sender, EventArgs e)
        {
          
        }

        private void btnExitChild_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            

        }

        private void chkViewPassword_CheckedChanged(object sender, EventArgs e)
        {
            ViewPassword();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
