using System.ComponentModel.DataAnnotations;

namespace Trail_A.Models
{
    public class Company
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

        public int OwnerId { get; set; }

        public User Owner { get; set; } = null!;

        public ICollection<Job> Jobs { get; set; }
            = new List<Job>();
    }
}
