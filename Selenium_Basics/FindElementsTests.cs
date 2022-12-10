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
        _driver
            .FindElement(By.XPath(
                "(//span[@class='top-navigation__item-link-holder--a11y']//preceding::span[@class='top-navigation__item-text'])[6]"))
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
        _driver.FindElement(By.XPath("//form[@action='/search']/child::button[@class='header-search__submit']"))
            .Click();
        Assert.That(_driver.Url, Does.Contain(searchWord.Replace(' ', '+')).IgnoreCase,
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

    [Test]
    [TestCase("Business Analysis")]
    public void CheckTitleOfSearchCorrespondsArticleTest(string searchWord)
    {
        _driver
            .FindElement(
                By.XPath("//*[@class='header-search__button header__icon' and contains(@aria-expanded, 'false')]"))
            .Click();
        _driver.FindElement(By.XPath("//*[@id='new_form_search']")).SendKeys(searchWord);
        _driver.FindElement(By.XPath("//*[@class='header-search__submit']")).Click();
        Thread.Sleep(1500);

        var expectedResultSearchPage = _driver.FindElement(By.XPath("(//*[@class='search-results__title'])[1]")).Text;
        _driver.FindElement(By.XPath("(//*[@class='search-results__title-link'])[1]")).Click();

        var actualResultOpenedPage = _driver
            .FindElement(By.XPath("//*[@class='title']//parent::div[@class='layout-box__wrapper']")).Text;
        Assert.That(expectedResultSearchPage, Is.EqualTo(actualResultOpenedPage),
            "Title of the article doesn't correspond the article from search list.");
    }
}