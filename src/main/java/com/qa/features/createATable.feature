Feature: Create a table

  Scenario Outline: Create a table
    Given Open the Chrome and start application
    When I click on the text input
    And I fill the input field "<textFieldCreate>"
    And I click the enter
    And I check the table "<errorMessage>"
    Then I delete the table

    Examples:
      | textFieldCreate                                                                       | errorMessage|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);         |It should be good.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);         |It should be good.|
      | CREATE TABLE myTable (string title, int32 release date, int32 runtime, string genre); |Case sensitive.   |
      | CREATE Table myTable (string name, string nickname, int32 age, int32 weight);         |Case sensitive.   |
      | CREATE table myTable (string name, string nickname, int32 age, int32 weight);         |Case sensitive.   |
      | CREATE tAbLe myTable (string name, string nickname, int32 age, int32 weight);         |Case sensitive.   |