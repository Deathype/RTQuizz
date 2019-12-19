INSERT INTO Classe (nomClasse, NombreEleve)
 VALUES
 ('RIL18', 12),
  ('RIS18', 12),
   ('RIP18', 12);

 INSERT INTO Formateur (Nom,Prenom,ProfMatiere)
 VALUES
 ('Jean', 'Luc','PROJET'),
 ('Jean', 'Michel','CSHARP'),
 ('Jean', 'Batiste','PHP'),
('Jean', 'philippe','JS');


    INSERT INTO Question (Theme,NomQuestion)
 VALUES
 ('C#', 'Comment faire un mapping d''une Base de donnée avec C# ?'),
 ('C#', 'Comment connecter une Base donnée MySQL a un projet C#?'),
 ('GProjet','Quel sont les acteur d''un projet AGIL');

     INSERT INTO Stagiaire(NomStagiaire,IdClass)
 VALUES
 ('Guillaume', 1),
 ('Marouen', 1),
 ('Tif',1),
 ('Nicolas', 1),
 ('Camille', 1),
 ('Clement',3),
 ('Renaut',3);


     INSERT INTO Reponses(NomReponse,BonneReponse,IdQuestion)
 VALUES
 ('Entity frameWork',1,1),
 ('Mapping relational object',0,1),
 ('Nuget',0,1);

--  SELECT * FROM Reponses

--INSERT INTO Repondre(IdStagiaire,IdQuestion,IdReponse,RepStagiaire)
-- VALUES
-- (1,1,1,'Entity framework'),
-- (2,1,2,'installé un package Nugets'),
-- (3,3,3,'scrum master-product owner');



INSERT INTO Quizz(NomQuizz,ThemeQuizz,idFormateur)
VALUES
('C# Quiz','C#',1),
('Agil Quiz','Methode Agil',1),
('ASP Quiz','C#',1),
('php Quiz','php',2);




INSERT INTO Repondre(IdStagiaire,IdQuestion,IdReponse,RepStagiaire)
VALUES
(3,2,1,'B');

   INSERT INTO Participe(IdQuizz,IdStagiaire)
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




 
 

   
