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
    public partial class frmRegisterSecretary : Form
    {
        public frmRegisterSecretary()
        {
            InitializeComponent();
           
        }
        public frmRegisterSecretary( Secretary sec)
        {
            InitializeComponent();
            txtName.Text = sec.Name;
            txtPhone.Text = sec.Phone;
            txtEmail.Text = sec.Email;
            txtResident.Text = sec.Residence;
            txtUsername.Text = sec.Username;
            txtPassword.Text = sec.Password;
     
            btnRegister.Visible = false;
           
        }

        private void ViewPassword()
        {
          

            if (chkViewPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.PasswordChar = ' ';
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.UseSystemPasswordChar = true;
              
            }

        }
        private void frmRegisterSecretary_Load(object sender, EventArgs e)
        {

           
        }

        private void btnExitChild_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkViewPassword_CheckedChanged(object sender, EventArgs e)
        {
            ViewPassword();
        }
    }
}
