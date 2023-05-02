using System.ComponentModel.DataAnnotations;

namespace CanariaWeb.Models.DTO
{
    public class ApartmentNumberUpdateDto
    {
        [Required]
        public int ApartmentNo { get; set; }
        [Required]
        public int FkApartmentId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
