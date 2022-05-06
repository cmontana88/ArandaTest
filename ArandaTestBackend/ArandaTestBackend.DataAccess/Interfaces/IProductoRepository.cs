using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaTestBackend.DataAccess.Interfaces
{
    public interface IProductoRepository : IDisposable
    {
        IEnumerable<Producto> GetProductos();
        IEnumerable<Producto> GetProductosOrdenados(string fieldOrder, bool orderAsc);
        IEnumerable<Producto> GetProductosFiltradosporNombre(string criterio, string fieldOrder, bool orderAsc);
        IEnumerable<Producto> GetProductosFiltradosporDescripcion(string criterio, string fieldOrder, bool orderAsc);
        IEnumerable<Producto> GetProductosFiltradosporCategoria(string criterio, string fieldOrder, bool orderAsc);
        Producto GetProductoByID(int ProductoId);
        void InsertProducto(Producto Producto);
        void DeleteProducto(int ProductoID);
        void UpdateProducto(Producto Producto);
        void Save();
    }
}
