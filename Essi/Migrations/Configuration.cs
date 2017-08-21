namespace Essi.Migrations
{
    using Essi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Essi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Essi.Models.ApplicationDbContext";
        }

        protected override void Seed(Essi.Models.ApplicationDbContext context)
        {
            // Create a default course for this application. Only one course should exist at a time.
            var course = new Course {
                Name = "Applications of Computing",
                CourseCode = "CS-100",
                StartDate = new DateTime(2017, 09, 01),
                EndDate = new DateTime(2017, 12, 21)
            };

            context.Courses.AddOrUpdate(course);
            context.SaveChanges();
        }
    }
}
