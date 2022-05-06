using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArandaTestBackend.Models
{
    public class ProductoRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
        public string ImagenBase64 { get; set; }
    }
}
