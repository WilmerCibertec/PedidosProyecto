using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories.Dapper
{
    public class Repository<T>:IRepository<T> where T:class
    {
        protected string _connectionString;
        public Repository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };
            _connectionString = connectionString;
        }
        public Task<int> Agregar(T entidad)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.InsertAsync(entidad);
            }
        }
        public Task<T> Obtener(T entidad)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAsync<T>(entidad);
            }
        }
        public Task<T> Obtener(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAsync<T>(id);
            }
        }
        public Task<T> Obtener(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAsync<T>(id);
            }
        }
        public Task<IEnumerable<T>> Listar()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAllAsync<T>();
            }
        }
        public Task<bool> Eliminar(T entidad)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.DeleteAsync<T>(entidad);
            }
        }
        public Task<bool> Modificar(T entidad)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.UpdateAsync<T>(entidad);
            }
        }
    }
}
