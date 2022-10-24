using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using GROUNDUP.AI.Hooks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace GROUNDUP.AI.StepDefinitions
{
    [Binding]
    public class SignUpFeatures
    {
        public IWebDriver driver = Webhook.driver;

        [Given(@"The user go to the registeration page")]
        public void GivenTheUserGoToTheRegisterationPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/register"); //Navigate to the URL
        }

        [When(@"The user Add in the First Name")]
        public void WhenTheUserAddInTheFirstName()
        {
            driver.FindElement(By.Id("firstname")).SendKeys("Phone"); // add firstname 
        }

        [When(@"The User Fill in the Lat Name")]
        public void WhenTheUserFillInTheLatName()
        {
            driver.FindElement(By.Id("lastname")).SendKeys("Naing Kha"); //addlastname
        }

        [When(@"The User Fill in the User Name")]
        public void WhenTheUserFillInTheUserName()
        {
            driver.FindElement(By.Id("userName")).SendKeys("user"); //addusername
        }

        [When(@"The User Fill in the Valid Password")]
        public void WhenTheUserFillInTheValidPassword()
        {
            driver.FindElement(By.Id("password")).SendKeys("P@ssword 123"); // addpassowrd
        }

        [When(@"The User click on the captcha")]
        public void WhenTheUserClickOnTheCaptcha()
        {
            var captchaframe = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[2]/form/div[6]/div/div/div/iframe"));
            driver.SwitchTo().Frame(captchaframe); // has to switch frame becoz captcha is in its own iframe element
            driver.FindElement(By.ClassName("recaptcha-checkbox-border")).Click(); //click on the captcha frame but will failed.
            driver.SwitchTo().ParentFrame(); 
            // The whole point of captcha is to prevent the automation bots. so this test case will fail
        }

        [When(@"The User Click on the Register button")]
        public void WhenTheUserClickOnTheRegisterButton()
        {
            driver.FindElement(By.Id("register")).Click();
        }

        [Then(@"The User is registered")]
        public void ThenTheUserIsRegistered()
        {
            var successfulAlert = "User Register Successfully.";
            Assert.AreEqual(successfulAlert, driver.SwitchTo().Alert().Text ); //confirming the alert is display correctly 
            
            driver.SwitchTo().Alert().Accept(); 
            

        }

        [Then(@"The User is guided back to the Registeration Page")]
        public void ThenTheUserIsGuidedBackToTheLoginPage()
        {
            driver.FindElement(By.Id("register"));
        }
        
        [Then(@"The User is shown the Error Message to verify captcha")]
        public void ThenTheUserIsShownTheErrorMessageToVerifyCaptcha()
        {
            driver.FindElement(By.Id("name"));
            var errormessage = "Please verify reCaptcha to register!";
            Assert.AreEqual(errormessage, driver.FindElement(By.Id("name")).Text);
        }
        
        [Then(@"The User close the browser")]
        public void ThenTheUserCloseTheBrowser()
        {
            driver.Quit();
        }

        [Given(@"The User Go to the login page")]
        public void GivenTheUserGoToTheLoginPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/login");
        }

        [When(@"The User Fill in the Valid User Name to Login")]
        public void WhenTheUserFillInTheValidUserNameToLogin()
        {
            var correctusername = "pnk123";
            driver.FindElement(By.Id("userName")).SendKeys(correctusername);
        }

        [When(@"The User Fill in the Valid Password to Login")]
        public void WhenTheUserFillInTheValidPasswordToLogin()
        {
            var correctpwd = "P@ssword 123";
            driver.FindElement(By.Id("password")).SendKeys(correctpwd);
        }

        [When(@"The User click on the login")]
        public void WhenTheUserClickOnTheLogin()
        {
            driver.FindElement(By.Id("login")).Click();
        }

        [Then(@"The User confirm hes guided to profile page")]
        public void ThenTheUserConfirmHesGuidedToProfilePage()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
           
            wait.Until(driver => driver.FindElement(By.XPath("//div[contains(text(), 'Profile')]")));   
        }

        [When(@"The User Fill in the InValid Username to Login")]
        public void WhenTheUserFillInTheInValidUsernameToLogin()
        {
            var wrongusername = "pnk123456";
            driver.FindElement(By.Id("userName")).SendKeys(wrongusername);
        }

        [Then(@"The User confirm the error message shows up")]
        public void ThenTheUserConfirmTheErrorMessageShowsUp()
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(), 'Invalid username or password!')]")));
        }
        [When(@"The User Fill in the InValid Password to Login")]
        public void WhenTheUserFillInTheInValidPasswordToLogin()
        {
            var wrongpwd = "qwer123";
            driver.FindElement(By.Id("password")).SendKeys(wrongpwd);
        }
        [When(@"The User Click on the New User Button")]
        public void WhenTheUserClickOnTheNewUserButton()
        {
            driver.FindElement(By.Id("newUser")).Click();
        }

        [Then(@"The user go to the registeration page")]
        public void ThenTheUserGoToTheRegisterationPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => driver.FindElement(By.XPath("//div[contains(text(), 'Register')]")));
        }

        [When(@"The user click on the Back to login button")]
        public void WhenTheUserClickOnTheBackToLoginButton()
        {
             driver.FindElement(By.Id("gotologin")).Click();
        
        }

        [Then(@"The User Go to the login page")]
        public void ThenTheUserGoToTheLoginPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            wait.Until(driver => driver.FindElement(By.XPath("//div[contains(text(), 'Login')]")));
        }

        [Given(@"The user is login and at the Profile page")]
        public void GivenTheUserIsLoginAndAtTheProfilePage()
        {
            var username = "pnk123";
            var pwd = "P@ssword 123";
            driver.Navigate().GoToUrl("https://demoqa.com/login");
            IWebElement Usernamefield = driver.FindElement(By.Id("userName"));
            Usernamefield.SendKeys(username);
            IWebElement PwdField = driver.FindElement(By.Id("password"));
            PwdField.SendKeys(pwd);
            IWebElement LgnBtn = driver.FindElement(By.Id("login"));
            LgnBtn.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(By.XPath("//div[contains(text(), 'Profile')]")));
            driver.Navigate().GoToUrl("https://demoqa.com/books");
        }

        [When(@"The user click on the logout button")]
        public void WhenTheUserClickOnTheLogoutButton()
        {
            driver.FindElement(By.XPath("//button[contains(text(), 'Log out')]")).Click();

        }
        [Then(@"The user confirm the logout")]
        public void ThenTheUserConfirmTheLogout()
        {
            var URL = driver.Url;
            Assert.AreEqual("https://demoqa.com/login", URL);
        }






    }
}
