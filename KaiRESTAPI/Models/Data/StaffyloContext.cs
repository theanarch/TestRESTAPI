using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KaiRESTAPI.Models.Data
{
    public partial class StaffyloContext : DbContext
    {
        public virtual DbSet<Country> Countries { get; set; }

        public StaffyloContext()
        {
        }

        public StaffyloContext(DbContextOptions<StaffyloContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(140)
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(140);
            });
        }
    }
}
