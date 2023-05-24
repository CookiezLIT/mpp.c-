using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Data;

public class FlightContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=tarom;User Id=postgres; Password=root");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>()
            .Property(f => f.Id)
                .HasColumnName("id");

        modelBuilder.Entity<Flight>()
            .Property(f => f.Departure)
                .HasColumnName("departure");

        modelBuilder.Entity<Flight>()
            .Property(f => f.Destination)
                .HasColumnName("destination");

        modelBuilder.Entity<Flight>()
            .Property(f => f.DepartureDateTime)
                .HasColumnName("departure_date_time");

        modelBuilder.Entity<Flight>()
            .Property(f => f.ArrivalDateTime)
                .HasColumnName("arrival_date_time");

        modelBuilder.Entity<Flight>()
            .Property(f => f.Capacity)
                .HasColumnName("capacity");

        modelBuilder.Entity<Flight>()
            .ToTable("flight", "public")
            .HasKey(x => x.Id);
        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<Flight> Flights { get; set; }
}
