using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Repository
{
    public abstract class BaseSqlServerRepository<T> where T : class
    {
        private readonly string _connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING") 
            ?? throw new ArgumentNullException("SQLSERVER_CONNECTION_STRING");
        private SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected int Execute(string sql, object? parameters = null)
        {
            using IDbConnection connection = CreateSqlConnection();
            return connection.Execute(sql, parameters);
        }

        protected T? QuerySingleOrDefault(string sql, object? parameters = null)
        {
            using IDbConnection connection = CreateSqlConnection();
            return connection.QuerySingleOrDefault<T>(sql, parameters);
        }
    }
}
