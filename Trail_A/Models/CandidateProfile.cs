using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Trail_A.Models
{
    public class CandidateProfile
    {
        public int Id { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

        public string? ResumeUrl { get; set; }

        [Required]
        [MaxLength(500)]
        public string Skill { get; set; } = null!;

        [Range(0, 50)]
        public int YearsOfExperience { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public ICollection<Application> Applications { get; set; }
            = new List<Application>();
    }
}
