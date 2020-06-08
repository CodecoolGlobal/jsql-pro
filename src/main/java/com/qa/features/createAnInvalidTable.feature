# Created by rebak at 2020. 03. 31.
Feature: Create invalid table
  # Enter feature description here

  Scenario Outline: Create invalid table
    Given Open the Chrome and start application
    When I click on the text input
    And I fill the input field "<textFieldCreate>"
    And I click the enter
    Then I check the table

    Examples:
      | textFieldCreate                                                               |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight)  |
      | CREATE TABLE myTable (name, string nickname, int32 age, int32 weight);        |
      | CREATE TABLE myTable (string name, string int32 age, int32 weight);           |
      | CREATE TABLE myTable (string name, string nickname, int32 age, int32);        |
      | SELECT TABLE myTable (string name, string nickname, int32 age, int32 weight); |
      | Create Table myTable (string name, string nickname, int32 age, int32 weight); |
      | Create TABLE myTable (string name, string nickname, int32 age, int32 weight); |
      | CREATE TABLE myTable (b name, s nickname, i age, i weight);                   |
      | create table myTable (string name, string nickname, int32 age, int32 weight); |
      | CREATE TABLE (string name, string nickname, int32 age, int32 weight);         |
      | CREATE TABLE myTable string name, string nickname, int32 age, int32 weight;   |