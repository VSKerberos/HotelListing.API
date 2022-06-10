using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;

namespace HotelListing.API.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly HotelListingDbContext context;
        private readonly IMapper mapper;

        public HotelsRepository(HotelListingDbContext context, IMapper mapper) : base(context,mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
