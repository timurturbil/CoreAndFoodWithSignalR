"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/categoryHub").build();

//Disable the send button until connection is established.
//document.getElementById("addButton").disabled = true;

connection.on("ReceiveCategory", function (_) {
    console.log("ReceiveCategory girdi")
    document.getElementById("statisticsData").click();
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("addButton").addEventListener("click", function (event) {
    connection.invoke("SendCategory").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

