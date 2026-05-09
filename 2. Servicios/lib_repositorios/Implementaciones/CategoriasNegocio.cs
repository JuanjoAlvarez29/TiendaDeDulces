
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class CategoriasNegocio : ICategoriasNegocio
    {
        private IConexion? _conexion;

        public List<Categorias> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Categorias!.ToList();
        }

        public Categorias Guardar(Categorias entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Categorias!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Categorias Modificar(Categorias entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var entry = _conexion.Entry(entidad);
            entry.State = EntityState.Modified;
            _conexion.SaveChanges();
            return entidad;
        }

        public bool Borrar(int id)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var entidad = _conexion.Categorias!.Find(id);
            if (entidad != null)
            {
                _conexion.Categorias.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }
    }
}