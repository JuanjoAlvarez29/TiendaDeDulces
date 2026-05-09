using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Proveedores
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool Activo { get; set; } = true;
        public int IdPais { get; set; }
        public Paises? Pais { get; set; }
        public List<Productos> Productos { get; set; } = new List<Productos>();
        public List<CalidadProveedor> CalidadProveedores { get; set; } = new List<CalidadProveedor>();
    }
}
