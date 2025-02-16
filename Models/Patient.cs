namespace MediMed.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty; // Phone number
        public string IDCard { get; set; } = string.Empty; // البطاقه (link)
        public ICollection<NursePatient> NursePatients { get; set; } = new List<NursePatient>();
    }
}
