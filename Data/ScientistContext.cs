#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SciMet.Models;
namespace SciMet.Data
{
    public class ScientistContext : DbContext
    {
        public ScientistContext (DbContextOptions<ScientistContext> options)
            : base(options)
        {
        }

        public DbSet<SciMet.Models.Scientist> Scientist { get; set; }
    }
}