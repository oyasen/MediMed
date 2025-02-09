using System.ComponentModel.DataAnnotations;

namespace MediMed.Dto
{
    public class NurseDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; } = string.Empty;
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

        [Required(ErrorMessage = "License number is required.")]
        [StringLength(20, ErrorMessage = "License number cannot exceed 20 characters.")]
        public string LicenseNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Contact { get; set; } = string.Empty;

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

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; } = string.Empty; // Address

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, ErrorMessage = "Location cannot exceed 100 characters.")]
        public string Location { get; set; } = string.Empty; // Location
    }
}
