
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface ICategoriasNegocio
    {
        List<Categorias> Consultar();
        Categorias Guardar(Categorias entidad);
        Categorias Modificar(Categorias entidad);
        bool Borrar(int id);
    }
}