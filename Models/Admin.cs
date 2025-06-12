using Microsoft.EntityFrameworkCore;

namespace MediMed.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
