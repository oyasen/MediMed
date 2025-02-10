namespace MediMed.Models
{
    public class NursePatient
    {
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
        public int? Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public int PatientId { get; set; } = 0;
        public Patient Patient { get; set; }
    }
}
