using System.ComponentModel.DataAnnotations;

namespace Flowers_API.Models
{
    public class Flowers
    {
        [Key]
        public int FlowerId { get; set; }
        [Required(ErrorMessage = "Flower Name is Required")]
        [StringLength(50 , ErrorMessage = "Flower Name cannot exists above 50")]
        public string FlowerName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Flower Color is Required")]
        [StringLength(30 , ErrorMessage ="Flower Color exists below 30")]
        public string FlowerColor { get; set; } = string.Empty;
        [Required(ErrorMessage ="Flower Season is Required")]
        public string FlowerSeason { get; set; } = string.Empty;
        [Required(ErrorMessage ="Flower Area is Required")]
        public string FlowerArea { get; set; } = string.Empty;


    }
}
