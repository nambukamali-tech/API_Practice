using System.ComponentModel.DataAnnotations;

namespace Zoo_API.Models
{
    public class Zoo
    {
        [Key]
        public int AnimalId { get; set; }
        [Required(ErrorMessage ="Animal Name is Required")]
        [StringLength(40)]
        public string AnimalName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Animal's Country is Required")]
        [StringLength(50)]
        public string CountryFrom { get; set; } = string.Empty;
        [Required(ErrorMessage ="Animal Age is Required")]
        public int AnimalAge { get; set; }
        [Required(ErrorMessage ="Animal LifeTime is Required")]
        public int LifeTime { get; set; }
    }
}
