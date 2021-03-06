﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using Newtonsoft.Json;

namespace RTQuizz.Hubs
{
    public class QuizzHub : Hub
    {
        //private static QuizzHub _Instance = new QuizzHub();
        //public static QuizzHub Instance { get { return _Instance; } }

        public List<ReponseClasse> ListeRepDetails = new List<ReponseClasse>();


        public QuizzHub()
        {

        }

        #region "Fonction perso"
        // connection
        public void ClearListReponse()
        {
            ListeRepDetails.Clear();
        }
        public async Task EnvoieresultatQuestionClasse(string Classe, string Question)
        {
            List<ReponseClasse> ListeRepDetailsTemp = new List<ReponseClasse>();

            foreach (ReponseClasse RepTemp in ListeRepDetails)
            {
                if (Question == RepTemp.Question && Classe == RepTemp.Classe)
                {
                    ListeRepDetailsTemp.Add(RepTemp);
                }
            }
            if (ListeRepDetailsTemp.Count > 0)
            {
                string StrTempRepDetails = JsonConvert.SerializeObject(ListeRepDetailsTemp); ;
                await Clients.All.SendAsync("ReceiveReponseDetails", StrTempRepDetails);
            }

        }
        public string ClasseCourante { get; set; }
        public string QuestionCourante { get; set; }
        public async Task EnvoieResultat()
        {

            await EnvoieresultatQuestionClasse(ClasseCourante, QuestionCourante);

        }
        public void AjoutResultat(Repondre Rep)
        {

            ReponseClasse RepClasseTemp = new ReponseClasse();
            RepClasseTemp.Question = Rep.Reponses.Question.NomQuestion;
            RepClasseTemp.Nom = Rep.Stagiaire.NomStagiaire;
            RepClasseTemp.Classe = Rep.Stagiaire.Classe.NomClasse;
            RepClasseTemp.Reponse = Rep.Reponses.NomReponse;
            RepClasseTemp.Juste = Rep.Reponses.BonneReponse;

            ReponseClasse matche = ListeRepDetails.Find(x => x.Nom.Contains(RepClasseTemp.Nom) && x.Classe.Contains(RepClasseTemp.Classe) && x.Question.Contains(RepClasseTemp.Question));

            ClasseCourante = RepClasseTemp.Classe;
            QuestionCourante = RepClasseTemp.Question;

            if (matche != null)
            {

                matche = RepClasseTemp;
            }
            else
            {
                ListeRepDetails.Add(RepClasseTemp);

            }


        }


        //#endregion
        //#region "Override"
        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    ConnectionInfo SuppUser = ListeDesConnections.ChercheUserParConnectionId(Context.ConnectionId);
        //    if (SuppUser != null)
        //    {
        //        await Groups.RemoveFromGroupAsync(Context.ConnectionId, SuppUser.Quizz);
        //        ListeDesConnections.DeleteUser(SuppUser);              
        //    }           
        //    await base.OnDisconnectedAsync(exception);       
        //}

        #endregion
        #region "Fonction intermediaire"

        #endregion
        //***********************************************************************************
        //public override async Task OnConnectedAsync()
        //{

        //    //  await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
        //    await base.OnConnectedAsync();

        //}
        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
        //    await base.OnDisconnectedAsync(exception);
        //}
        //public Task SendMessageToCaller(string message)
        //{
        //    return Clients.Caller.SendAsync("ReceiveMessage", message);
        //}
        //public Task SendMessage(string typeMessage, string user, string message)
        //{
        //    return Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        ////quand l'utilisateur veut se connecter a un classe (se connectera au groupe)
        //public async Task ConnectionUtilisateur(string utilisateur)
        //{
        //    string Classe = "";//test la BDD si il trouve l'utilisateur et renvoie la classe 
        //    if (Classe != "")
        //    {
        //        await Groups.AddToGroupAsync(Context.ConnectionId, Classe);
        //    }

        //    //return Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
    }
    public class ConnectionListe
    {
        private List<ConnectionInfo> ListeDeConnection;

        public ConnectionListe()
        {
            ListeDeConnection = new List<ConnectionInfo>();
        }

        public ConnectionInfo ChercheUserParNom(string UtilisateurNom)
        {
            foreach (ConnectionInfo UtilisateurDansListe in ListeDeConnection)
            {
                if (UtilisateurDansListe.User == UtilisateurNom)
                {
                    return UtilisateurDansListe;
                }
            }
            return null;
        }
        public ConnectionInfo ChercheUserParConnectionId(string ConnectionIdUser)
        {
            foreach (ConnectionInfo UtilisateurDansListe in ListeDeConnection)
            {
                if (UtilisateurDansListe.ConnectionId == ConnectionIdUser)
                {
                    return UtilisateurDansListe;
                }
            }
            return null;
        }
        public bool User(ConnectionInfo AjoutUser)
        {
            ConnectionInfo UserTemp = null;
            if (AjoutUser.User != "")
            {
                UserTemp = ChercheUserParNom(AjoutUser.User);
                if (UserTemp != null)
                {
                    UserTemp.classe = AjoutUser.classe;
                    UserTemp.ConnectionId = AjoutUser.ConnectionId;
                    UserTemp.Quizz = AjoutUser.Quizz;
                    UserTemp.QuestionNumero = 1;
                    return true;
                }
                else
                {
                    ListeDeConnection.Add(AjoutUser);
                    return true;
                }
            }
            return false;
        }
        public bool DeleteUser(ConnectionInfo SupprimerUser)
        {
            ConnectionInfo UserTemp = null;
            if (SupprimerUser.User != "")
            {
                UserTemp = ChercheUserParNom(SupprimerUser.User);
                if (UserTemp != null)
                {
                    ListeDeConnection.Remove(UserTemp);
                    return true;
                }
            }
            return false;
        }
        public int Count()
        {
            return ListeDeConnection.Count;
        }

    }
    public class ConnectionInfo
    {
        public string ConnectionId { get; set; }
        public string User { get; set; }
        public string classe { get; set; }
        public string Quizz { get; set; }
        public int QuestionNumero { get; set; }
    }
    public class ReponseClasse
    {
        public string Question { get; set; }
        public string Nom { get; set; }
        public string Classe { get; set; }
        public string Reponse { get; set; }
        public bool Juste { get; set; }
    }
}
