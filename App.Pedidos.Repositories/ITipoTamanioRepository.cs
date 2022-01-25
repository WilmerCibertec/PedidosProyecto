using System;
using App.Pedidos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories
{
    public interface ITipoTamanioRepository:IRepository<TipoTamanio>
    {
        TipoTamanio BuscarPorId(int id);
        Task<IEnumerable<TipoTamanio>> Listar(string nombre);
        Task<int> Eliminar(int id);
    }
}
