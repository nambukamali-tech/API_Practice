using System.ComponentModel.DataAnnotations;

namespace Flowers_API.Models
{
    public class Flowers
    {
        [Key]
        public int FlowerId { get; set; }
        public string FlowerName { get; set; } = string.Empty;
        public string FlowerColor { get; set; } = string.Empty;
        public string FlowerSeason { get; set; } = string.Empty;
        public string FlowerArea { get; set; } = string.Empty;


    }
}
