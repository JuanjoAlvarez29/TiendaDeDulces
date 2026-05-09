using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Promociones
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Porcentaje { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; } = true;
        public int IdProducto { get; set; }
        public Productos? Producto { get; set; }

    }
}
