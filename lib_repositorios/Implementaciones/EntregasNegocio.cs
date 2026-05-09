
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class EntregasNegocio : IEntregasNegocio
    {
        private IConexion? _conexion;

        public List<Entregas> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Entregas!
                .Include(e => e.Pedido)
                .Include(e => e.Empleado)
                .Include(e => e.Ciudad)
                .ToList();
        }

        public Entregas Guardar(Entregas entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Entregas!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Entregas Modificar(Entregas entidad)
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
            var entidad = _conexion.Entregas!.Find(id);
            if (entidad != null)
            {
                _conexion.Entregas.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}