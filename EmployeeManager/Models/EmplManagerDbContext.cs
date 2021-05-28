using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    // utilisation de IdentityDbContext au lieu de DbContext  car
    // je veux ajouter l'authentification 
    public class EmplManagerDbContext : IdentityDbContext
    {
        // classe qui va communiquer avec notre base de donnee. Elle derive de la classe DbContext de Microsoft.EntityFrameworkCore
        // notre classe prend comme paramettre DbContextOptions(classe generique) qui va nous fournir tous les outils pour que notre classe communique avec la BD
        public EmplManagerDbContext(DbContextOptions<EmplManagerDbContext> options) :
            base(options)
        {

        }

        // instance qui nous permet de sauvegarder et interroger une entite Employer dans la BD
        public DbSet<Employee> EmployeeDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>();
           //modelBuilder.Entity<Employee>().HasData(
           //      new Employee() { Id = 1, Name = "Michel", Email = "michel@logient.ca", Department = DeptEnum.NET },
           //      new Employee() { Id = 2, Name = "Adrien", Email = "adrien@logient.ca", Department = DeptEnum.NET },
           //      new Employee() { Id = 3, Name = "Sophie", Email = "sophie@logient.ca", Department = DeptEnum.NET }
           //     );


        }
    }
}
