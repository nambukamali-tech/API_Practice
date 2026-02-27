using System.ComponentModel.DataAnnotations;
using Zoo_API.Models;
namespace Zoo_API.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="UserName is Required")]
        [StringLength(100)]

        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Password is Required")]
        [StringLength(50)]

        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage ="Email Id is Required")]
        [StringLength(40)]
        public string Email { get; set; } = string.Empty;
    }
}
