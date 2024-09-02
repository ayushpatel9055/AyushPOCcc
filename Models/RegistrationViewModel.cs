using System.ComponentModel.DataAnnotations;

namespace POC.Models
{
    public class RegistrationViewModel
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName Is Required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        [Required(ErrorMessage = "LastName Is Required")]
        public string LastName { get; set; }
        [MaxLength(100, ErrorMessage = "Max 100 characters allowed")]
        [Required(ErrorMessage = "Email Is Required")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserName Is Required")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        [StringLength(20,MinimumLength =5, ErrorMessage = "Max 20 and Min 5 characters allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Please Confirm YourPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } 
    }
}
