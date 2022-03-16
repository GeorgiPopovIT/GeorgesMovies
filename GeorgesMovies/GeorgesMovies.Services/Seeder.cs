using GeorgesMovies.Data;
using GeorgesMovies.Models.Models;
using System;
using System.Collections.Generic;

namespace GeorgesMovies.Services
{
    public static class Seeder
    {
        public static void SeedData(GeorgesMoviesDbContext data)
        {
            data.Directors.Add(new Director { FirstName = "Andrew", LastName = "Gaynord" });
            var movieToSeed = new Movie
            {
                Title = "All My Friends Hate Me",
                Time = "1h 33min",
                ReleaseDate = DateTime.Parse("11/5/2022"),
                Overview = "Pete is cautiously excited about reuniting with his college crew for a birthday weekend. But, one by one, his friends slowly turn against him. Is he being punished, is he paranoid, or is he part of some sick joke?",
                Review = @"A week after watching it, I'm still thinking about the themes in this film, chuckling at the comic genius of Dustin Demri-Burns, and admiring the terseness of the script. I have not seen anything like it before.

The fantastic soundtrack, together with direction and cinematography conspire to create a truly visceral edginess.

Much like Pete's friends, the film never allows you to know where you are. It pulls you in with sympathy for Pete (and all the characters), then stands back to show you his cringe-worthy self-centredness and inauthenticity, then twists and turns again in a way that makes the film incredibly engaging.

There are certainly class issues explored and some 'horrible toffs', but perhaps the nerve-shattering power of All My Friends Hate Me is that the alternating hubris and insecurity, the not knowing how to take a joke, the unsaid, the just-below-the-skin aggression of the people who profess to love you, are so recognisable to all of us (especially in England). The film feels of the moment, in an age of individualistic anxiety, vascilating self-branding and self-doubt. The conceit of the film seems a bit like Kafka's Trial, with Pete a kind of modern-day Josef K.

A superb social satire.",
                PictureUrl = "https://m.media-amazon.com/images/M/MV5BYzViNzU1NjItNmE0Mi00ZWI0LTg5MmQtZDMxZmQ3NGY5ODZlXkEyXkFqcGdeQXVyMTM1MTE1NDMx._V1_QL75_UX180_CR0,7,180,266_.jpg",
                MovieUrl = "https://www.youtube.com/embed/WP6Q34uRdPM",
                GenreId = 1,
                DirectorId = 1,
                Rating = 7.5m
            };

            data.Movies.AddRange(new[]
            {
              movieToSeed
            });
            var actorsToSeed = new List<Actor>();

            actorsToSeed.AddRange(new[]
            {
                new Actor
                {
                    FirstName = "Georgina" ,
                    LastName = "Campbell",
                    Information = @"Georgina Campbell is an actress, known for Murdered by My Boyfriend (2014), Black Mirror (2011) and Suspicion (2022).
"
                },
                new Actor
                {
                    FirstName = "Joshua",
                    LastName = "McGuire",
                    Information = @"Joshua McGuire is an actor and writer, known for Lovesick (2014), About Time (2013) and Mr. Turner (2014).
"
                }
            });
            movieToSeed.Actors.Add(actorsToSeed[0]);
            movieToSeed.Actors.Add(actorsToSeed[1]);

            data.SaveChanges();

        }
    }
}
