using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public partial class Ventum
    {
        public int VentaId { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime? Fecha { get; set; }
        [Required(ErrorMessage = "El precio total es obligatorio")]
        public double? PrecioTotal { get; set; }
        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool? Estado { get; set; }
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int? ClienteId { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio")]
        public string? Producto { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}