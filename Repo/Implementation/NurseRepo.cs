using AutoMapper;
using MediMed.Data;
using MediMed.Dto;
using MediMed.Models;
using MediMed.Repo.Interface;

namespace MediMed.Repo.Implementation
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NurseRepo : INurseRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public NurseRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create
        public async Task CreateNurse(NurseDto nurseDto)
        {
            var nurse = _mapper.Map<Nurse>(nurseDto);

            _context.Nurses.Add(nurse);
            await _context.SaveChangesAsync();
        }

        // Read (Get All)
        public async Task<List<Nurse>> GetAllNurses()
        {
            return await _context.Nurses.ToListAsync();
        }
        public async Task<bool> Login(string email, string password)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Email == email && p.Password == password);

            return patient != null; // Returns true if patient exists, otherwise false
        }
        // Read (Get by Id)
        public async Task<Nurse?> GetNurseById(int id)
        {
            return await _context.Nurses.FindAsync(id);
        }

        // Update
        public async Task UpdateNurse(int id, NurseDto nurseDto)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                throw new Exception("Nurse not found.");
            }

            nurse.FirstName = nurseDto.FirstName;
            nurse.LastName = nurseDto.LastName;
            nurse.LicenseNumber = nurseDto.LicenseNumber;
            nurse.Contact = nurseDto.Contact;
            nurse.ProfessionalPracticeLicense = nurseDto.ProfessionalPracticeLicense;
            nurse.GraduationCertificate = nurseDto.GraduationCertificate;
            nurse.IDCard = nurseDto.IDCard;
            nurse.CriminalRecordAndIdentification = nurseDto.CriminalRecordAndIdentification;
            nurse.Address = nurseDto.Address;
            nurse.Location = nurseDto.Location;

            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id) ?? throw new Exception("Nurse not found.");
            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();
        }
    }
}
