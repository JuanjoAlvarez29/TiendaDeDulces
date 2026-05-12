
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IClientesNegocio
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        bool Borrar(int id);

        // Métodos extra
        string? ObtenerCodigoDescuentoCliente(int idCliente);
        bool CanjearCodigoDescuento(int idCliente, string codigo);
    }
}