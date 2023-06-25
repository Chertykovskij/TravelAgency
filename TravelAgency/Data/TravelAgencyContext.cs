using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;

namespace TravelAgency.Data
{
    /// <summary>
    /// Класс контекста базы данных
    /// </summary>
    public class TravelAgencyContext : IdentityDbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            // Для добавления таблиц пользователей
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<TravelService>()
           .HasMany(hs => hs.IncludedTours)
           .WithMany(h => h.IncludedServices)
           .UsingEntity<Dictionary<string, object>>(
               "TourIncludedServices",
               j => j.HasOne<Tour>().WithMany().HasForeignKey("TourId"),
               j => j.HasOne<TravelService>().WithMany().HasForeignKey("TravelServiceId"),
               j =>
               {
                   j.Property<int>("Id").UseIdentityColumn();
                   j.HasKey("Id");
               });

            modelBuilder.Entity<TravelService>()
           .HasMany(hs => hs.NotIcludedTours)
           .WithMany(h => h.NotIncludedServices)
           .UsingEntity<Dictionary<string, object>>(
               "TourNotIncludedServices",
               j => j.HasOne<Tour>().WithMany().HasForeignKey("TourId"),
               j => j.HasOne<TravelService>().WithMany().HasForeignKey("TravelServiceId"),
               j =>
               {
                   j.Property<int>("Id").UseIdentityColumn();
                   j.HasKey("Id");
               });


            modelBuilder.Entity<RoomAmenity>()
           .HasMany(hs => hs.Hotels)
           .WithMany(h => h.RoomAmenity)
           .UsingEntity<Dictionary<string, object>>(
               "HotelRoomAmenity",
               j => j.HasOne<Hotel>().WithMany().HasForeignKey("HotelId"),
               j => j.HasOne<RoomAmenity>().WithMany().HasForeignKey("RoomAmenityId"),
               j =>
               {
                   j.Property<int>("Id").UseIdentityColumn();
                   j.HasKey("Id");
               });

            modelBuilder.Entity<HotelFacility>()
           .HasMany(hs => hs.Hotels)
           .WithMany(h => h.HotelFacility)
           .UsingEntity<Dictionary<string, object>>(
               "HotelHotelFacility",
               j => j.HasOne<Hotel>().WithMany().HasForeignKey("HotelId"),
               j => j.HasOne<HotelFacility>().WithMany().HasForeignKey("HotelFacilityId"),
               j =>
               {
                   j.Property<int>("Id").UseIdentityColumn();
                   j.HasKey("Id");
               });
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Hotel>? Hotels { get; set; }
        public virtual DbSet<HotelFacility> HotelFacility { get; set; }
        public virtual DbSet<HotelStarRating> HotelStarRating { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        public virtual DbSet<RoomAmenity> RoomAmenity { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<TravelService> TravelService { get; set; }
        public virtual DbSet<CustomerRequest> CustomerRequests { get; set; }
    }
}
