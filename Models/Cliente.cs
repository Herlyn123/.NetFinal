using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]

        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]

        public string? Apellido { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]

        public string? Email { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]

        public string? Telefono { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]

        public string? Direccion { get; set; }
        [Required(ErrorMessage = "Este campo es obligatoria")]

        public bool? Estado { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
