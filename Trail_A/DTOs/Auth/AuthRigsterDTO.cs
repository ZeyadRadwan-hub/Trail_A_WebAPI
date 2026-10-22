using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTOs.Auth
{
    public class AuthRigsterDTO
    {
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
