
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface ITiposPagoNegocio
    {
        List<TiposPago> Consultar();
        TiposPago Guardar(TiposPago entidad);
        TiposPago Modificar(TiposPago entidad);
        bool Borrar(int id);
    }
}