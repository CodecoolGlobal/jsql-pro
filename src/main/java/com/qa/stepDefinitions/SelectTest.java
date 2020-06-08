package com.qa.stepDefinitions;


import com.qa.pages.HomePage;

public class SelectTest {

    private HomePage homePage = new HomePage();

    public void selectValidQuery(String selectText, String errorMessage) {
        homePage.createATable();
        homePage.insertInto();
        homePage.fillTheTextInputToSelect(selectText);
        homePage.fillTheTextInputToDelete();
    }

    public void selectInvalidQuery(String selectText, String errorMessage) {
        homePage.createATable();
        homePage.insertInto();
        homePage.fillTheTextInputToSelect(selectText);
        homePage.fillTheTextInputToDelete();
    }
}