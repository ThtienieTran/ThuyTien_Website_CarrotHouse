using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DemoDapper
{
    public class DataAccess
    {
        private readonly string connectionString;
        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public T QuerySingle<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingle<T>(sql, parameters);
            }
        }
        public T QueryFirst<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingle<T>(sql, parameters);
            }
        }
        public List<T> Query<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.Query<T>(sql, parameters).ToList();
            }
        }
        public void ExecuteCommand<U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(sql, parameters);
            }
        }
    }
}
