using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Librarie.Data.Entities;

namespace Library.Test
{
    
    [TestClass]
    public class ScorServiceTest
    {
        public IScoreService _scoreService;

        [TestInitialize]
        public void Init()
        {
            _scoreService = new ScoreService();
        }

        [TestMethod]
        public void ComputeScore_BookTypeSFBookScore5UserScore1_ShouldBe51()
        {
            //Arrange
            var book = new Book()
            {
                Type = "SF",
                Score = 5
            };
            const int userScore = 1;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(51, result);
        }

        [TestMethod]
        public void ComputeScore_BookTypeSFBookScore2UserScore20_ShouldBe40()
        {
            //Arrange
            var book = new Book()
            {
                Type = "SF",
                Score = 2
            };
            const int userScore = 20;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void ComputeScore_BookTypeSFBookScore2UserScore0_ShouldBe20()
        {
            //Arrange
            var book = new Book()
            {
                Type = "SF",
                Score = 2
            };
            const int userScore = 0;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void ComputeScore_BookScore2UserScore1_ShouldBe3()
        {
            //Arrange
            var book = new Book()
            {
                Type = "*",
                Score = 2
            };
            const int userScore = 1;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void ComputeScore_BookTypeCopiiBookScore1UserScore5_ShouldBe7()
        {
            //Arrange
            var book = new Book()
            {
                Type = "Copii",
                Score = 1
            };
            const int userScore = 5;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void ComputeScore_BookTypeCopiiBookScore2UserScore0_ShouldBe4()
        {
            //Arrange
            var book = new Book()
            {
                Type = "Copii",
                Score = 2
            };
            const int userScore = 0;

            //Act
            int result = _scoreService.ComputeScore(book, userScore);

            //Assert
            Assert.AreEqual(4, result);

        }
    }

    internal class ScoreService : IScoreService
    {
        public int ComputeScore(Book book, int userScore)
        {
            if(book.Type == "SF")
            {
                return 10 * book.Score + userScore;
            }
            else
            {
                if (book.Type == "Copii")
                {
                    return 2 * book.Score + userScore;
                }
            }

            return book.Score + userScore;
        }
    }

    public interface IScoreService
    {
        int ComputeScore(Book book, int userScore);
    }
}
