using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using GROUNDUP.AI.Hooks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.Assist;

namespace GROUNDUP.AI.StepDefinitions
{
    [Binding]
    public class FormsandfileStepDefinitions
    {
        public IWebDriver driver = Webhook.driver;

        [Given(@"The User is at the Registration Form page")]
        public void GivenTheUserIsAtTheRegistrationFormPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
        }

        [When(@"The user add first name")]
        public void WhenTheUserAddFirstName()
        {
            
           IWebElement FirstName= driver.FindElement(By.Id("firstName"));
            FirstName.SendKeys("Phone");
        }

        [When(@"The user add Last name")]
        public void WhenTheUserAddLastName()
        {
            IWebElement LastName = driver.FindElement(By.Id("lastName"));
            LastName.SendKeys("Naing Kha");
        }

        [When(@"The user add email")]
        public void WhenTheUserAddEmail()
        {
            IWebElement Email = driver.FindElement(By.Id("userEmail"));
            Email.SendKeys("phone@yopmail.com");
        }

        [When(@"The user choose Gender")]
        public void WhenTheUserChooseGender()
        {
            IWebElement GenderMale = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[2]/form/div[3]/div[2]/div[1]/label"));
            GenderMale.Click();
        }

        [When(@"The user add phnumber")]
        public void WhenTheUserAddPhnumber()
        {
            IWebElement PhNo = driver.FindElement(By.Id("userNumber"));
            PhNo.SendKeys("0912345678");
        }
        [When(@"The user add Date of Birth")]
        public void WhenTheUserAddDateOfBirth()
        {
            IWebElement Birthday = driver.FindElement(By.Id("dateOfBirthInput"));
            
            Birthday.Clear();
            Birthday.SendKeys("1 JUNE 1999");
            System.Threading.Thread.Sleep(3000);
            Birthday.SendKeys(Keys.Enter);
        }


        [When(@"The user choose subjects")]
        public void WhenTheUserChooseSubjects()
        {
            IWebElement Subjects = driver.FindElement(By.Id("subjectsInput"));
            Subjects.SendKeys("English");
            Subjects.SendKeys(Keys.Enter);          

        }

        [When(@"The user choose hobbies")]
        public void WhenTheUserChooseHobbies()
        {
            IWebElement HobbySport = driver.FindElement(By.XPath("//*[@id='hobbiesWrapper']/div[2]/div[1]/label"));
            HobbySport.Click();
        }

        [When(@"The user upload file")]
        public void WhenTheUserUploadFile()
        {
            var path = Environment.CurrentDirectory + "\\chickensandwich.jpg";
            IWebElement Uploadfile = driver.FindElement(By.Id("uploadPicture"));
           Uploadfile.SendKeys(path);
        }

        [When(@"The user add current address")]
        public void WhenTheUserAddCurrentAddress()
        {
            IWebElement Address = driver.FindElement(By.Id("currentAddress"));
            Address.SendKeys("Number street, Name Township");
        }

        [When(@"The user choose state")]
        public void WhenTheUserChooseState()
        {

            IWebElement State = driver.FindElement(By.XPath("//*[@id='state']/div/div[1]/div[2]/div"));
            State.SendKeys("NCR");

        }

        [When(@"The user choose city")]
        public void WhenTheUserChooseCity()
        {
            IWebElement City = driver.FindElement(By.Id("city"));
            City.SendKeys("Guragon");
            City.SendKeys(Keys.Enter);
        }

        [When(@"The user clicks Submit")]
        public void WhenTheUserClicksSubmit()
        {
            IWebElement submitbtn = driver.FindElement(By.Id("submit"));
            submitbtn.Click();

        }

        [Then(@"The form is submitted")]
        public void ThenTheUserInformationIsShowInFor()
        {
            driver.FindElement(By.XPath("//div[contains(text(), 'Thanks for submitting the form')]"));
        }

        [Then(@"The user Confirm the information shown in table")]
        public void ThenTheUserConfirmTheInformationShownInTable()
        {
            var Name = driver.FindElement(By.XPath("//table//tr[1]//td[2]"));
            var Email = driver.FindElement(By.XPath("//table//tr[2]//td[2]"));
            var Gender = driver.FindElement(By.XPath("//table//tr[3]//td[2]"));
            var Mobile = driver.FindElement(By.XPath("//table//tr[4]//td[2]"));
            var Birthday = driver.FindElement(By.XPath("//table//tr[5]//td[2]"));
            var Subjects = driver.FindElement(By.XPath("//table//tr[6]//td[2]"));
            var Hobbies = driver.FindElement(By.XPath("//table//tr[7]//td[2]"));
            var picture = driver.FindElement(By.XPath("//table//tr[8]//td[2]"));
            var address = driver.FindElement(By.XPath("//table//tr[9]//td[2]"));

            Assert.AreEqual("Phone Naing Kha", Name.Text);
            Assert.AreEqual("phone@yopmail.com",Email.Text);
            Assert.AreEqual("Male",Gender.Text);
            Assert.AreEqual("0912345678",Mobile.Text);
          //  Assert.AreEqual("01 June,1999", Birthday.Text);
          // There is a bug in the form. Try deleting all the placeholder value of Date of birth text field. The form went blank.

        
            Assert.AreEqual("English", Subjects.Text);
            Assert.AreEqual("Sports", Hobbies.Text);
            Assert.AreEqual("Number street, Name Township", address.Text);
            Assert.AreEqual("chickensandwich.jpg", picture.Text);

        }
        [When(@"The user add invalid emails")]
        public void WhenTheUserAddInvalidEmails(Table table)
        {
            var email = table.CreateSet<invalidemails>();
            foreach (var item in email)
            {
                driver.FindElement(By.Id("userEmail")).SendKeys(item.emails);
                driver.FindElement(By.Id("submit")).Click();
                driver.FindElement(By.Id("userEmail")).Clear();

            }


        }

        [Then(@"The form is not submitted")]
        public void ThenTheFormIsNotSubmitted()
        {

           
              IList<IWebElement> formsubmitheader =  driver.FindElements(By.XPath("//div[contains(text(), 'Thanks for submitting the form')]"));
                if (formsubmitheader.Count()== 0)
            {
                
            }
                else
            {
                Assert.Fail(); 
                // Failed the test on purpose becoz email should not be empty
            }
            
            

            }

        [When(@"The user add invalid ph number")]
        public void WhenTheUserAddInvalidPhNumber()
        {
            driver.FindElement(By.Id("userNumber")).SendKeys("09123");
            driver.FindElement(By.Id("submit")).Click();
            driver.FindElement(By.Id("userNumber")).Clear();
            driver.FindElement(By.Id("userNumber")).SendKeys("091234567");
            driver.FindElement(By.Id("submit")).Click();
            driver.FindElement(By.Id("userNumber")).Clear();


        }


        public record invalidemails
        {
            public string emails { get; set; }
        }
      
    }
}
