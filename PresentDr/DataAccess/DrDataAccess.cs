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
    class DrDataAccess
    {
        static string computerName = System.Environment.MachineName;
        //string connString = "Data Source=" + computerName + ";Initial Catalog=DoctorDB;Integrated Security=True";
        string connString = "Data Source=PAYAMBARAN;Initial Catalog=DoctorDB;Persist Security Info=True;User ID=sa;Password=Payambaran@p";

        public DrDataAccess()
        {

        }



        private dsDr GetDrBySQL(string sql)
        {
            //SqlConnection sqlConn = new SqlConnection("Data Source=BST-PC;Initial Catalog=opRoomDB;Integrated Security=True");
            SqlConnection sqlConn = new SqlConnection(connString);

            try
            {
                dsDr ds = new dsDr();
                ds.EnforceConstraints = false;
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds.Dr);

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

        private dsDoctor GetDoctorBySQL(string sql)
        {
            //SqlConnection sqlConn = new SqlConnection("Data Source=BST-PC;Initial Catalog=opRoomDB;Integrated Security=True");
            SqlConnection sqlConn = new SqlConnection(connString);

            try
            {
                dsDoctor ds = new dsDoctor();
                ds.EnforceConstraints = false;
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds.Doctor);

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

        public dsDr GetDrByID(System.Guid id)
        {
            dsDr ds = GetDrBySQL("SELECT * FROM dbo.vw_Dr" +
                " WHERE id = '?'".Replace("?", id.ToString()));



            return ds;
        }
        public dsDoctor GetDoctorByCardNum(int p){
            return GetDoctorBySQL("SELECT * FROM dbo.vw_Doctor where cardNum = '" + p + "'");
        }

        public dsDr GetDrByCardNum(int p)
        {
            return GetDrBySQL("SELECT * FROM dbo.vw_Dr where cardNum = '" + p + "'");
        }

        public dsDr GetAllDr()
        {
            return GetDrBySQL("SELECT * FROM dbo.vw_Dr");
        }

        public dsDr GetDrByKINDVKH()
        {
            return GetDrBySQL("SELECT * FROM dbo.vw_Dr where KINDVKH = '1'");
        }



        public void InsertDr(dsDr ds)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.InsertCommand = GetInsertCommand(sqlConn);
                sqlDataAdapter.Update(ds.Dr);
                Console.WriteLine("hey");

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
        public void UpdateDr(dsDr ds)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.UpdateCommand = GetUpdateCommand(sqlConn);
                sqlDataAdapter.Update(ds.Dr);

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

        public void DeleteDr(dsDr ds)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = GetDeleteCommand(sqlConn);

                ds.Dr[0].Delete();
                sqlDataAdapter.Update(ds.Dr);

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

        public void DeleteDrByID(System.Guid id)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {
                dsDr dsDr = GetDrByID(id);
                dsDr.Dr[0].Delete();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = GetDeleteCommand(sqlConn);
                sqlDataAdapter.Update(dsDr.Dr);
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
            SqlCommand updateCommand = new SqlCommand("dbo.spUpdateDr", conn);
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.Add(new SqlParameter("@cardNum", SqlDbType.Int));
            updateCommand.Parameters[0].SourceColumn = "cardNum";

            updateCommand.Parameters.Add(new SqlParameter("@fName", SqlDbType.NVarChar));
            updateCommand.Parameters[1].SourceColumn = "fName";

            updateCommand.Parameters.Add(new SqlParameter("@lName", SqlDbType.NVarChar));
            updateCommand.Parameters[2].SourceColumn = "lName";

            updateCommand.Parameters.Add(new SqlParameter("@biography", SqlDbType.NText));
            updateCommand.Parameters[3].SourceColumn = "biography";

            updateCommand.Parameters.Add(new SqlParameter("@shNP", SqlDbType.Int));
            updateCommand.Parameters[4].SourceColumn = "shNP";

            updateCommand.Parameters.Add(new SqlParameter("@specialtyId", SqlDbType.UniqueIdentifier));
            updateCommand.Parameters[5].SourceColumn = "specialtyId";

            updateCommand.Parameters.Add(new SqlParameter("@KINDVKH", SqlDbType.SmallInt));
            updateCommand.Parameters[6].SourceColumn = "KINDVKH";

            updateCommand.Parameters.Add(new SqlParameter("@pic", SqlDbType.NVarChar));
            updateCommand.Parameters[7].SourceColumn = "pic";

            updateCommand.Parameters.Add(new SqlParameter("@enName", SqlDbType.NVarChar));
            updateCommand.Parameters[8].SourceColumn = "enName";

            return updateCommand;
        }

        private SqlCommand GetDeleteCommand(SqlConnection conn)
        {
            SqlCommand delCommand = new SqlCommand("dbo.spDeleteDr", conn);
            delCommand.CommandType = CommandType.StoredProcedure;

            delCommand.Parameters.Add(new SqlParameter("@cardNum", SqlDbType.Int));
            delCommand.Parameters[0].SourceColumn = "cardNum";

            return delCommand;
        }

        private SqlCommand GetInsertCommand(SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("dbo.spInsertDr", conn);
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.Add(new SqlParameter("@cardNum", SqlDbType.Int));
            insertCommand.Parameters[0].SourceColumn = "cardNum";

            insertCommand.Parameters.Add(new SqlParameter("@fName", SqlDbType.NVarChar));
            insertCommand.Parameters[1].SourceColumn = "fName";

            insertCommand.Parameters.Add(new SqlParameter("@lName", SqlDbType.NVarChar));
            insertCommand.Parameters[2].SourceColumn = "lName";

            insertCommand.Parameters.Add(new SqlParameter("@biography", SqlDbType.NText));
            insertCommand.Parameters[3].SourceColumn = "biography";

            insertCommand.Parameters.Add(new SqlParameter("@shNP", SqlDbType.Int));
            insertCommand.Parameters[4].SourceColumn = "shNP";
                        
            insertCommand.Parameters.Add(new SqlParameter("@specialtyId", SqlDbType.UniqueIdentifier));
            insertCommand.Parameters[5].SourceColumn = "specialtyId";

            insertCommand.Parameters.Add(new SqlParameter("@KINDVKH", SqlDbType.SmallInt));
            insertCommand.Parameters[6].SourceColumn = "KINDVKH";

            insertCommand.Parameters.Add(new SqlParameter("@pic", SqlDbType.NVarChar));
            insertCommand.Parameters[7].SourceColumn = "pic";

            insertCommand.Parameters.Add(new SqlParameter("@enName", SqlDbType.NVarChar));
            insertCommand.Parameters[8].SourceColumn = "enName";

            
            return insertCommand;
        }

        
    }
}
