using System.ComponentModel.DataAnnotations;

namespace MediMed.Dto
{
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty; // New field

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character."
    )]
        public string Password { get; set; } = string.Empty;
    }
}
