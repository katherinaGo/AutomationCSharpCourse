using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Basics;

public class BaseTest
{
    protected IWebDriver _driver;
    protected const string MainPageUrl = "https://www.epam.com/";

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }
}