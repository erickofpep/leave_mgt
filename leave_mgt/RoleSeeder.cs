using Microsoft.AspNetCore.Identity;

public static class RoleSeeder
{
    public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        SeedRolesAsync(roleManager);
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
                UserName = "admin",
                Email = "admin@localhost"
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
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Administrator", "Employee", "Manager" };
        IdentityResult roleResult;

        foreach (var roleName in roleNames)
        {
            // Check if the role exists; if not, create it
            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }


}
