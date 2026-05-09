using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Usuarios
    {
        [Key] public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public int IdRol { get; set; }
        public Roles? Rol { get; set; }
        public List<Auditorias>? Auditorias { get; set; }
    }
}
