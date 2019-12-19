using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RTQuizz.Hubs
{
    public class QuizzHub : Hub
    {
        private static QuizzHub _Instance;
        public static QuizzHub Instance { get { return _Instance; } }
        public QuizzHub()
        {
            _Instance = this;

        }
        private ConnectionListe ListeDesConnections = new ConnectionListe();
        #region "Fonction perso"
        // connection
        public async Task ConnecterUserQuizz(string user,string classe,string quizz)
        {
            //cherche ou crée l'utilisateur (camille,clement)

            // ajoute au groupe du quizz        
            ConnectionInfo UserTemp = new ConnectionInfo();
            UserTemp.ConnectionId = Context.ConnectionId;
            UserTemp.User = user;
            UserTemp.classe = classe;
            UserTemp.Quizz = quizz;
            UserTemp.QuestionNumero = 1;

            if (ListeDesConnections.User(UserTemp) == true)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, quizz);
                
            }   
        }
        public Task SendQuestionDemande(string user)
        {
            ConnectionInfo UserTemp = ListeDesConnections.ChercheUserParNom(user);
          if (UserTemp != null)
            {
                 UserTemp.QuestionNumero++;
                //clement et camille recupere la question et les reponses (Question,reponseA,reponseB,reponseC,reponseD)
                               
                bool FinQuizz = true; //bdd
                string Question = "question";
                string Reponse1 = "";
                string Reponse2 = "";
                string Reponse3 = "";
                string Reponse4 = "";
                
                if (FinQuizz == true)
                {

                }
                else
                {
                  return Clients.Caller.SendAsync("ReceiveQuestion", Question, Reponse1, Reponse2, Reponse3, Reponse4);
                }
             
            }
            return null;
        }
        public Task ValideQuestion(string user,string ReponseSelectionner)
        {
            ConnectionInfo UserTemp = ListeDesConnections.ChercheUserParNom(user);
            if (UserTemp != null)
            {
                //camille clement enregistre la reponse
                //UserTemp.User 
                //UserTemp.classe 
                //UserTemp.Quizz
                //UserTemp.Question
                //ReponseSelectionner

                bool QuestionJuste = true;//bdd
                string Question = "question"; //bdd

                // envoie le resultat de la question
                return Clients.Caller.SendAsync("ReceiveResultatQuestion", Question, ReponseSelectionner, QuestionJuste);
         
            }
            return null;
        }

         



        #endregion
        #region "Override"
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            ConnectionInfo SuppUser = ListeDesConnections.ChercheUserParConnectionId(Context.ConnectionId);
            if (SuppUser != null)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, SuppUser.Quizz);
                ListeDesConnections.DeleteUser(SuppUser);              
            }           
            await base.OnDisconnectedAsync(exception);       
        }

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

        public ConnectionInfo ChercheUserParNom(string UtilisateurNom )
        {
            foreach (ConnectionInfo UtilisateurDansListe in ListeDeConnection)
            {
               if (UtilisateurDansListe.User== UtilisateurNom)
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
    public  string ConnectionId { get; set; }
    public string User { get; set; }
    public string classe { get; set; }
    public string Quizz { get; set; }
     public int QuestionNumero { get; set; }
    }
}
