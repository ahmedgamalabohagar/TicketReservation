using System.ComponentModel.DataAnnotations;

namespace TicketReservation.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string place { get; set; }
        public DateTime Time { get; set; }
        [Range(1, 3, ErrorMessage = "You can't Reserve more than 3 tickets.")]
        public int NoOfTickets { get; set; }
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string Info { get; set; }
        [MaxLength(1000)]
        public string Data { get; set; }
        public string? ImageName { get; set; }
    public ICollection<Ticket> tickets { get; set; }

    }
}
