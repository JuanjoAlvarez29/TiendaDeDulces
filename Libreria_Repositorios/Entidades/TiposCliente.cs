using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class TiposCliente
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Descuento { get; set; }
        public bool Activo { get; set; } = true;
        public List<Clientes> Clientes { get; set; } = new List<Clientes>();
    }
}
