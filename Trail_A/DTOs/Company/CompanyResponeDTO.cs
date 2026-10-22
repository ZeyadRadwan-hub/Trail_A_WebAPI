using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTOs.Company
{
    public class CompanyResponeDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public string? Website { get; set; }

        [Required]
        public string Location { get; set; } = null!;
        public int JobsCount { get; set; }
    }
}
