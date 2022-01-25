using System;
using App.Pedidos.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoriaRepository Categorias { get; }
        IClienteRepository Clientes { get; }
        IEstadoRepository Estados { get; }
        IPedidoRepository Pedidos { get; }
        IProductoRepository Productos { get; }
        IProductoTamanioRepository Producto_Tamanios { get; }
        ITipoTamanioRepository Tipo_Tamanios { get; }

    }
}
