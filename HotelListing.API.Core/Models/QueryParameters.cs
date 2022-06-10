namespace HotelListing.API.Models
{
    public class QueryParameters
    {
        private int _pagesize = 15;

        public int StartIndex { get; set; }

        public int PageNumber { get; set; }


        public int PageSize
        {
            get
            {
                return _pagesize;
            }
            set
            {
                _pagesize = value;
            }
        }

    }
}
