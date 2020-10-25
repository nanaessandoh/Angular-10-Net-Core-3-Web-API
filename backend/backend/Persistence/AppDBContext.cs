using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Persistence
{
    public class AppDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=CompanyDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, EmployeeName = "Karl Reit", DepartmentId = 1, DOB = new DateTime(2000, 10, 12), DOJ = new DateTime(2015, 12, 25), Gender = "Male" },
                new Employee { EmployeeID = 2, EmployeeName = "Catty Floyd", DepartmentId = 2, DOB = new DateTime(1995, 8, 5), DOJ = new DateTime(2015, 12, 25), Gender = "Female" },
                new Employee { EmployeeID = 3, EmployeeName = "Jimmy Trudeau", DepartmentId = 3, DOB = new DateTime(1995, 2, 2), DOJ = new DateTime(2015, 12, 25), Gender = "Male" },
                new Employee { EmployeeID = 4, EmployeeName = "Linda Oltah", DepartmentId = 4, DOB = new DateTime(1997, 8, 19), DOJ = new DateTime(2015, 12, 25), Gender = "Female" },
                new Employee { EmployeeID = 5, EmployeeName = "Steven Reeves", DepartmentId = 5, DOB = new DateTime(2003, 5, 19), DOJ = new DateTime(2015, 12, 25), Gender = "Male" }
                );

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentID = 1, DepartmentName = "IT", CreatedOn = new DateTime(2015, 12, 25) },
                new Department { DepartmentID = 2, DepartmentName = "Audit", CreatedOn = new DateTime(2015, 12, 25) },
                new Department { DepartmentID = 3, DepartmentName = "Accounts", CreatedOn = new DateTime(2015, 12, 25) },
                new Department { DepartmentID = 4, DepartmentName = "HR", CreatedOn = new DateTime(2015, 12, 25) },
                new Department { DepartmentID = 5, DepartmentName = "Marketing", CreatedOn = new DateTime(2015, 12, 25) }
                );
            base.OnModelCreating(modelBuilder);
        }


    }
}
