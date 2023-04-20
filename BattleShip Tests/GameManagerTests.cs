using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using WebApp.Models;
using Xunit;

namespace BattleShip_Tests
{
    public class GameManagerTests
    {
        [Fact]
        public void GetGame_Should_Return_Game_With_Correct_GameId()
        {
            // Arrange
            var gameId = "game1";
            var game = new Game(gameId);
            var managerMock = new Mock<GameManager>();
            managerMock.Setup(m => m.GetGame(gameId)).Returns(game);
            var manager = managerMock.Object;

            // Act
            var result = manager.GetGame(gameId);

            // Assert
            Assert.Equal(game, result);
        }

        [Fact]
        public void GetGame_Should_Return_Null_When_GameId_Not_Found()
        {
            // Arrange
            var gameId = "game1";
            var managerMock = new Mock<GameManager>();
            managerMock.Setup(m => m.GetGame(gameId)).Returns((Game)null);
            var manager = managerMock.Object;

            // Act
            var result = manager.GetGame(gameId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddGame_Should_Add_Game_To_Games_List()
        {
            // Arrange
            var gameId = "game1";
            var game = new Game(gameId);
            var managerMock = new Mock<GameManager>();
            var manager = managerMock.Object;

            // Act
            manager.AddGame(game);

            // Assert
            managerMock.Verify(m => m.AddGame(game), Times.Once);
        }

        [Fact]
        public void RemoveGame_Should_Remove_Game_From_Games_List()
        {
            // Arrange
            var gameId = "game1";
            var game = new Game(gameId);
            var managerMock = new Mock<GameManager>();
            managerMock.Setup(m => m.RemoveGame(game));
            var manager = managerMock.Object;

            // Act
            manager.RemoveGame(game);

            // Assert
            managerMock.Verify(m => m.RemoveGame(game), Times.Once);
        }
    }
}