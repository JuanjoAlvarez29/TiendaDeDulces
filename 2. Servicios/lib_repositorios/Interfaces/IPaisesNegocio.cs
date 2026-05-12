
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IPaisesNegocio
    {
        List<Paises> Consultar();
        Paises Guardar(Paises entidad);
        Paises Modificar(Paises entidad);
        bool Borrar(int id);
    }
}