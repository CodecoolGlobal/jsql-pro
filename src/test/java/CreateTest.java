import org.junit.jupiter.api.Test;

public class CreateTest extends Initialization {

    private HomePage homePage = new HomePage();

    @Test
    public void createATable() {
        homePage.fillTheTextInputToCreate();
        homePage.checkTableRow();
    }
}