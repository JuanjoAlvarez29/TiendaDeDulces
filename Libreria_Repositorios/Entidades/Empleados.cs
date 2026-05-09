using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Empleados
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Cedula { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public bool Activo { get; set; } = true;
        public int IdCargo { get; set; }
        public Cargos? Cargo { get; set; }
        public int IdCiudad { get; set; }
        public Ciudades? Ciudad { get; set; }
        public List<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
    }
}
