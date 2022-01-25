using System;
using App.Pedidos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories
{
    public interface IProductoRepository:IRepository<Producto>
    {
        Producto BuscarPorId(int id);
        Task<IEnumerable<Producto>> Listar(string nombre);
        Task<int> Eliminar(int id);
    }
}
