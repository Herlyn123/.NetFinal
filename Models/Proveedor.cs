using System;
using System.Collections.Generic;

namespace TallerFinal.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Compras = new HashSet<Compra>();
        }

        public int ProveedorId { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Contacto { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
