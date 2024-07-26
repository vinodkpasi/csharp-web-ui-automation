using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
namespace UIAutomationTests.Pages
{
    public class TrainPage : BasePage
    {
        public TrainPage(IWebDriver driver) : base(driver) { }

        private By txtFromStation = By.CssSelector("[placeholder=\"Enter Origin\"]");
        private By lblNoTrainFound = By.XPath("//div[text()='No trains found between specified stations']");
        private By txtToStation = By.CssSelector("[placeholder=\"Enter Destination\"]");
        private By lstDestination(string destination) => By.XPath("//li[contains(normalize-space(),'" + destination + "')]");
        private By btnSearch => By.CssSelector("button[data-testid='book-train-tickets']");
        private By lblError = By.CssSelector(".body-sm.text-primary");

        public IWebElement txtFromStationElement => driver.FindElement(txtFromStation);
        public IWebElement txtToStationElement => driver.FindElement(txtToStation);
        public IWebElement lstDestinationElement(string destination) => driver.FindElement(lstDestination(destination));
        public IWebElement btnSearchElement => driver.FindElement(btnSearch);
        public IWebElement lblErrorElement => driver.FindElement(lblError);
        public IWebElement lblNoTrainFoundElement => driver.FindElement(lblNoTrainFound);


        public void EnterFromStation(string destination)
        {
            txtFromStationElement.Clear();
            txtFromStationElement.Click();
            new Actions(driver).SendKeys(destination).Perform();
            Thread.Sleep(2000);
            lstDestinationElement(destination).Click();
            Thread.Sleep(2000);
        }

        public void EnterToStation(string destination)
        {
            txtToStationElement.Clear();
            txtToStationElement.Click();
            new Actions(driver).SendKeys(destination).Perform();
            Thread.Sleep(2000);
            lstDestinationElement(destination).Click();
            Thread.Sleep(2000);
        }

        public string ErrorMessage
        {
            get { return lblErrorElement.Text; }
        }

        public bool NoTrainFound
        {
            get { return lblNoTrainFoundElement.Displayed; }
        }

        public void SubmitSearch()
        {
            btnSearchElement.Click();
        }
    }
}

