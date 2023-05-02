using System.ComponentModel.DataAnnotations;

namespace CanariaWeb.Models.DTO
{
    public class ApartmentUpdateDto
    {
        [Required]
        public int ApartmentId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int Kvm { get; set; }
        [Required]
        public int Occupancy { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public string Comfort { get; set; }
    }
}
