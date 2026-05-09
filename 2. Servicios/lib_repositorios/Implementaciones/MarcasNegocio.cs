
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class MarcasNegocio : IMarcasNegocio
    {
        private IConexion? _conexion;

        public List<Marcas> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Marcas!.ToList();
        }

        public Marcas Guardar(Marcas entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Marcas!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Marcas Modificar(Marcas entidad)
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
            var entidad = _conexion.Marcas!.Find(id);
            if (entidad != null)
            {
                _conexion.Marcas.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}