
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IUsuariosNegocio
    {
        List<Usuarios> Consultar();
        Usuarios Guardar(Usuarios entidad);
        Usuarios Modificar(Usuarios entidad);
        bool Borrar(int id);
    }
}