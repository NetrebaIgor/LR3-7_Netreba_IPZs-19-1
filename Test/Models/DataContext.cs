using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class DataContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<InsuranceСar> Cars { get; set; }
        public DbSet<InsuranceMedic> Medic { get; set; }
        public DbSet<InsuranceCOVID> COVID { get; set; }
        public DbSet<InsuranceAutoCitizen> AutoCitizens { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
            Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@gmail.com";
            string adminPassword = "123456";
            string adminName = "Ігор";
            string adminSurname = "Нетреба";
            string adminPetronymic = "Вікторович";
            string adminPhone = "0689383086";


            
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword,Name = adminName,Surname = adminSurname,Petronymic=adminPetronymic,Phone=adminPhone, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
