﻿// Establish a connection to the SignalR hub
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/BattleShipHub")
    .build();

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

// Listen for the "BoardUpdated" event from the hub
connection.on("BoardUpdated", (playerName, boardState) => {
    // Determine which player's board to update
    const boardId = playerName === "player1" ? "player1-board" : "player2-board";

    // Update the board state
    const board = document.querySelector('#' + boardId); // Add a '#' before boardId
    board.boardState = boardState; // Use the 'boardState' property instead of the 'updateState' method
});

connection.on("GameCreated", (gameId) => {
    console.log(gameId);
    document.getElementById("lobbyscreen").remove();
    document.getElementById("playfield").classList.add("visible");

    // Sync game data after game creation
    connection.invoke("SyncGameData", gameId, 1).then(() => {
        console.log("Game data synced");
    }).catch(function (err) {
        return console.error(err.toString());
    });
});



// Listen for the "GameJoined" event from the hub
connection.on("PlayerJoined", (playerName, gameId) => {
    // Update the UI to show that a player has joined the game
    document.getElementById("lobbyscreen").remove();
    document.getElementById("playfield").classList.add("visible");

    // Sync game data after game creation
    connection.invoke("SyncGameData", gameId, 2).then(() => {
        console.log("Game data synced");
    }).catch(function (err) {
        return console.error(err.toString());
    });

    console.log(`${playerName} has joined the game with ID: ${gameId}`);
});

// Listen for the "GameStarted" event from the hub
connection.on("GameStarted", () => {
    // Update the UI to indicate the game has started
    console.log("Game has started");
});

// Listen for the "GameEnded" event from the hub
connection.on("GameOver", (winnerName) => {
    // Update the UI to show the winner of the game
    console.log(`Game has ended. The winner is: ${winnerName}`);
});

connection.on("GameDataSynced", (player1Name, player2Name, gameId) => {
    debugger;
    document.getElementById("player1name").innerHTML = player1Name;
    document.getElementById("player2name").innerHTML = player2Name;
    document.getElementById("gameRoomCode").innerHTML = gameId;
});

//adds a click event listener:
document.getElementById("joinButton").addEventListener("click", function () {
    const playerName = document.getElementById("playerName").value;
    const roomCode = document.getElementById("roomCode").value;
    connection.invoke("JoinGame", playerName, roomCode).catch(function (err) {
        return console.error(err.toString());
    });
});

document.getElementById("createButton").addEventListener("click", function (e) {
    connection.invoke("CreateGame", document.getElementById("playerName").value).catch(function (err) {
        return console.error(err.toString());
    });
});