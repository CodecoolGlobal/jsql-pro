Feature: Create invalid table

  Scenario Outline: Create invalid table
    Given Open the Chrome and start application
    When I click on the text input
    And I fill the input field "<textFieldCreate>"
    And I click the enter
    Then I check the table is not exist "<errorMessage>"

    Examples:
      | textFieldCreate                                                               | errorMessage  |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight)  | Please append ;.  |
      | CREATE TABLE myTable (name, string nickname, int32 age, int32 weight);        |There isn't string before name.|
      | CREATE TABLE myTable (string name, string int32 age, int32 weight);           |There are string and int32 as well before age.|
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32);        |There isn't weight after int32.               |
      | SELECT TABLE myTable (string name, string nickname, int32 age, int32 weight); |Write CREATE instead of SELECT.               |
      | Create Table myTable (string name, string nickname, int32 age, int32 weight); |Case sensitive.                               |
      | Create TABLE myTable (string name, string nickname, int32 age, int32 weight); |Case sensitive.                               |
      | CREATE TABLE myTable (b name, s nickname, i age, i weight);                   |Invalid format before columns.                |
      | create table myTable (string name, string nickname, int32 age, int32 weight); |Case sensitive.|
      | CREATE TABLE (string name, string nickname, int32 age, int32 weight);         |Specify a table name.|
      | CREATE TABLE myTable string name, string nickname, int32 age, int32 weight;   |Should contain "()". |