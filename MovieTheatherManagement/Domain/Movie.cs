using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MovieTheatherManagement.Domain
{    
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
