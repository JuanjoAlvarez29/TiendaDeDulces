
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class AuditoriasNegocio : IAuditoriasNegocio
    {
        private IConexion? _conexion;

        public List<Auditorias> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Auditorias!
                .Include(a => a.Usuario)
                .ToList();
        }

        public Auditorias Guardar(Auditorias entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            entidad.Fecha = DateTime.Now;
            _conexion.Auditorias!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Auditorias Modificar(Auditorias entidad)
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
            var entidad = _conexion.Auditorias!.Find(id);
            if (entidad != null)
            {
                _conexion.Auditorias.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}