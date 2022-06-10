using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace HotelListing.API.Data
{
    public class ApiUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
