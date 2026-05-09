
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class UsuariosNegocio : IUsuariosNegocio
    {
        private IConexion? _conexion;

        public List<Usuarios> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Usuarios!
                .Include(u => u.Rol)
                .ToList();
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Usuarios!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
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
            var entidad = _conexion.Usuarios!.Find(id);
            if (entidad != null)
            {
                _conexion.Usuarios.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}