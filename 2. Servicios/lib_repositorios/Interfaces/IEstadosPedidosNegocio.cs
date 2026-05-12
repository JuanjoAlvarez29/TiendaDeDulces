
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IEstadosPedidoNegocio
    {
        List<EstadosPedido> Consultar();
        EstadosPedido Guardar(EstadosPedido entidad);
        EstadosPedido Modificar(EstadosPedido entidad);
        bool Borrar(int id);
    }
}