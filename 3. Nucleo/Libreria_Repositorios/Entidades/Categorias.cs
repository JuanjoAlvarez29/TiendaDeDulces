using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria_repositorios.Entidades
{
        public class Categorias
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public List<Productos> Productos { get; set; } = new List<Productos>();
    }
}

