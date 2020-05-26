import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvFileSource;

public class CreateTest extends Initialization {

    private HomePage homePage = new HomePage();

    @ParameterizedTest
    @CsvFileSource(resources = "create.csv", numLinesToSkip = 1)
    public void createATable(String createTextInput, String errorMessage) {
        homePage.fillTheTextInputToCreate(createTextInput);
        Assertions.assertTrue(homePage.checkTableTitleIsDisplayed(), errorMessage);
        homePage.deleteATable();
    }
}