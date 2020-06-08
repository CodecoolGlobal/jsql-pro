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
    And I check the table record is not exist
    Then I fill the input field "<textFieldDelete>"

    Examples:
      | textFieldCreate                                                               | textFieldInsert                                  | textFieldSelect        | textFieldDelete |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, Jozsi, hatvan, 92); | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, 60, 92);            | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | SELECT INTO myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO nonExisting (Jozsef, Jozsi, 60, 92); | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | Insert Into myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable Jozsef, Jozsi, 60, 92;       | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | Insert INTO myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | insert into myTable (Jozsef, Jozsi, 60, 92);     | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO (Jozsef, Jozsi, 60, 92);             | SELECT * FROM myTable; | DELETE myTable; |