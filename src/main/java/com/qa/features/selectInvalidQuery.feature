Feature: Select invalid table

  Scenario Outline: Select invalid table
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
      | textFieldCreate                                                               | textFieldInsert                                  | textFieldSelect                 | textFieldDelete |errorMessage|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, Jozsi, hatvan, 92); | SELECT FROM myTable;            | DELETE myTable; |Specify the fields.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, 60, 92);            | SELECT * myTable;               | DELETE myTable; |Missing from.      |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | SELECT INTO myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM nonExistingTable; | DELETE myTable; |Non existing table.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO nonExisting (Jozsef, Jozsi, 60, 92); | SELECT hello FROM myTable;      | DELETE myTable; |Non existing record.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | Insert Into myTable (Jozsef, Jozsi, 60, 92);     | SELECT * SELECT;                | DELETE myTable; |Invalid format after *.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable Jozsef, Jozsi, 60, 92;       | INSERT * FROM myTable;          | DELETE myTable; |Should write SELECT instead of INSERT.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | Insert INTO myTable (Jozsef, Jozsi, 60, 92);     | Select * From myTable;          | DELETE myTable; |Case Sensitive.                       |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | insert into myTable (Jozsef, Jozsi, 60, 92);     | select * from myTable;          | DELETE myTable; |Case Sensitive.                       |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO (Jozsef, Jozsi, 60, 92);             | select * FROM myTable;          | DELETE myTable; |Case Sensitive.                       |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO (Jozsef, Jozsi, 60, 92);             | Select * from myTable;          | DELETE myTable; |Case Sensitive.                       |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO (Jozsef, Jozsi, 60, 92);             | select * From myTable;          | DELETE myTable; |Case Sensitive.                       |