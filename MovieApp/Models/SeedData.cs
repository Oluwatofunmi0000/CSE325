using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MovieApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                // Look for any movies.
                if (context.Movies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "Inception",
                        Genre = "Sci-Fi",
                        Year = 2010,
                        Director = "Christopher Nolan"
                    },
                    new Movie
                    {
                        Title = "The Matrix",
                        Genre = "Action",
                        Year = 1999,
                        Director = "The Wachowskis"
                    },
                    new Movie
                    {
                        Title = "Interstellar",
                        Genre = "Sci-Fi",
                        Year = 2014,
                        Director = "Christopher Nolan"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}