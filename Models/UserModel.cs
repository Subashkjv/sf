using System.ComponentModel.DataAnnotations;

namespace MVCSAMPLE.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
        [Display(Name = "Username")]
        public string username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 255 characters.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}
