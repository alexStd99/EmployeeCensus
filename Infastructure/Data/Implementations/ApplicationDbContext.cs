using EmployeeCensus.Domain.Entities;
using EmployeeCensus.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCensus.Infastructure.Data.Implementations
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var departmentIds = new Guid[10];
            var programmingLanguageIds = new Guid[10];
            var employeeIds = new Guid[10];

            for (int i = 0; i < 10; i++)
            {
                departmentIds[i] = Guid.NewGuid();
                programmingLanguageIds[i] = Guid.NewGuid();
                employeeIds[i] = Guid.NewGuid();
            }


            modelBuilder.Entity<Department>().HasData(
                new Department { Id = departmentIds[0], Name = "HR", Floor = 1, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[1], Name = "IT", Floor = 2, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[2], Name = "Finance", Floor = 3, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[3], Name = "Marketing", Floor = 4, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[4], Name = "Sales", Floor = 5, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[5], Name = "Support", Floor = 6, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[6], Name = "R&D", Floor = 7, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[7], Name = "Operations", Floor = 8, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[8], Name = "Logistics", Floor = 9, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Department { Id = departmentIds[9], Name = "Legal", Floor = 10, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<ProgrammingLanguage>().HasData(
                new ProgrammingLanguage { Id = programmingLanguageIds[0], Name = "C#", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[1], Name = "Java", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[2], Name = "Python", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[3], Name = "JavaScript", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[4], Name = "Ruby", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[5], Name = "Go", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[6], Name = "Swift", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[7], Name = "Kotlin", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[8], Name = "PHP", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new ProgrammingLanguage { Id = programmingLanguageIds[9], Name = "Rust", CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = employeeIds[0], FirstName = "John", LastName = "Doe", Age = 30, Gender = Gender.Male, DepartmentId = departmentIds[0], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[1], FirstName = "Jane", LastName = "Doe", Age = 28, Gender = Gender.Female, DepartmentId = departmentIds[1], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[2], FirstName = "Mike", LastName = "Smith", Age = 35, Gender = Gender.Male, DepartmentId = departmentIds[2], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[3], FirstName = "Emily", LastName = "Johnson", Age = 32, Gender = Gender.Female, DepartmentId = departmentIds[3], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[4], FirstName = "Chris", LastName = "Brown", Age = 40, Gender = Gender.Male, DepartmentId = departmentIds[4], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[5], FirstName = "Anna", LastName = "Davis", Age = 29, Gender = Gender.Female, DepartmentId = departmentIds[5], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[6], FirstName = "James", LastName = "Miller", Age = 45, Gender = Gender.Male, DepartmentId = departmentIds[6], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[7], FirstName = "Laura", LastName = "Wilson", Age = 34, Gender = Gender.Female, DepartmentId = departmentIds[7], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[8], FirstName = "David", LastName = "Moore", Age = 50, Gender = Gender.Male, DepartmentId = departmentIds[8], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Employee { Id = employeeIds[9], FirstName = "Sophia", LastName = "Taylor", Age = 27, Gender = Gender.Female, DepartmentId = departmentIds[9], IsDeleted = false, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<Experience>().HasData(
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[0], ProgrammingLanguageId = programmingLanguageIds[0], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[1], ProgrammingLanguageId = programmingLanguageIds[1], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[2], ProgrammingLanguageId = programmingLanguageIds[2], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[3], ProgrammingLanguageId = programmingLanguageIds[3], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[4], ProgrammingLanguageId = programmingLanguageIds[4], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[5], ProgrammingLanguageId = programmingLanguageIds[5], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[6], ProgrammingLanguageId = programmingLanguageIds[6], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[7], ProgrammingLanguageId = programmingLanguageIds[7], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[8], ProgrammingLanguageId = programmingLanguageIds[8], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new Experience { Id = Guid.NewGuid(), EmployeeId = employeeIds[9], ProgrammingLanguageId = programmingLanguageIds[9], CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.NewGuid(), Username = "user1", Password = "password1", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user2", Password = "password2", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user3", Password = "password3", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user4", Password = "password4", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user5", Password = "password5", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user6", Password = "password6", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user7", Password = "password7", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user8", Password = "password8", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user9", Password = "password9", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow },
                new User { Id = Guid.NewGuid(), Username = "user10", Password = "password10", LastActionTime = DateTime.UtcNow, CreatedDate = DateTime.UtcNow, EditDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Age).IsRequired();
                entity.Property(e => e.Gender).IsRequired();
                entity.HasOne(e => e.Department)
                      .WithMany()
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Name).IsRequired().HasMaxLength(50);
                entity.Property(d => d.Floor).IsRequired();
            });

            modelBuilder.Entity<ProgrammingLanguage>(entity =>
            {
                entity.HasKey(pl => pl.Id);
                entity.Property(pl => pl.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(exp => exp.Id);
                entity.HasOne(exp => exp.Employee)
                      .WithMany(e => e.Experiences)
                      .HasForeignKey(exp => exp.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(exp => exp.ProgrammingLanguage)
                      .WithMany()
                      .HasForeignKey(exp => exp.ProgrammingLanguageId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(50);
                entity.Property(u => u.LastActionTime).IsRequired();
            });
        }
    }
}
