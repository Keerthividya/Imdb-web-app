using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IMDB.Repository
{
    public class BaseRepository<T> where T : class
    {
        private readonly string _connectionString;
        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> Get(string query)
        {

            using var connection = new SqlConnection(_connectionString);
            return connection.Query<T>(query);
        }

        public T Get(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<T>(query, parameters);
        }

        public int Create(string query, object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.QuerySingle<int>(query, parameters);
        }

        public void Update(string query,object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query, parameters);
        }

        public void Delete(string query,object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(query,parameters);
        }

        public void StoredProcedure(string procedure,object parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(procedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
    }
