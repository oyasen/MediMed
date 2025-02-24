using System.ComponentModel.DataAnnotations;

namespace MediMed.Dto
{
    public class PatientDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(50, ErrorMessage = "Full name cannot exceed 50 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character."
        )]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(10, ErrorMessage = "Gender cannot exceed 10 characters.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Contact { get; set; } = string.Empty;

        [Required(ErrorMessage = "ID card image is required.")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Invalid Image URL.")]
        public string IDCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Personal picture is required.")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Invalid Image URL.")]
        public string PersonalPicture { get; set; } = string.Empty;

        public string Approved { get; set; } = "Processing";

        [StringLength(50, ErrorMessage = "Message cannot exceed 50 characters.")]
        public string Message { get; set; } = string.Empty;
    }
}
