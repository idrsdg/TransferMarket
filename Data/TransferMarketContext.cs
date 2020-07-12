using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransferMarket.Models;

namespace TransferMarket.Data
{
    public class TransferMarketContext : DbContext
    {
        public TransferMarketContext (DbContextOptions<TransferMarketContext> options)
            : base(options)
        {
        }

        public DbSet<TransferMarket.Models.Comment> Comment { get; set; }
    }
}
