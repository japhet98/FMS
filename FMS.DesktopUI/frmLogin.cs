using FMS.DesktopUI.FMS.Valiation;
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
    public partial class frmLogin : Form
    {
        Validation validation;
        public string User { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(string AccountType)
        {
            InitializeComponent();
            User = AccountType;
            lblAccountType.Text = AccountType;

        }


        // Register Update Secretary and CEO


        //Validat Login
        private bool checkLogin(string username,string password)
        {
            var Username = txtusername.Text.Trim().ToLower();
            var Password = txtpassword.Text.Trim().ToLower();

            var status = false;

            if(username.ToLower() == Username && password.ToLower() == Password)
            {
                status = true;
            }
            return status;

        }
    

        private void LogInUser()
        {
            /// Check if CEO Login
            if(chkCeo.Checked==true)
            {
                var ceo = new CEO();
                ceo.CeoId= 1;
                ceo.Name = "John Mensah";
                ceo.Phone = "0232332028";
                ceo.Username = "Kofi";
                ceo.Password = "123456789";

                //Check if Login is succesfull
                if (checkLogin(ceo.Username, ceo.Password) == true)
                {
                  
                    MessageBox.Show("Login Succesful");
                    var dashboard = new Form1("ceo", null, ceo);
                    this.Hide();
                    dashboard.Show();

                }
                    else
                    {
                        MessageBox.Show("Login Failed!! Invalid username or password ");
                    }
                  
                }
             
            else
            {
              var sec = new  Secretary();
                sec.SecretaryId = 1;
                sec.Name = "Japhet Kuntu Blankson";
                sec.Phone = "02452342433";
                sec.Residence = "Elmina";
                sec.Username = "Joe";
                sec.Password = "123456789";

                //Check if Login is succesfull
                if (checkLogin(sec.Username, sec.Password) == true)
                {

                    MessageBox.Show("Login Succesful");
                    var dashboard = new Form1("secretary", sec, null);
                    this.Hide();
                    dashboard.Show();

                }
                else
                {
                    MessageBox.Show("Login Failed!! Invalid username or password ");
                }
            }

            txtusername.Text = "";
            txtpassword.Text = "";

        }

        private void btnExitChild_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInput();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LogInUser();
        }

        private void clearInput()
        {
            txtusername.Text = "";
            txtpassword.Text = ""; 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           this.FormBorderStyle = FormBorderStyle.None;
        }
    }
} 
