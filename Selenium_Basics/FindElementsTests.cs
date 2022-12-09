using OpenQA.Selenium;

namespace Selenium_Basics;

public class FindElementsTests : BaseTest
{
    [SetUp]
    public void SetUpForTests()
    {
        _driver.Navigate().GoToUrl(MainPageUrl);
    }

    [Test]
    public void ListOfAvailableCountriesTest()
    {
        Thread.Sleep(2000);
        _driver
            .FindElement(By.XPath("//*[@class='top-navigation__item-link' and contains(text(),'Careers')]"))
            .Click();
        var actualListOfCountries = _driver
            .FindElements(By.XPath("//*[@class='tabs__title' and contains(@role,'presentation')]"))
            .Select(item => item.Text);
        var expectedListOfCountries = new List<string> { "AMERICAS", "EMEA", "APAC" };
        Assert.That(expectedListOfCountries, Is.EqualTo(actualListOfCountries),
            "List of countries doesn't include: AMERICAS, EMEA, APAC");
    }

    [Test]
    [TestCase("Automation")]
    [TestCase("Business Analysis")]
    public void CheckLinkParameterAfterSearchTest(string searchWord)
    {
        _driver
            .FindElement(
                By.XPath("//*[@class='header-search__button header__icon' and contains(@aria-expanded, 'false')]"))
            .Click();
        _driver.FindElement(By.XPath("//*[@id='new_form_search']")).SendKeys(searchWord);
        _driver.FindElement(By.XPath("//*[@class='header-search__submit']")).Click();
        var actualResultUrl = $"https://www.epam.com/search?q={searchWord}";
        Assert.That(_driver.Url, Is.EqualTo(actualResultUrl).IgnoreCase,
            $"Parameter in link doesn't contain '{searchWord}'.");
    }

    [Test]
    [TestCase("Automation")]
    public void CheckSearchWordDisplayedInResultsTest(string searchWord)
    {
        _driver
            .FindElement(
                By.XPath("//*[@class='header-search__button header__icon' and contains(@aria-expanded, 'false')]"))
            .Click();
        _driver.FindElement(By.XPath("//*[@id='new_form_search']")).SendKeys(searchWord);
        _driver.FindElement(By.XPath("//*[@class='header-search__submit']")).Click();
        var actualResultOfSearch = _driver
            .FindElements(By.XPath("//*[@class='search-results__item']"))
            .Take(5).Select(item => item.Text);
        Assert.That(actualResultOfSearch, Is.All.Contain(searchWord).IgnoreCase,
            $"There is no '{searchWord}' in the results.");
    }
}