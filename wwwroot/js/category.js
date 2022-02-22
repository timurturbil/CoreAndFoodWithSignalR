"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/categoryHub").build();

//Disable the send button until connection is established.
//document.getElementById("addButton").disabled = true;

connection.on("ReceiveCategory", function (_) {
    console.log("ReceiveCategory herer");
    document.getElementById("statisticsButton").click();
    //var li = document.createElement("li");
    //document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    //li.textContent = `${user} says ${message}`;
});

connection.start().then(function () {
    //document.getElementById("addButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("addButton").addEventListener("click", function (event) {
    connection.invoke("SendCategory").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

