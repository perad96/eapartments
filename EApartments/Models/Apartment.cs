using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EApartments.Models
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BuildingId { get; set; }
        public int CategoryId { get; set; }
        public string Code { get; set; }
        public int Floor { get; set; }
        public decimal RentPrice { get; set; }
        public decimal Deposit { get; set; }
        public string Status { get; set; }
    }
}
