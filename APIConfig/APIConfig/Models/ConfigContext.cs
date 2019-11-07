using System;
using APIDataBases.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIConfig.Models
{
    public partial class ConfigContext : DbContext
    {
        public ConfigContext()
        {
        }

        public ConfigContext(DbContextOptions<ConfigContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConnectionStrings> ConnectionStrings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=E-IHERNANDEZR1;Initial Catalog=Config;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConnectionStrings>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DatabaseName)
                    .HasColumnName("Database_Name")
                    .IsUnicode(false);

                entity.Property(e => e.Db)
                    .HasColumnName("DB")
                    .IsUnicode(false);
            });
            modelBuilder.Query<GetAllDatabasesResult>();
        }
    }
}
