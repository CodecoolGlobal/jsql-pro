Feature: Insert a table with invalid format

  Scenario Outline: Insert a table with invalid format
    Given Open the Chrome and start application
    When I click on the text input
    And I fill the input field "<textFieldCreate>"
    And I click the enter
    And I fill the input field "<textFieldInsert>"
    And I click the enter
    And I fill the input field "<textFieldSelect>"
    And I click the enter
    And I check the table record is not exist "<errorMessage>"
    Then I fill the input field "<textFieldDelete>"

    Examples:
      | textFieldCreate                                                               | textFieldInsert                                  | textFieldSelect        | textFieldDelete |errorMessage|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, Jozsi, hatvan, 92); | SELECT * FROM myTable; | DELETE myTable; |It isn't Integer.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, 60, 92);            | SELECT * FROM myTable; | DELETE myTable; |Less field.      |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | SELECT INTO myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM myTable; | DELETE myTable; |Write INSERT instead of SELECT.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO nonExisting (Jozsef, Jozsi, 60, 92); | SELECT * FROM myTable; | DELETE myTable; |Non existing table.            |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | Insert Into myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM myTable; | DELETE myTable; |Case sensitive.                |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable Jozsef, Jozsi, 60, 92;       | SELECT * FROM myTable; | DELETE myTable; |Case sensitive.                |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | Insert INTO myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM myTable; | DELETE myTable; |Case sensitive.                |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | insert into myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM myTable; | DELETE myTable; |Specify a table name.          |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO (Jozsef, Jozsi, 60, 92);             | SELECT * FROM myTable; | DELETE myTable; |Should contain "()".           |