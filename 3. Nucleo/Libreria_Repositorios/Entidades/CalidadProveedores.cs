using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class CalidadProveedores
    {
        [Key] public int Id { get; set; }
        public int Calificacion { get; set; }
        public string? Comentarios { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; } = true;
        public int IdProveedor { get; set; }
        public Proveedores? Proveedor { get; set; }
    }
}
