// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

var c = 0;

connection.on("ReceiveMessage", function (user, message) {
    var encodedUser = $("<div />").text(user).html();
    var encodedMsg = $("<div />").text(message).html();
    $("#chatBox").append("<div class='" + c + "' style='display: flex'><img class='avatar' src='https://img.icons8.com/color/36/000000/administrator-male.png'>"
        + "<strong>" + encodedUser + "</strong></div>"
        + "<p class='sub-" + c + "'>" + encodedMsg + "</p>");
});

$("#sendButton").click(function () {
    var user = document.getElementById('username').innerText;
    var message = $("#message").val();
    c++;
    connection.invoke("SendMessage", user, message);
    document.getElementById("message").value = "";
    if (c == 1) {
        return;
    }
});


document.getElementById("message").addEventListener("keyup", function (event) {
    if (event.key === "Enter") {
        var user = document.getElementById('username').innerText;
        var message = $("#message").val();
        c++;
        connection.invoke("SendMessage", user, message);
        document.getElementById("message").value = "";
        if (c == 1) {
            return;
        }
    }
});

connection.start().then(function () {
    console.log("Connected!");
}).catch(function (err) {
    console.error(err.toString());
});