using System.ComponentModel.DataAnnotations;

namespace Trail_A.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Required]
        public DateTime ApplicationDate { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        [MaxLength(2000)]
        public string? CoverLetter { get; set; }

        public int CandidateProfileId { get; set; }

        public CandidateProfile CandidateProfile { get; set; } = null!;

        public int JobId { get; set; }

        public Job Job { get; set; } = null!;
    }
}
