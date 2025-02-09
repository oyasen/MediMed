using MediMed.Dto;
using MediMed.Repo.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class HealthTipsController : ControllerBase
{
    private readonly IHealthTipRepo _repo;

    public HealthTipsController(IHealthTipRepo repo)
    {
        _repo = repo;
    }

    // Create
    [HttpPost]
    public async Task<IActionResult> CreateHealthTip(HealthTipDto healthTipDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _repo.CreateHealthTip(healthTipDto);
        return Created();
    }

    // Read (Get All)
    [HttpGet]
    public async Task<IActionResult> GetAllHealthTips()
    {
        var healthTips = await _repo.GetAllHealthTips();
        return Ok(healthTips);
    }

    // Read (Get by Id)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHealthTipById(int id)
    {
        var healthTip = await _repo.GetHealthTipById(id);
        if (healthTip == null)
        {
            return NotFound("Health tip not found.");
        }
        return Ok(healthTip);
    }

    // Update
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHealthTip(int id, HealthTipDto healthTipDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _repo.UpdateHealthTip(id, healthTipDto);
            return Accepted();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHealthTip(int id)
    {
        try
        {
            await _repo.DeleteHealthTip(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}