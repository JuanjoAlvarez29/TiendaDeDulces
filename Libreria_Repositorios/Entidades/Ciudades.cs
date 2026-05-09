using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Ciudades
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Departamento { get; set; }
        public string? CodigoPostal { get; set; }
        public bool Activo { get; set; } = true;
        public int IdPais { get; set; }
        public Paises? Pais { get; set; }
        public List<Clientes> Clientes { get; set; } = new List<Clientes>();
        public List<Entregas> Entregas { get; set; } = new List<Entregas>();
    }
}
