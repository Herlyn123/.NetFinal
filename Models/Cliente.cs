using System;
using System.Collections.Generic;

namespace TallerFinal.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public int? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
