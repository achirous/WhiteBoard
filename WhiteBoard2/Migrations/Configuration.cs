namespace WhiteBoard2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WhiteBoard2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WhiteBoard2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WhiteBoard2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddUsers(context);

        }
        void AddUsers(WhiteBoard2.Models.ApplicationDbContext context)
        {
            var user1 = new ApplicationUser { UserName = "student1@email.com" };
            var user2 = new ApplicationUser { UserName = "student2@email.com" };
            var user3 = new ApplicationUser { UserName = "student3@email.com" };
            var user4 = new ApplicationUser { UserName = "student4@email.com" };
            var user5 = new ApplicationUser { UserName = "student5@email.com" };
            var user6 = new ApplicationUser { UserName = "lecturer1@email.com" };
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            um.Create(user1, "Password");
            um.Create(user2, "Password");
            um.Create(user3, "Password");
            um.Create(user4, "Password");
            um.Create(user5, "Password");
            um.Create(user6, "Password");

            //instantiate RoleManager
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            //create Lecturer and Student roles in the RoleManager
            var roleLecturer = roleManager.Create(new IdentityRole("Lecturer"));
            var roleStudent = roleManager.Create(new IdentityRole("Student"));

            //get the students and the lecturer
            var student1 = um.FindByName("student1@email.com");
            var student2 = um.FindByName("student2@email.com");
            var student3 = um.FindByName("student3@email.com");
            var student4 = um.FindByName("student4@email.com");
            var student5 = um.FindByName("student5@email.com");
            var lecturer1 = um.FindByName("lecturer1@email.com");

            //assign Student role to all students and assign Lecturer role to the lecturer
            um.AddToRole(student1.Id.ToString(), "Student");
            um.AddToRole(student2.Id.ToString(), "Student");
            um.AddToRole(student3.Id.ToString(), "Student");
            um.AddToRole(student4.Id.ToString(), "Student");
            um.AddToRole(student5.Id.ToString(), "Student");
            um.AddToRole(lecturer1.Id.ToString(), "Lecturer");
        }
    }
}
