using Aplicaciones_libreria.Entidades;
using Aplicaciones_libreria.Interfaces;
using Libreria_repositorios.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace Aplicaciones_libreria.Implementaciones
{
    public class ClientesNegocio : IClientesNegocio
    {
        private IConexion? _conexion;

        public List<Clientes> Consultar()
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            return _conexion.Clientes!
                .Include(c => c.TipoCliente)
                .Include(c => c.Ciudad)
                .ToList();
        }

        public Clientes Guardar(Clientes entidad)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            _conexion.Clientes!.Add(entidad);
            _conexion.SaveChanges();
            return entidad;
        }

        public Clientes Modificar(Clientes entidad)
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
            var entidad = _conexion.Clientes!.Find(id);
            if (entidad != null)
            {
                _conexion.Clientes.Remove(entidad);
                _conexion.SaveChanges();
                return true;
            }
            return false;
        }

        //  MÉTODOS EXTRA
        public string? ObtenerCodigoDescuentoCliente(int idCliente)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var cliente = _conexion.Clientes!
                .Include(c => c.TipoCliente)
                .FirstOrDefault(c => c.Id == idCliente);

            if (cliente == null || cliente.TipoCliente == null) return null;

            // Generar código: CLIENTE + ID + NOMBRES + FECHA
            string nombreLimpio = cliente.Nombre!.Replace(" ", "").ToUpper();
            return $"CLIENTE_{idCliente}_{nombreLimpio}_{DateTime.Now:yyyyMMdd}";
        }

        public bool CanjearCodigoDescuento(int idCliente, string codigo)
        {
            _conexion = new Conexion();
            _conexion.StringConexion = Configuraciones.obtener("StringConexion");
            var cliente = _conexion.Clientes!.Find(idCliente);
            if (cliente == null) return false;

            // Validar que el código corresponde al cliente
            var codigoValido = ObtenerCodigoDescuentoCliente(idCliente);
            if (codigoValido == codigo)
            {
                // Registrar canje (podrías tener una tabla de códigos canjeados)
                // Por ahora solo retorna true
                return true;
            }
            return false;
        }
    }
}