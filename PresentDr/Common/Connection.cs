using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace PresentDr.Common
{
    /// <summary>
    /// ConnectionString Definition.
    /// </summary>
    #region Connection String
    public class ConnectionManager
    {
        private static ConnectionManager _instance;
        private string _ConnectionString;
        private string _MAConnectionString;

        protected ConnectionManager() { }

        public static ConnectionManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ConnectionManager();

                return _instance;
            }
        }
        public string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }

        public string MAConnectionString
        {
            get
            {
                return _MAConnectionString;
            }
            set
            {
                _MAConnectionString = value;
            }
        }




    }
    #endregion
}
