using ArandaTestBackend.DataAccess;
using System;
using System.Collections.Generic;

namespace ArandaTestBackend.Entities
{
    public class ProductosFiltrados
    {
        public int TotalPages { get; set; }
        public int Pages { get; set; }

        public IEnumerable<Producto> Productos { get; set; }
    }
}
