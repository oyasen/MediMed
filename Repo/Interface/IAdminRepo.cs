using MediMed.Dto;
using MediMed.Models;

namespace MediMed.Repo.Interface
{
    public interface IAdminRepo
    {
        Task CreateAdmin(Admin admin);
        Task<List<Admin>> GetAllAdmins();
        Task<Admin?> GetAdminById(int id);
        Task UpdateAdmin(int id, Admin admin);
        Task<bool> UpdateNurse(int id, bool approved , string? message);
        Task<bool> UpdatePatient(int id, bool approved , string? message);
        Task DeleteAdmin(int id);
        Task<int> Login(LoginDto loginDto);
    }
}
