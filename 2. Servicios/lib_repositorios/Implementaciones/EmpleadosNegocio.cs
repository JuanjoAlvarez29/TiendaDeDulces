using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class EmpleadosNegocio : IEmpleadosNegocio
    {
        private IConexion? _conexion;

        public List<Empleados> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Empleados!
                .Include(e => e.Cargo)
                .Include(e => e.Ciudad)
                .ToList();
        }

        public Empleados Guardar(Empleados entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Empleados!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Empleados Modificar(Empleados entidad)
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
            var entidad = _conexion.Empleados!.Find(id);
            if (entidad != null)
            {
                _conexion.Empleados.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}