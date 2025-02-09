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

        await _nurseRepo.CreateNurse(nurseDto);
        return Created();
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var isValid = await _nurseRepo.Login(email, password);
        return Ok(isValid);
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