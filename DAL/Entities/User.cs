using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class AppUser : IdentityUser
    {

        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }
        public string Role { get; set; }

        public ICollection<Ticket> tickets { get; set; }

    }
}
