namespace Selenium_Basics;

public class UrlTests : BaseTest
{
    private const string HowWeDoPageUrl = "https://www.epam.com/how-we-do-it";
    private const string OurWorkPageUrl = "https://www.epam.com/our-work";

    [Test]
    public void MainPageIsOpenedTest()
    {
        _driver.Navigate().GoToUrl(MainPageUrl);
        Assert.That(_driver.Url, Is.EqualTo(MainPageUrl), "Wrong Url is used for main page.");
    }

    [Test]
    public void HowWeDoPageIsOpenedTest()
    {
        _driver.Navigate().GoToUrl(HowWeDoPageUrl);
        _driver.Navigate().GoToUrl(OurWorkPageUrl);
        _driver.Navigate().Refresh();
        _driver.Navigate().Back();
        Assert.That(_driver.Url, Is.EqualTo(HowWeDoPageUrl), "Wrong Url is used for the page.");
    }
}