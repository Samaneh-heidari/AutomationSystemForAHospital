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
    class TempDataAccess
    {

        static string computerName = System.Environment.MachineName;
        string connString = "Data Source="+ computerName + ";Initial Catalog=DoctorDB;Integrated Security=True";
        //string connString = "Data Source=PAYAMBARAN;Initial Catalog=DoctorDB;Persist Security Info=True;User ID=sa;Password=Payambaran@p";

        public TempDataAccess()
        {

        }

        private dsTemp GetTempBySQL(string sql)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {
                //dsDay ds = new dsDay();
                dsTemp ds = new dsTemp();
                ds.EnforceConstraints = false;
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds.Temp_Table);

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

        public dsTemp GetTempByDrID(int id)
        {
            return GetTempBySQL("SELECT * FROM dbo.vw_Temp where dr_id = '" + id.ToString() + "'");

        }

        public dsTemp GetAllTemp()
        {
            return GetTempBySQL("SELECT * FROM dbo.vw_Temp");
        }


        public void InsertTemp(dsTemp Temp)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.InsertCommand = GetInsertCommand(sqlConn);
                sqlDataAdapter.Update(Temp.Temp_Table);

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

        public void UpdateTemp(dsTemp Temp)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.UpdateCommand = GetUpdateCommand(sqlConn);
                sqlDataAdapter.Update(Temp.Temp_Table);

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

        public void DeleteTemp(dsTemp Temp)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = GetDeleteCommand(sqlConn);

                Temp.Temp_Table[0].Delete();
                sqlDataAdapter.Update(Temp.Temp_Table);

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

        public void DeleteDayByDrID(int dr_id)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {
                dsTemp dsTemp = GetTempByDrID(dr_id);
                dsTemp.Temp_Table[0].Delete();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = GetDeleteCommand(sqlConn);
                sqlDataAdapter.Update(dsTemp.Temp_Table);
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
            SqlCommand updateCommand = new SqlCommand("dbo.spUpdateTemp", conn);
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.Add(new SqlParameter("@dr_id", SqlDbType.SmallInt));
            updateCommand.Parameters[0].SourceColumn = "dr_id";

            updateCommand.Parameters.Add(new SqlParameter("@dayHour", SqlDbType.NVarChar));
            updateCommand.Parameters[1].SourceColumn = "dayHour";

            return updateCommand;
        }

        private SqlCommand GetDeleteCommand(SqlConnection conn)
        {
            SqlCommand delCommand = new SqlCommand("dbo.spDeleteTemp", conn);
            delCommand.CommandType = CommandType.StoredProcedure;

            delCommand.Parameters.Add(new SqlParameter("@dr_id", SqlDbType.SmallInt));
            delCommand.Parameters[0].SourceColumn = "dr_id";

            return delCommand;
        }

        private SqlCommand GetInsertCommand(SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("dbo.spInsertTemp", conn);
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.Add(new SqlParameter("@dr_id", SqlDbType.SmallInt));
            insertCommand.Parameters[0].SourceColumn = "dr_id";

            insertCommand.Parameters.Add(new SqlParameter("@dayHour", SqlDbType.NVarChar));
            insertCommand.Parameters[1].SourceColumn = "dayHour";

            return insertCommand;
        }


    }
}


