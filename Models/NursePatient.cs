namespace MediMed.Models
{
    public class NursePatient
    {
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
        public double? Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime BookTime { get; set; }
        public int PatientId { get; set; } = 0;
        public Patient Patient { get; set; }
    }
}
