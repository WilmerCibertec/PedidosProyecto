using App.Pedidos.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories.Dapper
{
    public class PedidoRepository:Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(string connectionString) : base(connectionString)
        { }

        public async Task<int> InsertarPedido(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idPedido", pedido.idPedido);
                parameters.Add("@idCliente", pedido.idCliente);
                parameters.Add("@idProducto", pedido.idProducto);
                parameters.Add("@idTamanio", pedido.idTamanio);
                parameters.Add("@precio", pedido.Precio);
                parameters.Add("@cantidad", pedido.Cantidad);
                parameters.Add("@igv", pedido.Igv);
                parameters.Add("@precioTotal", pedido.PrecioTotal);
                parameters.Add("@idEstado", pedido.idEstado);

                int resultado = await connection.ExecuteAsync("INSERT INTO Pedido (idPedido,idCliente,idProducto,idTamanio,Precio,Cantidad,Igv ,PrecioTotal,idEstado)" +
                                                        " VALUES(@idPedido,@idCliente,@idProducto,@idTamanio,@precio,@cantidad,@igv,@precioTotal,@idEstado)",
                                                        parameters, commandType: CommandType.Text);

                return resultado;
           
            }
        }

        public async Task<IEnumerable<string>> ListarEnvio()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<string>("select a.idPedido,a.idCliente, b.Descripcion,a.idProducto,c.Descripcion,a.idTamanio,d.Descripcion," +
                                                " a.Precio, a.Cantidad, a.Igv, a.PrecioTotal, (case when a.idEstado = 1 then 'ENVIADO' END) Estado " +
                                                " from Pedido a inner join Cliente b on a.idCliente = b.idCliente " +
                                                " inner join Producto c on a.idProducto = c.idProducto " +
                                                " inner join Tipo_Tamanio d on a.idTamanio = d.IdTamanio " +
                                                " where a.idEstado = 1",null,commandType: CommandType.Text); 
            }
        }

        public async Task<IEnumerable<string>> ListarRecepcion()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<string>("select a.idPedido,a.idCliente, b.Descripcion,a.idProducto,c.Descripcion,a.idTamanio,d.Descripcion," +
                                                " a.Precio, a.Cantidad, a.Igv, a.PrecioTotal, (case when a.idEstado = 1 then 'ENVIADO' END) Estado " +
                                                " from Pedido a inner join Cliente b on a.idCliente = b.idCliente " +
                                                " inner join Producto c on a.idProducto = c.idProducto " +
                                                " inner join Tipo_Tamanio d on a.idTamanio = d.IdTamanio " +
                                                " where a.idEstado = 2", null, commandType: CommandType.Text);
            }
        }

        public async Task<int> ActualizarEnvioRecepcion(int id, int estado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                parameters.Add("@estado", estado);
                int resultado = await connection.ExecuteAsync("update Pedido set idEstado=@estado where idPedido=@id", parameters, commandType: CommandType.Text);
                return resultado;
            }
        }

    }
}
