using Aplicaciones_libreria.Entidades;
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IPromocionesNegocio
    {
        List<Promociones> Consultar();
        Promociones Guardar(Promociones entidad);
        Promociones Modificar(Promociones entidad);
        bool Borrar(int id);

        // Métodos extra
        decimal AplicarPromocion(int id, decimal precio);
        bool EstaVigente(int id);
    }
}