
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface ILoteNegocio
    {
        List<Lote> Consultar();
        Lote Guardar(Lote entidad);
        Lote Modificar(Lote entidad);
        bool Borrar(int id);

        // Métodos extra
        bool EsStockCritico(int id, int minimo);
        bool EstaVencido(int id);
    }
}