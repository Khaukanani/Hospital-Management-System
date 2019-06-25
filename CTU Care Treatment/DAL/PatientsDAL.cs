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
    class PatientsDAL
    {
        //Creating STATIC String Method for DB Connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select method for Product Module
        public DataTable Select()
        {
            //Create Sql Connection to connect Databaes
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DataTable to hold the data from database
            DataTable dt = new DataTable();

            try
            {
                //Writing the Query to Select data from database
                String sql = "SELECT * FROM tbl_Patients";

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
        #region Method to Insert Patients in database
        public bool Insert(PatientsBLL p)
        {
            //Creating Boolean Variable and set its default value to false
            bool isSuccess = false;

            //Sql Connection for Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to insert Patients into database
                String sql = "INSERT INTO tbl_Patients (FirstName, LastName, IdNumber, Gender, MedicalAidNumber, AddedDate, AddedBy, Email, Address, Description ) VALUES (@FirstName, @LastName, @IdNumber, @Gender, @MedicalAidNumber, @AddedDate, @AddedBy, @Email, @Address, @Description)";

                //Creating SQL Command to pass the values
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
                cmd.Parameters.AddWithValue("@LastName", p.LastName);
                cmd.Parameters.AddWithValue("@IdNumber", p.IdNumber);
                cmd.Parameters.AddWithValue("@Gender", p.Gender);
                cmd.Parameters.AddWithValue("@MedicalAidNumber", p.Contact);
                cmd.Parameters.AddWithValue("@AddedDate", p.AddedDate);
                cmd.Parameters.AddWithValue("@AddedBy", p.AddedBy);
                cmd.Parameters.AddWithValue("@Email", p.Email);
                cmd.Parameters.AddWithValue("@Address", p.Address);
                cmd.Parameters.AddWithValue("@Description", p.Description);

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
        #region Method to Update data in Database
        public bool Update(PatientsBLL p)
        {
            //create a boolean variable and set its initial value to false
            bool isSuccess = false;

            //Create SQL Connection for Database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL Query to Update Data in dAtabase
                String sql = "UPDATE tbl_Patients SET FirstName=@FirstName, LastName=@LastName, IdNumber=@IdNumber, Gender=@Gender, MedicalAidNumber=@MedicalAidNumber, AddedDate=@AddedDate, AddedBy=@AddedBy, Email=@Email, Address=@Address,Description=@Description WHERE FileNumber=@FileNumber ";

                //Create SQL Cmmand to pass the value to query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the values using parameters and cmd
                //Passign the values through parameters
                cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
                cmd.Parameters.AddWithValue("@LastName", p.LastName);
                cmd.Parameters.AddWithValue("@IdNumber", p.IdNumber);
                cmd.Parameters.AddWithValue("@Gender", p.Gender);
                cmd.Parameters.AddWithValue("@MedicalAidNumber", p.Contact);
                cmd.Parameters.AddWithValue("@AddedDate", p.AddedDate);
                cmd.Parameters.AddWithValue("@AddedBy", p.AddedBy);
                cmd.Parameters.AddWithValue("@Email", p.Email);
                cmd.Parameters.AddWithValue("@Address", p.Address);
                cmd.Parameters.AddWithValue("@FileNumber", p.FileNumber);
                cmd.Parameters.AddWithValue("@Description", p.Description);

                //Open the Database connection
                conn.Open();

                //Create Int Variable to check if the query is executed successfully or not
                int rows = cmd.ExecuteNonQuery();

                //if the query is executed successfully then the value of rows will be greater than 0 else it will be less than zero
                if (rows > 0)
                {
                    //Query ExecutedSuccessfully
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
        #region Method to Delete Data from Database
        public bool Delete(PatientsBLL p)
        {
            //Create Boolean Variable and Set its default value to false
            bool isSuccess = false;

            //SQL Connection for DB connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //Write Query data from Database
                String sql = "DELETE FROM tbl_Patients WHERE FileNumber=@FileNumber";

                //Sql Command to Pass the Value
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the values using cmd
                cmd.Parameters.AddWithValue("@FileNumber", p.FileNumber);

                //Open Database Connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //If the query is executed successfullly then the value of rows will be greated than 0 else it will be less than 0
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
                string sql = "SELECT * FROM tbl_Patients WHERE FileNumber LIKE '%" + keywords + "%' OR FirstName LIKE '%" + keywords + "%' OR IdNumber LIKE '%" + keywords + "%'";
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
