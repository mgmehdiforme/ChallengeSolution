using ChallengeApi.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ChallengeApi.DataContext
{

    public static class SeedDataManager
    {
        public static IHost SeedData<TContext>(this IHost host) where TContext : DbContext
        {
            SeedIdentityData<TContext>(host);
            return host;
        }

        private static void SeedIdentityData<TContext>(IHost host) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {

                var scopedServices = scope.ServiceProvider;                
                var roleManager = scopedServices.GetRequiredService<RoleManager<ApplicationRole>>();
                var userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();
                // Rest of your seeding logic

                try
                {
                    // Seed initial roles

                    if (!roleManager.RoleExistsAsync(UserRoles.Admin_Role).Result)
                    {
                        var role = new ApplicationRole(UserRoles.Admin_Role);
                        roleManager.CreateAsync(role).Wait();
                    }

                    if (!roleManager.RoleExistsAsync(UserRoles.User_Role).Result)
                    {
                        var role = new ApplicationRole(UserRoles.User_Role);
                        roleManager.CreateAsync(role).Wait();
                    }

                    // Seed initial users

                    var userAdmin = new ApplicationUser
                    {
                        UserName = "admin@example.com",
                        Email = "admin@example.com"
                    };
                    if (userManager.FindByEmailAsync(userAdmin.Email).Result == null)
                    {
                        var result = userManager.CreateAsync(userAdmin, "AdminP@ssword1").Result;
                        if (result.Succeeded)
                        {
                            userManager.AddToRoleAsync(userAdmin, UserRoles.Admin_Role).Wait();
                        }
                    }

                    var userGeneral = new ApplicationUser
                    {
                        UserName = "user@example.com",
                        Email = "user@example.com"
                    };
                    if (userManager.FindByEmailAsync(userGeneral.Email).Result == null)
                    {
                        var result = userManager.CreateAsync(userGeneral, "UserP@ssword1").Result;
                        if (result.Succeeded)
                        {
                            userManager.AddToRoleAsync(userGeneral, UserRoles.User_Role).Wait();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}