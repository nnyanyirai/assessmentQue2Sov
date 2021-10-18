using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SingleDotNetCoreWebApp.Models;

namespace Question2WebAPI.Data
{
    public class Question2WebAPIContext : DbContext
    {
        public Question2WebAPIContext (DbContextOptions<Question2WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SingleDotNetCoreWebApp.Models.Company> Company { get; set; }

        public DbSet<SingleDotNetCoreWebApp.Models.Address> Address { get; set; }

        public DbSet<SingleDotNetCoreWebApp.Models.Contact> Contact { get; set; }
    }
}
