using OpenQA.Selenium;

namespace UIAutomationTests.Pages
{
    public class HotelPage : BasePage
    {
        public HotelPage(IWebDriver driver) : base(driver) { }

        private By txtDestination = By.CssSelector("input[placeholder='Enter Destination']");
        private By lstDestination(string destination) => By.CssSelector("[data-testid='search-destinations'] [data-testid='" + destination + "']");
        private By btnSearch => By.CssSelector("button[data-testid='search-hotels']");
        private By txtCheckin => By.XPath("//p[text()='Check-in']/following-sibling::input");
        private By lblDate(string day) => By.XPath("//div[@class='react-calendar__month-view']//button[contains(@class,'react-calendar__month-view__days__day') and normalize-space()='" + day + "']");
        private By txtCheckout => By.XPath("//p[text()='Check-out']/following-sibling::input");

        public IWebElement txtDestinationElement => driver.FindElement(txtDestination);
        public IWebElement lstDestinationElement(string destination) => driver.FindElement(lstDestination(destination));
        public IWebElement btnSearchElement => driver.FindElement(btnSearch);
        public IWebElement txtCheckinElement => driver.FindElement(txtCheckin);
        public IWebElement txtCheckoutElement => driver.FindElement(txtCheckout);
        public IWebElement lblCheckinDateElement(string date) => driver.FindElement(lblDate(date));
        public IWebElement lblCheckoutDateElement(string date) => driver.FindElement(lblDate(date));

        public void EnterDestination(string destination)
        {
            if (txtDestinationElement.GetAttribute("value") != destination)
            {
                txtDestinationElement.Clear();
                txtDestinationElement.SendKeys(destination);
                lstDestinationElement(destination).Click();
            }
        }

        public void SelectCheckinDate(string day)
        {
            txtCheckinElement.Click();
            lblCheckinDateElement(day).Click();
        }

        public void SelectCheckoutDate(string day)
        {
            lblCheckoutDateElement(day).Click();
        }

        public void SubmitSearch()
        {
            btnSearchElement.Click();
        }
    }
}

