using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_System_ERD___Models.Models;


namespace University_System_ERD___Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> cources { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Enrollment> enrollments { get; set; }
        public DbSet<Instructor> instructors { get; set; }
        public DbSet<Student> students { get; set; }
        

        //connection sting => database address عنوان الداتا
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=UniversityDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
