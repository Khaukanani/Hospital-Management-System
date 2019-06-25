using CTU_Care_Treatment.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTU_Care_Treatment.DAL
{
    class AdmittedDAL
    {
        //Creating STATIC String Method for DB Connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select method for Admission Module
        public DataTable Select()
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DataTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select data from database
                String sql = "SELECT * FROM tbl_Admssion";

                //Creating SQL Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the value from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
        #region Method to Insert Admssion in database
        public bool Insert(AdmittedBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert Patients into database
                String sql = "INSERT INTO tbl_Admssion (FileNumber, Id, Reason, DateAdmitted) VALUES (@FileNumber, @Id, @Reason, @DateAdmitted)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@FileNumber", p.FileNumber);
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.Parameters.AddWithValue("@Reason", p.Reason);
                cmd.Parameters.AddWithValue("@DateAdmitted", p.DateAdmitted);

                //Opening the Database connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of rows will be greater than 0 else it will be less than 0
                if (rows > 0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
        #endregion

        #region SEARCH Method for Patients Module
        public DataTable Search(string keywords)
        {
            //SQL Connection fro DB Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Creating DataTable to hold value from database
            DataTable dt = new DataTable();

            try
            {
                //SQL query to search product
                string sql = "SELECT * FROM tbl_Admssion WHERE FileNumber LIKE '%" + keywords + "%' OR Reason LIKE '%" + keywords + "%'";
                //Sql Command to execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQL Data Adapter to hold the data from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }
        #endregion
    }
}
