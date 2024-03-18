using System.ComponentModel.DataAnnotations;

namespace forex_app.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Client ID is required")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
