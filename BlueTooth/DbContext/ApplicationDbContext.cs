using BlueTooth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

 


        public DbSet<Firma> Firme { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<DentalCheckUp> DentalChecks { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<EstablishedDiagnosis> EstablishedDiagnosis { get; set; }

        public DbSet<DentalCheck_Worker> DentalCheck_Workers { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Service> Services{ get; set; }

        public DbSet<DentalCheck_Service> DentalCheckServices { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Matherial> Matherials { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Service_Materials> ServiceMaterials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<DentalCheck_Worker>
                ().HasKey(c => new { c.DentalCheckUpId, c.WorkerId });

            builder.Entity<DentalCheck_Service>
                ().HasKey(c => new { c.DentalCheckID, c.ServiceID });

            builder.Entity<Service_Materials>
                ().HasKey(c => new { c.ServiceId, c.MatherialId });

            

            builder.Entity<Service>().HasData(
                   new Service { Id = 1, Name = "Jednopovršinska plomba", Price= 30 },
                   new Service { Id = 2, Name = "Dvopovršinska plomba", Price = 40 },
                   new Service { Id = 3, Name = "Višepovršinska plomba", Price = 50 },
                   new Service { Id = 4, Name = "Liječenje jednokorjenog zuba", Price = 70 },
                   new Service { Id = 5, Name = "Liječenje višekorjenog zuba", Price = 120 },
                   new Service { Id = 6, Name = "Extrakcija (vađenje zuba)", Price = 30 },
                   new Service { Id = 7, Name = "Extrakcija zuba sa šivanjem", Price = 50 },
                   new Service { Id = 8, Name = "Extrakcija mliječnog zuba", Price = 20 },
                   new Service { Id = 9, Name = "Zalivanje fisura", Price = 20 },
                   new Service { Id = 10, Name = "Čišćenje zubnog kamenca", Price = 40 },
                   new Service { Id = 11, Name = "Bijeljenje zuba", Price = 350 },
                   new Service { Id = 12, Name = "Bijeljenje liječenog zuba", Price = 80 },
                   new Service { Id = 13, Name = "Metalokeramička kruna", Price = 160 },
                   new Service { Id = 14, Name = "Bezmetalna (cirkonij) kruna", Price = 400 },
                   new Service { Id = 15, Name = "Totalna proteza", Price = 300 },
                   new Service { Id = 16, Name = "Parcijalna proteza", Price = 300 },
                   new Service { Id = 17, Name = "Parcijalna (wisil) proteza", Price = 650 },
                   new Service { Id = 18, Name = "Ugradnja implanta (straumann)", Price = 1500},
                   new Service { Id = 19, Name = "Ugradnja implanta (mis)", Price = 1200 },
                   new Service { Id = 20, Name = "Ugradnja implanta (direct)", Price = 1000 },
                   new Service { Id = 21, Name = "Hirurško vađenje umnjaka", Price = 160 },
                   new Service { Id = 22, Name = "Hirurško vađenje zuba", Price = 100 },
                   new Service { Id = 23, Name = "Apikotomija (uklanjanje vrha korjena zuba)", Price = 160 },
                   new Service { Id = 24, Name = "Incizija", Price = 70 },
                   new Service { Id = 25, Name = "Ortodontski mobilni aparat", Price = 350 },
                   new Service { Id = 26, Name = "Ortodontski fiksni aparat (metalne bravice)", Price = 1200 },
                   new Service { Id = 27, Name = "Ortodontski fiksni aparat (estetske bravice)", Price = 1200 }
               );



        }


    }


}
