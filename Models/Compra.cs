using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public partial class Compra
    {
        public int CompraId { get; set; }
        [Required(ErrorMessage = "El precio total es obligatorio")]
        public double? PrecioTotal { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime? FechaCompra { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool? Estado { get; set; }
        [Required(ErrorMessage = "El proveedor es obligatorio")]
        public int? ProveedorId { get; set; }

        public virtual Proveedor? Proveedor { get; set; }
    }
}
