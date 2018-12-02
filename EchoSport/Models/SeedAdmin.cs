using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchoSport.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EchoSport.Models
{
    public class SeedAdmin
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (!context.Roles.Any())
                {
                    context.Roles.Add(
                        new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTATOR" });

                    context.SaveChanges();
                }

                if (!context.Users.Any(u => u.Email == "admin@gmail.com"))
                {
                    context.Users.Add(new IdentityUser
                    {
                        UserName = "admin@gmail.com",
                        Email = "admin@gmail.com",
                        NormalizedUserName = "ADMIN@GMAIL.COM",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        PasswordHash = "AQAAAAEAACcQAAAAED0A9ZbsFZztHfHUCbtVo7RYB6sc8Uca1TJUxzuX6Z8ss/J3QoMIduG0QOx88JhhlA==",
                        SecurityStamp = "P5XX3JQZQ2KVYJNPEXOCIHHYZJMW6FXI",
                        ConcurrencyStamp = "f873f25b-5154-44e6-8543-4e42ef51989d",
                        LockoutEnabled = true,

                    });

                    context.SaveChanges();
                }


                if (!context.UserRoles.Any())
                {
                    var user = context.Users.SingleOrDefault(r => r.Email == "admin@gmail.com");
                    var userId = user.Id;

                    var role = context.Roles.SingleOrDefault(r => r.Name == "Administrator");
                    var roleId = role.Id;

                    context.UserRoles.Add(new IdentityUserRole<string>()
                    {
                        UserId = userId,
                        RoleId = roleId
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
