using CourseProject_1.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseProject_1.Data;

public class HospitalContext:DbContext
{
    public HospitalContext()
    {
            
    }

    public HospitalContext(DbContextOptions options) : base(options)
    {
            
    }

    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Diagnosis> Diagnoses { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
       
        modelBuilder.Entity<Patient>().HasOne(e => e.Doctor).WithMany(e => e.Patients)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Patient>().HasOne(e => e.Diagnosis).WithMany(e => e.Patients)
            .OnDelete(DeleteBehavior.NoAction);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=HospitalContext;Trusted_Connection=True;Integrated Security=True;");
        }
        base.OnConfiguring(optionsBuilder);
    }
}