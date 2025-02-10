﻿using MediMed.Dto;
using MediMed.Models;

namespace MediMed.Repo.Interface
{
    public interface IPatientRepo
    {
        Task<int> CreatePatient(PatientDto patientDto);
        Task<List<PatientDto>> GetAllPatients();
        Task<PatientDto?> GetPatientById(int id);
        Task UpdatePatient(int id, PatientDto patientDto);
        Task DeletePatient(int id);
        Task<int> Login(string email, string password);
        Task AssignNurseToPatient(int patientId, int nurseId);
        Task RemoveNurseFromPatient(int patientId, int nurseId);
        Task<List<Nurse>> GetNursesByPatientId(int patientId);
    }
}
