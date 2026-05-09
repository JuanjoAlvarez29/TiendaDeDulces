
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class FacturasNegocio : IFacturasNegocio
    {
        private IConexion? _conexion;

        public List<Facturas> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Facturas!
                .Include(f => f.Pedido)
                .ToList();
        }

        public Facturas Guardar(Facturas entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            entidad.Iva = CalcularIva(entidad.Id);
            entidad.Total = CalcularTotalConIva(entidad.Id);
            _conexion.Facturas!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Facturas Modificar(Facturas entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            entidad.Iva = CalcularIva(entidad.Id);
            entidad.Total = CalcularTotalConIva(entidad.Id);
            var entry = _conexion.Entry(entidad);
            entry.State = EntityState.Modified;
            _conexion.SaveChanges();
            return entidad;
        }

        public bool Borrar(int id)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var entidad = _conexion.Facturas!.Find(id);
            if (entidad != null)
            {
                _conexion.Facturas.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }

        // MÉTODOS EXTRA
        public decimal CalcularIva(int idFactura)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var factura = _conexion.Facturas!.Find(idFactura);
            if (factura == null) return 0;
            return factura.Subtotal * 0.19m;
        }

        public decimal CalcularTotalConIva(int idFactura)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var factura = _conexion.Facturas!.Find(idFactura);
            if (factura == null) return 0;
            return factura.Subtotal + CalcularIva(idFactura);
        }
    }
}