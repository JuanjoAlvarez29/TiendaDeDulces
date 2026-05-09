using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class Productos
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Activo { get; set; } = true;
        public int IdCategoria { get; set; }
        public Categorias? Categoria { get; set; }
        public int IdMarca { get; set; }
        public Marcas? Marca { get; set; }
        public List<Lote> Lotes { get; set; } = new List<Lote>();
        public List<MovimientoInventario> MovInventarios { get; set; } = new List<MovimientoInventario>();
        public List<Promociones> Promociones { get; set; } = new List<Promociones>();
        public List<PedidosProductos> PedidosProductos { get; set; } = new List<PedidosProductos>();

        
    }
}
