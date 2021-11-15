using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTheatherManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTheatherManagement.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
