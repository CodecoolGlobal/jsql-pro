import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.WebDriverWait;

public class HomePage extends BasePage {

    private WebDriver driver;
    private WebDriverWait wait;
    @FindBy(xpath = "//input[@name='name']")
    private WebElement textInput;
    @FindBy(xpath = "//*[text()='myTable']")
    private WebElement checkTableTitle;
    @FindBy(xpath = "//*[text()='József']")
    private WebElement checkTableRecord;
    private WebElement checkTask;
    private WebElement solutionButton;
    private WebElement resetButton;
    private WebElement errorMessage;

    public HomePage() {
        this.driver = getDriver();
        this.wait = getWait();
        PageFactory.initElements(driver, this);
    }

    public void fillTheTextInputToCreate() {
        textInput.sendKeys("CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);");
        textInput.sendKeys(Keys.ENTER);
    }

    public void fillTheTextInputToInsert() {
        textInput.sendKeys("INSERT INTO myTable (József, Józsi, 60, 92);");
        textInput.sendKeys(Keys.ENTER);
    }

    public void fillTheTextInputToDelete() {
        textInput.sendKeys("DELETE myTable;");
        textInput.sendKeys(Keys.ENTER);
    }

    public void fillTheTextInputToSelect() {
        textInput.sendKeys("SELECT * FROM myTable;");
        textInput.sendKeys(Keys.ENTER);
    }

    public boolean checkTableTitle() {
        return checkTableTitle.isDisplayed();
    }

    public boolean checkTableRecord() {
        return checkTableRecord.isDisplayed();
    }

    public void createATable(){
        fillTheTextInputToCreate();
        checkTableTitle();
    }

    public void deleteATable(){
        fillTheTextInputToDelete();
    }

    public boolean checkTask() {
        return checkTask.isDisplayed();
    }

    public void clickOnSolutionButton() {
        solutionButton.click();
    }

    public void clickOnResetButton() {
        resetButton.click();
    }

    public boolean checkErrorMessage() {
        return errorMessage.isDisplayed();
    }
}