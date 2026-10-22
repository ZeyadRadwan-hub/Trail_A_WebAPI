using System.ComponentModel.DataAnnotations;

namespace JobPortal.DTOs.Auth
{
    public class AuthLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
