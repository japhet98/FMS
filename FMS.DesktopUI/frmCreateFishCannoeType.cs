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
    public partial class frmCreateFishCannoeType : Form
    {
        public string Itemtype { get; set; }

        public frmCreateFishCannoeType()
        {
            InitializeComponent();
        }

        public frmCreateFishCannoeType(string type , string name)
        {
            InitializeComponent();
            Itemtype = type;
            lbltype.Text = type;
            if (type == "fish")
            {
                txtType.Text = name;
            }
            else if (type == "cannoe")
            {
                txtType.Text = name;
            }
        }
        public frmCreateFishCannoeType(string type)
        {
            InitializeComponent();
            Itemtype = type;
            lbltype.Text = type;

            if (type == "fish")
            {

            }
            else if(type == "cannoe")
            {

            }
            
        }

        private void type_Click(object sender, EventArgs e)
        {

        }
    }
}
