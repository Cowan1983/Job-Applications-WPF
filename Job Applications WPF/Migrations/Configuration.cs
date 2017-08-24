namespace Job_Applications_WPF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Job_Applications_WPF.JobLeadContext>
    {
        public Configuration()
        {
            //NOTE:
            //We created this file running the command
            //enable-migrations –EnableAutomaticMigration:$true
            //in the Package Manager Console. Tools -> NuGet Package Manager -> Package Manager Console

            //To allow Entity Framework to add and amend changes to the component objects in the data model, we
            //need to tell it to allow these to happen 
            AutomaticMigrationsEnabled = true;

            //If we want migrations to allow for dataloss (e.g. by the removal of value members from the class/interface)
            //AutomaticMigrationDataLossAllowed = true;

            ContextKey = "Job_Applications_WPF.JobLeadContext";
        }

        protected override void Seed(Job_Applications_WPF.JobLeadContext context)
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
        }
    }
}
