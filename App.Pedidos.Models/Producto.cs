using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Models
{
    public class Producto
    {
        [ExplicitKey]
        public int idProducto { get; set; }
        public int idCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
