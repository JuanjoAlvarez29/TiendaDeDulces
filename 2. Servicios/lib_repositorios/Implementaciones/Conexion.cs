using Microsoft.EntityFrameworkCore;
using Libreria_repositorios.Entidades;
namespace Aplicaciones_libreria.Implementaciones
{
    public class Conexion : DbContext
    {
        public String? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<CalidadProveedores>? CalidadProovedores { get; set; }
        public DbSet<Cargos>? Cargos { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Ciudades>? Ciudades { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }

        public DbSet<Entregas>? Entregas { get; set; }
        public DbSet<EstadosPedido>? EstadosPedido { get; set; }
        public DbSet<Facturas>? Facturas { get; set; }
        public DbSet<Lote>? Lote { get; set; }
        public DbSet<Marcas>? Marcas { get; set; }
        public DbSet<MovimientoInventario>? MovimientoInventario { get; set; }
        public DbSet<Paises>? Paises  { get; set; }

        public DbSet<Pedidos>? Pedidos { get; set; }

        public DbSet<PedidosProductos>? PedidosProductos { get; set; }
        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }

        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<TiposCliente>? TiposClientes { get; set; }
        public DbSet<TiposPago>? TiposPagos { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Roles>? Roles { get; set; }
        public DbSet<Auditorias>? Auditorias { get; set; }
        public DbSet<CarritoCompras>? CarritoCompras { get; set; }
        public DbSet<MetodosEnvio>? MetodosEnvios { get; set; }


    }
}
