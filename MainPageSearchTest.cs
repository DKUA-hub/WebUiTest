using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography.X509Certificates;
using WebUiTest.Pages.Impl;

namespace WebUiTest
{
    public class MainPageSearchTest
    {
        private IWebDriver _driver;
        private string _searchQuery = "iphone";
        private const string _Url = "https://www.amazon.com";
        public WebDriverWait _wait;

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(_Url);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [OneTimeSetUp]
        public void Wait()
        {
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }


        [Test]
        public void TestSearchReasult()
        {
            var mainPage = new HomePage(_driver);
            var resultPage = new SearchResultsPage(_driver);

            mainPage.PerformSearch(_searchQuery);

            var actualList = resultPage.SearchResultItemText();
            var expectedList = resultPage.SearchResultItemWithText(_searchQuery);
                        
            //System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(expectedList, actualList);

        }

        [OneTimeTearDown]
        public void QuitDriver()
        {
            _driver.Quit();
        }

        public bool IsElementVisible(By selector) 
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            try
            {
                return _driver.FindElement(selector).Displayed;
            }
            catch
            {
                return false;
            }
            finally
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }

        public bool IsElementVisibleExplicitWait(By selector)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            try
            {
                return _wait.Until(d => _driver.FindElement(selector).Displayed);
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
            finally
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
        }

        public void SwitchOffImplicitWait()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}