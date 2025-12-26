using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;

namespace Library_API
{
    public static class AdminUserSeeder
    {
        public static async Task SeedAdminAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            
            var adminEmail = "admin@library.local";

            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin != null) return;

            admin = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
                FirstName = "System",
                LastName = "Admin"
            };

            var result = await userManager.CreateAsync(admin, "Admin123!");

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }

}
