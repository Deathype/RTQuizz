sqlcmd -S (localdb)\MSSQLLocalDB -d master -i ScriptDB.sql -E

sqlcmd -S (localdb)\MSSQLLocalDB -d master -i ScriptInsert.sql -E
pause