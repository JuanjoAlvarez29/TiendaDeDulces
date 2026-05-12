
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IPedidosNegocio
    {
        List<Pedidos> Consultar();
        Pedidos Guardar(Pedidos entidad);
        Pedidos Modificar(Pedidos entidad);
        bool Borrar(int id);

        // Método extra
        decimal CalcularTotal(int id);
    }
}