using System.ComponentModel.DataAnnotations;

namespace CanariaWeb.Models.DTO
{
    public class ApartmentNumberDto
    {
        [Required]
        public int ApartmentNo { get; set; }
        [Required]
        public int FkApartmentId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
