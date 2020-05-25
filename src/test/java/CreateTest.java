import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class CreateTest extends Initialization {

    private HomePage homePage = new HomePage();

    @Test
    public void createATable() {
        homePage.fillTheTextInputToCreate();
        homePage.deleteATable();
        Assertions.assertTrue(homePage.checkTableTitleIsDisplayed());
    }
}