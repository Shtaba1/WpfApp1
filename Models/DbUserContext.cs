using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Windows.Controls;

namespace WpfApp1.Models
{
    //DbUserConext to jest nazwa kontekstu bazy danych, na której można wywoływać metody z Entityframeworku . Trzeba zmienić tą nazwę na bardziej adekwatną 
    public class DbUserContext : DbContext
    {
        //public DbUserContext(DbContextOptions<DbUserContext> options) : base() {}

        //deklaracja dbsetu z klasy user na users. Users to kolekcja z db
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Company>().Property(a=>a.Id).ValueGeneratedOnAdd();
            builder.Entity<User>().HasKey(a => a.UserId);
            builder.Entity<Company>().HasKey(a => a.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbProjekt;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=true;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }

}
