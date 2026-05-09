using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class TiposPagoNegocio : ITiposPagoNegocio
    {
        private IConexion? _conexion;

        public List<TiposPago> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.TiposPago!.ToList();
        }

        public TiposPago Guardar(TiposPago entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.TiposPago!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public TiposPago Modificar(TiposPago entidad)
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
            var entidad = _conexion.TiposPago!.Find(id);
            if (entidad != null)
            {
                _conexion.TiposPago.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}