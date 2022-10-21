using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed departments data
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 1, DepartmentName = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 3, DepartmentName = "Management" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentId = 4, DepartmentName = "Travel" });

            //sedd Employee data
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Sreenu",
                LastName = "Thuraka",
                Email = "tsreenu.9@gmail.com",
                DateOfBirth = new DateTime(1990, 02, 07),
                DepartmentId = 1,
                Gender = Gender.Male,
                PhotoPath = "images/sreenu.jpeg"
            });modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Sreenu",
                LastName = "Thuraka",
                Email = "tsreenu.9@gmail.com",
                DateOfBirth = new DateTime(1990, 02, 07),
                DepartmentId = 2,
                Gender = Gender.Male,
                PhotoPath = "images/sreenu.jpeg"
            });modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Sreenu",
                LastName = "Thuraka",
                Email = "tsreenu.9@gmail.com",
                DateOfBirth = new DateTime(1990, 02, 07),
                DepartmentId = 3,
                Gender = Gender.Male,
                PhotoPath = "images/sreenu.jpeg"
            });modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 4,
                FirstName = "Sreenu",
                LastName = "Thuraka",
                Email = "tsreenu.9@gmail.com",
                DateOfBirth = new DateTime(1990, 02, 07),
                DepartmentId = 4,
                Gender = Gender.Male,
                PhotoPath = "images/sreenu.jpeg"
            });modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 5,
                FirstName = "Sreenu",
                LastName = "Thuraka",
                Email = "tsreenu.9@gmail.com",
                DateOfBirth = new DateTime(1990, 02, 07),
                DepartmentId = 1,
                Gender = Gender.Male,
                PhotoPath = "images/sreenu.jpeg"
            });
        }
    }
}
