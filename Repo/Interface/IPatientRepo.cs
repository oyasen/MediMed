using MediMed.Dto;
using MediMed.Models;

namespace MediMed.Repo.Interface
{
    public interface IPatientRepo
    {
        Task CreatePatient(PatientDto patientDto);
        Task<List<Patient>> GetAllPatients();
        Task<Patient?> GetPatientById(int id);
        Task UpdatePatient(int id, PatientDto patientDto);
        Task DeletePatient(int id);
        Task<bool> Login(string email, string password);
    }
}
