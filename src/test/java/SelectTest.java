
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvFileSource;

public class SelectTest extends Initialization {

    private HomePage homePage = new HomePage();

    @ParameterizedTest
    @CsvFileSource(resources = "select.csv", numLinesToSkip = 1)
    public void selectQuery(String selectText, String errorMessage) {
        homePage.createATable();
        homePage.fillTheTextInputToSelect(selectText);
        Assertions.assertTrue(homePage.checkTableTitleIsDisplayed(), errorMessage);
    }
}