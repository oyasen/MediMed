using MediMed.Dto;
using MediMed.Models;
using MediMed.Repo.Implementation;
using MediMed.Repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminRepo _repo;
        private readonly INurseRepo _nurserepo;

        public AdminsController(IAdminRepo repo,INurseRepo nurseRepo)
        {
            _repo = repo;
            _nurserepo = nurseRepo;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var id = await _repo.Login(loginDto);
            return Ok(id);
        }
        [HttpPost("CreateNurse")]
        public async Task<IActionResult> CreateNurse(NurseDto nurseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = await _nurserepo.CreateNurse(nurseDto);
            return Ok(id);
        }
        [HttpPut("UpdateNurse/{id}")]
        public async Task<IActionResult> UpdateNurse(int id, bool approved, string? message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _repo.UpdateNurse(id, approved,message);
                return Accepted();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("DeleteNurse/{id}")]
        public async Task<IActionResult> DeleteNurse(int id)
        {
            try
            {
                await _nurserepo.DeleteNurse(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetNurse/{id}")]
        public async Task<IActionResult> GetNurseById(int id)
        {
            var nurse = await _nurserepo.GetNurseById(id);
            if (nurse == null)
            {
                return NotFound("Nurse not found.");
            }
            return Ok(nurse);
        }
        [HttpGet("GetNurses")]
        public async Task<IActionResult> GetAllNurses()
        {
            var nurses = await _nurserepo.GetAllNurses();
            return Ok(nurses);
        }
        // Create
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repo.CreateAdmin(admin);
            return Created();
        }

        // Read (Get All)
        [HttpGet]
        public async Task<IActionResult> GetAllHealthTips()
        {
            var admins = await _repo.GetAllAdmins();
            return Ok(admins);
        }

        // Read (Get by Id)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHealthTipById(int id)
        {
            var admin = await _repo.GetAdminById(id);
            if (admin == null)
            {
                return NotFound("Admin not found.");
            }
            return Ok(admin);
        }

        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHealthTip(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _repo.UpdateAdmin(id, admin);
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
                await _repo.DeleteAdmin(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
