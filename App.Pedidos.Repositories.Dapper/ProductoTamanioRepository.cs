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
    public class ProductoTamanioRepository:Repository<ProductoTamanio>
    {
        public ProductoTamanioRepository(string connectionString) : base(connectionString)
        { }
    }
}
