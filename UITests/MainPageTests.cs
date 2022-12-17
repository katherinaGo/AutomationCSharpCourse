using OpenQA.Selenium;

namespace UITests;

public class MainPageTests : BaseTest
{
    [Test]
    public void CheckIfHeaderPresentOnThePageTest()
    {
        var isHeaderDisplayed = Driver.FindElement(By.XPath("//*[@class='header__content']")).Displayed;
        Assert.That(isHeaderDisplayed, Is.True, "Header is not displayed on the page.");
    }

    [Test]
    public void CheckThatUrlCorrespondsTest()
    {
        var expectedResult = "https://www.epam.com/careers/locations";
        PageAction.MoveToElement(Waiter.Until(Driver =>
                Driver.FindElement(
                    By.XPath("//*[@class='top-navigation__item-link' and contains(@href, '/careers')]"))))
            .Build().Perform();

        Waiter.Until(Driver =>
                Driver.FindElement(
                    By.XPath("//*[@class='top-navigation__main-link' and contains(@href, '/careers/locations')]")))
            .Click();
        Assert.That(Driver.Url, Is.EqualTo(expectedResult),
            $"Url with Hiring Locations doesn't correspond to '{expectedResult}'. Now the url is '{Driver.Url}'");
    }

    [Test]
    public void CheckThatButtonDisplayedOnPageTest()
    {
        PageAction.MoveToElement(Waiter.Until(Driver =>
                Driver.FindElement(
                    By.XPath("//*[@class='top-navigation__item-link' and contains(@href, '/careers')]"))))
            .Build().Perform();

        Waiter.Until(Driver =>
                Driver.FindElement(
                    By.XPath("//*[@class='top-navigation__main-link' and contains(@href, '/careers/locations')]")))
            .Click();
        PageAction.MoveToElement(Waiter.Until(Driver =>
            Driver.FindElement(By.XPath(" //*[@class='footer__brands-list-wrapper']")))).Build().Perform();
        var isApplyButtonVisible =
            Driver.FindElement(By.XPath("//*[@class='button__content button__content--desktop']")).Displayed;
        Assert.That(isApplyButtonVisible, Is.True, "'Apply' button is not displayed on the page.");
    }

    [Test]
    public void CheckCorrectPageIsOpenedTest()
    {
        var expectedResult = "https://www.epam.com/careers/locations";

        PageAction.MoveToElement(Waiter.Until(Driver =>
                Driver.FindElement(
                    By.XPath("//*[@class='top-navigation__item-link' and contains(@href, '/careers')]"))))
            .Build().Perform();

        Waiter.Until(Driver =>
                Driver.FindElement(
                    By.XPath("//*[@class='top-navigation__main-link' and contains(@href, '/careers/locations')]")))
            .Click();
        PageAction.MoveToElement(Waiter.Until(Driver =>
            Driver.FindElement(By.XPath(" //*[@class='footer__brands-list-wrapper']")))).Build().Perform();

        var isApplyButtonVisible =
            Driver.FindElement(By.XPath("//*[@class='button__content button__content--desktop']")).Displayed;

        Assert.Multiple(() =>
        {
            Assert.That(Driver.Url, Is.EqualTo(expectedResult),
                $"Url with Hiring Locations doesn't correspond to '{expectedResult}'. Now the url is '{Driver.Url}'");
            Assert.That(isApplyButtonVisible, Is.True, "'Apply' button is not displayed on the page.");
        });
    }
}