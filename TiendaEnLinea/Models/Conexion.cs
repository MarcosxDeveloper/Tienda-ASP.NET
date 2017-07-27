using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TiendaEnLinea.ViewModels;

namespace TiendaEnLinea.Models
{
    public class Conexion : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Productor> Productores { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenDetalle> OrdenDetalles { get; set; }
        public DbSet<CarritoCompraViewModel> CarritoCompraViewModels { get; set; }
    }
}