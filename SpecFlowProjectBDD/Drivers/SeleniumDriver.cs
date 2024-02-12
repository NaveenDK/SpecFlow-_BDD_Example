using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectBDD.Drivers
{
     public class SeleniumDriver
    {
        private IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;


        public IWebDriver Setup()
        {

            //var firefoxOptions = new FirefoxOptions();
            //// This creates a new instance of FirefoxDriver, which will open a Firefox browser locally
            //driver = new FirefoxDriver(firefoxOptions);

            //// Set the driver in the scenario context so it can be accessed later
            //_scenarioContext.Set(driver, "WebDriver");

            //driver.Manage().Window.Maximize();

            var chromeOptions = new ChromeOptions();
            // This creates a new instance of FirefoxDriver, which will open a Firefox browser locally
            driver = new ChromeDriver(chromeOptions);

            // Set the driver in the scenario context so it can be accessed later
            _scenarioContext.Set(driver, "WebDriver");

            driver.Manage().Window.Maximize();

            return driver;
        }

    }
}
