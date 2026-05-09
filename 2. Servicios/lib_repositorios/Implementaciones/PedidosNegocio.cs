using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class PedidosNegocio : IPedidosNegocio
    {
        private IConexion? _conexion;

        public List<Pedidos> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Pedidos!
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Include(p => p.TipoPago)
                .Include(p => p.EstadoPedido)
                .Include(p => p.MetodoEnvio)
                .Include(p => p.Pedidos_Productos)
                .ToList();
        }

        public Pedidos Guardar(Pedidos entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            entidad.Total = CalcularTotal(entidad.Id);
            _conexion.Pedidos!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Pedidos Modificar(Pedidos entidad)
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
            var entidad = _conexion.Pedidos!.Find(id);
            if (entidad != null)
            {
                _conexion.Pedidos.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }

        // MÉTODO EXTRA
        public decimal CalcularTotal(int id)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var pedido = _conexion.Pedidos!
                .Include(p => p.Pedidos_Productos)
                .FirstOrDefault(p => p.Id == id);

            if (pedido == null || pedido.Pedidos_Productos == null) return 0;
            return pedido.Pedidos_Productos.Sum(d => d.Subtotal);
        }
    }
}