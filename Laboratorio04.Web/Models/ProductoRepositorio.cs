using System.ComponentModel.DataAnnotations;

namespace Laboratorio04.Web.Models
{
    public class ProductoRepositorio
    {
        private static readonly List<Producto> productos = new List<Producto>();
        private static int siguienteId = 1;

        public static List<Producto> ObtengaTodosLosProductos()
        {
            return productos.Select(Clone).ToList();
        }
        public static Producto? ObtengaElProductoPorId(int id)
        {
            var producto = productos.FirstOrDefault(x => x.Id == id);
            return producto is null ? null : Clone(producto);
        }

        public static void AgregueProducto(Producto producto)
        {
            producto.Id = siguienteId++;
            productos.Add(Clone(producto));
        }
        public static void ActualiceProducto(Producto producto)
        {
            var existente = productos.FirstOrDefault(x => x.Id == producto.Id);
            if (existente is null) return;
            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Categoria = producto.Categoria;
        }

        public static void ElimineProducto(int id)
        {
            var existente = productos.FirstOrDefault(x => x.Id == id);
            if (existente != null)
            {
                productos.Remove(existente);
            }
        }

        private static Producto Clone(Producto fuente)
        {
            return new Producto
            {
                Id = fuente.Id,
                Nombre = fuente.Nombre,
                Precio = fuente.Precio,
                Categoria = fuente.Categoria
            };
        }
    }
}
