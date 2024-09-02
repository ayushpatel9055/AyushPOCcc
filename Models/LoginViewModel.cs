using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserNameOrEmail Is Required")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        [DisplayName("UserName Or Email")]
        public string UserNameOrEmail { get; set; }


        [Required(ErrorMessage = "Password Is Required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 and Min 5 characters allowed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
