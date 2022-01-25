using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Models
{
    public class Cliente
    {
        [ExplicitKey]
        public int idCliente { get; set; }
        public string Descripcion { get; set; }
        public string telefono { get; set; }
        public string txt_email { get; set; }
    }
}
