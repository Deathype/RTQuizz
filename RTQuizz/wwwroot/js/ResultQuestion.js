"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Quizz").build();

connection.start().then(function () {

    connection.invoke("EnvoieResultat").catch(function (err) {
        return console.error(err.toString());
    });

}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveReponseDetails", function (ListeReponsesServeur) {
   // var Reponse = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
   // var encodedMsg = user;

    //var args = Array.prototype.slice.call(ListeReponses);
    ////// Avec ECMAScript 2015 / ES6
    ////var args = Array.from(arguments);

    console.log("Rentrer dans rep");
    console.log(ListeReponsesServeur);
    var ListeRep = [];

    ListeRep = JSON.parse(ListeReponsesServeur);
    //for (var i = 0; i < args.length; i+=3) {
    //    var LRS = { Nom:, Reponse:,Juste:}
    //}



    console.log(ListeRep);

    var Ancientbody = document.getElementById('TbodyRow');
    var new_tbody = document.createElement('tbody');
    new_tbody.setAttribute("id", "TbodyRow");


    console.log(Ancientbody);

    //TbodyRow
    //for(var RepT in ListeRep){

    ListeRep.forEach(RepT => {
        var tr = document.createElement("tr");
        var tdNom = document.createElement("td");
        var tdReponse = document.createElement("td");
        var tdJuste = document.createElement("td");

        tdNom.textContent = RepT.Nom;
        tdReponse.textContent = RepT.Reponse;
        //tdJuste.textContent = RepT.Juste;

        tr.appendChild(tdNom);
        tr.appendChild(tdReponse);

        var img = document.createElement("img");
        if (RepT.Juste) {
            img.src = "../images/validation.png";
            img.classList.add("resRepV");
        } else {
            img.src = "../images/redcross.png";
            img.classList.add("resRepF");
        }
        img.classList.add("resRep");
        tdJuste.appendChild(img);
        tr.appendChild(tdJuste);

        new_tbody.appendChild(tr);
    } );
    console.log(new_tbody);
Ancientbody.parentNode.replaceChild(new_tbody, Ancientbody);

});