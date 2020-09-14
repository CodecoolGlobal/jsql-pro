# ReactASPNET
#### This is a REACT app with ASP.NET backend, AUTOMATIC tests and CHAIN OF RESPONSIBILITY pattern. With this you are able to handle basic SQL commands.
#### Available Statements:
* CREATE
* SELECT
* INSERT
* DELETE
* WHERE
#### Don't forget that the program is case sensitive!
##### Some sample inputs:
* CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);
* INSERT INTO myTable (József, Józsi, 60, 92);
* INSERT INTO myTable (Péter, Peti, 45, 77);
* INSERT INTO myTable (Gyula, Gyuszi, 32, 67);"
* SELECT * FROM myTable;
* SELECT name, age FROM myTable WHERE weight > 68;
* DELETE myTable;
##### you can find the cain of responsibility pattern in ReactASPCrud/ReactASPCrud/Services/RecordService.cs -> manageTable() method 
