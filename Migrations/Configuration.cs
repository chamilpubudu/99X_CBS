namespace _99X_CBS.Migrations
{
    using _99X_CBS.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_99X_CBS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "_99X_CBS.Models.ApplicationDbContext";
        }

        protected override void Seed(_99X_CBS.Models.ApplicationDbContext context)
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

            this.AddUserAndRoles();
        }

        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("Manager");
            if (!success == true) return success;

            success = idManager.CreateRole("CBS_Attendances_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_Awards_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_Bonuses_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_CustomerFeedbackScore_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_EmployeeBillingUtilization_Manage");
            if (!success == true) return success;

            success = idManager.CreateRole("CBS_Employees_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_Engagement_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_FuelAllowances_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_Increments_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_MentorBuddy_Manage");
            if (!success == true) return success;

            success = idManager.CreateRole("CBS_Promotions_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_PublicAppearences_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_TechnologyExposure_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_Trainings_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_Travels_Manage");
            
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_UniversitySessions_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_ValueInnovations_Manage");
            if (!success == true) return success;
            success = idManager.CreateRole("CBS_ReportFormat_Manage");
            if (!success == true) return success;

            success = idManager.CreateRole("User");
            if (!success) return success;

            success = idManager.CreateRole("CBS_SalaryInformation_Manage");
            if (!success == true) return success;

            success = idManager.CreateRole("CBS_AdditionalAccomplishments_Manage");
            if (!success == true) return success;

            success = idManager.CreateRole("CBS_Benefits_Manage");
            if (!success == true) return success;

            var newUser = new ApplicationUser()
            {
                UserName = "chamil",
                FirstName = "Chamil",
                LastName = "Gunaratne",
                Email = "chamilg@99x.lk"
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Password1");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Manager");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;

            return success;
        }
    }
}
