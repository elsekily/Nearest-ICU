using Hospital.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class HospitalsDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<Hospital.Entities.Models.Hospital> Hospitals { get; set; }
        public HospitalsDbContext(DbContextOptions<HospitalsDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUserLogin<int>>(x => x.Property(m => m.LoginProvider).HasMaxLength(255));
            builder.Entity<IdentityUserLogin<int>>(x => x.Property(m => m.ProviderKey).HasMaxLength(255));

            builder.Entity<IdentityUserToken<int>>(x => x.Property(m => m.LoginProvider).HasMaxLength(255));
            builder.Entity<IdentityUserToken<int>>(x => x.Property(m => m.Name).HasMaxLength(255));

            builder.Entity<Entities.Models.Hospital>().HasOne(b => b.User).WithMany(u => u.Hospitals);

            builder.HasDbFunction(typeof(DbFunctions)
                .GetMethod(nameof(DbFunctions.Distance)))
                .HasName(nameof(DbFunctions.Distance));
        }
        
    }
}
