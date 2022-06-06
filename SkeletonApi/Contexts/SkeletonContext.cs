
using Microsoft.EntityFrameworkCore;
using SkeletonApi.Data;
using SkeletonApi.Models.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SkeletonApi.Contexts
{
    public class SkeletonContext : DbContext
    {
        public SkeletonContext(DbContextOptions<SkeletonContext> options) : base(options)
        {
        }
        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added) { }
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
                if (entry.State == EntityState.Modified)
                    ((BaseEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;
            }
            return await base.SaveChangesAsync(true, cancellationToken);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Deleted || e.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added) { }
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
                if (entry.State == EntityState.Modified)
                    ((BaseEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbSeeder.GetCategories().ForEach(c => modelBuilder.Entity<Category>().HasData(c));
            DbSeeder.GetProducts().ForEach(p => modelBuilder.Entity<Product>().HasData(p));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }    
    }
}
