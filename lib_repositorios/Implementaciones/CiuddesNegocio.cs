
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class CiudadesNegocio : ICiudadesNegocio
    {
        private IConexion? _conexion;

        public List<Ciudades> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Ciudades!.ToList();
        }

        public Ciudades Guardar(Ciudades entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Ciudades!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Ciudades Modificar(Ciudades entidad)
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
            var entidad = _conexion.Ciudades!.Find(id);
            if (entidad != null)
            {
                _conexion.Ciudades.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}