using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id=1,
                    Name="Turkey",
                    ShortName="TR"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    Id = 3,
                    Name = "Cayman Island",
                    ShortName = "CI"
                }
                );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id=1,
                    Name="Grand Palladium",
                    Address="George Town",
                    CountryId=1,
                    Rating=4.5
                },
                  new Hotel
                  {
                      Id = 2,
                      Name = "Sandals Resort and Spa",
                      Address = "Negril",
                      CountryId = 2,
                      Rating = 4.1
                  },
                   new Hotel
                   {
                       Id = 3,
                       Name = "Noah",
                       Address = "Kyrenia",
                       CountryId = 3,
                       Rating = 4.0
                   }

                );
        }
    }
}
