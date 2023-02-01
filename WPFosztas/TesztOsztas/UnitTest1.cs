using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace TesztOsztas
{
    public class Tests
    {
        protected const string windowsApplicationDriverURL = "http://127.0.0.1:4723";
        private const string WPFprogramID = @"C:\Users\fullstack\source\repos\WPFosztas\WPFosztas\bin\debug\WPFosztas.exe";
        private const string WPFprogramPath= @"C:\Users\fullstack\source\repos\WPFosztas\WPFosztas\bin\debug";

        protected static WindowsDriver<WindowsElement> driver;
        protected static ExtentReports extReport;
        protected static ExtentTest extTest;

        [OneTimeSetUp]
        public static void Setup()
        {
            if (driver==null)
            {
                var appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app",WPFprogramID);
                appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
                driver = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverURL),appiumOptions);
            }

        }

        [OneTimeSetUp]
        public static void ReportSetup()
        {
            extReport = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\fullstack\source\repos\WPFosztas\WPFosztas\bin\debug\report.html");
            extReport.AddSystemInfo("Osztás teszt", "Osztás automatizált teszt");
            extReport.AddSystemInfo("Tesztelõ", "Laci");
            extReport.AttachReporter(htmlReporter);
            htmlReporter.Config.DocumentTitle = "HTML teszt riport";
            htmlReporter.Config.ReportName = "Osztás teszt";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;


        }


        [Test]
        [TestCase(15,5,3)]
        [TestCase(25,15,3)]
        public void Test1(double a, double b, double elvart)
        {
            extTest = extReport.CreateTest("Osztás teszt");

            var ertek_a = driver.FindElementByAccessibilityId("ertek_a");
            ertek_a.Clear();
            var ertek_b = driver.FindElementByAccessibilityId("ertek_b");
            ertek_b.Clear();            


            ertek_a.SendKeys(a.ToString());
            ertek_b.SendKeys(b.ToString());

            driver.FindElementByAccessibilityId("buttonOsztas").Click();

            var eredmeny = driver.FindElementByAccessibilityId("eredmeny");


            Assert.AreEqual(2,Convert.ToDouble(eredmeny.Text));
            extTest.Log(Status.Pass,"Osztás teszt rendben");
        }

        [TearDown]
        public static void CloseReport()
        {
            var a = TestContext.CurrentContext.Test.Arguments.GetValue(0);
            var b = TestContext.CurrentContext.Test.Arguments.GetValue(1);
            var elvart = TestContext.CurrentContext.Test.Arguments.GetValue(2);

            var filename = "error_"+a + "_" + b + "_" + elvart + ".png";
            var Status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace= TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;


            if (Status == TestStatus.Failed)
            {
                ITakesScreenshot shot = (ITakesScreenshot)driver;
                Screenshot screenshot = shot.GetScreenshot();
                screenshot.SaveAsFile(WPFprogramPath+filename, ScreenshotImageFormat.Png);
                //extTest.Log(Status.Fail, stackTrace + errorMessage);
                //extTest.Log(Status.Fail, "Képernyõ");
                extTest.AddScreenCaptureFromPath("ErrPng.png");
            }

        }


        [OneTimeTearDown]
        public void Endtest()
        {
            driver.Close();
            driver.Quit();
            extReport.Flush();
        }
    }
    
}