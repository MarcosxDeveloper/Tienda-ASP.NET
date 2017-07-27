using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiendaEnLinea.Models;

namespace TiendaEnLinea.ViewModels
{
    public class CarritoCompraViewModel
    {
        [Key]
        public int CarrioCompraViewModelId { get; set; }
        public List<Carrito> CarritoArticulos { get; set; }
        public decimal CarritoTotal { get; set; }
    }
}