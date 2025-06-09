namespace MediMed.Repo.Interface
{
    using MediMed.Dto;
    using MediMed.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INurseRepo
    {
        Task<int> CreateNurse(NurseDto nurseDto);
        Task<List<NurseDto>> GetAllNurses();
        Task<NurseDto?> GetNurseById(int id);
        Task<bool> UpdateNurse(int id, NurseDto nurseDto);
        Task<bool> DeleteNurse(int id);
        Task<int> Login(LoginDto loginDto);
        Task<bool> forget(LoginDto loginDto);
        Task<bool> UpdateNursePatient(int Id, double newPrice, string status);
        Task<bool> RemovePatientFromNurse(int Id);
        Task<List<NursePatientDto>> GetPatientsByNurseId(int nurseId);
    }
}
