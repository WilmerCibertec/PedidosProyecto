using App.Pedidos.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories.Dapper
{
    public class ProductoRepository: Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(string connectionString): base(connectionString)
        {

        }

        public Task<IEnumerable<Producto>> Listar(string nombre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", nombre);
                return connection.QueryAsync<Producto>("SELECT idProducto,a.IdCategoria,b.Descripcion as DescripcionCategoria ,a.Descripcion as DescripcionProducto " +
                                                    " FROM Producto a inner join Categoria b on a.IdCategoria = b.idCategoria where a.Descripcion like '%@nombre%'", parameters,
                                                  commandType: CommandType.Text);
            }
        }

        public Task<int> Eliminar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return connection.ExecuteAsync("UPDATE Producto set Estado = false where idProducto=@id", parameters, commandType: CommandType.Text);
            }
        }

        public Producto BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Producto>().Where(c => c.idProducto.Equals(id)).First();
            }
        }
    }
}
