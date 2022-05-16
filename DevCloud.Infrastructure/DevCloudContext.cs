using DevCloud.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCloud.Infrastructure
{
    public class DevCloudContext : DbContext
    {
        public DevCloudContext()
        {
        }

        public DevCloudContext(DbContextOptions<DevCloudContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           ModelBuilderExtensions.Seed(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

        }
    }
}
