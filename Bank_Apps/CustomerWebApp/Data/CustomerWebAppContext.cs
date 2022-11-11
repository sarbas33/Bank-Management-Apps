using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerWebApp.Models;

namespace CustomerWebApp.Data
{
    public class CustomerWebAppContext : DbContext
    {
        public CustomerWebAppContext (DbContextOptions<CustomerWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerWebApp.Models.LoginCustomer> LoginCustomer { get; set; }
    }
}
