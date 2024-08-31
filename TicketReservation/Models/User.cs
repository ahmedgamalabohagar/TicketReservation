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
        [MaxLength(60)]
        public string Email { get; set; }
        [MaxLength (13)]
        public string Role {  get; set; }

        public ICollection<Ticket> tickets { get; set; }

    }
}
