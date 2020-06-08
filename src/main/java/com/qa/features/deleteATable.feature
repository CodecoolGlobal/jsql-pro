Feature: Delete a table

  Scenario Outline: Delete a table
    Given Open the Chrome and start application
    When I click on the text input
    And I fill the input field "<textFieldCreate>"
    And I click the enter
    And I fill the input field "<textFieldDelete>"
    Then I check the table is not exist

    Examples:
      | textFieldCreate                                                               | textFieldDelete |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight); | DELETE myTable; |