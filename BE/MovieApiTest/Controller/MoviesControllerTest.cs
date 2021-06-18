using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MoviesApi.Contract;
using MoviesApi.Controllers;
using MoviesApi.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MovieApiTest.Controller
{
    [TestFixture]
    internal class MoviesControllerTest
    {
        private  Mock<IMovieContract>  _movieContract;
        private  MoviesController _moviesController;
        private  Mock<ILogger<MoviesController>> _mockLogger;

        [SetUp]
        public void InitializeAndSetup()
        {
            _mockLogger = new Mock<ILogger<MoviesController>>();
            _movieContract = new Mock<IMovieContract>();
            _moviesController = new MoviesController(_mockLogger.Object,_movieContract.Object);
        }

        [Test]
        public void GetAllMovies_ReturnsAllMovie_When_ThereIsNoError()
        {
            // Arrange
            MoviesDTO Movies = new MoviesDTO
            {
                Movies = new List<Movie>
            {
                new Movie
                {
                     Id = "1",
                     ImdbID = "123",
                     ImdbRating ="7.5",
                     Language = "English",
                     ListingType ="Streaming",
                     Location = "pune",
                     Plot = "Horror Movie",
                     Poster = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTcxODgwMDkxNV5BMl5BanBnXkFtZTYwMDk2MDg3._V1_SX300.jpg",
                     SoundEffects = new List<string>
                     {
                         "DOLBY",
                         "DTS"
                     },
                     Title = "Conjuring"

                }
            }
            };
            var movies = _movieContract.Setup(x=> x.GetMovies()).Returns(Movies);

            //Act
            var result = _moviesController.GetMovies();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public void GetAllMovies_ThrowException_When_ThereIsError()
        {
            var movies = _movieContract.Setup(x => x.GetMovies()).Throws<Exception>();
            var result = _moviesController.GetMovies() as StatusCodeResult;
            Assert.AreEqual(500, result.StatusCode);
        }
    }
}
