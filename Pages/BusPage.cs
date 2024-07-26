using OpenQA.Selenium;
namespace UIAutomationTests.Pages
{
    public class BusPage : BasePage
    {
        public BusPage(IWebDriver driver) : base(driver) { }

        private By txtFromStation = By.CssSelector("[placeholder=\"From Station\"]");
        private By lblError = By.CssSelector("span.error");
        private By txtToStation = By.CssSelector("[placeholder=\"To Station\"]");
        private By btnSearch => By.Id("search-button");

        public IWebElement txtFromStationElement => driver.FindElement(txtFromStation);
        public IWebElement txtToStationElement => driver.FindElement(txtToStation);
        public IWebElement lblErrorElement => driver.FindElement(lblError);
        public IWebElement btnSearchElement => driver.FindElement(btnSearch);


        public void EnterFromStation(string destination)
        {
            txtFromStationElement.Clear();
            txtFromStationElement.SendKeys(destination);
        }

        public void EnterToStation(string destination)
        {
            txtToStationElement.Clear();
            txtToStationElement.SendKeys(destination);
        }

        public string ErrorMessage
        {
            get { return lblErrorElement.Text; }
        }

        public void SubmitSearch()
        {
            btnSearchElement.Click();
        }
    }
}

