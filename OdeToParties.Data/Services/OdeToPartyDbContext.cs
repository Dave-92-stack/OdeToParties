using OdeToParties.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToParties.Data.Services
{
    public class OdeToPartyDbContext : DbContext
    {
        public DbSet<Party> Parties { get; set; }
    }
}
