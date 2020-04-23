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
    public partial class Form1 : Form
    {
        Secretary Sec;
        CEO Ceo;
        private  string authentication { get; set; }
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
          HideMenusBeforLogin();
        }

        // User Login Consttructor
        public Form1(string user, Secretary sec,CEO ceo)
        {
            InitializeComponent();
            authentication = user;
            hideSubMenu();
            HideShowMenuAfterLogin(user);

            if (user == "secretary")
            {
                txtUsername.Text = sec.Name;
                Sec = sec;
                
                Console.WriteLine(sec);
            }
            if (user == "ceo")
            {
                txtUsername.Text = ceo.Name;
                Ceo = ceo;
                Console.WriteLine(ceo);
            }
          

        }
        public Form1(string user)
        {
            authentication = user;
            InitializeComponent();
            hideSubMenu();
            HideShowMenuAfterLogin(user);
        }

        public void HideShowMenuAfterLogin(string type)
        {
            // General Buttons
            btnCustomer.Visible = true;
            panelSubMenuCustomer.Visible = true;
         
            btnProfile.Visible = true;
            btnSettings.Visible = true;

            if (type == "ceo")
            {
                btnSecretary.Visible = true;
                btnCustomerPayment.Visible = false;
                btnCustomerOrder.Visible = false;
                btnCustomerAccount.Visible = false;
              
            }
            else if(type == "secretary")
            {
                btnSecretary.Visible = false;
               
                bntOthers.Visible = true;
                panelOthers.Visible = true;
            }
        }
      public void HideMenusBeforLogin()
        {
            btnCustomer.Visible = false;
            panelSubMenuCustomer.Visible = false;
          
            btnProfile.Visible = false;
            btnSecretary.Visible = false;
            btnSettings.Visible = false;
            bntOthers.Visible = false;
            panelOthers.Visible = false;
        }

        private void hideSubMenu()
        {
          
            panelSubMenuCustomer.Visible = false;
            panelOthers.Visible = false;
           
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

       

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSubMenuCustomer);
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        { 
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

      
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new frmLogin();
            login.Show();
        }

        

        private void bntOthers_Click(object sender, EventArgs e)
        {
            showSubMenu(panelOthers);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
           if(authentication == "ceo")
            {
                var ceo = new frmRegisterCeo(Ceo);
                ceo.ShowDialog();
               
               
            }
           else if(authentication == "secretary")
            {
                var sec = new frmRegisterSecretary(Sec);
                sec.ShowDialog();
            }
        }

        private void btnFishTypes_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCrudDashboard("fishtype"));
        }

        private void btnCannoeType_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCrudDashboard("cannoetype"));
        }

        private void btnCustomerAccount_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCrudDashboard("customer"));
        }

        private void btnCustomerOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCrudDashboard("order"));
        }

        private void btnCustomerPayment_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCrudDashboard("Cpayment"));
        }

        private void btnViewCustomerDeptor_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCrudDashboard("deptors"));
        }

        private void btnSecretary_Click(object sender, EventArgs e)
        {
            openChildForm(new frmCrudDashboard("secretary"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
        }
    }
}
