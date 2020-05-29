import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvFileSource;

public class SelectTest extends Initialization {

    private HomePage homePage = new HomePage();

    @ParameterizedTest
    @CsvFileSource(resources = "selectValid.csv", numLinesToSkip = 1, delimiter = '!')
    public void selectValidQuery(String selectText, String errorMessage) {
        homePage.createATable();
        homePage.insertInto();
        homePage.fillTheTextInputToSelect(selectText);
        Assertions.assertTrue(homePage.checkTableRecord(), errorMessage);
        homePage.fillTheTextInputToDelete();
    }

    @ParameterizedTest
    @CsvFileSource(resources = "selectInvalid.csv", numLinesToSkip = 1, delimiter = '!')
    public void selectInvalidQuery(String selectText, String errorMessage) {
        homePage.createATable();
        homePage.insertInto();
        homePage.fillTheTextInputToSelect(selectText);
        Assertions.assertFalse(homePage.checkTableRecord(), errorMessage);
        homePage.fillTheTextInputToDelete();
    }
}