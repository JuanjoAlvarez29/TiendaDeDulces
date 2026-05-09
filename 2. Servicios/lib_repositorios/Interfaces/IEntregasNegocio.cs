
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IEntregasNegocio
    {
        List<Entregas> Consultar();
        Entregas Guardar(Entregas entidad);
        Entregas Modificar(Entregas entidad);
        bool Borrar(int id);
    }
}