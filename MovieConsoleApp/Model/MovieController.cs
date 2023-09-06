using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieCLassLibrary;
using MovieCLassLibrary.Model;

namespace MovieConsoleApp.Model
{
    internal class MovieController
    {
        private MovieManager storage;
        string filePath = @"C:\Users\albin.kurian\Desktop\DotNet\section16.5\MovieConsoleApp\movieFile.txt";
        public MovieController()
        {
            storage = new MovieManager(filePath);
        }

        public void UploadMovie()
        {
            Console.Write("Enter the movie title: ");
            string movieName = Console.ReadLine();

            Console.Write("Enter the movie ID: ");
            //int movieId = Convert.ToInt32(Console.ReadLine());
            string movieIdInput = "";
            movieIdInput = Console.ReadLine();
            if (!int.TryParse(movieIdInput, out int movieId))
            {
                throw new MovieException("enter an Integer");
            }


            Console.Write("Enter the movie year: ");
            //int year = Convert.ToInt32(Console.ReadLine());
            string yearInput = "";
            yearInput = Console.ReadLine();
            if (!int.TryParse(yearInput, out int year))
            {
                throw new MovieException("Enter Year as Integer");


            }
            if (year < 1000 || year > 9999)
            {
                throw new MovieException("Year must be a 4-digit number.");
            }
            Console.Write("Enter the movie director: ");
            string director = Console.ReadLine();

            storage.UploadMovie(movieId, movieName, year, director);


            Console.WriteLine("Movie uploaded successfully.");
        }

        public void DisplayMovies()
        {
            string movieDetails = storage.DisplayMovies();

            if (string.IsNullOrEmpty(movieDetails))
            {
                Console.WriteLine("Storage is empty.");
            }
            else
            {
                Console.WriteLine("Movies in storage:");
                Console.WriteLine(movieDetails);
            }
        }

        public void Delete()
        {
            string indexInput = "";

            Console.Write("Enter the index of the movie to delete: ");
            indexInput = Console.ReadLine();

            if (int.TryParse(indexInput, out int index))
            {
                storage.DeleteMovie(index);
                Console.WriteLine("Movie deleted successfully.");
            }
            throw new MovieException("Enter an Integer");

        }


        public void SearchMoviesByYear()
        {
            Console.Write("Enter the year to search for: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                List<Movie> searchResults = storage.SearchByYear(year);

                if (searchResults.Count == 0)
                {
                    Console.WriteLine("No movies found for the specified year.");
                }
                else
                {
                    Console.WriteLine($"Movies released in {year}:");
                    foreach (var movie in searchResults)
                    {
                        Console.WriteLine($"{movie.MovieName} (Directed by {movie.Director})");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid year. Please enter a valid year.");
            }
        }
        public void Start()
        {
            int choice = 0;
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Upload Movie");
                Console.WriteLine("2. Display Movies");
                Console.WriteLine("3. Delete Movie");
                Console.WriteLine("4. search by year");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your Choice: ");
                string userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out choice))
                {
                    throw new MovieException("Enter an Integer");

                }


                switch (choice)
                {
                    case 1:
                        try
                        {
                            UploadMovie();
                        }
                        catch (MovieException me)
                        {
                            Console.WriteLine(me.Message);
                        }
                        break;

                    case 2:
                        try
                        {
                            DisplayMovies();
                        }
                        catch (MovieException me)
                        {
                            Console.WriteLine(me.Message);
                        }
                        break;
                    case 3:
                        //Delete();
                        try
                        {
                            Delete();
                        }
                        catch (MovieException me)
                        {
                            Console.WriteLine(me.Message);
                        }
                        break;
                    case 4:
                        SearchMoviesByYear();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program.");
                        return;

                    default:

                        Console.WriteLine("Input A number between 1 - 5 ");
                        break;
                }

            }
        }
    }
}
