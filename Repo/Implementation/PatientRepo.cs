using AutoMapper;
using MediMed.Data;
using MediMed.Dto;
using MediMed.Models;
using MediMed.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace MediMed.Repo.Implementation
{
    public class PatientRepo : IPatientRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PatientRepo(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Create
        public async Task<int> CreatePatient(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient.Id;
        }

        // Read (Get All)
        public async Task<List<PatientDto>> GetAllPatients()
        {
            return await _context.Patients.Select(p=>_mapper.Map<PatientDto>(p)).ToListAsync();
        }

        // Read (Get by Id)
        public async Task<PatientDto?> GetPatientById(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            return _mapper.Map<PatientDto>(patient);
        }

        // Update
        public async Task UpdatePatient(int id, PatientDto patientDto)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new Exception("Patient not found.");
            }

            patient.FirstName = patientDto.FirstName;
            patient.LastName = patientDto.LastName;
            patient.DateOfBirth = patientDto.DateOfBirth;
            patient.Gender = patientDto.Gender;
            patient.Contact = patientDto.Contact;
            patient.IDCard = patientDto.IDCard;
            patient.Location = patientDto.Location;

            await _context.SaveChangesAsync();
        }
        public async Task<int> Login(string email, string password)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Email == email && p.Password == password);

            return patient.Id; // Returns true if patient exists, otherwise false
        }
        public async Task AssignNurseToPatient(int patientId, int nurseId)
        {
            var nursePatient = new NursePatient
            {
                PatientId = patientId,
                NurseId = nurseId
            };

            _context.NursePatients.Add(nursePatient);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveNurseFromPatient(int patientId, int nurseId)
        {
            var nursePatient = await _context.NursePatients
                .FirstOrDefaultAsync(np => np.PatientId == patientId && np.NurseId == nurseId);

            if (nursePatient != null)
            {
                _context.NursePatients.Remove(nursePatient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Nurse>> GetNursesByPatientId(int patientId)
        {
            var nurses = await _context.NursePatients
                .Where(np => np.PatientId == patientId)
                .Select(np => np.Nurse)
                .ToListAsync();

            return nurses;
        }
        // Delete
        public async Task DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new Exception("Patient not found.");
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}
