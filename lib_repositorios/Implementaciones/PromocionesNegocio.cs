using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class PromocionesNegocio : IPromocionesNegocio
    {
        private IConexion? _conexion;

        public List<Promociones> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Promociones!
                .Include(p => p.Producto)
                .ToList();
        }

        public Promociones Guardar(Promociones entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Promociones!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Promociones Modificar(Promociones entidad)
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
            var entidad = _conexion.Promociones!.Find(id);
            if (entidad != null)
            {
                _conexion.Promociones.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }

        // MÉTODOS EXTRA
        public decimal AplicarPromocion(int id, decimal precio)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var promocion = _conexion.Promociones!.Find(id);
            if (promocion == null || !promocion.Activo || !EstaVigente(id))
                return precio;

            return precio - (precio * promocion.Porcentaje / 100);
        }

        public bool EstaVigente(int id)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var promocion = _conexion.Promociones!.Find(id);
            if (promocion == null) return false;
            return DateTime.Now >= promocion.FechaInicio && DateTime.Now <= promocion.FechaFin;
        }
    }
}