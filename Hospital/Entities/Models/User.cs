using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hospital.Entities.Models
{
    public class User : IdentityUser<int>
    {
        public ICollection<Models.Hospital> Hospitals { get; set; }
        public ICollection<UserRole> Roles { get; set; }
        public User()
        {
            Hospitals = new Collection<Models.Hospital>();
        }
    }
}
