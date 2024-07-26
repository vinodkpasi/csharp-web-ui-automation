using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UIAutomationTests.Pages;


namespace UIAutomation.Tests
{
    public class TrainTest
    {
        private IWebDriver driver;
        TrainPage trainPage;
        HomePage homePage;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Url = Util.GetKey("BASEURL");
            driver.Manage().Window.Maximize();
            trainPage = new TrainPage(driver);
            homePage = new HomePage(driver);
        }

        [Test]
        public void TrainBookingWithValidInput()
        {
            Assert.IsTrue(driver.Title == "ixigo - Best Travel Website, Book Flights, Trains, Hotels & Buses");
            homePage.SelectMenu("Trains");     
            trainPage.EnterFromStation("New Delhi");
            trainPage.EnterToStation("Hyderabad");
            trainPage.SubmitSearch();
        }

        [Test]
        public void TrainBookingWithEmptyInput()
        {
            Assert.IsTrue(driver.Title == "ixigo - Best Travel Website, Book Flights, Trains, Hotels & Buses");
            homePage.SelectMenu("Trains");
            trainPage.SubmitSearch();
            Assert.IsTrue(trainPage.ErrorMessage == "Please enter origin station!");
        }

        [Test]
        public void TrainBookingWithNoMatchingStation()
        {
            Assert.IsTrue(driver.Title == "ixigo - Best Travel Website, Book Flights, Trains, Hotels & Buses");
            homePage.SelectMenu("Trains");
            trainPage.EnterFromStation("New Delhi");
            trainPage.EnterToStation("Kavas");
            trainPage.SubmitSearch();
            Assert.IsTrue(trainPage.NoTrainFound);
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

