using MediMed.Dto;
using MediMed.Models;

namespace MediMed.Repo.Interface
{
    public interface IPatientRepo
    {
        Task<int> CreatePatient(PatientDto patientDto);
        Task<List<PatientDto>> GetAllPatients();
        Task<PatientDto?> GetPatientById(int id);
        Task<bool> UpdatePatient(int id, PatientDto patientDto);
        Task<bool> UpdateNursePatient(int nurseId, int patientId, string status);
        Task<bool> DeletePatient(int id);
        Task<int> Login(LoginDto loginDto);
        Task<bool> forget(LoginDto loginDto);
        Task<bool> AssignNurseToPatient(int patientId, int nurseId,string status);
        Task<bool> RemoveNurseFromPatient(int patientId, int nurseId);
        Task<List<NursePatientDto>> GetNursesByPatientId(int patientId);
    }
}
