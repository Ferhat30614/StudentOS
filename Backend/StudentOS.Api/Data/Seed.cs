using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StudentOS.Api.Models;

namespace StudentOS.Api.Data;

public static class Seed
{
    public static async Task RunAsync(IServiceProvider sp)
    {
        var roleMgr = sp.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (var r in new[] { "Admin", "Teacher", "Student" })
            if (!await roleMgr.RoleExistsAsync(r))
                await roleMgr.CreateAsync(new IdentityRole(r));

        var userMgr = sp.GetRequiredService<UserManager<AppUser>>();

        async Task Ensure(string email, string name, string role)
        {
            var u = await userMgr.FindByEmailAsync(email);
            if (u == null)
            {
                u = new AppUser { UserName = email, Email = email, FullName = name, Role = role };
                await userMgr.CreateAsync(u, "Passw0rd!");
                await userMgr.AddToRoleAsync(u, role);
            }
        }

        await Ensure("admin@test.com", "Admin User", "Admin");
        await Ensure("teacher@test.com", "Teacher User", "Teacher");
        await Ensure("student@test.com", "Student User", "Student");
    }
}
