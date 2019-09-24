using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VideoRentalManagementSystemGurpreet
{
   public abstract class db {
        //record method is used to pass the value to the database by using the query of the sql statements
        public void record(String qry) {

        }
    }
    //this class is used to inherit the db class for performing the whole task like insert delete or update and search 
    public class DataManagement : db
    {
        SqlConnection sqlConn;
        String connection_String = "Data Source=DESKTOP-HKD1BEO\\SQLEXPRESS;Initial Catalog=GurpreetVideoSystem;Integrated Security=True";
        SqlCommand sqlCmd;
        SqlDataReader sqlDatareader;

        // this code is used to in the details of a prticuar query from the table using the sql statement with the help of where clause 
        public DataTable getRecord(String qry)
        {
            DataTable tbl = new DataTable();


            sqlConn = new SqlConnection(connection_String);

            sqlConn.Open();
            sqlCmd = new SqlCommand(qry, sqlConn);

            sqlDatareader = sqlCmd.ExecuteReader();

            tbl.Load(sqlDatareader);

            sqlConn.Close();

            return tbl;
        }

        //this statement is related to insert delete update query that is the main statement of any database record 
        public void record(String sqlStatement) {

            sqlConn = new SqlConnection(connection_String);
            sqlConn.Open();
            

            sqlCmd = new SqlCommand(sqlStatement, sqlConn);
            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();

        }

        // code for count the no of entries of the specific query by using the where clause 
        public int count(int id ,String tbl,String colum) {

            String sql = "select * from " + tbl + " where " + colum + "=" + id +" and dateofReturn='Book'";
            DataTable tbl1 = new DataTable();
            tbl1 = getRecord(sql);
            return tbl1.Rows.Count;
        }

        public int charges(String date,int charges) {

            DateTime start = Convert.ToDateTime(date.ToString());
            DateTime end = DateTime.Now;



            TimeSpan difference = end - start; //create TimeSpan object

            int days = difference.Days;

            if (difference.Days == 0)
            {
                days = 1;
            }

            return days * charges;

        }


        public String reset() {
            return "";
        }
    }
}
