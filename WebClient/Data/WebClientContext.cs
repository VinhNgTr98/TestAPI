using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebClient.Model;

namespace WebClient.Data
{
    public class WebClientContext : DbContext
    {
        public WebClientContext (DbContextOptions<WebClientContext> options)
            : base(options)
        {
        }

        public DbSet<WebClient.Model.Book> Book { get; set; } = default!;
        public DbSet<WebClient.Model.Accounts> Account { get; set; } = default!;
    }
}
