namespace MediMed.Repo.Interface
{
    using MediMed.Dto;
    using MediMed.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INurseRepo
    {
        Task CreateNurse(NurseDto nurseDto);
        Task<List<NurseDto>> GetAllNurses();
        Task<NurseDto?> GetNurseById(int id);
        Task UpdateNurse(int id, NurseDto nurseDto);
        Task DeleteNurse(int id);
        Task<int> Login(string email, string password);
        Task AssignPatientToNurse(int nurseId, int patientId);
        Task RemovePatientFromNurse(int nurseId, int patientId);
        Task<List<Patient>> GetPatientsByNurseId(int nurseId);
    }
}
