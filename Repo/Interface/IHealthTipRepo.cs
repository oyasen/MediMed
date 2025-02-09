using MediMed.Dto;
using MediMed.Models;

namespace MediMed.Repo.Interface
{
    public interface IHealthTipRepo
    {
        Task CreateHealthTip(HealthTipDto healthTipDto);
        Task<List<HealthTipDto>> GetAllHealthTips();
        Task<HealthTipDto?> GetHealthTipById(int id);
        Task UpdateHealthTip(int id, HealthTipDto healthTipDto);
        Task DeleteHealthTip(int id);
    }
}
