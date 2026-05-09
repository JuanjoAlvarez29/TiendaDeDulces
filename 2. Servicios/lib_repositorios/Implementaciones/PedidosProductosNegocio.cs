using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class PedidosProductosNegocio : IPedidosProductosNegocio
    {
        private IConexion? _conexion;

        public List<PedidosProductos> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.PedidosProductos!
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .ToList();
        }

        public PedidosProductos Guardar(PedidosProductos entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            entidad.Subtotal = entidad.Cantidad * entidad.PrecioUnitario;
            _conexion.PedidosProductos!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public PedidosProductos Modificar(PedidosProductos entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            entidad.Subtotal = entidad.Cantidad * entidad.PrecioUnitario;
            var entry = _conexion.Entry(entidad);
            entry.State = EntityState.Modified;
            _conexion.SaveChanges();
            return entidad;
        }

        public bool Borrar(int id)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var entidad = _conexion.PedidosProductos!.Find(id);
            if (entidad != null)
            {
                _conexion.PedidosProductos.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
