# Created by rebak at 2020. 03. 31.
Feature: Check table after delete
  # Enter feature description here

  Scenario Outline: Check table after delete
    Given Open the Chrome and start application
    When I click on the text input
    And I fill the input field "<textFieldCreate>"
    And I click the enter
    And I fill the input field "<textFieldInsert>"
    And I click the enter
    And I fill the input field "<textFieldSelect>"
    And I click the enter
    And I fill the input field "<textFieldDelete>"
    Then I check the table record

    Examples:
      | textFieldCreate                                                               | textFieldInsert                              | textFieldSelect        | textFieldDelete |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | INSERT INTO myTable (Jozsef, Jozsi, 60, 92); | SELECT * FROM myTable; | DELETE myTable; |