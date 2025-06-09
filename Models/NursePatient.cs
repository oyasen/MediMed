using System.ComponentModel.DataAnnotations;

namespace MediMed.Models
{
    public class NursePatient
    {
        [Key]
        public int Id { get; set; }
        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public double Price { get; set; } = 0;
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime BookTime { get; set; }
    }
}
