using ArandaTestBackend.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaTestBackend.DataAccess.Repositorios
{
    public class ProductoRepository : IProductoRepository, IDisposable
    {
        private Model context;

        public ProductoRepository(string conexion)
        {
            this.context = new Model(conexion);
        }
        public void DeleteProducto(int ProductoID)
        {
            Producto producto = context.Producto.Find(ProductoID);
            context.Producto.Remove(producto);
        }

        public Producto GetProductoByID(int ProductoId)
        {
            return context.Producto.Find(ProductoId);
        }

        public IEnumerable<Producto> GetProductos()
        {
            return context.Producto.ToList();
        }

        public void InsertProducto(Producto Producto)
        {
            context.Producto.Add(Producto);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateProducto(Producto Producto)
        {
            context.Entry(Producto).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Producto> GetProductosOrdenados(string fieldOrder, bool orderAsc)
        {
            switch (fieldOrder)
            {
                case "Nombre":
                    if (orderAsc)
                        return context.Producto.ToList().OrderBy(p => p.Nombre);
                    else
                        return context.Producto.ToList().OrderByDescending(p => p.Nombre);
                case "Categoria":
                    if (orderAsc)
                        return context.Producto.ToList().OrderBy(p => p.Categoria);
                    else
                        return context.Producto.ToList().OrderByDescending(p => p.Categoria);
                default:
                    return context.Producto.ToList();
            }
        }

        public IEnumerable<Producto> GetProductosFiltradosporNombre(string criterio, string fieldOrder, bool orderAsc)
        {
            switch(fieldOrder)
            {
                case "Nombre":
                    if(orderAsc)
                        return context.Producto.Where(p => p.Nombre.Contains(criterio)).ToList().OrderBy(p => p.Nombre);
                    else
                        return context.Producto.Where(p => p.Nombre.Contains(criterio)).ToList().OrderByDescending(p => p.Nombre);
                case "Categoria":
                    if (orderAsc)
                        return context.Producto.Where(p => p.Nombre.Contains(criterio)).ToList().OrderBy(p => p.Categoria);
                    else
                        return context.Producto.Where(p => p.Nombre.Contains(criterio)).ToList().OrderByDescending(p => p.Categoria);
                default:
                    return context.Producto.Where(p => p.Nombre.Contains(criterio));                    
            }            
        }

        public IEnumerable<Producto> GetProductosFiltradosporDescripcion(string criterio, string fieldOrder, bool orderAsc)
        {
            switch (fieldOrder)
            {
                case "Nombre":
                    if (orderAsc)
                        return context.Producto.Where(p => p.Descripcion.Contains(criterio)).ToList().OrderBy(p => p.Nombre);
                    else
                        return context.Producto.Where(p => p.Descripcion.Contains(criterio)).ToList().OrderByDescending(p => p.Nombre);
                case "Categoria":
                    if (orderAsc)
                        return context.Producto.Where(p => p.Descripcion.Contains(criterio)).ToList().OrderBy(p => p.Categoria);
                    else
                        return context.Producto.Where(p => p.Descripcion.Contains(criterio)).ToList().OrderByDescending(p => p.Categoria);
                default:
                    return context.Producto.Where(p => p.Descripcion.Contains(criterio));
            }
        }

        public IEnumerable<Producto> GetProductosFiltradosporCategoria(string criterio, string fieldOrder, bool orderAsc)
        {
            switch (fieldOrder)
            {
                case "Nombre":
                    if (orderAsc)
                        return context.Producto.Where(p => p.Categoria.Contains(criterio)).ToList().OrderBy(p => p.Nombre);
                    else
                        return context.Producto.Where(p => p.Categoria.Contains(criterio)).ToList().OrderByDescending(p => p.Nombre);
                case "Categoria":
                    if (orderAsc)
                        return context.Producto.Where(p => p.Categoria.Contains(criterio)).ToList().OrderBy(p => p.Categoria);
                    else
                        return context.Producto.Where(p => p.Categoria.Contains(criterio)).ToList().OrderByDescending(p => p.Categoria);
                default:
                    return context.Producto.Where(p => p.Categoria.Contains(criterio));
            }
        }
    }
}
