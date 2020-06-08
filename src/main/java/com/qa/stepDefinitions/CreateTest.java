package com.qa.stepDefinitions;

import com.qa.pages.HomePage;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;

import static org.junit.jupiter.api.Assertions.*;

public class CreateTest {

    private HomePage homePage = new HomePage();

    @Given("^Open the Chrome and start application$")
    public void Open_the_Chrome_and_start_application() {
        homePage.navigate();
    }

    @When("^I click on the text input$")
    public void I_click_on_the_text_input() {

    }

    @When("^I fill the input field \"([^\"]*)\"$")
    public void I_fill_the_input_field(String createTextInput) {
        homePage.fillTheTextInputToCreate(createTextInput);
    }

    @When("^I click the enter$")
    public void I_click_the_enter() {

    }

    @Then("^I check the table$")
    public void I_check_the_table() {
        assertTrue(homePage.checkTableTitleIsDisplayed());
    }

    @Then("^I delete the table$")
    public void iDeleteTheTable() {
        homePage.fillTheTextInputToDelete();
    }

    @Then("^I check the table is not exist$")
    public void iCheckTheTableIsNotExist() {
        assertTrue(homePage.checkTableTitleIsNotDisplayed());
    }
}