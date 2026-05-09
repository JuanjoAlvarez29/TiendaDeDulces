using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria_repositorios.Entidades
{
    public class PedidosProductos
    {
        [Key] public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public bool Activo { get; set; } = true;
        public int IdPedido { get; set; }
        public Pedidos? Pedido { get; set; }
        public int IdProducto { get; set; }
        public Productos? Producto { get; set; }
    }
}
