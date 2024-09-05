using System.ComponentModel.DataAnnotations;

namespace TicketReservation.Models
{
    public class UserVM
    {

        public int Id { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public ICollection<TicketVM> tickets { get; set; }

    }
}
