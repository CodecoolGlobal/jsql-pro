import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.CsvFileSource;

public class InsertTest extends Initialization {

    private HomePage homePage = new HomePage();

    @ParameterizedTest
    @CsvFileSource(resources = "insertIntoValid.csv", numLinesToSkip = 1, delimiter = '!')
    public void insertATable(String insertIntoText, String errorMessage) {
        homePage.createATable();
        homePage.fillTheTextInputToInsert(insertIntoText);
        homePage.selectATable();
        Assertions.assertTrue(homePage.checkTableRecord(), errorMessage);
        homePage.fillTheTextInputToDelete();
    }

    @ParameterizedTest
    @CsvFileSource(resources = "insertIntoInvalid.csv", numLinesToSkip = 1, delimiter = '!')
    public void insertATableInvalidFormat(String insertIntoText, String errorMessage) {
        homePage.createATable();
        homePage.fillTheTextInputToInsert(insertIntoText);
        homePage.selectATable();
        Assertions.assertFalse(homePage.checkTableRecord(), errorMessage);
        homePage.fillTheTextInputToDelete();
    }
}