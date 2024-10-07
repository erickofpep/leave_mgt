using Microsoft.AspNetCore.Identity;

namespace leave_mgt
{
    public static class SeedData
    {
        //The main function which is going to get called, which further call "SeedUser" and "SeedRoles"
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            //Check if there is any user by name "admin"
            if (userManager.FindByEmailAsync("admin").Result == null)
            {
                //if check result is null, create an object called "user", which is of the type "IdentityUser"
                var user = new IdentityUser
                {
                    UserName = "admin@localhost.com", //"admin",
                    Email = "admin@localhost.com" //"admin@localhost.com"
                };

                //store the result of this operation in the variable "result"
                var result = userManager.CreateAsync(user, "P@ssword1").Result;

                //if the user was created successfully, then we assign this user to a role.
                if (result.Succeeded)
                {
                    //assign the created user with the role, "Administrator" and "Wait" for it to complete before it proceeds.

                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Manager").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Manager"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

        }
    }
}
