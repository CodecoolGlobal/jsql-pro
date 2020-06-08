# Created by rebak at 2020. 03. 31.
Feature: Create a table
  # Enter feature description here

  Scenario Outline: Create a table
    Given Open the Chrome and start application
    When I click on the text input
    And I fill the input field "<textFieldCreate>"
    And I click the enter
    Then I check the table

    Examples:
      | textFieldCreate                                                                       |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);         |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);         |
      | CREATE TABLE myTable (string title, int32 release date, int32 runtime, string genre); |
      | CREATE Table myTable (string name, string nickname, int32 age, int32 weight);         |
      | CREATE table myTable (string name, string nickname, int32 age, int32 weight);         |
      | CREATE tAbLe myTable (string name, string nickname, int32 age, int32 weight);         |