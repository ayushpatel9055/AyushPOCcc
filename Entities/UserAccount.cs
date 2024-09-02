using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace POC.Entities
{
    [Index(nameof(Email),IsUnique =true)]
    [Index(nameof(UserName), IsUnique = true)]

    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="FirstName Is Required")]
        [MaxLength(50,ErrorMessage ="Max 50 characters allowed")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        [Required(ErrorMessage ="LastName Is Required")]
        public string LastName { get; set; }
        [MaxLength(100, ErrorMessage = "Max 100 characters allowed")]
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserName Is Required")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Is Required")]
        [MaxLength(20, ErrorMessage = "Max 20 characters allowed")]
        public string Password { get; set; }
    }
}
