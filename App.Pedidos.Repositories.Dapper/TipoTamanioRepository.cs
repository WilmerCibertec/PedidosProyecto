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
    public class TipoTamanioRepository:Repository<TipoTamanio>,ITipoTamanioRepository
    {
        public TipoTamanioRepository(string connectionString) : base(connectionString)
        { }
        public TipoTamanio BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<TipoTamanio>().Where(c => c.idTamanio.Equals(id)).First();
            }
        }

        public async Task<IEnumerable<TipoTamanio>> Listar(string nombre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", nombre);
                return await connection.QueryAsync<TipoTamanio>
                    ("Select idTamanio, Descripcion from dbo.Tipo_Tamanio" +
                      "Where Descripcion like '%@nombre%'", parameters, commandType: System.Data.CommandType.Text);
            }

        }
        public async Task<int> Eliminar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("Delete from dbo.Tipo_Tamanio " +
                                                "where idTamanio = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }
    }
}
