import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvFileSource;

public class CreateTest extends Initialization {

    private HomePage homePage = new HomePage();

    @ParameterizedTest
    @CsvFileSource(resources = "createValid.csv", numLinesToSkip = 1, delimiter = '!')
    public void createATable(String createTextInput, String errorMessage) {
        homePage.fillTheTextInputToCreate(createTextInput);
        Assertions.assertTrue(homePage.checkTableTitleIsDisplayed(), errorMessage);
        homePage.fillTheTextInputToDelete();
    }

    @ParameterizedTest
    @CsvFileSource(resources = "createInvalid.csv", numLinesToSkip = 1, delimiter = '!')
    public void createAnInvalidTable(String createTextInput, String errorMessage) {
        homePage.fillTheTextInputToCreate(createTextInput);
        Assertions.assertTrue(homePage.checkTableTitleIsNotDisplayed(), errorMessage);
    }
}