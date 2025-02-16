using AutoMapper;
using MediMed.Data;
using MediMed.Dto;
using MediMed.Models;
using MediMed.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace MediMed.Repo.Implementation
{
    public class AdminRepo : IAdminRepo
    {
        private readonly AppDbContext _context;
        public AdminRepo(AppDbContext context)
        {
            _context = context;
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

        public async Task CreateAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<Admin?> GetAdminById(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task UpdateAdmin(int id, Admin newadmin)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                throw new Exception("Admin not found.");
            }
            admin.Email = newadmin.Email;
            admin.Password = newadmin.Password;
            admin.UserName = newadmin.UserName;
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                throw new Exception("Admin not found.");
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateNurse(int id, bool approved , string? message)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                throw new Exception("Nurse not found.");
            }
            nurse.Approved = approved;
            nurse.Message = message;

            _context.Nurses.Update(nurse);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
