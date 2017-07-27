using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Articulo> Articulos { get; set; }
    }
}