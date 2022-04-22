using Microsoft.EntityFrameworkCore;
using SciMet.Data;
// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Linq;


namespace SciMet.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScientistContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ScientistContext>>()))
            {
                if (context == null || context.Scientist == null)
                {
                    throw new ArgumentNullException("Null ScientistContext");
                }

                // Look for any movies.
                if (context.Scientist.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scientist.AddRange(
                    new Scientist
                    {
                        ID = 1,
                        Name = "Glenn Tesler",
                        Title = "Professor",
                        Research = "Graph Theory"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}