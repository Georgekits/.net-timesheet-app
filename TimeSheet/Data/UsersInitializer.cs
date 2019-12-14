using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Data
{
    public static class UsersInitializer
    {
        public static void SeedUsers(UserManager<MyUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@test.com").Result == null)
            {
                MyUser user = new MyUser
                {
                    FirstName = "test",
                    UserName = "admin@test.com",
                    Email = "admin@test.com",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();

                }
            }
            else if (userManager.FindByEmailAsync("manager@test.com").Result == null)
            {
                MyUser user2 = new MyUser
                {
                    FirstName = "test2",
                    UserName = "manager@test.com",
                    Email = "manager@test.com",
                    EmailConfirmed = true
                };

                IdentityResult result = userManager.CreateAsync(user2, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user2, "Manager").Wait();

                }
            }
        }
    }
}
