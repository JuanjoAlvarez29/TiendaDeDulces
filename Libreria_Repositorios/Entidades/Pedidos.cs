using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Pedidos
    {
        [Key] public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public bool Activo { get; set; } = true;
        public int IdCliente { get; set; }
        public Clientes? Cliente { get; set; }
        public int IdEmpleado { get; set; }
        public Empleados? Empleado { get; set; }
        public int IdTipoPago { get; set; }
        public TiposPago? TipoPago { get; set; }
        public int IdEstadoPedido { get; set; }
        public EstadosPedido? EstadoPedido { get; set; }
        public int IdMetodoEnvio { get; set; }
        public MetodosEnvio? MetodoEnvio { get; set; }
        public List<PedidosProductos> Pedidos_Productos { get; set; } = new List<PedidosProductos>();
        public List<Facturas> Facturas { get; set; } = new List<Facturas>();
        public List<Entregas> Entregas { get; set; } = new List<Entregas>();
    }
}
