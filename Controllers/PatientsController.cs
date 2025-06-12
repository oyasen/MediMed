using MediMed.Dto;
using MediMed.Repo.Implementation;
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
            try
            {
                var id = await _patientRepo.CreatePatient(patientDto);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost("{patientId}/assign-nurse/{nurseId}")]
        public async Task<IActionResult> AssignNurseToPatient(int patientId, int nurseId,string status,string description)
        {
            try
            {
                await _patientRepo.AssignNurseToPatient(patientId, nurseId, status,description);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPut("update-nurse/{id}")]
        public async Task<IActionResult> UpdateNurseToPatient(int Id, string status)
        {
            try
            {
                await _patientRepo.UpdateNursePatient(Id, status);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("remove-nurse/{Id}")]
        public async Task<IActionResult> RemoveNurseFromPatient(int Id)
        {
            try
            {
                await _patientRepo.RemoveNurseFromPatient(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{patientId}/nurses")]
        public async Task<IActionResult> GetNursesByPatientId(int patientId)
        {
            var nurses = await _patientRepo.GetNursesByPatientId(patientId);
            return Ok(nurses);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var id = await _patientRepo.Login(loginDto);
            return Ok(id);
        }
        [HttpPost("forget")]
        public async Task<IActionResult> Forget(LoginDto loginDto)
        {
            var updated = await _patientRepo.forget(loginDto);
            return Ok(updated);
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
                var updated = await _patientRepo.UpdatePatient(id, patientDto);
                return Accepted(updated);
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
