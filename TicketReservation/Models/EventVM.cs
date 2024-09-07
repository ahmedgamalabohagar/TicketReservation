using System.ComponentModel.DataAnnotations;

namespace TicketReservation.Models
{
    public class EventVM
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string place { get; set; }
        public DateTime Time { get; set; }
        public int NoOfAvilTickets { get; set; }
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string Info { get; set; }
        [MaxLength(1000)]
        public string Data { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }

    }
}
