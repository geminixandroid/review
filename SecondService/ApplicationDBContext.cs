using Microsoft.EntityFrameworkCore;
using SecondService.Models;

namespace SecondService
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.UserId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Organization>()
                .Property(p => p.OrganizationId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Organization>().HasData(
                 new Organization
                 {
                     OrganizationId = 1,
                     OrganizationName = "ООО Рога и Копыта"
                 }
                , new Organization
                  {
                      OrganizationId = 2,
                      OrganizationName = "ЗАО Березка"
                  });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "Имя1",
                LastName = "Фамилия1",
                Email = "Почта1",
                MobilePhoneNumber = "Телефон1",
                OrganizationId = 1
            },
             new User
             {
                UserId = 2,
                FirstName = "Имя2",
                LastName = "Фамилия2",
                Email = "Почта2",
                MobilePhoneNumber = "Телефон2",
                OrganizationId = 1
            }
             ,
             new User
             {
                 UserId = 3,
                 FirstName = "Имя3",
                 LastName = "Фамилия3",
                 Email = "Почта3",
                 MobilePhoneNumber = "Телефон3",
                 OrganizationId =2
             });
        }      
    }
}
