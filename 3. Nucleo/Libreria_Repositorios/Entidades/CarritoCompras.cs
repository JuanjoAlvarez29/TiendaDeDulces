using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class CarritoCompras
    {
        [Key] public int Id { get; set; }
        public string? SesionId { get; set; }
        public int IdCliente { get; set; }
        public Clientes? Cliente { get; set; }
        public int IdProducto { get; set; }
        public Productos? Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
        public DateTime FechaAgregado { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;
    }
}
