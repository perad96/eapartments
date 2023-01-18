using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EApartments.Models
{
    public class LeasePayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LeaseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
