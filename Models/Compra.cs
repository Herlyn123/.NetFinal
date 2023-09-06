using System;
using System.Collections.Generic;

namespace TallerFinal.Models
{
    public partial class Compra
    {
        public int CompraId { get; set; }
        public double? PrecioTotal { get; set; }
        public DateTime? FechaCompra { get; set; }
        public string? Estado { get; set; }
        public int? ProveedorId { get; set; }

        public virtual Proveedor? Proveedor { get; set; }
    }
}
