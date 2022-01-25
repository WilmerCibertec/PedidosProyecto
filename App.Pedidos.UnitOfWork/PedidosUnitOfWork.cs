using App.Pedidos.Repositories;
using App.Pedidos.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Pedidos.UnitOfWork
{
    public class PedidosUnitOfWork : IUnitOfWork
    {
        public PedidosUnitOfWork(string connectionString)
        {
            Categorias = new CategoriaRepository(connectionString);
            Clientes = new ClienteRepository(connectionString);
            Estados = new EstadoRepository(connectionString);
            Productos = new ProductoRepository(connectionString);


            Tipo_Tamanios = new TipoTamanioRepository(connectionString);
        }

        public ICategoriaRepository Categorias
        {
            get;
            private set;
        }
        public IClienteRepository Clientes
        {
            get;
            private set;
        }
        public IEstadoRepository Estados
        {
            get;
            private set;
        }
        public IPedidoRepository Pedidos
        {
            get;
            private set;
        }
        public IProductoRepository Productos
        {
            get;
            private set;
        }
        public IProductoTamanioRepository Producto_Tamanios
        {
            get;
            private set;
        }
        public ITipoTamanioRepository Tipo_Tamanios
        {
            get;
            private set;
        }
    }
}
