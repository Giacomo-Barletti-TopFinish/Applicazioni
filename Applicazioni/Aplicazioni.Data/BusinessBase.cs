﻿using Applicazioni.Data.Core;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicazioni.Data
{
    public class BusinessBase : Core.BusinessBase
    {
        protected static string ConnectionName
        {
            get
            {
                return "RVL";
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
        public BusinessBase()
        {
            _connectionString = ConnectionString;
        }

        protected override IDbConnection OpenConnection(string contextName)
        {
            //  SqlConnection con = new SqlConnection(_connectionString);
            OracleConnection con = new OracleConnection(_connectionString);
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
