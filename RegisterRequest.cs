using System.ComponentModel.DataAnnotations;

namespace Zoo_API.Models
{
    public class RegisterRequest
    {
        [Required(ErrorMessage ="UserName is Required")]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Password is Required")]
        [StringLength(60)]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage ="Email is Required")]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;
    }
}
