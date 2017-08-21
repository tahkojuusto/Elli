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

            var course = new Course { Name = "Applications of Computing", CourseCode = "CS-100", StartDate = new DateTime(2017, 09, 01), EndDate = new DateTime(2017, 12, 21) };

            //var HTML = new ExerciseRound { Name = "HTML", CourseID = course.ID };

            //var Ex1 = new Exercise { Name = "1", MinPoints = 0, MaxPoints = 6, IsRequired = true, IsBonus = false };
            //var Ex2 = new Exercise { Name = "2", MinPoints = 0, MaxPoints = 9, IsRequired = false, IsBonus = true };

            //HTML.Exercises.Add(Ex1);
            //HTML.Exercises.Add(Ex2);
            //course.ExerciseRounds.Add(HTML);

            context.Courses.AddOrUpdate(course);



            context.SaveChanges();
        }
    }
}
