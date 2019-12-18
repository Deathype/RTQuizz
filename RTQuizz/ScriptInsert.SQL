INSERT INTO Classe (nomClasse, NombreEleve)
 VALUES
 ('RIL18', 12),
  ('RIS18', 12),
   ('RIP18', 12);

 INSERT INTO Formateur (Nom,Prenom,ProfMatiere)
 VALUES
 ('Jean', 'Luc','PROJET'),
 ('Jean', 'Michel','CSHARP'),
 ('Jean', 'Batiste','PHP');

  INSERT INTO Formateur (Nom,Prenom,ProfMatiere)
 VALUES
 ('Jean', 'Luc','PROJET'),
 ('Jean', 'Michel','CSHARP'),
 ('Jean', 'Batiste','PHP');

   INSERT INTO Formateur (Nom,Prenom,ProfMatiere)
 VALUES
 ('Jean', 'Luc','PROJET'),
 ('Jean', 'Michel','CSHARP'),
 ('Jean', 'Batiste','PHP');


    INSERT INTO Question (Theme,NomQuestion)
 VALUES
 ('C#', 'ASP.net'),
 ('C#', 'Nuget'),
 ('GProjet','AGIL');

     INSERT INTO Stagiaire(NomStagiaire,IdClass)
 VALUES
 ('Guillaume', 1),
 ('Marouen', 2),
 ('Tif',3);

--SELECT * FROM Quizz;

--     INSERT INTO Quizz(NomQuizz,ThemeQuizz,idFormateur)
-- VALUES
-- ('C#Quiz','c#',1);
-- SELECT * FROM Quizz;


     INSERT INTO Reponses(NomReponse,BonneReponse,IdQuestion)
 VALUES
 ('ORM C#',1,1),
 ('asp.net',1,1),
 ('Nuget',0,1);

--  SELECT * FROM Reponses

--INSERT INTO Repondre(IdStagiare,IdQuestion,IdReponse,RepStagiaire)
-- VALUES
-- (1,2,1,'A'),
-- (2,3,1,'B'),
-- (2,4,1,'A');

INSERT INTO Stagiaire(NomStagiaire,IdClass)

VALUES
('Marouen',1),
('Guillaume',2),
('Tif',3);


INSERT INTO Quizz(NomQuizz,ThemeQuizz,idFormateur)
VALUES
('C# Quiz','C#',6),
('ASP Quiz','C#',6);




INSERT INTO Repondre(IdStagiare,IdQuestion,IdReponse,RepStagiaire)
VALUES
(3,2,1,'B');

   INSERT INTO Participe(IdQuizz,IdStagiare)
 VALUES
 (1, 1),
 (1, 2),
 (2,2);


SELECT * FROM Repondre
SELECT * FROM Stagiaire
SELECT * FROM Question
SELECT * FROM Reponses
SELECT * FROM Repondre
SELECT * FROM Reponses
SELECT * FROM Quizz


 SELECT * FROM Participe;




 
 

   
