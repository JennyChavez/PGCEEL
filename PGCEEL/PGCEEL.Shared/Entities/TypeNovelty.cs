using System.ComponentModel.DataAnnotations;

namespace PGCEEL.Shared.Entities
{
    public class TypeNovelty
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Novedad")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;
    }
}
