﻿using CTU_Care_Treatment.BLL;
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
    class DoctrosDAL
    {
        //Static String method for database connection
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region SELECT METHOD for Doctor 
        public DataTable Select()
        {
            //SQL Connection for Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //DataTble to hold the value from database and return it
            DataTable dt = new DataTable();

            try
            {
                //Write SQL Query t Select all the DAta from dAtabase
                string sql = "SELECT * FROM tbl_Doctors";

                //Creating SQL Command to execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Creting SQL Data Adapter to Store Data From Database Temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();
                //Passign the value from SQL Data Adapter to Data table
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
        #region INSERT Method to Add details fo Dealer or Customer
        public bool Insert(DoctorsBLL dc)
        {
            //Creting SQL Connection First
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create and Boolean value and set its default value to false
            bool isSuccess = false;

            try
            {
                //Write SQL Query to Insert Details of Doctors
                string sql = "INSERT INTO tbl_Doctors (Type, DrName, Email, Contact, Address, AddedDate, AddedBy) VALUES (@Type, @DrName, @Email, @Contact, @Address, @AddedDate, @AddedBy)";

                //SQl Command to Pass the values to query and execute
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the calues using Parameters
                cmd.Parameters.AddWithValue("@Type", dc.Type);
                cmd.Parameters.AddWithValue("@DrName", dc.DrName);
                cmd.Parameters.AddWithValue("@Email", dc.Email);
                cmd.Parameters.AddWithValue("@Contact", dc.Contact);
                cmd.Parameters.AddWithValue("@Address", dc.Address);
                cmd.Parameters.AddWithValue("@AddedDate", dc.AddedDate);
                cmd.Parameters.AddWithValue("@AddedBy", dc.AddedBy);

                //Open DAtabaseConnection
                conn.Open();

                //Int variable to check whether the query is executed successfully or not
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
        #region UPDATE method for Doctor Module
        public bool Update(DoctorsBLL dc)
        {
            //SQL Connection for Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Create Boolean variable and set its default value to false
            bool isSuccess = false;

            try
            {
                //SQL Query to update data in database
                string sql = "UPDATE tbl_Doctors SET Type=@Type, DrName=@DrName, Email=@Email, Contact=@Contact, Address=@Address, AddedDate=@AddedDate, AddedBy=@AddedBy WHERE DoctorsID=@DoctorsID";
                //Create SQL Command to pass the value in sql
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Passing the values through parameters
                cmd.Parameters.AddWithValue("@Type", dc.Type);
                cmd.Parameters.AddWithValue("@DrName", dc.DrName);
                cmd.Parameters.AddWithValue("@Email", dc.Email);
                cmd.Parameters.AddWithValue("@Contact", dc.Contact);
                cmd.Parameters.AddWithValue("@Address", dc.Address);
                cmd.Parameters.AddWithValue("@AddedDate", dc.AddedDate);
                cmd.Parameters.AddWithValue("@AddedBy", dc.AddedBy);
                cmd.Parameters.AddWithValue("@DoctorsID", dc.DoctorsID);

                //open the Database Connection
                conn.Open();

                //Int varialbe to check if the query executed successfully or not
                int rows = cmd.ExecuteNonQuery();
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
        #region DELETE Method for Dealer and Customer Module
        public bool Delete(DoctorsBLL dc)
        {
            //SQlConnection for Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create a Boolean Variable and set its default value to false
            bool isSuccess = false;

            try
            {
                //SQL Query to Delete Data from dAtabase
                string sql = "DELETE FROM tbl_Doctors WHERE DoctorsID=@DoctorsID";

                //SQL command to pass the value
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Passing the value
                cmd.Parameters.AddWithValue("@DoctorsID", dc.DoctorsID);

                //Open DB Connection
                conn.Open();
                //integer variable
                int rows = cmd.ExecuteNonQuery();
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
        #region SEARCH METHOD for Dealer and Customer Module
        public DataTable Search(string keyword)
        {
            //Create a Sql Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Creating a Data TAble and returnign its value
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Search Dealer or Customer Based in id, type and name
                string sql = "SELECT * FROM tbl_Doctors WHERE DoctorsID LIKE '%" + keyword + "%' OR Type LIKE '%" + keyword + "%' OR DrName LIKE '%" + keyword + "%'";

                //Sql Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Sql Dat Adapeter to hold tthe data from dataase temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open DAta Base Connection
                conn.Open();
                //Pass the value from adapter to data table
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
        #region METHOD TO SAERCH Doctor MODULE
        public DoctorsBLL SearchDealerCustomerForTransaction(string keyword)
        {
            //Create an object for DeaCustBLL class
            DoctorsBLL dc = new DoctorsBLL();

            //Create a DAtabase Connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            //Create a DAta Table to hold the value temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write a SQL Query to Search Dealer or Customer Based on Keywords
                string sql = "SELECT DrName, Email, Contact, Address from tbl_Doctors WHERE DoctorsID LIKE '%" + keyword + "%' OR DrName LIKE '%" + keyword + "%'";

                //Create a Sql Data Adapter to Execute the Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //Open the DAtabase Connection
                conn.Open();

                //Transfer the data from SqlData Adapter to DAta Table
                adapter.Fill(dt);

                //If we have values on dt we need to save it in dealerCustomer BLL
                if (dt.Rows.Count > 0)
                {
                    dc.DrName = dt.Rows[0]["DrName"].ToString();
                    dc.Email = dt.Rows[0]["Email"].ToString();
                    dc.Contact = dt.Rows[0]["Contact"].ToString();
                    dc.Address = dt.Rows[0]["Address"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database connection
                conn.Close();
            }

            return dc;
        }
        #endregion
        #region METHOD TO GET ID OF THE DEALER OR CUSTOMER BASED ON NAME
        public DoctorsBLL GetDeaCustIDFromName(string Name)
        {
            //First Create an Object of DeaCust BLL and REturn it
            DoctorsBLL dc = new DoctorsBLL();

            //SQL Conection here
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Data TAble to Holdthe data temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to Get id based on Name
                string sql = "SELECT id FROM tbl_dea_cust WHERE name='" + Name + "'";
                //Create the SQL Data Adapter to Execute the Query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                conn.Open();

                //Passing the CAlue from Adapter to DAtatable
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Pass the value from dt to DeaCustBLL dc
                    dc.DoctorsID = int.Parse(dt.Rows[0]["DoctorsID"].ToString());
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

            return dc;
        }
        #endregion
    }
}
