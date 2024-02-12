

using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V119.Browser;
using OpenQA.Selenium.Support.UI;
using SpecFlowProjectBDD.Drivers;
using System.Configuration;
using TechTalk.SpecFlow.Assist;
namespace SpecFlowProjectBDD.StepDefinitions
{
    [Binding]
    class GoogleSearchSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        IWebDriver driver;


        private readonly ScenarioContext _scenarioContext;


        public GoogleSearchSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I have navigated to Google page")]
        public void GivenIHaveNavigatedToGooglePage()
        {
            driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();
            driver.Url = "https://www.google.com";

        }


        [Given(@"I see the Google page fully loaded")]
        public void GivenIseeTheGooglePageFullyLoaded()
        {
            if (driver.FindElement(By.Name("q")).Displayed == true)
                Console.WriteLine("Page Loaded FUlly");
            else
                Console.WriteLine("Page failed to laod");
        }

        [When(@"I type search keyword as")]
        public void WhenITypeSearchKeywordAs(Table table)
        {
            dynamic tableDetail = table.CreateDynamicInstance();
         driver.FindElement(By.Name("q")).SendKeys(tableDetail.Keyword);


        }

    
         
            [Then(@"I should see the result for keyword")]
            public void ThenIShouldSeeTheResultForKeyword(Table table)
            {
                dynamic tableDetail = table.CreateDynamicInstance();
                string key = tableDetail.keyword;

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                try
                {
                    // Wait for the textarea to be visible
                    var textArea = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@name=\"q\"]")));

                    // Get the text from the textarea
                    var textValue = textArea.GetAttribute("value"); // If directly getting text does not work, try using GetAttribute("value")

                    if (textValue.Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Text area contains the expected text: {textValue}");
                    }
                    else
                    {
                        Console.WriteLine($"Expected text '{key}' but found '{textValue}'");
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("Textarea not found within the timeout period.");
                }
            }





            //}
            //catch (WebDriverTimeoutException)
            //{
            //    // Element not found within the timeout period
            //    Console.WriteLine("Control not exist");
            //}
        

    }
}
