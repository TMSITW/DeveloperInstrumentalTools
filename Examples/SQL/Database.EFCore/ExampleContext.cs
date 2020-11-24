using System;
using Database.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.EFCore
{
    public partial class ExampleContext : DbContext
    {
        public DbSet<SummaryEntity> Summaries { get; set; }
        public DbSet<WeatherEntity> Weathers { get; set; }
        
        public DbSet<CurrencyEntity> Currencys { get; set; }
        
        public DbSet<ExchangeRateEntity> Rates { get; set; }
        
        public ExampleContext()
        {
        }

        public ExampleContext(DbContextOptions<ExampleContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=postgres;User ID=postgres;Password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            modelBuilder.Entity<WeatherEntity>(entity =>
            {
                entity.ToTable("Weather");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.Summary);
            });

            modelBuilder.Entity<SummaryEntity>(entity =>
            {
                entity.ToTable("Summary");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });
            
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 1, Code = "Freezing" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 2, Code = "Bracing" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 3, Code = "Chilly" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 4, Code = "Cool" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 5, Code = "Mild" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 6, Code = "Warm" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 7, Code = "Balmy" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 8, Code = "Hot" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 9, Code = "Sweltering" });
            modelBuilder.Entity<SummaryEntity>().HasData(new SummaryEntity { Id = 10, Code = "Scorching" });
            
            modelBuilder.Entity<WeatherEntity>().HasData(new
            {
                Id = 1, 
                TimeStamp = new DateTime(2020, 1, 1),
                Temperature = -1.3m,
                SummaryId = 3
            });
            
            modelBuilder.Entity<WeatherEntity>().HasData(new
            {
                Id = 2, 
                TimeStamp = new DateTime(2020, 1, 2),
                Temperature = 5.1m,
                SummaryId = 5
            });
            
            modelBuilder.Entity<WeatherEntity>().HasData(new
            {
                Id = 3, 
                TimeStamp = new DateTime(2020, 1, 3),
                Temperature = -10m,
                SummaryId = 1
            });
            
            modelBuilder.Entity<ExchangeRateEntity>(entity =>
            {
                entity.ToTable("Rate");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                entity.HasOne(d => d.Currency);
            });
            
            modelBuilder.Entity<CurrencyEntity>(entity =>
            {
                entity.ToTable("Currency");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
            });
            
            modelBuilder.Entity<CurrencyEntity>().HasData(new CurrencyEntity() { Id = 1, Name = "RUB" });
            modelBuilder.Entity<CurrencyEntity>().HasData(new CurrencyEntity() { Id = 2, Name = "EUR" });
            modelBuilder.Entity<CurrencyEntity>().HasData(new CurrencyEntity() { Id = 3, Name = "USD" });
            
            modelBuilder.Entity<ExchangeRateEntity>().HasData(new
            {
                Id = 1, 
                CurrencyId = 1,
                Date = new DateTime(2020, 11, 24, 15, 05, 45, 0, DateTimeKind.Unspecified),
                Value = 1.0
            });
            
            modelBuilder.Entity<ExchangeRateEntity>().HasData(new
            {
                Id = 2, 
                CurrencyId = 2,
                Date = new DateTime(2020, 11, 24, 16, 10, 34, 0, DateTimeKind.Unspecified),
                Value = 95.0
            });
            
            modelBuilder.Entity<ExchangeRateEntity>().HasData(new
            {
                Id = 3, 
                CurrencyId = 3,
                Date = new DateTime(2020, 11, 24, 16, 10, 35, 0, DateTimeKind.Unspecified),
                Value = 80.0
            });
            
            //modelBuilder.Entity<WeatherEntity>().OwnsOne(p => p.Summary).HasData(new { Date = new DateTime(2020, 1, 1), Temperature = -1, Code = "Chill" });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
