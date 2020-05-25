import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class InsertTest extends Initialization {

    private HomePage homePage = new HomePage();

    @Test
    public void insertATable() {
        homePage.createATable();
        homePage.fillTheTextInputToInsert();
        Assertions.assertTrue(homePage.checkTableRecord());
        homePage.deleteATable();
    }
}