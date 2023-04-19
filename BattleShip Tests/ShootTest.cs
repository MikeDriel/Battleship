using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebApp.Models.Game;
using WebApp.Models;

namespace BattleShip_Tests
{
    public class ShootTest
    {
        [Fact]
        public void Shoot_Should_Return_Miss_When_Target_Cell_Is_Empty()
        {
            // Arrange
            Game game = new Game("Game1");
            int row = 3;
            int col = 2;
            int[][] targetBoard = game.Board2;
            targetBoard[row][col] = 0; // Set target cell to empty
            Player shooter = game.CurrentPlayer;
            game._players.Add(shooter); // Add shooter to the _players list

            // Act
            MoveStates result = game.Shoot(shooter, row, col); // Pass shooter as parameter

            // Assert
            Assert.Equal(MoveStates.Miss, result);
            Assert.Equal(1, targetBoard[row][col]); // Verify target cell is marked as missed
        }
    }
}