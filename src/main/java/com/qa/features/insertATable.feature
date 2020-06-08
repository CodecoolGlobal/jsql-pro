Feature: Insert a table

  Scenario Outline: Insert a table
    Given Open the Chrome and start application
    When I click on the text input
    And I fill the input field "<textFieldCreate>"
    And I click the enter
    And I fill the input field "<textFieldInsert>"
    And I click the enter
    And I fill the input field "<textFieldSelect>"
    And I click the enter
    And I check the table record
    Then I fill the input field "<textFieldDelete>"

    Examples:
      | textFieldCreate                                                               | textFieldInsert                                        | textFieldSelect        | textFieldDelete |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, Jozsi, 60, 92);           | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Becstelen Jozsef, 2009, 60, war); | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, Jozsi, 60, 92);           | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT Into myTable (Jozsef, Jozsi, 60, 92);           | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT into myTable (Jozsef, Jozsi, 60, 92);           | SELECT * FROM myTable; | DELETE myTable; |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT iNtO myTable (Jozsef, Jozsi, 60, 92);           | SELECT * FROM myTable; | DELETE myTable; |