using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Security.Cryptography.X509Certificates;

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
            IWebElement searchField = _driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
            searchField.SendKeys(_searchQuery);
            searchField.SendKeys(Keys.Enter);

            IList<string> actualList = _driver.FindElements(By.CssSelector(".s-main-slot h2 .a-link-normal"))
                .Select(item => item.Text.ToLower().ToString())
                .ToList();
            IList<string> expectedList = actualList
                .Where(item => item.Contains(_searchQuery))
                .ToList();

            //System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(expectedList, actualList);

            //Assert.True(_driver.FindElement(By.CssSelector("#nav-logo-sprites")).Displayed);
            Assert.True(IsElementVisible(By.CssSelector("#nav-logo-sprites")));

            SwitchOffImplicitWait();
            Assert.True(IsElementVisibleExplicitWait(By.CssSelector("#nav-logo-sprites")));

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