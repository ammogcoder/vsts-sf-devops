using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumBingTests
{
    /// <summary>
    /// Summary description for MySeleniumTests
    /// </summary>
    [TestClass]
    public class MySeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public MySeleniumTests()
        {
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void TestMyBTN()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.Id("MyBTN")).Click();
            //driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
            Assert.IsTrue(driver.Title.Contains("ASP.NET | The ASP.NET Site"), "Verified title of the page");
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://localhost:50362/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Web.Http.Results;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using StoreApp.Controllers;
//using StoreApp.Models;

//namespace StoreApp.Tests
//{
//    [TestClass]
//    public class TestSimpleProductController
//    {
//        [TestMethod]
//        public void GetAllProducts_ShouldReturnAllProducts()
//        {
//            var testProducts = GetTestProducts();
//            var controller = new SimpleProductController(testProducts);

//            var result = controller.GetAllProducts() as List<Product>;
//            Assert.AreEqual(testProducts.Count, result.Count);
//        }

//        [TestMethod]
//        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
//        {
//            var testProducts = GetTestProducts();
//            var controller = new SimpleProductController(testProducts);

//            var result = await controller.GetAllProductsAsync() as List<Product>;
//            Assert.AreEqual(testProducts.Count, result.Count);
//        }

//        [TestMethod]
//        public void GetProduct_ShouldReturnCorrectProduct()
//        {
//            var testProducts = GetTestProducts();
//            var controller = new SimpleProductController(testProducts);

//            var result = controller.GetProduct(4) as OkNegotiatedContentResult<Product>;
//            Assert.IsNotNull(result);
//            Assert.AreEqual(testProducts[3].Name, result.Content.Name);
//        }

//        [TestMethod]
//        public async Task GetProductAsync_ShouldReturnCorrectProduct()
//        {
//            var testProducts = GetTestProducts();
//            var controller = new SimpleProductController(testProducts);

//            var result = await controller.GetProductAsync(4) as OkNegotiatedContentResult<Product>;
//            Assert.IsNotNull(result);
//            Assert.AreEqual(testProducts[3].Name, result.Content.Name);
//        }

//        [TestMethod]
//        public void GetProduct_ShouldNotFindProduct()
//        {
//            var controller = new SimpleProductController(GetTestProducts());

//            var result = controller.GetProduct(999);
//            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
//        }

//        private List<Product> GetTestProducts()
//        {
//            var testProducts = new List<Product>();
//            testProducts.Add(new Product { Id = 1, Name = "Demo1", Price = 1 });
//            testProducts.Add(new Product { Id = 2, Name = "Demo2", Price = 3.75M });
//            testProducts.Add(new Product { Id = 3, Name = "Demo3", Price = 16.99M });
//            testProducts.Add(new Product { Id = 4, Name = "Demo4", Price = 11.00M });

//            return testProducts;
//        }
//    }
//}