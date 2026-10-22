using Microsoft.EntityFrameworkCore;
using Trail_A.Models;

namespace JobPortal.Data
{
    public class App_Database_Context : DbContext
    {
        public App_Database_Context(
            DbContextOptions<App_Database_Context> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique Indexes
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<CandidateProfile>()
                .HasIndex(cp => cp.UserId)
                .IsUnique();

            modelBuilder.Entity<Application>()
                .HasIndex(a => new
                {
                    a.CandidateProfileId,
                    a.JobId
                })
                .IsUnique();
            // User 1:1 CandidateProfile
            modelBuilder.Entity<User>()
                .HasOne(u => u.CandidateProfile)
                .WithOne(cp => cp.User)
                .HasForeignKey<CandidateProfile>(cp => cp.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // User 1:M Company
            modelBuilder.Entity<User>()
                .HasMany(u => u.Companies)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            // Company 1:M Job
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(j => j.Company)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.NoAction);

            // CandidateProfile 1:M Application
            modelBuilder.Entity<CandidateProfile>()
                .HasMany(cp => cp.Applications)
                .WithOne(a => a.CandidateProfile)
                .HasForeignKey(a => a.CandidateProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            // Job 1:M Application
            modelBuilder.Entity<Job>()
                .HasMany(j => j.Applications)
                .WithOne(a => a.Job)
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.NoAction);
            
            // Data Seeding
            SeedData(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Ahmed Hassan",
                    Email = "ahmed@example.com",
                    Password = "123456",
                    Role = UserRole.Candidate,
                    CreatedAt = new DateTime(2026, 9, 1)
                },
                new User
                {
                    Id = 2,
                    FullName = "Sara Mohamed",
                    Email = "sara@example.com",
                    Password = "123456",
                    Role = UserRole.Employer,
                    CreatedAt = new DateTime(2026, 9, 2)
                },
                new User
                {
                    Id = 3,
                    FullName = "Omar Ali",
                    Email = "omar@example.com",
                    Password = "123456",
                    Role = UserRole.Admin,
                    CreatedAt = new DateTime(2025, 9, 3)
                },
                new User
                {
                    Id = 4,
                    FullName = "Mona Adel",
                    Email = "mona@example.com",
                    Password = "123456",
                    Role = UserRole.Candidate,
                    CreatedAt = new DateTime(2026, 9, 4)
                },
                new User
                {
                    Id = 5,
                    FullName = "Youssef Samir",
                    Email = "youssef@example.com",
                    Password = "123456",
                    Role = UserRole.Candidate,
                    CreatedAt = new DateTime(2026, 9, 5)
                }
            );

            // CandidateProfiles
            modelBuilder.Entity<CandidateProfile>().HasData(
                new CandidateProfile
                {
                    Id = 1,
                    UserId = 1,
                    Phone = "01012345678",
                    ResumeUrl = "example.com/resume1",
                    Skill = "ASP.NET Core",
                    YearsOfExperience = 3
                },
                new CandidateProfile
                {
                    Id = 2,
                    UserId = 4,
                    Phone = "01098765432",
                    ResumeUrl = "example.com/resume2",
                    Skill = "Java",
                    YearsOfExperience = 2
                },
                new CandidateProfile
                {
                    Id = 3,
                    UserId = 5,
                    Phone = "01055556677",
                    ResumeUrl = "example.com/resume3",
                    Skill = "Python",
                    YearsOfExperience = 1
                }
            );

            // Companies
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Tech Solutions",
                    Description = "Software development company",
                    Website = "https://techsolutions.example.com",
                    Location = "Cairo",
                    OwnerId = 2
                },
                new Company
                {
                    Id = 2,
                    Name = "Future Systems",
                    Description = "IT consulting company",
                    Website = "https://futuresystems.example.com",
                    Location = "Giza",
                    OwnerId = 2
                },
                new Company
                {
                    Id = 3,
                    Name = "Digital Works",
                    Description = "Digital services company",
                    Website = "https://digitalworks.example.com",
                    Location = "Alexandria",
                    OwnerId = 2
                }
            );

            // Jobs
            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    Title = "Backend Developer",
                    Description = "Develop APIs using ASP.NET Core",
                    Salary = 30000m,
                    Location = "Cairo",
                    EmploymentType = "FullTime",
                    PostedDate = new DateTime(2026, 10, 1),
                    Deadline = new DateTime(2026, 11, 1),
                    Status = "Open",
                    CompanyId = 1
                },
                new Job
                {
                    Id = 2,
                    Title = "Frontend Developer",
                    Description = "Develop web interfaces",
                    Salary = 25000m,
                    Location = "Giza",
                    EmploymentType = "FullTime",
                    PostedDate = new DateTime(2026, 10, 2),
                    Deadline = new DateTime(2026, 11, 2),
                    Status = "Open",
                    CompanyId = 2
                },
                new Job
                {
                    Id = 3,
                    Title = "Software Tester",
                    Description = "Test software applications",
                    Salary = 20000m,
                    Location = "Alexandria",
                    EmploymentType = "Contract",
                    PostedDate = new DateTime(2026, 10, 3),
                    Deadline = new DateTime(2026, 11, 3),
                    Status = "Open",
                    CompanyId = 3
                }
            );

            // Applications
            modelBuilder.Entity<Application>().HasData(
                new Application
                {
                    Id = 1,
                    CandidateProfileId = 1,
                    JobId = 1,
                    ApplicationDate = new DateTime(2026, 10, 5),
                    Status = "Pending",
                    CoverLetter = "Interested in backend development"
                },
                new Application
                {
                    Id = 2,
                    CandidateProfileId = 2,
                    JobId = 2,
                    ApplicationDate = new DateTime(2026, 10, 6),
                    Status = "UnderReview",
                    CoverLetter = "Experienced in web technologies"
                },
                new Application
                {
                    Id = 3,
                    CandidateProfileId = 3,
                    JobId = 3,
                    ApplicationDate = new DateTime(2026, 10, 7),
                    Status = "Accepted",
                    CoverLetter = "Interested in software quality"
                }
            );
        }
    }
}
