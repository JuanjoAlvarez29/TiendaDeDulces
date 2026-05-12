
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface ICiudadesNegocio
    {
        List<Ciudades> Consultar();
        Ciudades Guardar(Ciudades entidad);
        Ciudades Modificar(Ciudades entidad);
        bool Borrar(int id);
    }
}