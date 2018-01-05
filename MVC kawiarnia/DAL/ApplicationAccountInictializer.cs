using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_kawiarnia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC_kawiarnia.DAL
{
    public class ApplicationAccountInictializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Task.Run(async () => { await SeedAsync(context); }).Wait();
        }
        private async Task SeedAsync(ApplicationDbContext context)
        {

            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppAdmin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser
                {
                    UserName = "admin@mdwojak.pl",
                    Email = "admin@mdwojak.pl",
                };

                manager.Create(user, "123456!!");
                manager.AddToRole(user.Id, "AppAdmin");
            }
        }
    }
}