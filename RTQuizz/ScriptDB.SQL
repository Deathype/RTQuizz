/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------Chaine de connection utuliser 

SERVER=(localdb)\MSSQLLocalDB; DATABASE=QuizDB;Trusted_Connection=True
*/



/*------------------------------------------------------------
-- Table: Classe
------------------------------------------------------------*/

USE master;
GO
IF DB_ID (N'QuizDB') IS NOT NULL
DROP DATABASE QuizDB;
GO
CREATE DATABASE QuizDB;
GO

USE QuizDB;
GO

/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Classe
------------------------------------------------------------*/
/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Classe
------------------------------------------------------------*/
CREATE TABLE Classe(
	IdClass       INT IDENTITY (1,1) NOT NULL ,
	NomClasse     VARCHAR (40) NOT NULL ,
	NombreEleve   INT  NOT NULL  ,
	CONSTRAINT Classe_PK PRIMARY KEY (IdClass)
);


/*------------------------------------------------------------
-- Table: Stagiaire
------------------------------------------------------------*/
CREATE TABLE Stagiaire(
	IdStagiare     INT IDENTITY (1,1) NOT NULL ,
	NomStagiaire   VARCHAR (40) NOT NULL ,
	IdClass        INT  NOT NULL  ,
	CONSTRAINT Stagiaire_PK PRIMARY KEY (IdStagiare)

	,CONSTRAINT Stagiaire_Classe_FK FOREIGN KEY (IdClass) REFERENCES Classe(IdClass)
);


/*------------------------------------------------------------
-- Table: Formateur
------------------------------------------------------------*/
CREATE TABLE Formateur(
	idFormateur   INT IDENTITY (1,1) NOT NULL ,
	Nom           VARCHAR (50) NOT NULL ,
	Prenom        VARCHAR (10) NOT NULL ,
	ProfMatiere   VARCHAR (10) NOT NULL  ,
	CONSTRAINT Formateur_PK PRIMARY KEY (idFormateur)
);


/*------------------------------------------------------------
-- Table: Quizz
------------------------------------------------------------*/
CREATE TABLE Quizz(
	IdQuizz       INT IDENTITY (1,1) NOT NULL ,
	NomQuizz      VARCHAR (40) NOT NULL ,
	ThemeQuizz    VARCHAR (40) NOT NULL ,
	idFormateur   INT  NOT NULL  ,
	CONSTRAINT Quizz_PK PRIMARY KEY (IdQuizz)

	,CONSTRAINT Quizz_Formateur_FK FOREIGN KEY (idFormateur) REFERENCES Formateur(idFormateur)
);


/*------------------------------------------------------------
-- Table: Question
------------------------------------------------------------*/
CREATE TABLE Question(
	IdQuestion    INT IDENTITY (1,1) NOT NULL ,
	Theme         VARCHAR (10) NOT NULL ,
	NomQuestion   VARCHAR (40) NOT NULL  ,
	CONSTRAINT Question_PK PRIMARY KEY (IdQuestion)
);


/*------------------------------------------------------------
-- Table: Reponses
------------------------------------------------------------*/
CREATE TABLE Reponses(
	IdReponse      INT IDENTITY (1,1) NOT NULL ,
	NomReponse     VARCHAR (40) NOT NULL ,
	BonneReponse   bit  NOT NULL ,
	IdQuestion     INT  NOT NULL  ,
	CONSTRAINT Reponses_PK PRIMARY KEY (IdReponse)

	,CONSTRAINT Reponses_Question_FK FOREIGN KEY (IdQuestion) REFERENCES Question(IdQuestion)
);


/*------------------------------------------------------------
-- Table: composer
------------------------------------------------------------*/
CREATE TABLE composer(
	IdQuestion   INT  NOT NULL ,
	IdQuizz      INT  NOT NULL  ,
	CONSTRAINT composer_PK PRIMARY KEY (IdQuestion,IdQuizz)

	,CONSTRAINT composer_Question_FK FOREIGN KEY (IdQuestion) REFERENCES Question(IdQuestion)
	,CONSTRAINT composer_Quizz0_FK FOREIGN KEY (IdQuizz) REFERENCES Quizz(IdQuizz)
);


/*------------------------------------------------------------
-- Table: Repondre
------------------------------------------------------------*/
CREATE TABLE Repondre(
	IdStagiare     INT  NOT NULL ,
	IdQuestion     INT  NOT NULL ,
	IdReponse      INT  NOT NULL ,
	RepStagiaire   VARCHAR (40) NOT NULL  ,
	CONSTRAINT Repondre_PK PRIMARY KEY (IdStagiare,IdQuestion,IdReponse)

	,CONSTRAINT Repondre_Stagiaire_FK FOREIGN KEY (IdStagiare) REFERENCES Stagiaire(IdStagiare)
	,CONSTRAINT Repondre_Question0_FK FOREIGN KEY (IdQuestion) REFERENCES Question(IdQuestion)
	,CONSTRAINT Repondre_Reponses1_FK FOREIGN KEY (IdReponse) REFERENCES Reponses(IdReponse)
);


/*------------------------------------------------------------
-- Table: Participe
------------------------------------------------------------*/
CREATE TABLE Participe(
	IdQuizz      INT  NOT NULL ,
	IdStagiare   INT  NOT NULL  ,
	CONSTRAINT Participe_PK PRIMARY KEY (IdQuizz,IdStagiare)

	,CONSTRAINT Participe_Quizz_FK FOREIGN KEY (IdQuizz) REFERENCES Quizz(IdQuizz)
	,CONSTRAINT Participe_Stagiaire0_FK FOREIGN KEY (IdStagiare) REFERENCES Stagiaire(IdStagiare)
);



GO



