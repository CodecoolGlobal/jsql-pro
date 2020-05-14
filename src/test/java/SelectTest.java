
import org.junit.jupiter.api.Test;

public class SelectTest extends Initialization {

    private HomePage homePage = new HomePage();

    @Test
    public void selectQuery() {
        homePage.fillTheTextInputToSelect();
        homePage.checkTableTitle();
    }
}