using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaTestBackend.DataAccess
{
    [Table("Producto")]
    public partial class Producto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        public string Categoria { get; set; }

        [Required]
        public string Imagen { get; set; }
        [Required]
        public string ImagenBase64 { get; set; }
    }
}
