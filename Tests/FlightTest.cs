using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UIAutomationTests.Pages;

namespace UIAutomation.Tests
{
    public class FlightTest
    {
        private IWebDriver driver;
        FlightPage flightPage;
        HomePage homePage;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = Util.GetKey("BASEURL");
            driver.Manage().Window.Maximize();
            flightPage = new FlightPage(driver);
            homePage = new HomePage(driver);
        }


        [Test]
        public void FlightBookingWithInvalidCityName()
        {
            Assert.IsTrue(driver.Title == "ixigo - Best Travel Website, Book Flights, Trains, Hotels & Buses");
            homePage.SelectMenu("Flights");
            flightPage.EnterFromStation("New Delhi");
            flightPage.EnterToStation("Mumbai");
            flightPage.OpenTravellerPopup();
            flightPage.SelectAdults(9);
            flightPage.SelectChildren(8);
            Assert.IsTrue(flightPage.ErrorMessage == "You can only book for upto 9 travellers at one go");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}

