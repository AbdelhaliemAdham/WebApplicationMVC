using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                      {
                        Id = 1,
                        Name = "Royal Villa",
                        Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        Image = "https://placehold.co/600x400",
                        Occupancy = 4,
                        Price = 200,
                        Sqfeet = 550,
                      },
                    new Villa
                    {
                        Id = 2,
                        Name = "Premium Pool Villa",
                        Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        Image = "https://placehold.co/600x401",
                        Occupancy = 4,
                        Price = 300,
                        Sqfeet = 550,
                    },
                    new Villa
                    {
                        Id = 3,
                        Name = "Luxury Pool Villa",
                        Description = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                        Image = "https://placehold.co/600x402",
                        Occupancy = 4,
                        Price = 400,
                        Sqfeet = 750,
                    });
            modelBuilder.Entity<VillaNumber>().HasData(
                 new VillaNumber
                 {
                     Villa_Number = 1001,
                     VillaId = 1,
                 },
                 new VillaNumber
                 {
                     Villa_Number = 1002,
                     VillaId = 1,
                 },
                 new VillaNumber
                 {
                     Villa_Number = 1003,
                     VillaId = 1,
                 },
                 new VillaNumber
                 {
                     Villa_Number = 2001,
                     VillaId = 2,
                 },
                  new VillaNumber
                  {
                      Villa_Number = 2002,
                      VillaId = 2,
                  },
                   new VillaNumber
                   {
                       Villa_Number = 2003,
                       VillaId = 2,
                   },
                    new VillaNumber
                    {
                        Villa_Number = 3001,
                        VillaId = 3,
                    },
                    new VillaNumber
                    {
                        Villa_Number = 3002,
                        VillaId = 3,
                    },
                    new VillaNumber
                    {
                        Villa_Number = 3003,
                        VillaId = 3,
                    }






                );
        }
        
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
    }
}
