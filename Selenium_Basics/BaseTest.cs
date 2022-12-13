using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Basics;

public class BaseTest
{
    protected IWebDriver _driver;
    protected static WebDriverWait _waiter;
    protected const string MainPageUrl = "https://www.epam.com/";

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        _driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}