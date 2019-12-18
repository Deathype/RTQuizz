sqlcmd -S (localdb)\MSSQLLocalDB -d master -i ScriptDB.sql -E

sqlcmd -S (localdb)\MSSQLLocalDB -d QuizDB -i ScriptInsert.sql -E
pause