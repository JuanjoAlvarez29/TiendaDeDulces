using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class EstadosPedidoNegocio : IEstadosPedidoNegocio
    {
        private IConexion? _conexion;

        public List<EstadosPedido> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.EstadosPedido!.ToList();
        }

        public EstadosPedido Guardar(EstadosPedido entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.EstadosPedido!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public EstadosPedido Modificar(EstadosPedido entidad)
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
            var entidad = _conexion.EstadosPedido!.Find(id);
            if (entidad != null)
            {
                _conexion.EstadosPedido.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}