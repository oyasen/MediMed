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
        public async Task<int> CreateNurse(NurseDto nurseDto)
        {
            try
            {
                var nurse = _mapper.Map<Nurse>(nurseDto);
                _context.Nurses.Add(nurse);
                await _context.SaveChangesAsync();
                return nurse.Id;
            }
            catch
            {
                return 0;
            }
        }

        // Read (Get All)
        public async Task<List<NurseDto>> GetAllNurses()
        {
            return await _context.Nurses.Select(n=> _mapper.Map<NurseDto>(n)).ToListAsync();
        }
        public async Task<int> Login(LoginDto loginDto)
        {
            var nurse = await _context.Nurses
                .FirstOrDefaultAsync(p => p.Email == loginDto.Email && p.Password == loginDto.Password);
            if(nurse == null)
            {
                return 0;
            }
            return nurse.Id; // Returns id if patient exists, otherwise false
        }
        public async Task<bool> UpdateNursePatient(int id, double newPrice, string status)
        {
            var nursePatient = await _context.NursePatients
                .FirstOrDefaultAsync(np => np.Id == id);

            if (nursePatient == null)
            {
                throw new KeyNotFoundException("Assignment not found.");
            }
            nursePatient.Status = status;
            nursePatient.Price = newPrice; // Update the price or other fields if needed

            _context.NursePatients.Update(nursePatient);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> RemovePatientFromNurse(int Id)
        {
            var nursePatient = await _context.NursePatients
                .FirstOrDefaultAsync(np => np.Id == Id);

            if (nursePatient != null)
            {
                _context.NursePatients.Remove(nursePatient);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<NursePatientDto>> GetPatientsByNurseId(int nurseId)
        {
            var patients = await _context.NursePatients
                .Where(np => np.NurseId == nurseId)
                .Include(np => np.Patient).Select(np => _mapper.Map<NursePatientDto>(np))
                .ToListAsync();

            return patients;
        }
        // Read (Get by Id)
        public async Task<NurseDto?> GetNurseById(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            return _mapper.Map<NurseDto>(nurse);
        }

        // Update
        public async Task<bool> UpdateNurse(int id, NurseDto nurseDto)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                throw new Exception("Nurse not found.");
            }

            nurse.FullName = nurseDto.FullName;
            nurse.Email = nurseDto.Email;
            nurse.Password = nurseDto.Password;
            nurse.Contact = nurseDto.Contact;
            nurse.Specialaization = nurseDto.Specialaization;
            nurse.ProfessionalPracticeLicense = nurseDto.ProfessionalPracticeLicense;
            nurse.GraduationCertificate = nurseDto.GraduationCertificate;
            nurse.IDCard = nurseDto.IDCard;
            nurse.CriminalRecordAndIdentification = nurseDto.CriminalRecordAndIdentification;
            nurse.Approved = nurseDto.Approved;
            nurse.Message = nurseDto.Message;
            nurse.Location = nurseDto.Location;
            nurse.DateOfBirth = nurseDto.DateOfBirth;
            nurse.Gender = nurseDto.Gender;
            nurse.PersonalPicture = nurseDto.PersonalPicture;

            _context.Nurses.Update(nurse);
            return await _context.SaveChangesAsync() > 0;
        }


        // Delete
        public async Task<bool> DeleteNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id) ?? throw new Exception("Nurse not found.");
            _context.Nurses.Remove(nurse);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> forget(LoginDto loginDto) 
        {
            var nurse = await _context.Nurses
                .FirstOrDefaultAsync(p => p.Email == loginDto.Email);
            if (nurse == null)
            {
                return false;
            }
            nurse.Password = loginDto.Password;
            _context.Nurses.Update(nurse);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
