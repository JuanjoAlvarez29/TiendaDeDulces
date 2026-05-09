using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Auditorias
    {
        [Key] public int Id { get; set; }
        public string TablaNombre { get; set; } = string.Empty;
        public int RegistroId { get; set; }
        public string Accion { get; set; } = string.Empty; // CREATE, UPDATE, DELETE
        public string? ValorAnterior { get; set; }
        public string? ValorNuevo { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int IdUsuario { get; set; }
        public Usuarios? Usuario { get; set; }
    }
}
