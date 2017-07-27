using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.Models
{
    public class OrdenDetalle
    {
        public int OrdenDetalleId { get; set; }
        public int OrdenId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public virtual Articulo Articulo { get; set; }
        public virtual Orden Orden { get; set; }
    }
}