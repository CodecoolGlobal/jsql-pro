import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class DeleteTest extends Initialization {

    private HomePage homePage = new HomePage();

    @Test
    public void deleteATable() {
        homePage.fillTheTextInputToCreateValid();
        homePage.fillTheTextInputToDelete();
        Assertions.assertFalse(homePage.checkTableTitleIsNotDisplayed());
    }

    @Test
    public void checkTableAfterDelete() {
        homePage.createATable();
        homePage.insertInto();
        homePage.selectATable();
        homePage.fillTheTextInputToDelete();
        Assertions.assertTrue(homePage.checkTableRecord(), "It's already deleted.");
    }
}
