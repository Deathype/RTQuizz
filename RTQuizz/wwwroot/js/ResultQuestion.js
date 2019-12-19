"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Quizz").build();

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});

connection.on("ReceiveReponseDetails", function (ListeReponsesServeur) {
   // var Reponse = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
   // var encodedMsg = user;

    //var args = Array.prototype.slice.call(ListeReponses);
    ////// Avec ECMAScript 2015 / ES6
    ////var args = Array.from(arguments);
    var ListeRep = [];

    ListeRep = JSON.parse(ListeReponsesServeur);
    //for (var i = 0; i < args.length; i+=3) {
    //    var LRS = { Nom:, Reponse:,Juste:}
    //}
       
    var Ancientbody = document.getElementById('TbodyRow');
    var new_tbody = document.createElement('tbody');
    new_tbody.setAttribute("id", "TbodyRow");

    //TbodyRow
    for(var RepT in ListeRep){

    var tr = document.createElement("tr");
    var tdNom = document.createElement("tr");
    var tdReponse = document.createElement("tr");
    var tdJuste = document.createElement("tr");

    tdNom.textContent = RepT.Nom;
    tdReponse.textContent = RepT.Reponse;
    tdJuste.textContent = RepT.Juste;

    tr.appendChild(tdNom);
    tr.appendChild(tdReponse);
    tr.appendChild(tdJuste);

    new_tbody.appendChild(tr);
}

Ancientbody.parentNode.replaceChild(new_tbody, Ancientbody);

});