using CTU_Care_Treatment.BLL;
using CTU_Care_Treatment.BLL.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTU_Care_Treatment.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        LoginBLL l = new LoginBLL();
        LoginDAL dal = new LoginDAL();
        public static string loggedIn;

        private void pboxClose_Click(object sender, EventArgs e)
        {
            //Code to close this form
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            //Checking the login credentials
            bool sucess = dal.loginCheck(l);
            if (sucess == true)
            {
                //Login Successfull
                MessageBox.Show("Login Successful.");
                loggedIn = l.username;
                //Need to open Respective Forms based on User Type
                switch (l.user_type)
                {
                    case "Admin":
                        {
                            //Display Admin Dashboard
                            AdminDashboad admin = new AdminDashboad();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            //Display User Dashboard
                            UserDashboard user = new UserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            //Display an error message
                            MessageBox.Show("Invalid User Type.");
                        }
                        break;
                }
            }
            else
            {
                //login Failed
                MessageBox.Show("Login Failed. Try Again");
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();
            l.user_type = cmbUserType.Text.Trim();

            //Checking the login credentials
            bool sucess = dal.loginCheck(l);
            if (sucess == true)
            {
                //Login Successfull
                MessageBox.Show("Login Successful.");
                loggedIn = l.username;
                //Need to open Respective Forms based on User Type
                switch (l.user_type)
                {
                    case "Admin":
                        {
                            //Display Admin Dashboard
                            AdminDashboad admin = new AdminDashboad();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            //Display User Dashboard
                            UserDashboard user = new UserDashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;

                    default:
                        {
                            //Display an error message
                            MessageBox.Show("Invalid User Type.");
                        }
                        break;
                }
            }
            else
            {
                //login Failed
                MessageBox.Show("Login Failed. Try Again");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
