using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.Linq;

public class FakeMovieRepository
{
    private readonly List<Movie> movies;
    private int _nextId = 1;

    public FakeMovieRepository()
    {
        movies = new List<Movie>();

        AddDummyData();
    }

    private void AddDummyData()
    {
        // This method can be used to add some dummy data to the repository
        movies.Add(new Movie(_nextId++, 120, "Geshche", "Geshche", "Geshche", "Geshche", "Geshche", new Category(50, "Geshche"), "Geshche", 5, 2020));
    }

    public Movie GetMovieById(int id)
    {
        return movies.FirstOrDefault(m => m.Id == id);
    }

    public List<Movie> GetAllMovies()
    {
        return movies;
    }

    public void CreateMovie(Movie movie)
    {
        movie.Id = _nextId++;  // Simulate auto-incrementing primary key
        movies.Add(movie);
    }

    public void UpdateMovie(Movie movie)
    {
        var existingMovie = GetMovieById(movie.Id);
        if (existingMovie != null)
        {
            movies.Remove(existingMovie);
            movies.Add(movie);
        }
        else
        {
            throw new InvalidOperationException($"Movie with ID {movie.Id} does not exist.");
        }
    }

    public void DeleteMovie(int id)
    {
        var movie = GetMovieById(id);
        if (movie != null)
        {
            movies.Remove(movie);
        }
        else
        {
            throw new InvalidOperationException($"Movie with ID {id} does not exist.");
        }
    }
}
