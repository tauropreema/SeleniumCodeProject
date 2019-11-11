using System.IO;

namespace SpecflowPages
{
    public class ConstantUtils
    {
        //Base Url
        public static string Url = "http://www.skillswap.pro/";

        //ScreenshotPath
        // public static string ScreenshotPath = @"C:\Users\Preema\MVP Studio\Specflow Tests Base\SpecflowTests-Base\SpecflowTests-Base\SpecflowTests\SpecflowPages\TestReports\Screenshots\";
        public static string ScreenshotPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\Screenshots\";
        //ExtentReportsPath
        // public static string ReportsPath = @"C:\Users\Preema\MVP Studio\Specflow Tests Base\SpecflowTests-Base\SpecflowTests-Base\SpecflowTests\SpecflowPages\TestReports\Test.html";
        public static string ReportsPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\Test.html";
        //ReportXML Path
        // public static string ReportXMLPath = @"C:\Users\Preema\MVP Studio\Specflow Tests Base\SpecflowTests-Base\SpecflowTests-Base\SpecflowTests\SpecflowPages\TestReports\ReportXML.xml";
        public static string ReportXMLPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\ReportXML.xml";


    }
}
