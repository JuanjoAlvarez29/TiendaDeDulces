
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface ITiposClienteNegocio
    {
        List<TiposCliente> Consultar();
        TiposCliente Guardar(TiposCliente entidad);
        TiposCliente Modificar(TiposCliente entidad);
        bool Borrar(int id);

        // Métodos extra
        string GenerarCodigoDescuento(int idTipoCliente);
        decimal AplicarDescuentoPorCodigo(string codigo, decimal montoOriginal);
    }
}