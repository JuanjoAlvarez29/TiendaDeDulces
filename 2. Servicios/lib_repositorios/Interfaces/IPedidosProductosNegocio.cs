
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IPedidosProductosNegocio
    {
        List<PedidosProductos> Consultar();
        PedidosProductos Guardar(PedidosProductos entidad);
        PedidosProductos Modificar(PedidosProductos entidad);
        bool Borrar(int id);
    }
}