using App.Pedidos.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories.Dapper
{
    public class CategoriaRepository:Repository<Categoria>,ICategoriaRepository
    {
        public CategoriaRepository(string connectionString) : base(connectionString)
        { }
        public Categoria BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Categoria>().Where(c => c.idCategoria.Equals(id)).First();
            }
        }

        public async Task<IEnumerable<Categoria>> Listar(string nombre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", nombre);
                return await connection.QueryAsync<Categoria>
                    ("Select idCategoria, Descripcion, Estado from dbo.Categoria" +
                      "Where Descripcion like '%@nombre%'",parameters , commandType:System.Data.CommandType.Text);
            }
                
        }
        public async Task<int> Eliminar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("update dbo.Categoria " +
                                                "set Estado = 0 " +
                                                "where idCategoria = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }
    }
}
