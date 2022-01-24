using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Models
{
    public class ProductoTamanio
    {
        [ExplicitKey]
        public int idProducto { get; set; }
        public int idTamanio { get; set; }
        public string Precio { get; set; }
    }
}
