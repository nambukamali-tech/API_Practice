using System.ComponentModel.DataAnnotations;

namespace Zoo_API.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage ="UserName is Required")]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Password is Required")]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
