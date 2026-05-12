
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IMovimientoInventarioNegocio
    {
        List<MovimientoInventario> Consultar();
        MovimientoInventario Guardar(MovimientoInventario entidad);
        MovimientoInventario Modificar(MovimientoInventario entidad);
        bool Borrar(int id);
    }
}