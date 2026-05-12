using Aplicaciones_libreria.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface ICalidadProveedoresNegocio
    {
        List<CalidadProveedores> Consultar();
        CalidadProveedores Guardar(CalidadProveedores entidad);
        CalidadProveedores Modificar(CalidadProveedores entidad);
        bool Borrar(int id);
    }
}