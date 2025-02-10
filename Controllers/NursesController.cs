using MediMed.Dto;
using MediMed.Repo.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class NursesController : ControllerBase
{
    private readonly INurseRepo _nurseRepo;

    public NursesController(INurseRepo nurseRepo)
    {
        _nurseRepo = nurseRepo;
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> CreateNurse(NurseDto nurseDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        int id = await _nurseRepo.CreateNurse(nurseDto);
        return Ok(id);
    }
    [HttpPost("{nurseId}/assign-patient/{patientId}")]
    public async Task<IActionResult> AssignPatientToNurse(int nurseId, int patientId,int newPrice,string status)
    {
        await _nurseRepo.UpdateNursePatient(nurseId, patientId, newPrice,status);
        return Ok();
    }

    [HttpPost("{nurseId}/remove-patient/{patientId}")]
    public async Task<IActionResult> RemovePatientFromNurse(int nurseId, int patientId)
    {
        await _nurseRepo.RemovePatientFromNurse(nurseId, patientId);
        return Ok();
    }

    [HttpGet("{nurseId}/patients")]
    public async Task<IActionResult> GetPatientsByNurseId(int nurseId)
    {
        var patients = await _nurseRepo.GetPatientsByNurseId(nurseId);
        return Ok(patients);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var id = await _nurseRepo.Login(email, password);
        return Ok(id);
    }

    // Read (Get All)
    [HttpGet]
    public async Task<IActionResult> GetAllNurses()
    {
        var nurses = await _nurseRepo.GetAllNurses();
        return Ok(nurses);
    }

    // Read (Get by Id)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNurseById(int id)
    {
        var nurse = await _nurseRepo.GetNurseById(id);
        if (nurse == null)
        {
            return NotFound("Nurse not found.");
        }
        return Ok(nurse);
    }

    // Update
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNurse(int id, NurseDto nurseDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _nurseRepo.UpdateNurse(id, nurseDto);
            return Accepted();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNurse(int id)
    {
        try
        {
            await _nurseRepo.DeleteNurse(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}