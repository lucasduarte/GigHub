using System.ComponentModel.DataAnnotations;

namespace GigHub.Mvc.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
