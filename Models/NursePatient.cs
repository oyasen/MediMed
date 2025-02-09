namespace MediMed.Models
{
    public class NursePatient
    {
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
