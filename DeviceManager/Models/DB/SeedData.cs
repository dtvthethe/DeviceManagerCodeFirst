using System.Linq;

namespace DeviceManager.Models.DB
{
    public class SeedData
    {
        public static void CreateData(DeviceManagerDbContext context)
        {
            // Role
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(new Role[] {
                    new Role{Name = "Admin"},
                new Role { Name = "Employee" },
                new Role { Name = "Test" },
                });
            }

            // Category:
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new Category[] {
                    new Category{Name = "Monitor"},
                    new Category{Name = "Keyboard"},
                    new Category{Name = "Mouse"},
                    new Category{Name = "CPU"},
                });
            }

            // Unit:
            if (!context.Units.Any())
            {
                context.Units.AddRange(new Unit[] {
                    new Unit{Name = "Kg"},
                    new Unit{Name = "H"},
                });
            }

            // Status:
            if (!context.Statuses.Any())
            {
                context.Statuses.AddRange(new Status[] {
                    new Status{Name="Used"},
                    new Status{Name = "Reused"},
                    new Status{Name = "New"},
                });
            }

            // Provider:
            if (!context.Providers.Any())
            {
                context.Providers.AddRange(new Provider[] {
                    new Provider{Name="Apple"},
                    new Provider{Name = "SamSung"},
                    new Provider{Name = "Sony"},
                });
            }

            // Departments:
            if (!context.Departments.Any())
            {
                context.Departments.AddRange(new Department[] {
                    new Department{Name="IT"},
                    new Department{Name = "Account"},
                });
            }

            // Commit all:
            context.SaveChanges();

        }
    }
}