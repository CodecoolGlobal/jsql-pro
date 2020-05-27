import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class DeleteTest extends Initialization{

    private HomePage homePage = new HomePage();

    @Test
    public void deleteATable(){
        homePage.fillTheTextInputToCreateValid();
        Assertions.assertFalse(homePage.checkTableTitleIsNotDisplayed());
        homePage.fillTheTextInputToDelete();
    }
}
