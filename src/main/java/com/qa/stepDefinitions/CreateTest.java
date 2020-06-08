package com.qa.stepDefinitions;

import com.qa.pages.HomePage;

public class CreateTest {

    private HomePage homePage = new HomePage();


    public void createATable(String createTextInput, String errorMessage) {
        homePage.fillTheTextInputToCreate(createTextInput);
        homePage.fillTheTextInputToDelete();
    }

    public void createAnInvalidTable(String createTextInput, String errorMessage) {
        homePage.fillTheTextInputToCreate(createTextInput);
    }
}