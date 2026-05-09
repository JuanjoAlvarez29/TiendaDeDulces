using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class MetodosEnvio
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty; // Domicilio, Recogida en tienda, Envío nacional
        public string? Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int DiasEstimados { get; set; }
        public bool Activo { get; set; } = true;
        public List<Pedidos>? Pedidos { get; set; }
    }
}
