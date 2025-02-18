using System.ComponentModel.DataAnnotations;

namespace MediMed.Dto
{
    public class NurseDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(50, ErrorMessage = "Full name cannot exceed 50 characters.")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty; // New field

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character."
    )]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Contact { get; set; } = string.Empty;
        [Required(ErrorMessage = "Specialaization is required.")]
        [StringLength(50, ErrorMessage = "Specialaization cannot exceed 50 characters.")]
        public string Specialaization { get; set; } = string.Empty;
        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; } = string.Empty;
        [Required(ErrorMessage = "Professional practice license link is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        public string ProfessionalPracticeLicense { get; set; } = string.Empty; // شهاده مزاوله المهنه (link)

        [Required(ErrorMessage = "Graduation certificate link is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        public string GraduationCertificate { get; set; } = string.Empty; // شهاده التخرج (link)

        [Required(ErrorMessage = "ID card link is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        public string IDCard { get; set; } = string.Empty; // البطاقه (link)

        [Required(ErrorMessage = "Criminal record and identification link are required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        public string CriminalRecordAndIdentification { get; set; } = string.Empty; // فيش و تشبيه (link)
    }
}
