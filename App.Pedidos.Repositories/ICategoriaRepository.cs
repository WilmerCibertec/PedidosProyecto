using App.Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories
{
    public interface ICategoriaRepository:IRepository<Categoria>
    {
        Categoria BuscarPorId(int id);
        Task<IEnumerable<Categoria>> Listar(string nombre);
        Task<int> Eliminar(int id);
    }
}
