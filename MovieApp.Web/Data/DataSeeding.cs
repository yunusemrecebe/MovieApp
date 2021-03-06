using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Web.Entity;

namespace MovieApp.Web.Data
{
    public static class DataSeeding
    {
        public static void Seed(IApplicationBuilder builder)
        {
            var scope = builder.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();
            
            context.Database.Migrate();

            if (context.Database.GetPendingMigrations().Count()==0)
            {
                if (context.Movies.Count()==0)
                {
                    context.Movies.AddRange(
                        new List<Movie>()
        {
                new Movie {
                Title="Jiu Jitsu",
                Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                ImageUrl="1.jpg",
                GenreId=1
            },
            new Movie {
                Title="Fatman",
                Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                ImageUrl="2.jpg",
                GenreId=1
            },
            new Movie {
                Title="The Dalton Gang",
                Description="When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
                ImageUrl="3.jpg",
                GenreId=3
            },
                new Movie {
                Title="Tenet",
                Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                ImageUrl="4.jpg",
                GenreId=3
            },
            new Movie {
                Title="The Craft: Legacy",
                Description="An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
                ImageUrl="5.jpg",
                GenreId=3
            },
            new Movie {
                Title="Hard Kill",
                Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
                ImageUrl="6.jpg",
                GenreId=4
            }
        }
                        );
                }
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(
                        new List<Genre>()
                        {
                            new Genre {Name="Macera"},
                            new Genre {Name="Komedi"},
                            new Genre {Name="Romantik"},
                            new Genre {Name="Savaş"},
                            new Genre {Name="Bilim Kurgu"}
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
