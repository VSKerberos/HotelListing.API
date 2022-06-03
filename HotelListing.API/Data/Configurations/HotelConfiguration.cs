using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Grand Palladium",
                    Address = "George Town",
                    CountryId = 1,
                    Rating = 4.5
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
