using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UITests;

public class BaseTest
{
    protected IWebDriver Driver { get; set; }
    protected WebDriverWait Waiter { get; private set; }
    protected Actions PageAction { get; private set; }

    private const string MainUrl = "https://www.epam.com";

    [SetUp]
    public void SetUp()
    {
        Driver = new ChromeDriver();
        PageAction = new Actions(Driver);
        Waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(MainUrl);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}