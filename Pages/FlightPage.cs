using OpenQA.Selenium;
namespace UIAutomationTests.Pages
{
    public class FlightPage : BasePage
    {
        public FlightPage(IWebDriver driver) : base(driver) { }

        private By txtFromStationOpener = By.CssSelector("[data-testid='originId']");
        private By btnClearIcon = By.CssSelector("[data-testid='CloseIcon']");
        private By txtFromStation = By.XPath("//label[text()='From']/following-sibling::input");
        private By txtToStation = By.XPath("//label[text()='To']/following-sibling::input");
        private By lblError = By.XPath("//div[text()='You can only book for upto 9 travellers at one go']");
        private By btnTraveller => By.CssSelector("[data-testid='pax']");
        private By lstDestination(string destination) => By.XPath("//li[contains(normalize-space(),'" + destination + "')]");

        public IWebElement txtFromStationElement => driver.FindElement(txtFromStation);
        public IWebElement txtFromStationOpenerElement => driver.FindElement(txtFromStationOpener);
        public IWebElement btnClearIconElement => driver.FindElement(btnClearIcon);
        public IWebElement txtToStationElement => driver.FindElement(txtToStation);

        public IWebElement btnTravellerElement => driver.FindElement(btnTraveller);
        public IWebElement lblErrorElement => driver.FindElement(lblError);
        public IWebElement lstDestinationElement(string destination) => driver.FindElement(lstDestination(destination));

        public void EnterFromStation(string destination)
        {
            txtFromStationOpenerElement.Click();
            btnClearIconElement.Click();
            txtFromStationElement.SendKeys(destination);
            lstDestinationElement(destination).Click();
            Thread.Sleep(2000);
        }

        public void EnterToStation(string destination)
        {
            txtToStationElement.SendKeys(destination);
            lstDestinationElement(destination).Click();
            Thread.Sleep(2000);
        }

        public string ErrorMessage
        {
            get { return lblErrorElement.Text; }
        }

        public void OpenTravellerPopup()
        {
            btnTravellerElement.Click();
        }

        public void SelectAdults(int number)
        {
            driver.FindElement(By.XPath("//p[text()='Adults']/../following-sibling::div//button[text()='"+number+"']")).Click();
        }

        public void SelectChildren(int number)
        {
            driver.FindElement(By.XPath("//p[text()='Children']/../following-sibling::div//button[text()='" + number + "']")).Click();
        }
    }
}

