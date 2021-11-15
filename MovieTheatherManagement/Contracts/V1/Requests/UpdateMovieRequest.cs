using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTheatherManagement.Contracts.V1.Requests
{
    public class UpdateMovieRequest
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
