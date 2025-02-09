namespace MediMed.Repo.Interface
{
    using MediMed.Dto;
    using MediMed.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INurseRepo
    {
        Task CreateNurse(NurseDto nurseDto);
        Task<List<Nurse>> GetAllNurses();
        Task<Nurse?> GetNurseById(int id);
        Task UpdateNurse(int id, NurseDto nurseDto);
        Task DeleteNurse(int id);
        Task<bool> Login(string email, string password);
    }
}
