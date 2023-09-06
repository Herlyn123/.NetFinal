using System;
using System.Collections.Generic;

namespace TallerFinal.Models
{
    public partial class Ventum
    {
        public int VentaId { get; set; }
        public DateTime? Fecha { get; set; }
        public double? PrecioTotal { get; set; }
        public string? Estado { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
