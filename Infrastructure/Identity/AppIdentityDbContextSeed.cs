using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Ion",
                    Email = "ion.vasilasco.1997@gmail.com",
                    UserName = "ion.vasilasco.1997@gmail.com",
                    UserDetails = new UserDetails
                    {
                        FirstName = "Ion",
                        LastName = "Vasilasco",
                        Country = "Moldova"
                    }
                };

                await userManager.CreateAsync(user, "Secr3t$");
            }
        }
    }
}