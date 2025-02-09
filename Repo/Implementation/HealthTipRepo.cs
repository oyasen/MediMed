using AutoMapper;
using MediMed.Data;
using MediMed.Dto;
using MediMed.Models;
using MediMed.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace MediMed.Repo.Implementation
{
    public class HealthTipRepo : IHealthTipRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public HealthTipRepo(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create
        public async Task CreateHealthTip(HealthTipDto healthTipDto)
        {
            var healthTip = _mapper.Map<HealthTip>(healthTipDto);

            _context.HealthTips.Add(healthTip);
            await _context.SaveChangesAsync();
        }

        // Read (Get All)
        public async Task<List<HealthTipDto>> GetAllHealthTips()
        {
            return await _context.HealthTips.Select(h=> _mapper.Map<HealthTipDto>(h)).ToListAsync();
        }

        // Read (Get by Id)
        public async Task<HealthTipDto?> GetHealthTipById(int id)
        {
            var healthTip = await _context.HealthTips.FindAsync(id);
            return _mapper.Map<HealthTipDto>(healthTip);
        }

        // Update
        public async Task UpdateHealthTip(int id, HealthTipDto healthTipDto)
        {
            var healthTip = await _context.HealthTips.FindAsync(id);
            if (healthTip == null)
            {
                throw new Exception("Health tip not found.");
            }

            healthTip.Tip = healthTipDto.Tip;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteHealthTip(int id)
        {
            var healthTip = await _context.HealthTips.FindAsync(id);
            if (healthTip == null)
            {
                throw new Exception("Health tip not found.");
            }

            _context.HealthTips.Remove(healthTip);
            await _context.SaveChangesAsync();
        }
    }
}
