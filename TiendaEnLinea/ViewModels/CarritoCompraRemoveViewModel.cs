using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.ViewModels
{
    public class CarritoCompraRemoveViewModel
    {
        public string Mensaje { get; set; }
        public decimal CarritoTotal { get; set; }
        public int CarritoContador { get; set; }
        public int ArticuloContador { get; set; }
        public int EliminarId { get; set; }
    }
}