using System.ComponentModel.DataAnnotations;

namespace MediMed.Dto
{
    public class NursePatientDto
    {
        public int Id { get; set; }
        public int NurseId { get; set; }
        public NurseDto? Nurse { get; set; }

        public double? Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = "BookTime is required.")]
        [DataType(DataType.DateTime)]
        public DateTime BookTime { get; set; }


        public int PatientId { get; set; } = 0;
        public PatientDto? Patient { get; set; }
    }
}
