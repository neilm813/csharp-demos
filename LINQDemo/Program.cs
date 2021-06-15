using System;
using System.Collections.Generic;
using System.Linq;
using LINQDemo.Models;

namespace LINQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie("Blood Diamond", "Leonardo DiCaprio", 8, 2006),
                new Movie("The Departed", "Leonardo DiCaprio", 8.5, 2006),
                new Movie("Gladiator", "Russell Crowe", 8.5, 2000),
                new Movie("A Beautiful Mind", "Russell Crowe", 8.2, 2001),
                new Movie("Good Will Hunting", "Matt Damon", 8.3, 1997),
                new Movie("The Martian", "Matt Damon", 8, 2015),
                new Movie("Robocop", "Peter Weller", 10, 1984),
                new Movie("Robocop", "Joel Kinneman", 7, 2014),
            };

            List<Actor> actors = new List<Actor>
            {
                new Actor { FullName = "Matt Damon", Age = 48 },
                new Actor { FullName = "Leonardo DiCaprio", Age = 44 },
                new Actor { FullName = "Peter Weller", Age = 61 },
            };

            Movie selectedMovie = movies.FirstOrDefault(m => m.Title == "Robocop");
            int oldestYear = movies.Min(m => m.Year);
            selectedMovie = movies.FirstOrDefault(m => m.Year == oldestYear);
            selectedMovie = movies.FirstOrDefault(m => m.Year == movies.Min(movie => movie.Year));

            // Console.WriteLine("oldest movie:" + selectedMovie);

            List<Movie> selectedMovies = null;

            selectedMovies = movies.Where(m => m.Title == "Robocop").ToList();
            // PrintEach(selectedMovies, "Robocop movies.");

            selectedMovies = movies.Where(m => m.Title.Contains("The")).ToList();
            // PrintEach(selectedMovies, "Movies where title contains 'The'.");

            /* 
            SELECT *
            FROM movies
            WHERE LeadActor = "Russell Crow" AND Year > 2000;
            */
            selectedMovies = movies.Where(m => m.LeadActor == "Russell Crowe" && m.Year > 2000).ToList();
            // PrintEach(selectedMovies, "Russell Crowe Movies after year 2000.");

            List<string> movieNames = movies
                .Where(m => m.LeadActor == "Russell Crowe" || m.LeadActor == "Matt Damon")
                .OrderByDescending(m => m.Rating)
                .Select(m => m.Title)
                .ToList();

            PrintEach(movieNames, "Movie titles with Russell or Matt actors.");

            // Advanced, NOT ON EXAM
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
            Console.WriteLine("\n" + label);

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
