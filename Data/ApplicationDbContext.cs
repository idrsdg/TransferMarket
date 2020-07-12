using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransferMarket.Models;

namespace TransferMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        { }
        public DbSet<TransferMarket.Models.Category> Categories { get; set; }
        public DbSet<TransferMarket.Models.Player> Players { get; set; }
        
    }
}
