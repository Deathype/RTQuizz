"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Quizz").build();

class ListeReponseServeurClasse {
    Nom;
    Reponse;
    Juste;
}


//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

connection.on("ReceiveReponseDetails", function (ListeReponsesServeur) {
    var Reponse = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user;

    //var args = Array.prototype.slice.call(ListeReponses);
    ////// Avec ECMAScript 2015 / ES6
    ////var args = Array.from(arguments);
    var ListeRep = [];

    ListeRep = JSON.parse(ListeReponsesServeur);
    //for (var i = 0; i < args.length; i+=3) {
    //    var LRS = { Nom:, Reponse:,Juste:}
    //}

    foreach(var Rep in ListeRep){
    document.getElementById("ReponseList").innerHTML(Rep.);

}

    console.log(ListeRep)
    //var li = document.createElement("li");
    //li.textContent = encodedMsg;

   // document.getElementById("ReponseList").innerHTML(msg);
});