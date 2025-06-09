using MediMed.Models;
using Microsoft.EntityFrameworkCore;

namespace MediMed.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<HealthTip> HealthTips { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<NursePatient> NursePatients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NursePatient>()
                .HasOne(np => np.Nurse)
                .WithMany(n => n.NursePatients)
                .HasForeignKey(np => np.NurseId);

            modelBuilder.Entity<NursePatient>()
                .HasOne(np => np.Patient)
                .WithMany(p => p.NursePatients)
                .HasForeignKey(np => np.PatientId);
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
