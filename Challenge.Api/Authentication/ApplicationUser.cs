using Microsoft.AspNetCore.Identity;

namespace ChallengeApi.Authentication
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser():base()
        {
        }
        public ApplicationUser(string userName) : base(userName)
        {
        }
    }

    public class ApplicationRole : IdentityRole<long>
    {
        public ApplicationRole():base()
        {
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}