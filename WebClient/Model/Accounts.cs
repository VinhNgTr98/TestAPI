using System.ComponentModel.DataAnnotations;

namespace WebClient.Model
{
    public class Accounts
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password{ get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

       
    }
}
