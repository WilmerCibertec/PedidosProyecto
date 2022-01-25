using App.Pedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.Repositories
{
    public interface IEstadoRepository:IRepository<Estado>
    {
        Estado BuscarPorId(int id);
        Task<IEnumerable<Estado>> Listar(string nombre);
    }
}
