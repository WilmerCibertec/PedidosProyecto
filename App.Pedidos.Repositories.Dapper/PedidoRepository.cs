using App.Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories.Dapper
{
    public class PedidoRepository:Repository<Pedido>
    {
        public PedidoRepository(string connectionString) : base(connectionString)
        { }
    }
}
