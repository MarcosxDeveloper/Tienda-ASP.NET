using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaEnLinea.Models;
using TiendaEnLinea.Controllers;

namespace TiendaEnLinea.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        Conexion tiendaDB = new Conexion();
        public ActionResult Index()
        {
            var categoria = tiendaDB.Categorias.ToList();
            return View(categoria);
        }
        public ActionResult Browse(string Categoria)
        {
            var CategoriaModel = tiendaDB.Categorias.Include("Articulos").Single(c => c.Nombre == Categoria);
            return View(CategoriaModel);
        }
        public ActionResult Details(int ID)
        {
            var ArticuloModel = tiendaDB.Articulos.Find(ID);
            return View(ArticuloModel);
        }
    }
}