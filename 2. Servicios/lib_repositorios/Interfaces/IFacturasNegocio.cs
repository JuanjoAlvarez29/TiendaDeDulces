
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IFacturasNegocio
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);
        Facturas Modificar(Facturas entidad);
        bool Borrar(int id);

        // Métodos extra
        decimal CalcularIva(int idFactura);
        decimal CalcularTotalConIva(int idFactura);
    }
}