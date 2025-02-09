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
        public async Task CreatePatient(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        // Read (Get All)
        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        // Read (Get by Id)
        public async Task<Patient?> GetPatientById(int id)
        {
            return await _context.Patients.FindAsync(id);
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
