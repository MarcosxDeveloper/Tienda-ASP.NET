using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.Models
{
    public class Carrito
    {
        [Key]
        public int RecordId { get; set; }
        public string CarritoId { get; set; }
        public int ArticuloId { get; set; }
        public int Contador { get; set; }
        public System.DateTime DatosCreados { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}