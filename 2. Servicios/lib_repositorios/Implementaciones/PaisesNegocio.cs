
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class PaisesNegocio : IPaisesNegocio
    {
        private IConexion? _conexion;

        public List<Paises> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Paises!.ToList();
        }

        public Paises Guardar(Paises entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Paises!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Paises Modificar(Paises entidad)
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
            var entidad = _conexion.Paises!.Find(id);
            if (entidad != null)
            {
                _conexion.Paises.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}