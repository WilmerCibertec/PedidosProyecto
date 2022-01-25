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
    public class ClienteRepository:Repository<Cliente>,IClienteRepository
    {
        public ClienteRepository(string connectionString) : base(connectionString)
        { }
        public Cliente BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Cliente>().Where(c => c.idCliente.Equals(id)).First();
            }
        }

        public async Task<IEnumerable<Cliente>> Listar(string nombre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", nombre);
                return await connection.QueryAsync<Cliente>
                    ("Select idCLiente, Descripcion, Telefono, Txt_email from dbo.Cliente" +
                      "Where Descripcion like '%@nombre%'", parameters, commandType: System.Data.CommandType.Text);
            }

        }
        public async Task<int> Eliminar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                return await connection.ExecuteAsync("Delete from dbo.Cliente " +
                                                "where idCliente = @id", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }
    }
}
