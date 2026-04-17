using Laboratorio04.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio04.Web.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            var listaProductos = ProductoRepositorio.ObtengaTodosLosProductos();
            return View(listaProductos);
        }

        public IActionResult Detalles(int id)
        {
            var producto = ProductoRepositorio.ObtengaElProductoPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        public IActionResult Crear()
        {
            return View(new Producto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }
            ProductoRepositorio.AgregueProducto(producto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            var producto = ProductoRepositorio.ObtengaElProductoPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }
            ProductoRepositorio.ActualiceProducto(producto);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Eliminar(int id)
        {
            var producto = ProductoRepositorio.ObtengaElProductoPorId(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            ProductoRepositorio.ElimineProducto(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
