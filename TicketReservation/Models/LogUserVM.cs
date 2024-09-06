using System.ComponentModel.DataAnnotations;

namespace TicketReservation.Models
{
    public class LogUserVM
    {
        [Required]
        public string Email { get; set; }
        public string Pass { get; set; }
        public bool RememberMe { get; set; }
    }
}
