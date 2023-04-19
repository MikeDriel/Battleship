using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace BattleShip_Tests
{
    public class ShipTests
    {
        [Fact]
        public void Ship_IsSunk_Should_Return_True_When_Hits_Equal_Length()
        {
            // Arrange
            string type = "Carrier";
            int length = 5;
            string orientation = "horizontal";
            (int row, int col) position = (0, 0);
            Ship ship = new Ship(type, length, orientation, position);

            // Act
            for (int i = 0; i < length; i++)
            {
                ship.Hit();
            }

            // Assert
            Assert.True(ship.IsSunk());
        }

        [Fact]
        public void Ship_IsSunk_Should_Return_False_When_Hits_Less_Than_Length()
        {
            // Arrange
            string type = "Battleship";
            int length = 4;
            string orientation = "vertical";
            (int row, int col) position = (3, 7);
            Ship ship = new Ship(type, length, orientation, position);

            // Act
            ship.Hit();

            // Assert
            Assert.False(ship.IsSunk());
        }

        [Fact]
        public void Ship_ContainsCoordinate_Should_Return_True_When_Coordinate_Is_Contained()
        {
            // Arrange
            string type = "Cruiser";
            int length = 3;
            string orientation = "horizontal";
            (int row, int col) position = (5, 2);
            Ship ship = new Ship(type, length, orientation, position);
            int row = 5;
            int col = 3;

            // Act
            bool result = ship.ContainsCoordinate(row, col);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Ship_ContainsCoordinate_Should_Return_False_When_Coordinate_Is_Not_Contained()
        {
            // Arrange
            string type = "Submarine";
            int length = 3;
            string orientation = "vertical";
            (int row, int col) position = (1, 9);
            Ship ship = new Ship(type, length, orientation, position);
            int row = 4;
            int col = 9;

            // Act
            bool result = ship.ContainsCoordinate(row, col);

            // Assert
            Assert.False(result);
        }
    }
}
