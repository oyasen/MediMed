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
        public async Task<int> Login(string email, string password)
        {
            var nurse = await _context.Nurses
                .FirstOrDefaultAsync(p => p.Email == email && p.Password == password);
            if(nurse == null)
            {
                return 0;
            }
            return nurse.Id; // Returns true if patient exists, otherwise false
        }
        public async Task UpdateNursePatient(int nurseId, int patientId, int newPrice, string status)
        {
            var nursePatient = await _context.NursePatients
                .FirstOrDefaultAsync(np => np.NurseId == nurseId && np.PatientId == patientId);

            if (nursePatient == null)
            {
                throw new KeyNotFoundException("Assignment not found.");
            }
            nursePatient.Status = status;
            nursePatient.Price = newPrice; // Update the price or other fields if needed

            _context.NursePatients.Update(nursePatient);
            await _context.SaveChangesAsync();
        }


        public async Task RemovePatientFromNurse(int nurseId, int patientId)
        {
            var nursePatient = await _context.NursePatients
                .FirstOrDefaultAsync(np => np.NurseId == nurseId && np.PatientId == patientId);

            if (nursePatient != null)
            {
                _context.NursePatients.Remove(nursePatient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Patient>> GetPatientsByNurseId(int nurseId)
        {
            var patients = await _context.NursePatients
                .Where(np => np.NurseId == nurseId)
                .Select(np => np.Patient)
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
