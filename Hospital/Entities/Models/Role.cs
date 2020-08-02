using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Hospital.Entities.Models
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> User { get; set; }

    }
