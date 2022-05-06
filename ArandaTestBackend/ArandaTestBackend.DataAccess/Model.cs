using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArandaTestBackend.DataAccess
{
    public partial class Model : DbContext
    {
        public Model(string connectionString) : base(GetOptions(connectionString))
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Categoria)
                .IsUnicode(false);
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
