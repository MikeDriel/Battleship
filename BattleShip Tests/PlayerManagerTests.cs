using global::WebApp.Models;
using Moq;

namespace BattleShip_Tests {


    public class PlayerManagerTests
    {
        [Fact]
        public void Test_GetPlayer_ReturnsPlayerWithMatchingConnectionId()
        {
            // Arrange
            var connectionId = "123";
            var expectedPlayer = new Player("Mike", connectionId);
            var playerManager = new PlayerManager();
            playerManager.AddPlayer(expectedPlayer);

            var mockPlayerManager = new Mock<PlayerManager>();
            mockPlayerManager.Setup(pm => pm.GetPlayer(connectionId)).Returns(expectedPlayer);

            // Act
            var result = mockPlayerManager.Object.GetPlayer(connectionId);

            // Assert
            Assert.Equal(expectedPlayer, result);
            mockPlayerManager.Verify(pm => pm.GetPlayer(connectionId), Times.Once);
        }

        [Fact]
        public void Test_GetPlayer_ReturnsNullForNonexistentConnectionId()
        {
            // Arrange
            var connectionId = "123";
            var playerManager = new PlayerManager();

            var mockPlayerManager = new Mock<PlayerManager>();
            mockPlayerManager.Setup(pm => pm.GetPlayer(connectionId)).Returns((Player)null);

            // Act
            var result = mockPlayerManager.Object.GetPlayer(connectionId);

            // Assert
            Assert.Null(result);
            mockPlayerManager.Verify(pm => pm.GetPlayer(connectionId), Times.Once);
        }

        [Fact]
        public void Test_AddPlayer_AddsPlayerToList()
        {
            // Arrange
            var connectionId = "123";
            var player = new Player("Mike", connectionId);
            var playerManager = new PlayerManager();

            var mockPlayerManager = new Mock<PlayerManager>();
            mockPlayerManager.Setup(pm => pm.AddPlayer(player)).Callback<Player>(p => playerManager.AddPlayer(p));

            // Act
            mockPlayerManager.Object.AddPlayer(player);

            // Assert
            Assert.True(playerManager.GetPlayer(player.ConnectionId) != null);
            mockPlayerManager.Verify(pm => pm.AddPlayer(player), Times.Once);
        }
    }
}