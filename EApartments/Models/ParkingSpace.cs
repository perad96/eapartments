using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EApartments.Models
{
    public class ParkingSpace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string SpaceNumber { get; set; }
        public decimal Rent { get; set; }
        public string Status { get; set; }
    }
}
