using System.ComponentModel.DataAnnotations;

namespace TicketReservation.Models
{
    public class User
    {
        // Role
        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(25)]
        public string Password { get; set; }
        [MaxLength(11)]
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Ticket> tickets { get; set; }

    }
}
