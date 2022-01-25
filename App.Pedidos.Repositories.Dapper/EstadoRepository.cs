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
    public class EstadoRepository:Repository<Estado>,IEstadoRepository
    {
        public EstadoRepository(string connectionString) : base(connectionString)
        { }
        public Estado BuscarPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Estado>().Where(c => c.idEstado.Equals(id)).First();
            }
        }

        public async Task<IEnumerable<Estado>> Listar(string nombre)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@nombre", nombre);
                return await connection.QueryAsync<Estado>
                    ("Select idEstado, Descripcion from dbo.Estado" +
                      "Where Descripcion like '%@nombre%'", parameters, commandType: System.Data.CommandType.Text);
            }

        }

    }
}
