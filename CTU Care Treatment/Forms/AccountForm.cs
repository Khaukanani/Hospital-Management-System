using CTU_Care_Treatment.BLL;
using CTU_Care_Treatment.DAL;
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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }
        AccountBLL dc = new AccountBLL();
        AccountDAL dcDal = new AccountDAL();

        UserDAL uDal = new UserDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Clear()
        {
            txtFileNumber.Text = "";
            txtUserID.Text = "";
            txtPrescripitonID.Text = "";
            txtAccommodationFee.Text = "";
            txtPrescriptionFee.Text = "";
            //txtSearch.Text = "";
            txtAccommodationFee.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Get the Values from Form
            dc.FileNumber = int.Parse(txtFileNumber.Text);
            dc.Id = int.Parse(txtUserID.Text);
            dc.PrescriptionID = int.Parse(txtPrescripitonID.Text);
            dc.AdmissionFee = decimal.Parse(txtAdmissionFee.Text);
            dc.AccommodationFee = decimal.Parse(txtAccommodationFee.Text);
            dc.PrescriptionFee = decimal.Parse(txtPrescriptionFee.Text);
            dc.Total = dc.AdmissionFee + dc.AccommodationFee + dc.PrescriptionFee;
            dc.Date = DateTime.Now;
            //Getting the ID to Logged in user and passign its value in dealer or cutomer module
            string loggedUsr = Login.loggedIn;
            UserBLL usr = uDal.GetIDFromUsername(loggedUsr);
            dc.Id = usr.Id;

            //Creating boolean variable to check whether the dealer or cutomer is added or not
            bool success = dcDal.Insert(dc);

            if (success == true)
            {
                //Dealer or Cutomer inserted successfully 
                MessageBox.Show("Successfully");
                Clear();
                //Refresh Data Grid View
                DataTable dt = dcDal.Select();
                dgvPatientsView.DataSource = dt;
            }
            else
            {
                //failed to insert dealer or customer
            }
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            DataTable dt = dcDal.Select();
            dgvPatientsView.DataSource = dt;
        }

        private void dgvPatientsView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int variable to get the identityof row clicked
            int rowIndex = e.RowIndex;

            txtFileNumber.Text = dgvPatientsView.Rows[rowIndex].Cells[0].Value.ToString();
            txtUserID.Text = dgvPatientsView.Rows[rowIndex].Cells[1].Value.ToString();
            txtPrescripitonID.Text = dgvPatientsView.Rows[rowIndex].Cells[2].Value.ToString();
            txtAdmissionFee.Text = dgvPatientsView.Rows[rowIndex].Cells[3].Value.ToString();
            txtAccommodationFee.Text = dgvPatientsView.Rows[rowIndex].Cells[4].Value.ToString();
            txtPrescriptionFee.Text = dgvPatientsView.Rows[rowIndex].Cells[5].Value.ToString();
            txtTotal.Text = dgvPatientsView.Rows[rowIndex].Cells[6].Value.ToString();
            txtDate.Text = dgvPatientsView.Rows[rowIndex].Cells[7].Value.ToString();
    
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get the keyowrd from text box
            string keyword = txtSearch.Text;

            if (keyword != null)
            {
                //Search the Dealer or Customer
                DataTable dt = dcDal.Search(keyword);
                dgvPatientsView.DataSource = dt;
            }
            else
            {
                //Show all the Dealer or Customer
                DataTable dt = dcDal.Select();
                dgvPatientsView.DataSource = dt;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var myPaintArgs = new PaintEventArgs
       (
           e.Graphics,
           new Rectangle(new Point(0, 0), this.Size)
       );

            this.InvokePaint(dgvPatientsView, myPaintArgs);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {

        }
    }
 
}
