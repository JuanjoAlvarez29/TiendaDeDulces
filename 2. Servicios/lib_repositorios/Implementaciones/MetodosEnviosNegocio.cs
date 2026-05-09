using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class MetodosEnvioNegocio : IMetodosEnvioNegocio
    {
        private IConexion? _conexion;

        public List<MetodosEnvio> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.MetodosEnvio!.ToList();
        }

        public MetodosEnvio Guardar(MetodosEnvio entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.MetodosEnvio!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public MetodosEnvio Modificar(MetodosEnvio entidad)
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
            var entidad = _conexion.MetodosEnvio!.Find(id);
            if (entidad != null)
            {
                _conexion.MetodosEnvio.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}