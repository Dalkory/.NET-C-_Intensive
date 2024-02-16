using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using s21_d04_Model;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string? booksFilePath = configuration.GetSection("FilePaths:Books")?.Value;
string? moviesFilePath = configuration.GetSection("FilePaths:Movies")?.Value;

List<Book>? books = booksFilePath != null ? Book.LoadBooksFromJson(booksFilePath) : null;
List<Movie>? movies = moviesFilePath != null ? Movie.LoadMoviesFromJson(moviesFilePath) : null;

Console.WriteLine();

if (args.Length > 0 && args[0] == "best" && books != null && movies != null)
{
    var bestBook = books.OrderBy(book => book.Rank).FirstOrDefault();
    var bestMovie = movies.FirstOrDefault(movie => movie.IsCriticsPick);

    Console.WriteLine("Best in books:");
    if (bestBook != null)
    {
        Console.WriteLine("- " + bestBook);
    }

    Console.WriteLine();
    Console.WriteLine("Best in movie reviews:");
    if (bestMovie != null)
    {
        Console.WriteLine("- " + bestMovie);
    }
}
else if (args.Length > 0)
{
    throw new ArgumentException("Invalid argument. Please provide 'best' as the argument.");
} 
else 
{
    Console.Write("Input search text: ");
    string? search = Console.ReadLine();

    if (books != null && movies != null && search != null)
    {
        var matchingBooks = books.Search(search);
        var matchingMovies = movies.Search(search);
        if (matchingBooks.Length + matchingMovies.Length > 0)
        {
            Console.WriteLine($"Items found: {matchingBooks.Length + matchingMovies.Length}\n");

            if (matchingBooks.Length > 0)
            {
                Console.WriteLine($"Book search result [{matchingBooks.Length}]:");
                foreach (var book in matchingBooks)
                {
                    Console.WriteLine("- " + book);
                }
                Console.WriteLine();
            }

            if (matchingMovies.Length > 0)
            {
                Console.WriteLine($"Movie search result [{matchingMovies.Length}]:");
                foreach (var movie in matchingMovies)
                {
                    Console.WriteLine("- " + movie);
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"No media found matching \"{search}\".");
        }
    }
}