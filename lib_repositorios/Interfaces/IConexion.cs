
    using Libreria_repositorios.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.EntityFrameworkCore.Infrastructure;

    namespace Aplicaciones_libreria.Interfaces
    {
        public interface IConexion
        {
            string? StringConexion { get; set; }

            // DbSets para todas las 25 entidades
            DbSet<Categorias>? Categorias { get; set; }
            DbSet<Paises>? Paises { get; set; }
            DbSet<TiposCliente>? TiposCliente { get; set; }
            DbSet<Ciudades>? Ciudades { get; set; }
            DbSet<Cargos>? Cargos { get; set; }
            DbSet<TiposPago>? TiposPago { get; set; }
            DbSet<EstadosPedido>? EstadosPedido { get; set; }
            DbSet<Proveedores>? Proveedores { get; set; }
            DbSet<Marcas>? Marcas { get; set; }
            DbSet<Productos>? Productos { get; set; }
            DbSet<Lote>? Lotes { get; set; }
            DbSet<MovimientoInventario>? MovimientoInventario { get; set; }
            DbSet<CalidadProvedores>? CalidadProveedor { get; set; }
            DbSet<Promociones>? Promociones { get; set; }
            DbSet<Clientes>? Clientes { get; set; }
            DbSet<Empleados>? Empleados { get; set; }
            DbSet<Pedidos>? Pedidos { get; set; }
            DbSet<PedidosProductos>? Pedidos_Productos { get; set; }
            DbSet<Facturas>? Facturas { get; set; }
            DbSet<Entregas>? Entregas { get; set; }
            DbSet<Usuarios>? Usuarios { get; set; }
            DbSet<Roles>? Roles { get; set; }
            DbSet<Auditorias>? Auditorias { get; set; }
            DbSet<CarritoCompras>? CarritoCompras { get; set; }
            DbSet<MetodosEnvio>? MetodosEnvio { get; set; }

            DatabaseFacade Database { get; }
            EntityEntry<T> Entry<T>(T entity) where T : class;
            int SaveChanges();
        }
    }

