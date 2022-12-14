using OpenQA.Selenium;

namespace Selenium_Advanced;

public class EpamTests : BaseTest
{
    [Test]
    public void CheckJobListingsOpenedTest()
    {
        PageAction.MoveToElement
                (Driver.FindElement(By.XPath("//*[@class='top-navigation__item-link'][@href='/careers']")))
            .Build()
            .Perform();
        Jse?.ExecuteScript("arguments[0].click()",
            Driver.FindElement(By.XPath("//*[@class='top-navigation__main-link'][@href='/careers/job-listings']")));

        Assert.That(Driver.Url, Is.EqualTo("https://www.epam.com/careers/job-listings"),
            "There is another link for Listings page.");
    }

    [Test]
    public void CheckListOfLanguagesTest()
    {
        var expectedListOfLanguages = new List<string>()
        {
            "Global (English)",
            "Hungary (English)",
            "СНГ (Русский)",
            "Česká Republika (Čeština)",
            "India (English)",
            "Україна (Українська)",
            "Czech Republic (English)",
            "日本 (日本語)",
            "中国 (中文)",
            "DACH (Deutsch)",
            "Polska (Polski)"
        };
        Waiter.Until(Driver => Driver.FindElement(By.XPath("//*[@class='location-selector__button']"))).Click();

        var actualListOfLanguages =
            Waiter.Until(Driver => Driver.FindElements(By.XPath("//*[@class='location-selector__item']")))
                .Select(item => item.Text);

        Assert.That(actualListOfLanguages,
            Is.EqualTo(expectedListOfLanguages),
            "List of language doesn't correspond needed ones.");
    }

    [Test]
    public void Check20ResultsOnPageTest()
    {
        Driver.FindElement(By.XPath("//*[@class='header-search__button header__icon']")).Click();
        Waiter.Until(Driver => Driver.FindElement(
                By.XPath("//*[@class='frequent-searches__item' and contains(text(), 'Automation')]")))
            .Click();
        PageAction.SendKeys(Keys.Enter).Build().Perform();
        PageAction.ScrollToElement(Waiter.Until(Driver =>
                Driver.FindElement(By.XPath("//*[@class='search-results__footer']")))).Build()
            .Perform();
        PageAction.ScrollToElement(Driver.FindElement(By.XPath("//*[@class='search-results__footer']"))).Perform();

        var actualAmountOfFoundResults = Driver.FindElements(By.XPath("//*[@class='search-results__item']"));
        Assert.That(actualAmountOfFoundResults, Has.Count.EqualTo(20),
            "There are not 20 found result displayed on the one page.");
    }
}