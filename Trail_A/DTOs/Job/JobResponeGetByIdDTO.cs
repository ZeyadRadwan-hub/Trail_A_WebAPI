using JobPortal.DTOs.Company;
using System.ComponentModel.DataAnnotations;
using Trail_A.Models;
namespace JobPortal
{
    public class JobResponeGetByIdDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Location { get; set; } = null!;

        [Required]
        [Range(0, 1000000)]
        public decimal Salary { get; set; }

        [Required]
        public string EmploymentType { get; set; } = null!;

        [Required]
        public DateTime PostedDate { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        public CompanyInfoDTO Company { get; set; } = null!;

    }
}
