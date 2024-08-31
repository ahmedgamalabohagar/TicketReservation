using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketReservation.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public bool Valid { get; set; }
        [ForeignKey("user")]
        public int UserID { get; set; }
        public User user { get; set; }
        [ForeignKey("event")]
        public int EventID { get; set; }
        public Event Event { get; set; }

    }
}
