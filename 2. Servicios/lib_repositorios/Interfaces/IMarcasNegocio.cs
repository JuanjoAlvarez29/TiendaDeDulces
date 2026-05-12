
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IMarcasNegocio
    {
        List<Marcas> Consultar();
        Marcas Guardar(Marcas entidad);
        Marcas Modificar(Marcas entidad);
        bool Borrar(int id);
    }
}