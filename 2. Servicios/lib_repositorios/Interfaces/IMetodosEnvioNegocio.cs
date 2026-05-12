
using Libreria_repositorios.Entidades;

namespace Aplicaciones_libreria.Interfaces
{
    public interface IMetodosEnvioNegocio
    {
        List<MetodosEnvio> Consultar();
        MetodosEnvio Guardar(MetodosEnvio entidad);
        MetodosEnvio Modificar(MetodosEnvio entidad);
        bool Borrar(int id);
    }
}