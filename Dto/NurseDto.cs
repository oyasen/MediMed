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
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Contact { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        public DateOnly DateOfBirth { get; set; }

        [StringLength(10, ErrorMessage = "Gender cannot exceed 10 characters.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Specialization is required.")]
        [StringLength(50, ErrorMessage = "Specialization cannot exceed 50 characters.")]
        public string Specialaization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Professional practice license link is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        [DataType(DataType.ImageUrl)]
        public string ProfessionalPracticeLicense { get; set; } = string.Empty; // شهاده مزاوله المهنه (link)

        [Required(ErrorMessage = "Graduation certificate link is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        [DataType(DataType.ImageUrl)]
        public string GraduationCertificate { get; set; } = string.Empty; // شهاده التخرج (link)

        [Required(ErrorMessage = "ID card link is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        [DataType(DataType.ImageUrl)]
        public string IDCard { get; set; } = string.Empty; // البطاقه (link)

        [Required(ErrorMessage = "Personal picture link is required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        [DataType(DataType.ImageUrl)]
        public string PersonalPicture { get; set; } = string.Empty;

        [Required(ErrorMessage = "Criminal record and identification link are required.")]
        [Url(ErrorMessage = "Invalid URL.")]
        [DataType(DataType.ImageUrl)]
        public string CriminalRecordAndIdentification { get; set; } = string.Empty; // فيش و تشبيه (link)

        public string Approved { get; set; } = "Processing";

        [StringLength(50, ErrorMessage = "Message cannot exceed 50 characters.")]
        public string Message { get; set; } = string.Empty;
    }
}
