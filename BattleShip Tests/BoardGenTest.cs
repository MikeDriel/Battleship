using Microsoft.AspNetCore.Routing;
using WebApp.Models;
using Xunit;

namespace BattleShip_Tests
{

    public class BoardGenTest
    {
        [Fact]
        public void Game_Initialization_Should_Create_Boards_With_Ships()
        {
            // Arrange
            string gameId = "Game1";

            // Act
            Game game = new Game(gameId);

            // Assert
            Assert.NotNull(game.Board1);
            Assert.NotNull(game.Board2);
            Assert.NotNull(game.Ships1);
            Assert.NotNull(game.Ships2);
        }

        [Fact]
        public void EnoughBoatCellsOnBoards()
        {
            // Arrange
            Game game = new Game("testGameId");

            // Act
            int totalBoatCells = CountBoatCells(game.Board1) + CountBoatCells(game.Board2);

            // Assert
            Assert.Equal(34, totalBoatCells);
        }

        // Helper method to count the number of boat cells on a board
        private int CountBoatCells(int[][] board)
        {
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i][j] == 2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}