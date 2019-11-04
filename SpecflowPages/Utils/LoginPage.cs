using OpenQA.Selenium;
using System.Threading;

namespace SpecflowPages.Utils
{
    public class LoginPage
    {
        public static void LoginStep()
        {
            Driver.NavigateUrl();
            Thread.Sleep(1000);

            //Enter Url
            Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Sign In')]")).Click();

            //*[@id='home']/div/div/div[1]/div/a[2]
            //Enter Username
            Driver.driver.FindElement(By.XPath("//input[@name='email']")).SendKeys("tauropreema2018@gmail.com");
            //  / html / body / div[2] / div / div / div / div[1] / form / div[1] / input
            //Enter password
            Driver.driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("iandsilva");/// html / body / div[2] / div / div / div / div[1] / form / div[2] / input
            Thread.Sleep(1000);
            //Click on Login Button
            Driver.driver.FindElement(By.XPath("//button[contains(.,'Login')]")).Click();///html/body/div[2]/div/div/div/div[1]/form/div[4]/div

            //string msg = "Add New Job";
            //string Actualmsg = Driver.driver.FindElement(By.XPath("//*[@id='addnewjob']")).Text;

            //if (msg == Actualmsg)
            //{
            //Console.WriteLine("Test Passed");
            //CommonMethods.ExtentReports();
            //Thread.Sleep(500);
            //test = CommonMethods.extent.StartTest("Login with valid data");
            //Thread.Sleep(1000);
            //CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
            //SaveScreenShotClass.SaveScreenshot(Driver.driver, "HomePage");
            //}
            //else
            //{
            //Console.WriteLine("Test Failed");
            //CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
            //}
        }

    }
}
