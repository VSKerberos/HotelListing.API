using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext context;
        private readonly IMapper mapper;

        public CountriesRepository(HotelListingDbContext context, IMapper mapper) : base(context,mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async  Task<Country> GetDetails(int? id)
        {
            return await context.Countries.Include(q=>q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
