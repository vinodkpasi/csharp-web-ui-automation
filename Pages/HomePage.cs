using OpenQA.Selenium;

namespace UIAutomationTests.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        private By menu(string menuText) => By.CssSelector("li[data-testid='navlist'] a[href='/" + menuText.ToLower() + "']");

        private IWebElement menuElement(string menuText) => driver.FindElements(menu(menuText))[1];
        public void SelectMenu(string menuText)
        {
            menuElement(menuText).Click();
            Thread.Sleep(3000);
        }

    }
}