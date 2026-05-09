
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class MovimientoInventarioNegocio : IMovimientoInventarioNegocio
    {
        private IConexion? _conexion;

        public List<MovimientoInventario> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.MovimientoInventario!
                .Include(m => m.Producto)
                .ToList();
        }

        public MovimientoInventario Guardar(MovimientoInventario entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.MovimientoInventario!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public MovimientoInventario Modificar(MovimientoInventario entidad)
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
            var entidad = _conexion.MovimientoInventario!.Find(id);
            if (entidad != null)
            {
                _conexion.MovimientoInventario.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}