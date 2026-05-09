using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class RolesNegocio : IRolesNegocio
    {
        private IConexion? _conexion;

        public List<Roles> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Roles!.ToList();
        }

        public Roles Guardar(Roles entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Roles!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Roles Modificar(Roles entidad)
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
            var entidad = _conexion.Roles!.Find(id);
            if (entidad != null)
            {
                _conexion.Roles.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}