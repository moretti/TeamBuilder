using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TeamBuilder.Models
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }

        public AppDbContext() 
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }

    #region Test data
    public partial class AppDbContext
    {
        private static readonly DateTime _baseCreatedAtDate = DateTime.Now;
        private static readonly Random _random = new Random();

        static AppDbContext()
        {
            Database.SetInitializer(new TestDataInitializer());
        }

        private class TestDataInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
        {
            protected override void Seed(AppDbContext context)
            {
                var t1 = context.Teams.Add(CreateTeam("House Stark"));
                var t2 = context.Teams.Add(CreateTeam("House Lannister"));
                var t3 = context.Teams.Add(CreateTeam("House Baratheon"));
                var t4 = context.Teams.Add(CreateTeam("House Tully"));

                context.SaveChanges();

                context.Employees.Add(CreateEmployee("Ned", "Stark", t1));
                context.Employees.Add(CreateEmployee("Catelyn", "Stark", t1));
                context.Employees.Add(CreateEmployee("Jon", "Snow", t1));
                context.Employees.Add(CreateEmployee("Tyrion", "Lannister", t2));
                context.Employees.Add(CreateEmployee("Cersei", "Lannister", t2));
                context.Employees.Add(CreateEmployee("Jaime", "Lannister", t2));
                context.Employees.Add(CreateEmployee("Renly", "Baratheon", t3));
                context.Employees.Add(CreateEmployee("Shireen", "Baratheon", t3));
                context.Employees.Add(CreateEmployee("Edmure", "Tully", t4));
                context.Employees.Add(CreateEmployee("Brynden", "Tully", t4));
            }

            private static Team CreateTeam(string name)
            {
                return new Team
                {
                    Name = name,
                    CreatedAt = _baseCreatedAtDate.AddMinutes(_random.Next(-60 * 24 * 365 * 5, 0)),
                };
            }

            private static Employee CreateEmployee(string firstName, string lastName, Team team)
            {
                return new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = new DateTime(_random.Next(1945, 1991), _random.Next(1, 13), _random.Next(1, 29), 0, 0, 0),
                    Team = team,
                };
            }
        }
    }
    #endregion
}