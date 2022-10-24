using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using GROUNDUP.AI.Hooks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


namespace GROUNDUP.AI.StepDefinitions
{


    [Binding]
    public class BooksFindingAndCollection
    {
        public IWebDriver driver = Webhook.driver;


        [Given(@"The user is login and at the book store url")]
        public void GivenTheUserIsLoginAndAtTheBookStoreUrl()
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

        [When(@"The user clicks on book A")]
        public void WhenTheUserClicksOnBookA()
        {
            IWebElement BookA = driver.FindElement(By.XPath("//a[contains(text(), 'Git Pocket Guide')]"));
            BookA.Click();
        }

        [Then(@"The user is taken to the book detail")]
        public void ThenTheUserIsTakenToTheBookDetail()
        {
            System.Threading.Thread.Sleep(1000);
            IWebElement Description = driver.FindElement(By.XPath("//label[contains(text(), 'Description :')]"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => Description);
        }

        [Then(@"The user confirm the book tittle")]
        public void ThenTheUserConfirmTheBookTittle()
        {
            IWebElement BookTittle = driver.FindElement(By.XPath("//label[contains(text(), 'Git Pocket Guide')]"));
            Assert.AreEqual("Git Pocket Guide", BookTittle.Text);
        }

        [When(@"The user add the book to the book collection")]
        public void WhenTheUserAddTheBookAToTheBookCollection()
        {
            System.Threading.Thread.Sleep(1000);
            IWebElement Addtocollectbtn = driver.FindElement(By.XPath("//button[contains(text(), 'Add To Your Collection')]"));
            Addtocollectbtn.Click();
        }

        [Then(@"The user sees the successful alert")]
        public void ThenTheUserSeesTheSuccessfulAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.SwitchTo().Alert());

            IAlert successfulalert = driver.SwitchTo().Alert();
            String alerttext = successfulalert.Text;
            Assert.AreEqual("Book added to your collection.", alerttext);

        }

        [Then(@"The user click on Ok")]
        public void ThenTheUserClickOnOk()
        {
            driver.SwitchTo().Alert().Accept();
            System.Threading.Thread.Sleep(1000);
        }

        [Then(@"The user sees the Error alert")]
        public void ThenTheUserSeesTheErrorAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.SwitchTo().Alert());

            IAlert successfulalert = driver.SwitchTo().Alert();
            String alerttext = successfulalert.Text;
            Assert.AreEqual("Book already present in the your collection!", alerttext);
        }

        [When(@"The user click goes back to book store")]
        public void WhenTheUserClickGoesBackToBookStore()
        {
            IWebElement Gobacktobookstore = driver.FindElement(By.XPath("//button[contains(text(), 'Back To Book Store')]"));
            Gobacktobookstore.Click();
        }

        [Then(@"The user gets the book store")]
        public void ThenTheUserGetsTheBookStore()
        {
            string URL = driver.Url;
            Assert.AreEqual("https://demoqa.com/books", URL);

        }

        [When(@"The user goes to profile")]
        public void WhenTheUserGoesToProfile()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/profile");
        }

        [Then(@"The user sees the book A in the collection")]
        public void ThenTheUserSeesTheBookAInTheCollection()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(By.XPath("//a[contains(text(), 'Git Pocket Guide')]")));
        }

        [When(@"The user clicks on the delete button")]
        public void WhenTheUserClicksOnTheDeleteButton()
        {
            IWebElement DeleteBtn = driver.FindElement(By.Id("delete-record-undefined"));
            DeleteBtn.Click();
        }

        [Then(@"The user sees the confirm alert")]
        public void ThenTheUserSeesTheConfirmAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(drier => driver.FindElement((By.XPath("//div[contains(text(), 'Do you want to delete this book?')]"))));

        }

        [When(@"The user clicks ok")]
        public void WhenTheUserClicksOk()
        {
            IWebElement Okbtn = driver.FindElement((By.Id("closeSmallModal-ok")));
            Okbtn.Click();
        }

        [Then(@"The user sees the book delete alert")]
        public void ThenTheUserSeesTheBookDeleteAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.SwitchTo().Alert());

            IAlert bookdeletealert = driver.SwitchTo().Alert();
            String alerttext = bookdeletealert.Text;
            Assert.AreEqual("Book deleted.", alerttext);
            System.Threading.Thread.Sleep(2000);
        }


        [Then(@"The user cannot see the book A anymore")]
        public void ThenTheUserCannotSeeTheBookAnymore()
        {
            IList<IWebElement> formsubmitheader = driver.FindElements(By.XPath("//a[contains(text(), 'Git Pocket Guide')]"));
            if (formsubmitheader.Count() == 0)
            { }
            else
            {
                Assert.Fail();
            }


        }
    
        
        [When(@"The user click on the book B")]
        public void WhenTheUserClickOnTheBookB()
        {
            System.Threading.Thread.Sleep(1000);    
            IWebElement BookB = driver.FindElement(By.XPath("//a[contains(text(), 'Learning JavaScript Design Patterns')]"));
            BookB.Click();
        }

        [When(@"THe user clicks on the delete all books button")]
        public void WhenTHeUserClicksOnTheDeleteAllBooksButton()
        {
            IWebElement DeleteallBookbtn = driver.FindElement(By.XPath("//button[contains(text(), 'Delete All Books')]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
           
            
            DeleteallBookbtn.Click();   
        }

        [Then(@"The user sees the all books delete alert")]
        public void ThenTheUserSeesTheAllBooksDeleteAlert()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.SwitchTo().Alert());

            IAlert bookdeletealert = driver.SwitchTo().Alert();
            String alerttext = bookdeletealert.Text;
            Assert.AreEqual("All Books deleted.", alerttext);
            System.Threading.Thread.Sleep(2000);

        }




    }
}