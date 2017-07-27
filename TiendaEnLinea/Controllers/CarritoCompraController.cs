using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaEnLinea.Models;
using TiendaEnLinea.ViewModels;

namespace TiendaEnLinea.Controllers
{
    public class CarritoCompraController : Controller
    {
        // GET: CarritoCompra
        Conexion tiendaDB = new Conexion();
        public ActionResult Index()
        {
            var cart = CarritoCompra.GetCart(this.HttpContext);
            var viewModel = new CarritoCompraViewModel
            {
                CarritoArticulos = cart.GetCartItems(),
                CarritoTotal = cart.GetTotal()
            };
            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedItem = tiendaDB.Articulos.Single(item => item.ArticuloId == id);
            var cart = CarritoCompra.GetCart(this.HttpContext);
            cart.AgregarAlCarrito(addedItem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = CarritoCompra.GetCart(this.HttpContext);
            string itemName = tiendaDB.Carritos.Single(item => item.RecordId == id).Articulo.Titulo;
            int itemCount = cart.QuitarDelCarrito(id);
            var results = new CarritoCompraRemoveViewModel
            {
                Mensaje = Server.HtmlEncode(itemName) + " Se Ha Removido De Tu Carrito",
                CarritoTotal = cart.GetTotal(),
                CarritoContador = cart.GetCount(),
                ArticuloContador = itemCount,
                EliminarId = id
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = CarritoCompra.GetCart(this.HttpContext);
            ViewData["CarritoContador"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}