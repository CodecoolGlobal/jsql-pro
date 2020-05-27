import org.openqa.selenium.Keys;
import org.openqa.selenium.TimeoutException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;
import org.openqa.selenium.support.PageFactory;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

public class HomePage extends BasePage {

    private WebDriver driver;
    private WebDriverWait wait;
    @FindBy(xpath = "//input[@name='name']")
    private WebElement textInput;
    @FindBy(xpath = "//*[text()='myTable']")
    private WebElement checkTableTitle;
    @FindBy(xpath = "//*[text()='60']")
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

    public void selectATable() {
        textInput.sendKeys("SELECT * FROM myTable;");
        textInput.sendKeys(Keys.ENTER);
        textInput.clear();
    }

    public void insertInto() {
        textInput.sendKeys("INSERT INTO myTable (Jozsef, Jozsi, 60, 92);");
        textInput.sendKeys(Keys.ENTER);
        textInput.clear();
    }

    public void fillTheTextInputToCreateValid() {
        textInput.sendKeys("CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);");
        textInput.sendKeys(Keys.ENTER);
        textInput.clear();
    }

    public void fillTheTextInputToCreate(String createTextInput) {
        textInput.sendKeys(createTextInput);
        textInput.sendKeys(Keys.ENTER);
        textInput.clear();
    }

    public void fillTheTextInputToInsert(String insertIntoText) {
        textInput.sendKeys(insertIntoText);
        textInput.sendKeys(Keys.ENTER);
        textInput.clear();
    }

    public void fillTheTextInputToDelete() {
        wait.until(ExpectedConditions.visibilityOf(checkTableTitle));
        textInput.sendKeys("DELETE myTable;");
        textInput.sendKeys(Keys.ENTER);
    }

    public void fillTheTextInputToSelect(String selectText) {
        textInput.sendKeys(selectText);
        textInput.sendKeys(Keys.ENTER);
    }

    public boolean checkTableTitleIsDisplayed() {
        try {
            wait.until(ExpectedConditions.visibilityOf(checkTableTitle));
            return checkTableTitle.isDisplayed();
        } catch (TimeoutException e) {
            return false;
        }
    }

    public boolean checkTableTitleIsNotDisplayed() {
        wait.until(ExpectedConditions.visibilityOf(checkTableTitle));
        return !checkTableTitle.isDisplayed();
    }

    public boolean checkTableRecord() {
        try {
            wait.until(ExpectedConditions.elementToBeClickable(checkTableRecord));
            return checkTableRecord.isDisplayed();
        } catch (TimeoutException e) {
            return false;
        }
    }

    public void createATable(){
        if(!checkTableTitleIsDisplayed()) {
            fillTheTextInputToCreateValid();
        } else {
        }
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