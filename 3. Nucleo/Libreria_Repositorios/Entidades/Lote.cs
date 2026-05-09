using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Lote
    {
        [Key] public int Id { get; set; }
        public DateTime FechaFabricacion { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int Cantidad { get; set; }
        public bool Activo { get; set; } = true;
        public int IdProducto { get; set; }
        public Productos? Producto { get; set; }

       
    }
}
