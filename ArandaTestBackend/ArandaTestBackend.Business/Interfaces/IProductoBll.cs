using ArandaTestBackend.DataAccess;
using ArandaTestBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaTestBackend.Business.Interfaces
{
    public interface IProductoBll
    {
        void CrearProducto(Producto producto);
        void ActualizarProducto(Producto producto);
        void EliminarProducto(int productoId);
        IEnumerable<Producto> ObtenerTodosLosProductos();
        ProductosFiltrados ObtenerTodosLosProductosFiltrados(string fieldFilter, string criterioFilter, string filedOrder, bool orderAsc, int page, int itemxpage);

        Producto ObtenerProductoPorId( int id);
    }
}
