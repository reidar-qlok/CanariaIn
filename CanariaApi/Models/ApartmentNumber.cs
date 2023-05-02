using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanariaApi.Models
{
    public class ApartmentNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApartmentNo { get; set; }
        [ForeignKey("Apartment")]
        public int FkApartmentId { get; set; }
        public Apartment Apartment { get; set; }//Navigering
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
