
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class ProductosNegocio : IProductosNegocio
    {
        private IConexion? _conexion;

        public List<Productos> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Productos!
                .Include(p => p.Categoria)
                .Include(p => p.Marca)
                .ToList();
        }

        public Productos Guardar(Productos entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Productos!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Productos Modificar(Productos entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var entry = _conexion.Entry(entidad);
            entry.State = EntityState.Modified;
            _conexion.SaveChanges();
            return entidad;
        }

        public bool Borrar(int id)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var entidad = _conexion.Productos!.Find(id);
            if (entidad != null)
            {
                _conexion.Productos.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }

        // MÉTODO EXTRA
        public decimal CalcularGanancia(int id)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var producto = _conexion.Productos!.Find(id);
            if (producto == null) return 0;
            return producto.PrecioVenta - producto.PrecioCompra;
        }
    }
}