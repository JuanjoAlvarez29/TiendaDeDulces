using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class CalidadProveedorNegocio : ICalidadProveedoresNegocio
    {
        private IConexion? _conexion;

        public List<CalidadProveedores> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.CalidadProveedores!
                .Include(c => c.Proveedor)
                .ToList();
        }

        public CalidadProveedores Guardar(CalidadProveedores entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.CalidadProveedor!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public CalidadProveedores Modificar(CalidadProveedores entidad)
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
            var entidad = _conexion.CalidadProveedor!.Find(id);
            if (entidad != null)
            {
                _conexion.CalidadProveedor.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}