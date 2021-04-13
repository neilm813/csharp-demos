using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Intro
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie> {
                new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
                new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
                new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
                new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
                new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
                new Movie("The Martian", "Matt Damon", 8, 2015),
            };

            List<Actor> actors = new List<Actor> {
                new Actor { FullName = "Matt Damon", Age = 48 },
                new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
            };

            Movie selectedMovie = movies.FirstOrDefault(film => film.Title == "Gladiator");
            Console.WriteLine("selected movie: " + selectedMovie);

            selectedMovie = movies.FirstOrDefault(m => m.Title == "abc");
            Console.WriteLine("selected movie: " + selectedMovie);

            Movie oldestMovie = movies.FirstOrDefault(m => m.Year == movies.Min(film => film.Year));
            Console.WriteLine("oldestMovie: " + oldestMovie);

            IEnumerable<Movie> orderedMovies = movies.OrderBy(movie => movie.Title);
            PrintEach(orderedMovies, "Alphabetical Title Movies");

            orderedMovies = movies.OrderByDescending(m => m.Title);
            PrintEach(orderedMovies, "Reverse Alphabetical Title Movies");

            IEnumerable<Movie> filteredMovies = movies.Where(movie => movie.LeadActor == "Leonardo DiCaprio");
            PrintEach(filteredMovies, "Leo's Movies");

            filteredMovies = movies.Where(movie => movie.Title.StartsWith("T"));
            PrintEach(filteredMovies, "Title starts with 'T'");

            filteredMovies = movies.Where(mov => mov.Title.Contains("ood"));
            PrintEach(filteredMovies, "Title contains 'ood'");

            filteredMovies = movies.Where(m => m.LeadActor == "Russell Crowe" && m.Year > 2000);
            PrintEach(filteredMovies, "Crowe movies after year 2000");

            List<string> mattDamonMovieTitles =
                movies
                    .Where(m => m.LeadActor == "Matt Damon")
                    .Select(m => m.Title)
                    .ToList();
            PrintEach(mattDamonMovieTitles, "Matt Damon Movie Titles:");

            // Extra, you don't need to know this now.
            var moviesAndActor = movies
                .Join(actors, // join with actors list
                    movie => movie.LeadActor, // movie.LeadActor ==
                    actor => actor.FullName, // actor.FullName
                    (movie, actor) => new { movie, actor } // return new dict with movie and actor inside
                ).Where(movieAndActor => movieAndActor.actor.FullName == "Leonardo DiCaprio")
                .ToList();

            PrintEach(moviesAndActor);
            Console.WriteLine(moviesAndActor[0].actor.Age);
        }

        public static void PrintEach(IEnumerable<dynamic> items, string label = "")
        {
            Console.WriteLine(new String('-', 80));
            Console.WriteLine("\n" + label);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
