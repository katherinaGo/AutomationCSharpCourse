using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Advanced;

public class BaseTest
{
    private const string MainUrl = "https://www.epam.com";
    protected IWebDriver Driver { get; private set; }
    protected WebDriverWait Waiter { get; private set; }
    protected Actions PageAction { get; private set; }
    protected IJavaScriptExecutor? Jse { get; private set; }

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        PageAction = new Actions(Driver);
        Jse = Driver as IJavaScriptExecutor;
        Waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        Driver.Manage().Window.Maximize();
        Driver.Navigate().GoToUrl(MainUrl);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }
}