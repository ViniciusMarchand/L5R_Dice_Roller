using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Services
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        public new DbSet<User> Users { get; set; }
    }
}
