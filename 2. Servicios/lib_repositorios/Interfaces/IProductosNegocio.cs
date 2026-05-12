
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IProductosNegocio
    {
        List<Productos> Consultar();
        Productos Guardar(Productos entidad);
        Productos Modificar(Productos entidad);
        bool Borrar(int id);

        // Método extra
        decimal CalcularGanancia(int id);
    }
}