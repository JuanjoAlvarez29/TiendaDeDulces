
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface ICarritoComprasNegocio
    {
        List<CarritoCompras> Consultar();
        CarritoCompras Guardar(CarritoCompras entidad);
        CarritoCompras Modificar(CarritoCompras entidad);
        bool Borrar(int id);
    }
}