
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class LoteNegocio : ILoteNegocio
    {
        private IConexion? _conexion;

        public List<Lote> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Lote!
                .Include(l => l.Producto)
                .ToList();
        }

        public Lote Guardar(Lote entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Lote!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Lote Modificar(Lote entidad)
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
            var entidad = _conexion.Lote!.Find(id);
            if (entidad != null)
            {
                _conexion.Lote.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }

        //  MÉTODOS EXTRA
        public bool EsStockCritico(int id, int minimo)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var lote = _conexion.Lote!.Find(id);
            if (lote == null) return false;
            return lote.Cantidad < minimo;
        }

        public bool EstaVencido(int id)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var lote = _conexion.Lote!.Find(id);
            if (lote == null) return false;
            return lote.FechaCaducidad < DateTime.Now;
        }
    }
}