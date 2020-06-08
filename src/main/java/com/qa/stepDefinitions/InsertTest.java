package com.qa.stepDefinitions;


import com.qa.pages.HomePage;

public class InsertTest {

    private HomePage homePage = new HomePage();

    public void insertATable(String insertIntoText, String errorMessage) {
        homePage.createATable();
        homePage.fillTheTextInputToInsert(insertIntoText);
        homePage.selectATable();
        homePage.fillTheTextInputToDelete();
    }

    public void insertATableInvalidFormat(String insertIntoText, String errorMessage) {
        homePage.createATable();
        homePage.fillTheTextInputToInsert(insertIntoText);
        homePage.selectATable();
        homePage.fillTheTextInputToDelete();
    }
}