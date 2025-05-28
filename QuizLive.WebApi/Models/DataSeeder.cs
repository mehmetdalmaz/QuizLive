using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using QuizLive.Entitiy.Concrete;

namespace QuizLive.WebApi.Models
{
    public class DataSeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            string adminRole = "Admin";
            string adminEmail = "admin@site.com";
            string adminPassword = "Admin123!";

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole<int>(adminRole));
            }

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var newAdminUser = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    FullName = "Admin Kullanıcı" // ya da istediğin başka bir isim
                };


                var createUserResult = await userManager.CreateAsync(newAdminUser, adminPassword);
                if (createUserResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdminUser, adminRole);
                }
                else
                {
                    throw new Exception("Admin kullanıcı oluşturulamadı: " +
                        string.Join(", ", createUserResult.Errors.Select(e => e.Description)));
                }
            }
        }



    }
}