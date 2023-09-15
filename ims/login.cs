using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ims
{
    public partial class login : Sample
    {
        public login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTXT.Text == "") { nameErrorLabel.Visible = true; } else { nameErrorLabel.Visible = false; }
            if (passwordTXT.Text == "") { passErrorLabel.Visible = true; } else { passErrorLabel.Visible = false; }
            if (nameErrorLabel.Visible || passErrorLabel.Visible)
            {
                MainClass.ShowMSG("Fields with * are mandatory", "Stop", "Error");      //error is the type of message
            }
            else
            {
                if (retrieval.getUserDetails(usernameTXT.Text, passwordTXT.Text))
                {
                    HomeScreen hm = new HomeScreen();
                    MainClass.showWindow(hm, this, MDI.ActiveForm);
                }
                else
                {

                }                
            }                        
        }

        private void usernameTXT_TextChanged(object sender, EventArgs e)
        {
            if (usernameTXT.Text == "") { nameErrorLabel.Visible = true; } else { nameErrorLabel.Visible = false; }
        }

        private void passwordTXT_TextChanged(object sender, EventArgs e)
        {
            if (passwordTXT.Text == "") { passErrorLabel.Visible = true; } else { passErrorLabel.Visible = false; }

        }
    }
}
