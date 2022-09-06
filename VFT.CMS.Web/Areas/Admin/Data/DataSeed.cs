using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VFT.CMS.EntityFrameworkCore;
using VFT.CMS.Application;

namespace VFT.CMS.Web.Areas.Admin.Data
{
    public static class DataSeed
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            IServiceScopeFactory scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<CMSDbContext>();
                context.Database.Migrate();

                UserManager<CMSIdentityUser> _userManager = scope.ServiceProvider.GetRequiredService<UserManager<CMSIdentityUser>>();
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                // Seed database code goes here

                // User Info
                //string userName = "SuperAdmin";
                string firstName = "Super";
                string lastName = "Admin";
                string email = "vifiretek@admin.com";
                string password = "vft!234%Qwert";
                string role = "SuperAdmin";
                string role2 = "SeniorManager";
                string role3 = "Manager";

                if (await _userManager.FindByNameAsync(email) == null)
                {
                    // Create SuperAdmins role if it doesn't exist
                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                    if (await roleManager.FindByNameAsync(role2) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role2));
                    }
                    if (await roleManager.FindByNameAsync(role3) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role3));
                    }

                    // Create user account if it doesn't exist
                    CMSIdentityUser user = new CMSIdentityUser
                    {
                        UserName = email,
                        Email = email,
                        //extended properties
                        FirstName = firstName,
                        LastName = lastName,
                        AvatarURL = "/images/user.png",
                        DateRegistered = DateTime.UtcNow.ToString(),
                        Position = "",
                        NickName = "",
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, password);

                    // Assign role to the user
                    if (result.Succeeded)
                    {
                        await _userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.GivenName, user.FirstName));
                        await _userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.Surname, user.LastName));
                        await _userManager.AddClaimAsync(user, new Claim(CustomClaimTypes.AvatarURL, user.AvatarURL));

                        //SignInManager<ApplicationUser> _signInManager = serviceProvider.GetRequiredService<SignInManager<ApplicationUser>>();
                        //await _signInManager.SignInAsync(user, isPersistent: false);

                        await _userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }
}
