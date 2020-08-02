using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Hospital.Entities.Resources
{
    public class Policies
    {
        public const string Admin = "Admin";
        public const string Moderator = "Moderator";
        public static AuthorizationPolicy Policy(string role)
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
            policy.RequireAuthenticatedUser().RequireRole(role);

            return policy.Build();
        }
    }
}
