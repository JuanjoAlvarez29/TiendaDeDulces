
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface ICargosNegocio
    {
        List<Cargos> Consultar();
        Cargos Guardar(Cargos entidad);
        Cargos Modificar(Cargos entidad);
        bool Borrar(int id);
    }
}