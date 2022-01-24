using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Models
{
    public class Pedido
    {
        [ExplicitKey]
        public int idPedido { get; set; }
        public int idCliente { get; set; }
        public int idProducto { get; set; }
        public int idTamanio { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int Igv { get; set; }
        public decimal PrecioTotal { get; set; }
        public int idEstado { get; set; }
    }
}
