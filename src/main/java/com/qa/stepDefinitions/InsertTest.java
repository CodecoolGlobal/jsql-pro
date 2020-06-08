package com.qa.stepDefinitions;

import com.qa.pages.HomePage;
import cucumber.api.java.en.And;

import static org.junit.jupiter.api.Assertions.*;

public class InsertTest {

    private HomePage homePage = new HomePage();

    @And("^I check the table record is not exist$")
    public void iCheckTheTableRecordIsNotExist() {
        assertFalse(homePage.checkTableRecord());
    }
}