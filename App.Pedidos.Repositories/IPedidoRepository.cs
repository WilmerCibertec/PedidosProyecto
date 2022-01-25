using System;
using App.Pedidos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories
{
    public interface IPedidoRepository:IRepository<Pedido>
    {
        Task<int> InsertarPedido(Pedido pedido);

        Task<IEnumerable<string>> ListarEnvio();

        Task<IEnumerable<string>> ListarRecepcion();

        Task<int> ActualizarEnvioRecepcion(int id, int estado);
    }
}
