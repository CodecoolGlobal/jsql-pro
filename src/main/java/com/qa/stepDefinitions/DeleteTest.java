package com.qa.stepDefinitions;

import com.qa.pages.HomePage;
import cucumber.api.java.en.Then;

import static org.junit.jupiter.api.Assertions.*;


public class DeleteTest {

    private HomePage homePage = new HomePage();

    @Then("^I check the table record$")
    public void I_check_the_table_record() {
        assertTrue(homePage.checkTableRecord());
    }

}
