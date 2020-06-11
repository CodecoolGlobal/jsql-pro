import org.openqa.selenium.Platform;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.firefox.FirefoxOptions;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;

import java.net.MalformedURLException;
import java.net.URL;

public class WebDriverManager {

    private static WebDriver driver = null;
    private static String password = System.getenv("PASSWORD");
    private static String hubUser = System.getenv("hubUSERNAME");
    private static String hub = System.getenv("hubURL");
    private static String hubUrl = "https://" + hubUser + ":" + password + "@" + hub;
    private static String gridUrl = "http://172.17.0.2:4444/grid/register";


    private WebDriverManager() {
    }

    public static WebDriver getDriver1() {
        System.setProperty("webdriver.chrome.driver", "/src/test/resources/chromedriver1");
        driver.manage().window().maximize();
        return driver;
    }

    public static WebDriver getDriver() {
        if (driver == null) {
            try {
                System.setProperty("webdriver.gecko.driver", "src\\test\\resources\\geckodriver.exe");
                //FirefoxOptions options = new FirefoxOptions();
                //options.addArguments("--start-maximized");
                DesiredCapabilities capabilities = DesiredCapabilities.firefox();
                //capabilities.setCapability(FirefoxOptions.FIREFOX_OPTIONS, options);
                capabilities.setBrowserName("firefox");
                capabilities.setPlatform(Platform.WIN10);
                driver = new RemoteWebDriver(new URL(gridUrl), capabilities);
            } catch (MalformedURLException e) {
                e.fillInStackTrace();
            }
        }
        return driver;
    }

    public static WebDriver initDriver() {
        if (driver != null) {
            return driver;
        } else {
            System.setProperty("webdriver.chrome.driver", "/src/test/resources/chromedriver1");
            driver = new ChromeDriver();
        }
        return driver;
    }

    public static void quit() {
        driver.quit();
        driver = null;
    }
}