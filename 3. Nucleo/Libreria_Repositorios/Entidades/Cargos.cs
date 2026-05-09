using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Cargos
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Salario { get; set; }
        public bool Activo { get; set; } = true;
        public List<Empleados> Empleados { get; set; } = new List<Empleados>();
    }
}
