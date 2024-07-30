using System.ComponentModel.DataAnnotations;

namespace SharedClasses
{
    public class ProductoDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "El código es obligatorio.")]
        [StringLength(255, ErrorMessage = "El código no puede tener más de 255 caracteres.")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(350, ErrorMessage = "La descripción no puede tener más de 350 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La {0} es obligatoria.")]
        public int Cantidad { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Seleccione una marca.")]
        public long IdMarca { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Seleccione una categoría.")]
        public long IdCategoria { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }
    }
}
