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
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }
        HistoryDAL cdal = new HistoryDAL();
        HistoryBLL p = new HistoryBLL();
        UserDAL dal = new UserDAL();


        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //show all users from the database
            DataTable dt = cdal.Select();
            dgvPatientsView.DataSource = dt;
        }
    }
}
