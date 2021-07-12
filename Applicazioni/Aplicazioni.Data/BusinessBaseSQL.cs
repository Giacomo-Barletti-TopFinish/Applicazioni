using Applicazioni.Data.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data
{
    public class BusinessBaseSQL : Core.BusinessBase
    {
        protected static string ConnectionName
        {
            get
            {
                return "MPI";
            }
        }

        protected static string ConnectionString
        {
            get
            {

                ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[ConnectionName];
                return c.ConnectionString;
            }
        }
        protected string _connectionString;
        public BusinessBaseSQL()
        {
            _connectionString = ConnectionString;
        }

        protected override IDbConnection OpenConnection(string contextName)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            con.Open();
            return con;
        }

        public void Rollback()
        {
            SetAbort();
        }

        [DataContext]
        public long GetID()
        {
            AdapterBase a = new AdapterBase(DbConnection, DbTransaction);
            return a.GetID();
        }
    }
}
