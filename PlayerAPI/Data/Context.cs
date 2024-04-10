using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlayerAPI.Models;

namespace PlayerAPI.Data
{
    public class Context:IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
    }
}
