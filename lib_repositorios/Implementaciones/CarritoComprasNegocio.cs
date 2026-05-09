using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class CarritoComprasNegocio : ICarritoComprasNegocio
    {
        private IConexion? _conexion;

        public List<CarritoCompras> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.CarritoCompras!
                .Include(c => c.Cliente)
                .Include(c => c.Producto)
                .ToList();
        }

        public CarritoCompras Guardar(CarritoCompras entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.CarritoCompras!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public CarritoCompras Modificar(CarritoCompras entidad)
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
            var entidad = _conexion.CarritoCompras!.Find(id);
            if (entidad != null)
            {
                _conexion.CarritoCompras.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}