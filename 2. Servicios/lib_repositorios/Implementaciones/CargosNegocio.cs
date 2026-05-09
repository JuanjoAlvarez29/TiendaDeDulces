
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class CargosNegocio : ICargosNegocio
    {
        private IConexion? _conexion;

        public List<Cargos> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Cargos!.ToList();
        }

        public Cargos Guardar(Cargos entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Cargos!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Cargos Modificar(Cargos entidad)
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
            var entidad = _conexion.Cargos!.Find(id);
            if (entidad != null)
            {
                _conexion.Cargos.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}