using App.Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> Listar(string nombre);
        Task<int> Eliminar(int id);
        Producto BuscarPorId(int id);
        
    }
}
