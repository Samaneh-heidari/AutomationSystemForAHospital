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
    class SpecialtyDataAccess
    {
        static string computerName = System.Environment.MachineName;
       // string connString = "Data Source="+ computerName + ";Initial Catalog=DoctorDB;Integrated Security=True";
        string connString = "Data Source=PAYAMBARAN;Initial Catalog=DoctorDB;Persist Security Info=True;User ID=sa;Password=Payambaran@p";

        public SpecialtyDataAccess()
        {

        }

        private dsSpecialty GetSpecialtyBySQL(string sql)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {
                dsSpecialty ds = new dsSpecialty();
                ds.EnforceConstraints = false;
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(ds.Specialty);

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
        public dsSpecialty GetSpecialtyByID(System.Guid id)
        {
            dsSpecialty ds = GetSpecialtyBySQL("SELECT * FROM dbo.vw_Specialty" +
                " WHERE specialtyId = '?'".Replace("?", id.ToString()));



            return ds;
        }

        public dsSpecialty GetSpecialtyBySpecialtyID(Guid specialtyId)
        {
            return GetSpecialtyBySQL("Select * From vw_Specialty where specialtyId = '" + specialtyId.ToString() + "'");
        }

        public dsSpecialty GetAllSpecialty()
        {
            return GetSpecialtyBySQL("SELECT * FROM dbo.vw_Specialty");
        }





        public void InsertSpecialty(dsSpecialty Specialty)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.InsertCommand = GetInsertCommand(sqlConn);
                sqlDataAdapter.Update(Specialty.Specialty);

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
        public void UpdateSpecialty(dsSpecialty Specialty)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.UpdateCommand = GetUpdateCommand(sqlConn);
                sqlDataAdapter.Update(Specialty.Specialty);

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

        public void DeleteSpecialty(dsSpecialty Specialty)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionManager.Instance.ConnectionString);
            try
            {

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = GetDeleteCommand(sqlConn);

                Specialty.Specialty[0].Delete();
                sqlDataAdapter.Update(Specialty.Specialty);

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

        public void DeleteSpecialtyByID(System.Guid specialtyId)
        {
            SqlConnection sqlConn = new SqlConnection(connString);
            try
            {
                dsSpecialty dsSpecialty = GetSpecialtyByID(specialtyId);
                dsSpecialty.Specialty[0].Delete();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = GetDeleteCommand(sqlConn);
                sqlDataAdapter.Update(dsSpecialty.Specialty);
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
            SqlCommand updateCommand = new SqlCommand("dbo.spUpdateSpecialty", conn);
            updateCommand.CommandType = CommandType.StoredProcedure;

            updateCommand.Parameters.Add(new SqlParameter("@specialtyId", SqlDbType.UniqueIdentifier));
            updateCommand.Parameters[0].SourceColumn = "specialtyId";

            updateCommand.Parameters.Add(new SqlParameter("@specialty", SqlDbType.NVarChar));
            updateCommand.Parameters[1].SourceColumn = "specialty";

            updateCommand.Parameters.Add(new SqlParameter("@enSpecialty", SqlDbType.NVarChar));
            updateCommand.Parameters[1].SourceColumn = "enSpecialty";

            return updateCommand;
        }

        private SqlCommand GetDeleteCommand(SqlConnection conn)
        {
            SqlCommand delCommand = new SqlCommand("dbo.spDeleteSpecialty", conn);
            delCommand.CommandType = CommandType.StoredProcedure;

            delCommand.Parameters.Add(new SqlParameter("@specialtyId", SqlDbType.UniqueIdentifier));
            delCommand.Parameters[0].SourceColumn = "specialtyId";

            return delCommand;
        }

        private SqlCommand GetInsertCommand(SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand("dbo.spInsertSpecialty", conn);
            insertCommand.CommandType = CommandType.StoredProcedure;

            insertCommand.Parameters.Add(new SqlParameter("@specialtyId", SqlDbType.UniqueIdentifier));
            insertCommand.Parameters[0].SourceColumn = "specialtyId";

            insertCommand.Parameters.Add(new SqlParameter("@specialty", SqlDbType.NVarChar));
            insertCommand.Parameters[1].SourceColumn = "specialty";

            insertCommand.Parameters.Add(new SqlParameter("@enSpecialty", SqlDbType.NVarChar));
            insertCommand.Parameters[1].SourceColumn = "enSpecialty";

            return insertCommand;
        }
    }
}
