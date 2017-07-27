using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaEnLinea.Models
{
    [Bind(Exclude = "ArticuloId")]
    public class Articulo
    {
        [ScaffoldColumn(false)]
        public int ArticuloId { get; set; }

        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }

        [DisplayName("Productor")]
        public int ProductorId { get; set; }

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [StringLength(160)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El Campo {0} Es Requerido")]
        [Range(0.1, 100, ErrorMessage = "El Precio Debe Estar Entre 0.1 y 100")]
        public decimal Precio { get; set; }

        [DisplayName("Foto Del Articulo")]
        [StringLength(1024)]
        public string ArticuloArtUrl { get; set; }

        public virtual Categoria Categorias { get; set; }
        public virtual Productor Productor { get; set; }
    }
}