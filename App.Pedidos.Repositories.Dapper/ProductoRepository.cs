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
    public class ProductoRepository:Repository<Producto>,IProductoRepository
    {
        public ProductoRepository(string connectionString) : base(connectionString)
        { }
        public Producto BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Producto>().Where(c => c.idProducto.Equals(id)).First();
            }
        }

        public async Task<IEnumerable<Producto>> Listar(string nombre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", nombre);
                return await connection.QueryAsync<Producto>
                    ("Select idProducto, idCategoria, Descripcion from dbo.Producto" +
                      "Where Descripcion like '%@nombre%'", parameters, commandType: System.Data.CommandType.Text);
            }

        }
        public async Task<int> Eliminar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("Delete from dbo.Producto " +
                                                "where idProducto = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }
    }
}
