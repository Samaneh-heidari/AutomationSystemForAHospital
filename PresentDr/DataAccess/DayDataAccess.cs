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
    class DayDataAccess
    {
        static string computerName = System.Environment.MachineName;
        //string connString = "Data Source="+ computerName + ";Initial Catalog=DoctorDB;Integrated Security=True";
        string connString = "Data Source=PAYAMBARAN;Initial Catalog=DoctorDB;Persist Security Info=True;User ID=sa;Password=Payambaran@p";
       
        public DayDataAccess()
        {

        }

        private dsDay GetDayBySQL(string sql)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {
                dsDay ds = new dsDay();
                ds.EnforceConstraints = false;
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds.Day);

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

        public dsDay GetDayByID(System.Guid id)
        {
            dsDay ds = GetDayBySQL("SELECT * FROM dbo.vw_Day" +
                " WHERE dayId = '?'".Replace("?", id.ToString()));



            return ds;
        }

        public dsDay GetDayByDayID(string dayId)
        {
            return GetDayBySQL("Select * From vw_Day where dayId = '" + dayId + "'");
        }

        public dsDay GetDayByDayID(short p)
        {
            return GetDayBySQL("Select * From vw_Day where dayId = '" + p + "'");
        }

        public dsDay GetAllDays()
        {
            return GetDayBySQL("SELECT * FROM dbo.vw_Day");
        }
        
        public void InsertDay(dsDay Day)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.InsertCommand = GetInsertCommand(sqlConn);
                sqlDataAdapter.Update(Day.Day);

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
        }
        
        public void UpdateDay(dsDay Day)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.UpdateCommand = GetUpdateCommand(sqlConn);
                sqlDataAdapter.Update(Day.Day);

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
        }

        public void DeleteDay(dsDay Day)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = GetDeleteCommand(sqlConn);

                Day.Day[0].Delete();
                sqlDataAdapter.Update(Day.Day);

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
        }

        public void DeleteDayByID(System.Guid dayId)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {
                dsDay dsDay = GetDayByID(dayId);
                dsDay.Day[0].Delete();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = GetDeleteCommand(sqlConn);
                sqlDataAdapter.Update(dsDay.Day);
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

        }



        private SqlCommand GetUpdateCommand(SqlConnection conn)
        {
            SqlCommand updateCommand = new SqlCommand("dbo.spUpdateDay", conn);
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.Add(new SqlParameter("@dayId", SqlDbType.SmallInt));
            updateCommand.Parameters[0].SourceColumn = "dayId";

            updateCommand.Parameters.Add(new SqlParameter("@days", SqlDbType.NVarChar));
            updateCommand.Parameters[1].SourceColumn = "days";

            return updateCommand;
        }

        private SqlCommand GetDeleteCommand(SqlConnection conn)
        {
            SqlCommand delCommand = new SqlCommand("dbo.spDeleteDay", conn);
            delCommand.CommandType = CommandType.StoredProcedure;

            delCommand.Parameters.Add(new SqlParameter("@dayId", SqlDbType.SmallInt));
            delCommand.Parameters[0].SourceColumn = "dayId";

            return delCommand;
        }

        private SqlCommand GetInsertCommand(SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("dbo.spInsertDay", conn);
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.Add(new SqlParameter("@dayId", SqlDbType.SmallInt));
            insertCommand.Parameters[0].SourceColumn = "dayId";

            insertCommand.Parameters.Add(new SqlParameter("@days", SqlDbType.NVarChar));
            insertCommand.Parameters[1].SourceColumn = "days";

            return insertCommand;
        }

        
    }
}
