using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaEnLinea.Models
{
    public class CarritoCompra
    {
        Conexion tiendaDB = new Conexion();
        string CarritoCompraId { get; set; }
        public const string CartSessionKey = "CarritoId";
        public static CarritoCompra GetCart(HttpContextBase context)
        {
            var cart = new CarritoCompra();
            cart.CarritoCompraId = cart.GetCartId(context);
            return cart;
        }
        // Metodo de ayuda para simplificar las llamadas al carrito de compra
        public static CarritoCompra GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AgregarAlCarrito(Articulo item)
        {
            var cartItem = tiendaDB.Carritos.SingleOrDefault(
                c => c.CarritoId == CarritoCompraId && c.ArticuloId == item.ArticuloId);
            if (cartItem == null)
            {
                cartItem = new Carrito
                {
                    ArticuloId = item.ArticuloId,
                    CarritoId = CarritoCompraId,
                    Contador = 1,
                    DatosCreados = DateTime.Now
                };
                tiendaDB.Carritos.Add(cartItem);
            }
            else
            {
                cartItem.Contador++;
            }
            tiendaDB.SaveChanges();
        }

        public int QuitarDelCarrito(int id)
        {
            var cartItem = tiendaDB.Carritos.Single(
                cart => cart.CarritoId == CarritoCompraId && cart.RecordId == id);
            int itemCount = 0;
            if (cartItem != null)
            {
                if (cartItem.Contador > 1)
                {
                    cartItem.Contador--;
                    itemCount = cartItem.Contador;
                }
                else
                {
                    tiendaDB.Carritos.Remove(cartItem);
                }
                tiendaDB.SaveChanges();
            }
            return itemCount;
        }

        public void LimpiarCarrito()
        {
            var cartItems = tiendaDB.Carritos.Where(cart => cart.CarritoId == CarritoCompraId);
            foreach (var cartItem in cartItems)
            {
                tiendaDB.Carritos.Remove(cartItem);
            }
            tiendaDB.SaveChanges();
        }

        public List<Carrito> GetCartItems()
        {
            return tiendaDB.Carritos.Where(cart => cart.CarritoId == CarritoCompraId).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in tiendaDB.Carritos
                          where cartItems.CarritoId == CarritoCompraId
                          select (int?)cartItems.Contador).Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in tiendaDB.Carritos
                              where cartItems.CarritoId == CarritoCompraId
                              select (int?)cartItems.Contador * cartItems.Articulo.Precio).Sum();
            return total ?? decimal.Zero;
        }

        public int CreateOrder(Orden order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                var orderDetail = new OrdenDetalle
                {
                    ArticuloId = item.ArticuloId,
                    OrdenId = order.OrdenId,
                    PrecioUnitario = item.Articulo.Precio,
                    Cantidad = item.Contador
                };
                orderTotal += (item.Contador * item.Articulo.Precio);
                tiendaDB.OrdenDetalles.Add(orderDetail);
            }
            order.Total = orderTotal;
            tiendaDB.SaveChanges();
            LimpiarCarrito();
            return order.OrdenId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string Email)
        {
            var shoppingCart = tiendaDB.Carritos.Where(c => c.CarritoId == CarritoCompraId);
            foreach (Carrito item in shoppingCart)
            {
                item.CarritoId = Email;
            }
            tiendaDB.SaveChanges();
        }
    }
}