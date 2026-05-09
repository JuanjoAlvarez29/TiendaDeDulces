using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class MovimientoInventario
    {
        [Key] public int Id { get; set; }
        public int Cantidad { get; set; }
        public string? Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string? Observacion { get; set; }
        public bool Activo { get; set; } = true;
        public int IdProducto { get; set; }
        public Productos? Producto { get; set; }
    }
}
