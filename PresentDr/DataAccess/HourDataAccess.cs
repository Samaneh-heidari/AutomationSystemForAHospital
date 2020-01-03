using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PresentDr.Common;
using PresentDr.DataSet;
using System.Data.SqlClient;
using System.Data;

namespace PresentDr.DataAccess
{
    class HourDataAccess
    {
        static string computerName = System.Environment.MachineName;
        //string connString = "Data Source=" + computerName + ";Initial Catalog=DoctorDB;Integrated Security=True";
        string connString = "Data Source=PAYAMBARAN;Initial Catalog=DoctorDB;Persist Security Info=True;User ID=sa;Password=Payambaran@p";

        public HourDataAccess()
        {

        }

        private dsHour GetHourBySQL(string sql)
        {
            //SqlConnection sqlConn = new SqlConnection("Data Source=BST-PC;Initial Catalog=opRoomDB;Integrated Security=True");
            SqlConnection sqlConn = new SqlConnection(connString);

            try
            {
                dsHour ds = new dsHour();
                ds.EnforceConstraints = false;
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds.Hour);

                return ds;
            }
            catch (SqlException exp)
            {
                ExceptionHandler.InsertException(exp.Number, exp.Message, exp.Source, new FarsiDate().GetPersianDate(DateTime.Now, true));
                throw exp;

            }
            finally
            {
                sqlConn.Close();
            }
            return null;
        }
        public dsHour GetByDayID(System.Guid id)
        {
            dsHour ds = GetHourBySQL("SELECT * FROM dbo.vw_Hour" +
                " WHERE dayId = '?'".Replace("?", id.ToString()));

            return ds;
        }

        public dsHour GetByCardNum(int p) {
            dsHour ds = GetHourBySQL("SELECT * FROM dbo.vw_Hour" +
                " WHERE cardNum = '" + p + "'");

            return ds;
        }
        public dsHour GetByDayID(short id)
        {
            dsHour ds = GetHourBySQL("SELECT * FROM dbo.vw_Hour" +
                " WHERE dayId = '"+ id + "'");

            return ds;
        }
        public dsHour GetAllHour()
        {
            return GetHourBySQL("SELECT * FROM dbo.vw_Hour");
        }

    }
}
