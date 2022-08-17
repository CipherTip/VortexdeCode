using System.ComponentModel.DataAnnotations;

namespace VortexdeCodeAPI.ViewModel
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Current New Password is required")]
        public string CurrentPassword { get; set; }
       
        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; }
    }
}
