using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Compras = new HashSet<Compra>();
        }

        public int ProveedorId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]
        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]
        public string? Contacto { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]
        public bool? Estado { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
