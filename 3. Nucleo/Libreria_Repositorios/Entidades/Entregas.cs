using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Entregas
    {
        [Key] public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public DateTime FechaEntrega { get; set; }
        public string? Direccion { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; } = true;
        public int IdPedido { get; set; }
        public Pedidos? Pedido { get; set; }
        public int IdEmpleado { get; set; }
        public Empleados? Empleado { get; set; }
        public int IdCiudad { get; set; }
        public Ciudades? Ciudad { get; set; }
    }
}
