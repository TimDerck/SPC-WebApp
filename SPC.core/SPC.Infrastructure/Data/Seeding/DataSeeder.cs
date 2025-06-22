using Microsoft.AspNetCore.Identity;
using SPC.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Infrastructure.Data.Seeding
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public DataSeeder(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            // 1. Seed roles
            string[] roles = { "Admin", "Supervisor", "Expert", "User", "Auditor" };
            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }

            // 2. Seed an Admin user if none exist
            if (!_userManager.Users.Any())
            {
                var defaultSite = _dbContext.Sites.FirstOrDefault();
                if (defaultSite == null)
                    throw new Exception("No Site exists! Add Sites before seeding users.");

                var admin = new ApplicationUser
                {
                    UserName = "admin@lab.com",
                    Email = "admin@lab.com",
                    FirstName = "Admin",
                    LastName = "User",
                    Initials = "AU",
                    EmailConfirmed = true,
                    SiteId = defaultSite.Id,
                    CreatedAt = DateTime.UtcNow
                };

                var result = await _userManager.CreateAsync(admin, "Admin123!"); 
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "Admin");
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    throw new Exception("Failed to create Admin user: " + errors);
                }
            }
        }
    }
}
