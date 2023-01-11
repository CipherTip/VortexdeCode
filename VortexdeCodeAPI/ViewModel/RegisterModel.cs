using System.ComponentModel.DataAnnotations;

namespace VortexdeCodeAPI.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "User Last Name is required")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
