using System;
using Xunit;
using global::WebApp.Models;
using static global::WebApp.Models.Game;

namespace BattleShip_Tests
{

    namespace WebApp.Tests
    {
        public class GameTest
        {
            [Fact]
            public void Test_GameInitialization()
            {
                // Arrange
                string gameId = "testGameId";
                
                // Act
                Game game = new Game(gameId);

                // Create and add players
                game.AddPlayer("Player1", "123");
                game.AddPlayer("Player2", "153");

                // Assert
                Assert.Equal(gameId, game.GameId);
                Assert.False(game.IsGameOver);
                Assert.NotNull(game.Player1);
                Assert.NotNull(game.Player2);
                Assert.Equal(2, game.PlayerCount);
                Assert.NotNull(game.Board1);
                Assert.NotNull(game.Board2);
                Assert.NotNull(game.Ships1);
                Assert.NotNull(game.Ships2);
                Assert.False(game.Started);
            }

            [Fact]
            public void Test_InitializeBoards()
            {
                // Arrange
                Game game = new Game("testGameId");

                // Act
                game.InitializeBoards();

                // Assert
                Assert.NotNull(game.Board1);
                Assert.NotNull(game.Board2);
                Assert.NotNull(game.Ships1);
                Assert.NotNull(game.Ships2);
            }

            [Fact]
            public void Test_Shoot()
            {
                // Arrange
                Game game = new Game("testGameId");
                game.InitializeBoards();

                // Create and add players
                game.AddPlayer("Player1", "123");
                game.AddPlayer("Player2", "153");

                // Act
                Player currentPlayer = game.Player2;
                Player otherPlayer = game.Player1;
                int row = 4;
                int col = 5;
                MoveStates result = game.Shoot(currentPlayer, row, col);
                game.SwitchPlayer();

                // Assert
                Assert.Contains(result, new[] { MoveStates.Miss, MoveStates.Hit, MoveStates.GameOver });
                Assert.Equal(otherPlayer, game.CurrentPlayer);
            }
        }
    }
}