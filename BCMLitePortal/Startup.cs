using BCMLitePortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BCMLitePortal.Startup))]
namespace BCMLitePortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login   
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // Create default admin role   
            if (!roleManager.RoleExists("Admin"))
            {

                // Create admin role  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = "Admin"
                };
                roleManager.Create(role);

                //Create super admin user for website maintenance and development                
                var user = new ApplicationUser()
                {
                    UserName = "keketso",
                    Email = "keketso@digitalperspective.co.za"
                };
                string userPWD = "P@ssw0rd1";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // Create plan owner role  
            if (!roleManager.RoleExists("Plan Owner"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = "Plan Owner"
                };
                roleManager.Create(role);

            }

            // Create general employee role  
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }
    }
}
