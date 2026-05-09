
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Aplicaciones_libreria.Implementaciones
{
    public class TiposClienteNegocio : ITiposClienteNegocio
    {
        private IConexion? _conexion;

        public List<TiposCliente> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.TiposCliente!.ToList();
        }

        public TiposCliente Guardar(TiposCliente entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.TiposCliente!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public TiposCliente Modificar(TiposCliente entidad)
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
            var entidad = _conexion.TiposCliente!.Find(id);
            if (entidad != null)
            {
                _conexion.TiposCliente.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }

        //MÉTODOS EXTRA
        public string GenerarCodigoDescuento(int idTipoCliente)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var tipoCliente = _conexion.TiposCliente!.Find(idTipoCliente);
            if (tipoCliente == null) return string.Empty;

            // Generar código: TIPO + ID + FECHA (ej: MAYORISTA_5_20260507)
            string nombreLimpio = tipoCliente.Nombre!.Replace(" ", "").ToUpper();
            return $"{nombreLimpio}_{idTipoCliente}_{DateTime.Now:yyyyMMddHHmmss}";
        }

        public decimal AplicarDescuentoPorCodigo(string codigo, decimal montoOriginal)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");

            // Buscar tipo cliente por código 
            var partes = codigo.Split('_');
            if (partes.Length < 2) return montoOriginal;

            if (int.TryParse(partes[1], out int idTipoCliente))
            {
                var tipoCliente = _conexion.TiposCliente!.Find(idTipoCliente);
                if (tipoCliente != null)
                {
                    return montoOriginal - (montoOriginal * tipoCliente.Descuento / 100);
                }
            }
            return montoOriginal;
        }
    }
}