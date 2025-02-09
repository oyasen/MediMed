using System.ComponentModel.DataAnnotations;

namespace MediMed.Dto
{
    public class HealthTipDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tip is required.")]
        [StringLength(500, ErrorMessage = "Tip cannot exceed 500 characters.")]
        public string Tip { get; set; } = string.Empty;
    }
}
