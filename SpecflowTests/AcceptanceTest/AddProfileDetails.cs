using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start

    {
        #region Sign up 
        [Given(@"I have navigated to the portal Skillswap")]
        public void GivenIHaveNavigatedToThePortalSkillswap()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I create a new account")]
        public void WhenICreateANewAccount()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"that user should be created")]
        public void ThenThatUserShouldBeCreated()
        {
            ScenarioContext.Current.Pending();
        }

        #endregion
        #region Login
        [When(@"I enter my user credentials")]
        public void WhenIEnterMyUserCredentials()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to see the home page")]
        public void ThenIShouldBeAbleToSeeTheHomePage()
        {
            ScenarioContext.Current.Pending();
        }

        #endregion
        #region Add language


        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='first']")).Click();


        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[11]")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Chinese");

            //Click on Language Level
            IWebElement LangDropDown = Driver.driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));
            LangDropDown.Click();
            //Choose the language level
            SelectElement drpLang = new SelectElement(LangDropDown);
            drpLang.SelectByText("Conversational");
            //IWebElement Lang = Driver.driver.FindElements(By.XPath("//select[contains(@class,'ui dropdown')]"))[1];
            // Lang.Click();

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }



        }
        #endregion
        #region Edit language
        [When(@"I edit a existing language")]
        public void WhenIEditAExistingLanguage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"that language edited should be displayed on my listings")]
        public void ThenThatLanguageEditedShouldBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }

        #endregion
        #region Delete language
        [When(@"I click on Delete")]
        public void WhenIClickOnDelete()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"that language should not be displayed on my listings")]
        public void ThenThatLanguageShouldNotBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }


        #endregion
        #region Add Skills
        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(5000);
            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[contains(@data-tab,'second')]")).Click();

        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            try
            {
                //Click on Add New Button
                Driver.driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]")).Click();
                //Choose Skill
                Driver.driver.FindElement(By.XPath("//input[contains(@name,'name')]")).SendKeys("PHP");
                //Choose Skill level
                IWebElement skillsDropdown = Driver.driver.FindElement(By.XPath("//select[@name='level']"));
                SelectElement skills = new SelectElement(skillsDropdown);
                skills.SelectByText("Intermediate");
                //Click on Add
                Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "C#";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(.,'C#')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
        #endregion
        #region Edit Skills
        [When(@"I edit an existing skill")]
        public void WhenIEditAnExistingSkill()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"that skill edited should be displayed on my listings")]
        public void ThenThatSkillEditedShouldBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion


        #region Delete Skills
        [Then(@"that skill should not be displayed on my listings")]
        public void ThenThatSkillShouldNotBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion

        #region Add Education
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            Thread.Sleep(5000);
            //Click on the Education tab
            Driver.driver.FindElement(By.XPath("//a[contains(@data-tab,'third')]")).Click();
            
        }

        [When(@"I add a new education")]
        public void WhenIAddANewEducation()
        {
            try
            {
                //Click on Add button
                Driver.driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[21]")).Click();
                //Add the College name
                Driver.driver.FindElement(By.Name("instituteName")).SendKeys("St.Aloysius");
                //Add the country of College
                IWebElement countryDropdown = Driver.driver.FindElement(By.Name("country"));
                SelectElement country = new SelectElement(countryDropdown);
                country.SelectByText("India");
                //Choose title
                IWebElement titleDropdown = Driver.driver.FindElement(By.Name("title"));
                SelectElement title = new SelectElement(titleDropdown);
                title.SelectByText("B.Sc");
                // Add Degree
                Driver.driver.FindElement(By.Name("degree")).SendKeys("Bachelor");
                //Choose Year of Graduation
                IWebElement yearDropdown = Driver.driver.FindElement(By.Name("yearOfGraduation"));
                SelectElement yearOfGraduation = new SelectElement(yearDropdown);
                yearOfGraduation.SelectByText("2007");
                //Click on Add button
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Add')]")).Click();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Then(@"that education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            try { 
            //Start the Reports
            CommonMethods.ExtentReports();
            Thread.Sleep(1000);
            CommonMethods.test = CommonMethods.extent.StartTest("Add a Education");

            Thread.Sleep(1000);
            string ExpectedValue = "B.Sc";
            string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(.,'B.Sc')]")).Text;
            Thread.Sleep(500);
            if (ExpectedValue == ActualValue)
            {
                CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Education Successfully");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
            }

            else
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

        }
           catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
}

        #endregion
        #region Edit Education
        [When(@"I edit an existing education")]
        public void WhenIEditAnExistingEducation()
        {
            try
            {
                //Click on Edit button
                Driver.driver.FindElement(By.XPath("(//i[contains(@class,'outline write icon')])[8]")).Click();

                //Edit the College name
                IWebElement insituteName = Driver.driver.FindElement(By.Name("instituteName"));
                insituteName.Clear();
                insituteName.SendKeys("St.Agnes");
                //Add the country of College
                //IWebElement countryDropdown = Driver.driver.FindElement(By.Name("country"));
                //SelectElement country = new SelectElement(countryDropdown);
                //country.SelectByText("India");
                //Choose title
                IWebElement titleDropdown = Driver.driver.FindElement(By.Name("title"));
                SelectElement title = new SelectElement(titleDropdown);
                title.SelectByText("B.Tech");
                // Add Degree
                IWebElement degree = Driver.driver.FindElement(By.Name("degree"));
                degree.Clear();
                degree.SendKeys("Bachelor Technology");
                //Choose Year of Graduation
                IWebElement yearDropdown = Driver.driver.FindElement(By.Name("yearOfGraduation"));
                SelectElement yearOfGraduation = new SelectElement(yearDropdown);
                yearOfGraduation.SelectByText("2001");
                //Click on Update button
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"that education edited should be displayed on my listings")]
        public void ThenThatEducationEditedShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Education");

                Thread.Sleep(1000);
                string ExpectedValue = "B.Tech";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(.,'B.Tech')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationUpdated");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        #endregion
        #region Delete Education
        [Then(@"that education should not be displayed on my listings")]
        public void ThenThatEducationShouldNotBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }

        #endregion
        #region Add Certifications
        [Given(@"I clicked on the Certifications tab under Profile page")]
        public void GivenIClickedOnTheCertificationsTabUnderProfilePage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I add a new certifications")]
        public void WhenIAddANewCertifications()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"that certifications should be displayed on my listings")]
        public void ThenThatCertificationsShouldBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion
        #region Edit Certifications
        [When(@"I edit an existing certifications")]
        public void WhenIEditAnExistingCertifications()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"that certifications edited should be displayed on my listings")]
        public void ThenThatCertificationsEditedShouldBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion
        #region Delete Certifications
        [Then(@"that certifications should not be displayed on my listings")]
        public void ThenThatCertificationsShouldNotBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }
         #endregion

    }
}
