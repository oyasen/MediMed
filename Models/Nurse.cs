namespace MediMed.Models
{
    public class Nurse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty; // Phone number
        public string ProfessionalPracticeLicense { get; set; } = string.Empty; // شهاده مزاوله المهنه (link)
        public string GraduationCertificate { get; set; } = string.Empty; // شهاده التخرج (link)
        public string IDCard { get; set; } = string.Empty;// البطاقه (link)
        public string CriminalRecordAndIdentification { get; set; } = string.Empty; // فيش و تشبيه (link)
        public string Address { get; set; } = string.Empty;// Address
        public string Location { get; set; } = string.Empty;// Location
        public ICollection<NursePatient> NursePatients { get; set; } = new List<NursePatient>();
    }
}
