using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UIAutomationTests.Pages;

namespace UIAutomation.Tests
{
    public class HotelTest
    {
        #pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private IWebDriver driver;
        #pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        HotelPage hotelPage;
        HomePage homePage;

        public HotelTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = Util.GetKey("BASEURL");
            driver.Manage().Window.Maximize();
            hotelPage = new HotelPage(driver);
            homePage = new HomePage(driver);
        }

        [Test]
        public void HotelBooking()
        {
            Assert.IsTrue(driver.Title == "ixigo - Best Travel Website, Book Flights, Trains, Hotels & Buses");
            homePage.SelectMenu("Hotels");
            hotelPage.EnterDestination("Goa");
            hotelPage.SelectCheckinDate(DateTime.Today.Day.ToString());
            hotelPage.SelectCheckoutDate(DateTime.Today.AddDays(1).Day.ToString());
            hotelPage.SubmitSearch();
        }

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
