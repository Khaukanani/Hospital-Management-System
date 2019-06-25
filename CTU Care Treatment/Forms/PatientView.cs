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
    public partial class PatientView : Form
    {
        public PatientView()
        {
            InitializeComponent();
        }
        PatientsDAL cdal = new PatientsDAL();
        PatientsBLL p = new PatientsBLL();
        UserDAL dal = new UserDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatientView_Load(object sender, EventArgs e)
        {
            DataTable dt = cdal.Select();
            dgvPatientsView.DataSource = dt;
        }

        private void dgvPatientsView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the index of particular row
            int rowIndex = e.RowIndex;
            txtName.Text = dgvPatientsView.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvPatientsView.Rows[rowIndex].Cells[2].Value.ToString();
            txtIdNumber.Text = dgvPatientsView.Rows[rowIndex].Cells[3].Value.ToString();
            txtGender.Text = dgvPatientsView.Rows[rowIndex].Cells[4].Value.ToString();
            txtMedicalAid.Text = dgvPatientsView.Rows[rowIndex].Cells[5].Value.ToString();
            txtAddress.Text = dgvPatientsView.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyword from Text box
            string keywords = txtSearch.Text;

            //Chec if the keywords has value or not
            if (keywords != null)
            {
                //Show user based on keywords
                DataTable dt = cdal.Search(keywords);
                dgvPatientsView.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = cdal.Select();
                dgvPatientsView.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
