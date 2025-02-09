using MediMed.Dto;
using MediMed.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;

        public PatientsController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        // Create
        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _patientRepo.CreatePatient(patientDto);
            return Created();
        }
        [HttpPost("{patientId}/assign-nurse/{nurseId}")]
        public async Task<IActionResult> AssignNurseToPatient(int patientId, int nurseId)
        {
            await _patientRepo.AssignNurseToPatient(patientId, nurseId);
            return Ok();
        }

        [HttpPost("{patientId}/remove-nurse/{nurseId}")]
        public async Task<IActionResult> RemoveNurseFromPatient(int patientId, int nurseId)
        {
            await _patientRepo.RemoveNurseFromPatient(patientId, nurseId);
            return Ok();
        }

        [HttpGet("{patientId}/nurses")]
        public async Task<IActionResult> GetNursesByPatientId(int patientId)
        {
            var nurses = await _patientRepo.GetNursesByPatientId(patientId);
            return Ok(nurses);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var id = await _patientRepo.Login(email, password);
            return Ok(id);
        }

        // Read (Get All)
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientRepo.GetAllPatients();
            return Ok(patients);
        }

        // Read (Get by Id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientRepo.GetPatientById(id);
            if (patient == null)
            {
                return NotFound("Patient not found.");
            }
            return Ok(patient);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _patientRepo.UpdatePatient(id, patientDto);
                return Accepted();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _patientRepo.DeletePatient(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
