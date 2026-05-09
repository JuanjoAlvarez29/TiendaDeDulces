
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class ProveedoresNegocio : IProveedoresNegocio
    {
        private IConexion? _conexion;

        public List<Proveedores> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Proveedores!.ToList();
        }

        public Proveedores Guardar(Proveedores entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Proveedores!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Proveedores Modificar(Proveedores entidad)
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
            var entidad = _conexion.Proveedores!.Find(id);
            if (entidad != null)
            {
                _conexion.Proveedores.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}