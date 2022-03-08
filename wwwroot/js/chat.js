"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (_) {
    document.getElementById("statisticsData").click();
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    //var user = document.getElementById("userInput").value;
    //var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});