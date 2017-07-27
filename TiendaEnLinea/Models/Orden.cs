using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaEnLinea.Models
{
    public class Orden
    {
        [ScaffoldColumn(false)]
        public int OrdenId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrdenFecha { get; set; }
        [ScaffoldColumn(false)]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public string CodigoPostal { get; set; }
        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public string Pais { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [StringLength(24)]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "El Correo No Es Valido")]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<OrdenDetalle> OrdenDetalles { get; set; }

    }
}