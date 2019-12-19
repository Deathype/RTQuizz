using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using Newtonsoft.Json;

namespace RTQuizz.Hubs
{
    public class QuizzHub : Hub
    {
        private static QuizzHub _Instance;
        public static QuizzHub Instance { get { return _Instance; } }

        public List<ReponseClasse> ListeRepDetails = new List<ReponseClasse>();
        
        public QuizzHub()
        {
            _Instance = this;
          
        }
       
        #region "Fonction perso"
        // connection
      public void ClearListReponse()
        {
            ListeRepDetails.Clear();
         }
        public Task EnvoieresultatQuestionClasse(Repondre Rep)
        {
            List<ReponseClasse> ListeRepDetailsTemp = new List<ReponseClasse>();

            ReponseClasse RepClasseTemp = new ReponseClasse();
            RepClasseTemp.Question = Rep.Reponses.Question.NomQuestion;
            RepClasseTemp.Nom = Rep.Stagiaire.NomStagiaire;
            RepClasseTemp.Classe = Rep.Stagiaire.Classe.NomClasse;
            RepClasseTemp.Reponse = Rep.Reponses.NomReponse;
            RepClasseTemp.Juste = Rep.Reponses.Question.NomQuestion;

            ReponseClasse matche = ListeRepDetails.Find(x => x.Nom.Contains(RepClasseTemp.Nom) && x.Classe.Contains(RepClasseTemp.Classe) && x.Question.Contains(RepClasseTemp.Question));

            if (matche != null)
            {
                matche = RepClasseTemp;
            }
            else
            {
                ListeRepDetails.Add(RepClasseTemp);
            }

            ListeRepDetailsTemp.Clear();
            foreach (ReponseClasse RepTemp in ListeRepDetails)
            {
                if (RepClasseTemp.Question == RepTemp.Question)
                {
                    ListeRepDetailsTemp.Add(RepTemp);
                }
            }

            if (ListeRepDetailsTemp.Count > 0)
            {
                string StrTempRepDetails = JsonConvert.SerializeObject(ListeRepDetailsTemp); ;
                return Clients.All.SendAsync("ReceiveReponseDetails", StrTempRepDetails);
            }
            return null;
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
    public class ReponseClasse
    {
       public string  Question { get; set; }
        public string Nom { get; set; }
        public string Classe { get; set; }
        public string Reponse { get; set; }
    public string Juste { get; set; }
    }
}
