using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UIAutomationTests.Pages;

namespace UIAutomation.Tests
{
    public class BusTest
    {
        private IWebDriver driver;
        BusPage busPage;
        HomePage homePage;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = Util.GetKey("BASEURL");
            driver.Manage().Window.Maximize();
            busPage = new BusPage(driver);
            homePage = new HomePage(driver);
        }


        [Test]
        public void BusBookingWithInvalidCityName()
        {
            Assert.IsTrue(driver.Title == "ixigo - Best Travel Website, Book Flights, Trains, Hotels & Buses");
            homePage.SelectMenu("Buses");
            busPage.EnterFromStation("abc");
            busPage.EnterToStation("xyz");
            busPage.SubmitSearch();
            Assert.IsTrue(busPage.ErrorMessage == "Please enter your Origin City");
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

