using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TallerFinal.Models.ViewModels
{
    public class VentasViewModels
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


        // Lista  de los clientes
        public List<SelectListItem> OpcionesDeClientes { get; set; }
    }
}