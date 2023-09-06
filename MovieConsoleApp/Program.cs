using MovieConsoleApp.Model;
using MovieCLassLibrary;
using MovieCLassLibrary.Model;

namespace MovieConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieController movieController = new MovieController();
            movieController.Start();
        }
    }
}