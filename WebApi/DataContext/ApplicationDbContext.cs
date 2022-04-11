using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {

        }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasData(new Users
                {
                    Id = 1,
                    UserName = "user1",
                    Password = "user1"
                },
                new Users
                {
                    Id = 2,
                    UserName = "user2",
                    Password = "user2"
                },
                new Users
                {
                    Id = 3,
                    UserName = "user3",
                    Password = "user3"
                }
                );

        }

    }
}