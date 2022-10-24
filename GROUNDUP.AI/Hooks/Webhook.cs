using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace GROUNDUP.AI.Hooks
{
    [Binding]
    public sealed class Webhook
    {
        public static IWebDriver driver;

        [BeforeScenario("@tag1","@driver")]
        public void BeforeScenarioWithTag()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            
            ChromeOptions options = new ChromeOptions();
            // options.AddExtensions("C:/Users/User/Downloads/extension_5_3_0_0.crx");
            options.AddExtensions(Environment.CurrentDirectory + "//adblock.crx");
            driver = new ChromeDriver(options);
            System.Threading.Thread.Sleep(1000);
            driver.SwitchTo().Window(driver.WindowHandles.First());



            driver.Manage().Window.Maximize();
           
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            
        }

        [AfterScenario]
        public void AfterScenario()
        {
           
        }
    }
}