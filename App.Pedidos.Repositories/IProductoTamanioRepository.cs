using System;
using App.Pedidos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories
{
    public interface IProductoTamanioRepository:IRepository<ProductoTamanio>
    {
        ProductoTamanio BuscarPorId(int id);
        Task<int> Eliminar(int id);
    }
}
