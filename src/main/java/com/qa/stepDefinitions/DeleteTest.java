package com.qa.stepDefinitions;


import com.qa.pages.HomePage;

public class DeleteTest {

    private HomePage homePage = new HomePage();

    public void deleteATable() {
        homePage.fillTheTextInputToCreateValid();
        homePage.fillTheTextInputToDelete();
    }

    public void checkTableAfterDelete() {
        homePage.createATable();
        homePage.insertInto();
        homePage.selectATable();
        homePage.fillTheTextInputToDelete();
    }
}
