using CurrencyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyAPI
{
    public class CurrenciesDbContext : DbContext
    {
        public CurrenciesDbContext()
        {
            //Database.EnsureDeleted();
             Database.EnsureCreated();
        }

        public virtual DbSet<DayModel> Days { get; set; }
        public virtual DbSet<CurrencyModel> Currencies { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CurrencyApi");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                optionsBuilder.UseSqlite("Data Source = " + path + "\\Currency.db");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DayModel>(entity =>
            {
                entity.ToTable("currency_day");

                entity.HasKey(key => key.Date);
            });

            modelBuilder.Entity<CurrencyModel>(entity =>
            {
                entity.ToTable("currency");

                entity.HasKey(key => new { key.ValuteID, key.DayCurrencyID });

                entity.HasOne(x => x.Day)
                    .WithMany(p => p.Currencies)
                    .HasForeignKey(с => с.DayCurrencyID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.ToTable("users");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role");
            });
        }
    }

}
