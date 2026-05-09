using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Paises
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Codigo { get; set; }
        public string? Continente { get; set; }
        public bool Activo { get; set; } = true;
        public List<Ciudades> Ciudades { get; set; } = new List<Ciudades>();
        public List<Proveedores> Proveedores { get; set; } = new List<Proveedores>();
    }
}
