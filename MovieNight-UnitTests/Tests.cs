using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieNight_Classes;
using MovieNight_BusinessLogic.Services;
using System.Collections.Generic;
using System.Linq;
using MovieNight_InterfacesDAL.IManagers;
using MovieNight_DataAccess.Controllers;

namespace MovieNight_Tests
{
    [TestClass]
    public class MovieManagerTests
    {
        private MovieManager movieManager;
        private FakeMovieRepository fakeMovieRepository;

        [TestInitialize]
        public void Setup()
        {
            fakeMovieRepository = new FakeMovieRepository();
            movieManager = new MovieManager(fakeMovieRepository);
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllMovies()
        {
            // Arrange
            fakeMovieRepository.CreateMovie(new Movie(1, 100, "Dakata", "Zhivota na Lango", "No Lango, No Life", "Https.Dani", "Https.El", new Category(1, "Langare"), "Turciq", 5, 2003));
            fakeMovieRepository.CreateMovie(new Movie(1, 100, "Dakata", "Zhivota na Lango", "No Lango, No Life", "Https.Danil", "Https.Langov", new Category(1, "Langare"), "Turciq", 5, 2003));

            // Act
            var movies = movieManager.GetAll();

            // Assert
            Assert.AreEqual(2, movies.Count);
        }

        [TestMethod]
        public void GetById_ShouldReturnSpecificMovie()
        {
            // Arrange
            var movie = new Movie(1, 100, "Dakata", "Zhivota na Lango", "No Lango, No Life", "Https.Danka", "Https.Langov", new Category(1, "Langare"), "Turciq", 5, 2003);
            fakeMovieRepository.CreateMovie(movie);

            // Act
            var fetchedMovie = movieManager.GetById(movie.Id);

            // Assert
            Assert.AreEqual(movie.Title, fetchedMovie.Title);
        }

        [TestMethod]
        public void Create_ShouldAddNewMovie()
        {
            // Arrange
            var newMovie = new Movie(1, 100, "Dakata", "Zhivota na Lango", "No Lango, No Life", "Https.Dani", "Https.Langov", new Category(1, "Langare"), "Turciq", 5, 2003);

            // Act
            movieManager.Create(newMovie);

            // Assert
            Assert.AreEqual(1, fakeMovieRepository.GetAllMovies().Count);
            Assert.AreEqual("New Movie", fakeMovieRepository.GetAllMovies().First().Title);
        }

        [TestMethod]
        public void Update_ShouldModifyExistingMovie()
        {
            // Arrange
            var existingMovie = new Movie { Title = "Old Title" };
            fakeMovieRepository.CreateMovie(existingMovie);
            var updatedMovie = new Movie { Id = existingMovie.Id, Title = "Updated Title" };

            // Act
            movieManager.Update(updatedMovie);

            // Assert
            var result = fakeMovieRepository.GetMovieById(existingMovie.Id);
            Assert.AreEqual("Updated Title", result.Title);
        }

        [TestMethod]
        public void Delete_ShouldRemoveMovie()
        {
            // Arrange
            var movie = new Movie(1, 100, "Dakata", "Zhivota na Lango", "No Lango, No Life", "Https.Daniel", "Https.Langov", new Category(1, "Langare"), "Turciq", 5, 2003);
            fakeMovieRepository.CreateMovie(movie);

            // Act
            movieManager.Delete(movie.Id);

            // Assert
            var result = fakeMovieRepository.GetMovieById(movie.Id);
            Assert.IsNull(result);
        }
    }
}
