using ArandaTestBackend.Business.Interfaces;
using ArandaTestBackend.DataAccess;
using ArandaTestBackend.DataAccess.Interfaces;
using ArandaTestBackend.DataAccess.Repositorios;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Linq;
using ArandaTestBackend.Entities;

namespace ArandaTestBackend.Business
{
    public class ProductoBll : IProductoBll
    {
        private IProductoRepository _productoRepository;

        public ProductoBll(string conexion)
        {
            _productoRepository = new ProductoRepository(conexion);
        }

        public void CrearProducto(Producto producto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    _productoRepository.InsertProducto(producto);
                    _productoRepository.Save();

                    ts.Complete();
                }                    
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public void ActualizarProducto(Producto producto)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    _productoRepository.UpdateProducto(producto);
                    _productoRepository.Save();

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EliminarProducto(int productoId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    _productoRepository.DeleteProducto(productoId);
                    _productoRepository.Save();

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Producto> ObtenerTodosLosProductos()
        {
            try
            {
                return _productoRepository.GetProductos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ProductosFiltrados ObtenerTodosLosProductosFiltrados(string fieldFilter, string criterioFilter, string filedOrder, bool orderAsc, int page, int itemxpage)
        {
            try
            {
                IEnumerable<Producto> productos;
                switch (fieldFilter)
                {
                    case "Nombre":
                        productos = _productoRepository.GetProductosFiltradosporNombre(criterioFilter, filedOrder, orderAsc);
                        break;
                    case "Descripcion":
                        productos = _productoRepository.GetProductosFiltradosporDescripcion(criterioFilter, filedOrder, orderAsc);
                        break;
                    case "Categoria":
                        productos = _productoRepository.GetProductosFiltradosporCategoria(criterioFilter, filedOrder, orderAsc);
                        break;
                    default:
                        productos = _productoRepository.GetProductosOrdenados(filedOrder, orderAsc);
                        break;
                }

                var productosFiltrados = new ProductosFiltrados();

                productosFiltrados.Productos = productos.ToList().Skip(itemxpage * (page - 1)).Take(itemxpage);
                productosFiltrados.TotalPages = (productos.Count() / itemxpage) + (productos.Count() % itemxpage == 0 ? 0 : 1);
                productosFiltrados.Pages = productosFiltrados.TotalPages < page ? productosFiltrados.TotalPages : page;

                return productosFiltrados;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            try
            {
                return _productoRepository.GetProductoByID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
