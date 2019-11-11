using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start

    {
      
        #region Add language


        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            try
            {
                //Wait
                Thread.Sleep(5000);

                // Click on Profile tab
                //  Driver.driver.FindElement(By.XPath("//a[@data-tab='first']")).Click();
                Driver.driver.FindElement(By.XPath("//a[contains(text(),'Languages')]"));
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {

            try
            {
                //Click on Add New button
                Driver.driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[11]")).Click();
                //Add Language
                Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys("Chinese");
                //Click on Language Level
                IWebElement Language = Driver.driver.FindElement(By.XPath("//select[contains(@class,'ui dropdown')]"));
                Language.Click();
                //Choose the language level
                SelectElement languageDropdown = new SelectElement(Language);
                languageDropdown.SelectByText("Conversational");
                //Click on Add button
                Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

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
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = "Chinese";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        tempValue++;
                        return;

                    }
                }
                if (tempValue == 0)
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

            try
            {
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    Thread.Sleep(5000);
                    //Fetch the Language
                    string languageValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (languageValue == "English")
                    {
                        //Click On Edit button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                        Thread.Sleep(3000);
                        //Modify language
                        IWebElement language = Driver.driver.FindElement(By.XPath("//input[@name='name']"));
                        language.Clear();
                        language.SendKeys("Hindi");
                        //Modify level
                        IWebElement level = Driver.driver.FindElement(By.Name("level"));
                        SelectElement levelDropdown = new SelectElement(level);
                        levelDropdown.SelectByText("Fluent");
                        //Click on Update
                        Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
                        return;
                    }
                }
                Console.WriteLine("Language to be edited does not exist");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"that language edited should be displayed on my listings")]
        public void ThenThatLanguageEditedShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Language");
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = "Hindi";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);

                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited a Language Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageEdited");
                        tempValue++;
                        return;
                    }
                }
                if (tempValue == 0)
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        #endregion
        #region Delete language
        [When(@"I delete a existing language")]
        public void WhenIDeleteAExistingLanguage()
        {
            try
            {
                int tempValue = 0;
                Thread.Sleep(1000);
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    //Fetch the Language
                    string languageValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (languageValue == "Chinese")
                    {
                        //Click on Delete button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();
                        tempValue++;
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0)
                    Console.WriteLine("There exist no records to Delete");
                if (tempValue == 1)
                    Console.WriteLine("There are no matching records to Delete");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Then(@"that language should not be displayed on my listings")]
        public void ThenThatLanguageShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");
                Thread.Sleep(1000);
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    string ExpectedValue = "English";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0 || tempValue == 1)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeleted");
                }


            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }


        #endregion
        #region Add Skills
        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            try
            {
                //Wait
                Thread.Sleep(5000);
                //Click on Skills tab
                Driver.driver.FindElement(By.XPath("//a[contains(text(),'Skills')]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            try
            {
                //Click on Add New Button
                Driver.driver.FindElement(By.XPath("//div[@class='ui teal button'][contains(.,'Add New')]")).Click();
                //Choose Skill
                Driver.driver.FindElement(By.XPath("//input[contains(@name,'name')]")).SendKeys("C++");
                //Choose Skill level
                IWebElement skillsDropdown = Driver.driver.FindElement(By.XPath("//select[@name='level']"));
                SelectElement skills = new SelectElement(skillsDropdown);
                skills.SelectByText("Intermediate");
                //Click on Add
                Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            }
            catch (Exception ex)
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
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = "C++";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
                        tempValue++;
                        return;
                    }
                }

                if (tempValue == 0)
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
            try
            {
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    Thread.Sleep(5000);
                    //Fetch the Skill
                    string Skill = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (Skill == "C")
                    {
                        //Click on Edit button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i")).Click();
                        IWebElement skillName = Driver.driver.FindElement(By.Name("name"));
                        skillName.Clear();
                        skillName.SendKeys("Java");
                        IWebElement skillLevel = Driver.driver.FindElement(By.Name("level"));
                        SelectElement skillDropdown = new SelectElement(skillLevel);
                        skillDropdown.SelectByText("Intermediate");
                        Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
                        return;
                    }
                }
                Console.WriteLine("Skills to be edited does not exist");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Then(@"that skill edited should be displayed on my listings")]
        public void ThenThatSkillEditedShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Skill");
                Thread.Sleep(1000);
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {

                    string ExpectedValue = "Java";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited Skill Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillEdited");
                        tempValue++;
                        return;
                    }
                }
                if (tempValue == 0)
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        #endregion


        #region Delete Skills
        [When(@"I delete a existing skill")]
        public void WhenIDeleteAExistingSkill()
        {
            try
            {
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    //Fetch the Skill
                    string Skill = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (Skill == "C++")
                    {
                        //Click on Delete
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();
                        tempValue++;
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0)
                    Console.WriteLine("There exist no records to Delete");
                if (tempValue == 1)
                    Console.WriteLine("There are no matching records to Delete");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"that skill should not be displayed on my listings")]
        public void ThenThatSkillShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill");
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    string ExpectedValue = "C++";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        return;
                    }
                }

                if ((NoOfRows.Count) == 0 || tempValue == 1)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillDeleted");
                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        #endregion

        #region Add Education
        [Given(@"I clicked on the Education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            try
            {
                Thread.Sleep(5000);
                //Click on the Education tab
                Driver.driver.FindElement(By.XPath("//a[contains(text(),'Education')]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }


        }

        [When(@"I add a new education")]
        public void WhenIAddANewEducation()
        {
            try
            {
                //Click on Add button
                Driver.driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[21]")).Click();
                //Add the College name
                Driver.driver.FindElement(By.Name("instituteName")).SendKeys("St.Agnes");
                //Add the country of College
                IWebElement countryDropdown = Driver.driver.FindElement(By.Name("country"));
                SelectElement country = new SelectElement(countryDropdown);
                country.SelectByText("India");
                //Choose title
                IWebElement titleDropdown = Driver.driver.FindElement(By.Name("title"));
                SelectElement title = new SelectElement(titleDropdown);
                title.SelectByText("B.Sc");
                // Add Degree
                Driver.driver.FindElement(By.Name("degree")).SendKeys("Masters");
                //Choose Year of Graduation
                IWebElement yearDropdown = Driver.driver.FindElement(By.Name("yearOfGraduation"));
                SelectElement yearOfGraduation = new SelectElement(yearDropdown);
                yearOfGraduation.SelectByText("2010");
                //Click on Add button
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Add')]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Then(@"that education should be displayed on my listings")]
        public void ThenThatEducationShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Education");
                Thread.Sleep(1000);
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = "B.Sc";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody["+i+"]/tr/td[3]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Education Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
                        tempValue++;
                        return;
                    }
                }
                if (tempValue == 0)
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
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    Thread.Sleep(5000);
                    //Fetch the Title
                    string Title = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    if (Title == "M.Tech")
                    {
                        //Click on Edit button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[1]")).Click();
                        //Edit the University 
                        IWebElement insituteName = Driver.driver.FindElement(By.Name("instituteName"));
                        insituteName.Clear();
                        insituteName.SendKeys("St.Anns");
                        //Add the country of College
                        IWebElement countryDropdown = Driver.driver.FindElement(By.Name("country"));
                        SelectElement country = new SelectElement(countryDropdown);
                        country.SelectByText("India");
                        //Choose title
                        IWebElement titleDropdown = Driver.driver.FindElement(By.Name("title"));
                        SelectElement title = new SelectElement(titleDropdown);
                        title.SelectByText("BArch");
                        // Add Degree
                        IWebElement degree = Driver.driver.FindElement(By.Name("degree"));
                        degree.Clear();
                        degree.SendKeys("Bachelor");
                        //Choose Year of Graduation
                        IWebElement yearDropdown = Driver.driver.FindElement(By.Name("yearOfGraduation"));
                        SelectElement yearOfGraduation = new SelectElement(yearDropdown);
                        yearOfGraduation.SelectByText("2010");
                        //Click on Update button
                        Driver.driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();
                        return;
                    }
                }
                Console.WriteLine("Education to be edited does not exist");
                return;
            }
            catch (Exception ex)
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
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = "BArch";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated Education Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationUpdated");
                        tempValue++;
                        return;
                    }

                    else
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }
                if (tempValue == 0)
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        #endregion
        #region Delete Education
        [When(@"I delete a existing education")]
        public void WhenIDeleteAExistingEducation()
        {
            try
            {
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    //Fetch the Title
                    string Title = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    if (Title == "B.Sc")
                    {
                        //Click on Delete button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();
                        tempValue++;
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0)
                    Console.WriteLine("There exist no records to Delete");
                if (tempValue == 1)
                    Console.WriteLine("There are no matching records to Delete");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Then(@"that education should not be displayed on my listings")]
        public void ThenThatEducationShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Education");
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    string ExpectedValue = "B.Sc";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0 || tempValue == 1)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationDeleted");
                }
            }

            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }

        #endregion
        #region Add Certifications
        [Given(@"I clicked on the Certifications tab under Profile page")]
        public void GivenIClickedOnTheCertificationsTabUnderProfilePage()
        {

            try
            {
                //Click on Certifications tab
                Thread.Sleep(7000);
                Driver.driver.FindElement(By.XPath("//a[contains(text(),'Certifications')]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }


        }

        [When(@"I add a new certifications")]
        public void WhenIAddANewCertifications()
        {
            try
            {
                //Click on Add New Button
                Driver.driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[3]")).Click();
                //Add CertificationName
                Driver.driver.FindElement(By.Name("certificationName")).SendKeys("Diploma");
                //Add CertificationFrom
                Driver.driver.FindElement(By.Name("certificationFrom")).SendKeys("Adobe");
                //Choose the year
                IWebElement year = Driver.driver.FindElement(By.Name("certificationYear"));
                SelectElement yearDropdown = new SelectElement(year);
                yearDropdown.SelectByText("2017");
                //Click on Add
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Add')]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"that certifications should be displayed on my listings")]
        public void ThenThatCertificationsShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Certification");
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = "Diploma";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody["+i+"]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Certification Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationAdded");
                        tempValue++;
                        return;
                    }
                }
                if (tempValue == 0)
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        #endregion
        #region Edit Certifications
        [When(@"I edit an existing certifications")]
        public void WhenIEditAnExistingCertifications()
        {
            try
            {
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    Thread.Sleep(5000);
                    //Fetch the Certificate
                    string Certificate = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (Certificate == "Masters")

                    {
                        //Click on Edit
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[1]/i")).Click();
                        IWebElement certificationName = Driver.driver.FindElement(By.Name("certificationName"));
                        certificationName.Clear();
                        certificationName.SendKeys("Certificate 3");
                        IWebElement certificationFrom = Driver.driver.FindElement(By.Name("certificationFrom"));
                        certificationFrom.Clear();
                        certificationFrom.SendKeys("University");
                        IWebElement year = Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']"));
                        SelectElement yearDropdown = new SelectElement(year);
                        yearDropdown.SelectByText("2019");
                        Driver.driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();
                        return;
                    }
                }
                Console.WriteLine("Certificate to be edited does not exist");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"that certifications edited should be displayed on my listings")]
        public void ThenThatCertificationsEditedShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Certification");
                Thread.Sleep(1000);
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = "Certificate 3";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited Certification Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationEdited");
                        tempValue++;
                        return;
                    }
                }
             if (tempValue == 0)
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");


            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        #endregion
        #region Delete Certifications
        [When(@"I delete a existing certifications")]
        public void WhenIDeleteAExistingCertifications()
        {
            try
            {
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    Thread.Sleep(5000);
                    //Fetch the Certificate
                    string Certificate = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (Certificate == "Diploma")
                    {
                        //click on Delete button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[2]/i")).Click();
                        tempValue++;
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0)
                    Console.WriteLine("There exist no records to Delete");
                if (tempValue == 1)
                {
                    Console.WriteLine("There are no matching records to Delete");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Then(@"that certifications should not be displayed on my listings")]
        public void ThenThatCertificationsShouldNotBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Certification");
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    string ExpectedValue = "Diploma";
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        return;                      
                    }

                }
                if ((NoOfRows.Count) == 0 || tempValue == 1)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationDeleted");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
        #endregion

    }
}
